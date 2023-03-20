using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TugasCrud.Models;

namespace TugasCrud.Controllers
{
    public class FundingsController : Controller
    {
        private KopinakiEntities db = new KopinakiEntities();

        // GET: Fundings
        public ActionResult Index()
        {
            return View(db.Fundings.ToList());
        }

        // GET: Fundings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funding funding = db.Fundings.Find(id);
            if (funding == null)
            {
                return HttpNotFound();
            }
            return View(funding);
        }

        // GET: Fundings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fundings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Funding,Account_No,ID_Customer,Balance")] Funding funding)
        {
            if (ModelState.IsValid)
            {
                db.Fundings.Add(funding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funding);
        }

        // GET: Fundings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funding funding = db.Fundings.Find(id);
            if (funding == null)
            {
                return HttpNotFound();
            }
            return View(funding);
        }

        // POST: Fundings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Funding,Account_No,ID_Customer,Balance")] Funding funding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funding);
        }

        // GET: Fundings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funding funding = db.Fundings.Find(id);
            if (funding == null)
            {
                return HttpNotFound();
            }
            return View(funding);
        }

        // POST: Fundings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Funding funding = db.Fundings.Find(id);
            db.Fundings.Remove(funding);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
