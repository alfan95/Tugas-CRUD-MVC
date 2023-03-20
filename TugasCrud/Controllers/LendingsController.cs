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
    public class LendingsController : Controller
    {
        private KopinakiEntities db = new KopinakiEntities();

        // GET: Lendings
        public ActionResult Index()
        {
            return View(db.Lendings.ToList());
        }

        // GET: Lendings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return HttpNotFound();
            }
            return View(lending);
        }

        // GET: Lendings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lendings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Lending,Account_No,ID_Customer,Balance,Plafond")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                db.Lendings.Add(lending);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lending);
        }

        // GET: Lendings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return HttpNotFound();
            }
            return View(lending);
        }

        // POST: Lendings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Lending,Account_No,ID_Customer,Balance,Plafond")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lending);
        }

        // GET: Lendings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lending lending = db.Lendings.Find(id);
            if (lending == null)
            {
                return HttpNotFound();
            }
            return View(lending);
        }

        // POST: Lendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lending lending = db.Lendings.Find(id);
            db.Lendings.Remove(lending);
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
