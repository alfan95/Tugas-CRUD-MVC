using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TugasCrud.Models;

namespace TugasCrud.Controllers
{
    public class HomeController : Controller
    {
        KopinakiEntities db = new KopinakiEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ResultTugas()
        {
            var datalending = (from cst in db.Customers
                               join lnd in db.Lendings on cst.ID_Customer equals lnd.ID_Customer
                               into datalnd
                               from dl in datalnd.DefaultIfEmpty()
                               group dl by
                               new
                               {
                                   CustomerId = cst.ID_Customer
                               }
                               into groupped
                               select new
                               {
                                   IdCustomer = groupped.Key.CustomerId,
                                   BalanceLending = groupped.Sum(s => s.Balance == null ? 0 : s.Balance)
                               }).ToList();
            var datafunding = (from cst in db.Customers
                               join lnd in db.Fundings on cst.ID_Customer equals lnd.ID_Customer
                               into datalnd
                               from dl in datalnd.DefaultIfEmpty()
                               group dl by
                               new
                               {
                                   CustomerId = cst.ID_Customer
                               }
                               into groupped
                               select new
                               {
                                   IdCustomer = groupped.Key.CustomerId,
                                   BalanceFunding = groupped.Sum(s => s.Balance == null ? 0 : s.Balance)
                               }).ToList();
            List<ObjectStored> colData = new List<ObjectStored>();
            var agn = db.Agunans.ToList();
            foreach(var item in db.Customers.ToList())
            {
                var lndItem = datalending.Where(w => w.IdCustomer == item.ID_Customer).Select(s => s.BalanceLending).FirstOrDefault();
                var fndItem = datafunding.Where(w => w.IdCustomer == item.ID_Customer).Select(s => s.BalanceFunding).FirstOrDefault();
                var agnItem = string.Join(",", agn.Where(w => w.ID_Customer == item.ID_Customer).Select(s => s.Agunan_ID).ToList());
                colData.Add(new ObjectStored()
                {
                    CustomerId = item.ID_Customer,
                    Name = item.Name,
                    Address = item.Address,
                    LendingBalance = lndItem,
                    FundingBalance = fndItem,
                    Agunan = agnItem
                });
            }
            ViewBag.ColData = colData;
            return View();
        }

        public class ObjectStored
        {
            public string CustomerId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public int? LendingBalance { get; set; }
            public int? FundingBalance { get; set; }
            public string Agunan { get; set; }
        }
    }
}