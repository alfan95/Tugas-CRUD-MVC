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
    public class AgunansController : Controller
    {
        private KopinakiEntities db = new KopinakiEntities();

        // GET: Agunans
        public ActionResult Index()
        {
            return View(db.Agunans.ToList());
        }

        // GET: Agunans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agunan agunan = db.Agunans.Find(id);
            if (agunan == null)
            {
                return HttpNotFound();
            }
            return View(agunan);
        }

        // GET: Agunans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agunans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Agunan_ID,Account_No,ID_Customer,Type,Amount")] Agunan agunan)
        {
            if (ModelState.IsValid)
            {
                db.Agunans.Add(agunan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agunan);
        }

        // GET: Agunans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agunan agunan = db.Agunans.Find(id);
            if (agunan == null)
            {
                return HttpNotFound();
            }
            return View(agunan);
        }

        // POST: Agunans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Agunan_ID,Account_No,ID_Customer,Type,Amount")] Agunan agunan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agunan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agunan);
        }

        // GET: Agunans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agunan agunan = db.Agunans.Find(id);
            if (agunan == null)
            {
                return HttpNotFound();
            }
            return View(agunan);
        }

        // POST: Agunans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Agunan agunan = db.Agunans.Find(id);
            db.Agunans.Remove(agunan);
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
