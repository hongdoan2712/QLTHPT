using QLTHPT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLTHPT.Controllers
{
    public class KHOIsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: KHOIs
        public ActionResult Index()
        {
            return View(db.KHOIs.ToList());
        }

        // GET: KHOIs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOIs kHOIs = db.KHOIs.Find(id);
            if (kHOIs == null)
            {
                return HttpNotFound();
            }
            return View(kHOIs);
        }

        // GET: KHOIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KHOIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KHOI_MA,KHOI_TEN")] KHOIs kHOIs)
        {
            if (ModelState.IsValid)
            {
                db.KHOIs.Add(kHOIs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kHOIs);
        }

        // GET: KHOIs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOIs kHOIs = db.KHOIs.Find(id);
            if (kHOIs == null)
            {
                return HttpNotFound();
            }
            return View(kHOIs);
        }

        // POST: KHOIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KHOI_MA,KHOI_TEN")] KHOIs kHOIs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHOIs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kHOIs);
        }

        // GET: KHOIs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHOIs kHOIs = db.KHOIs.Find(id);
            if (kHOIs == null)
            {
                return HttpNotFound();
            }
            return View(kHOIs);
        }

        // POST: KHOIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHOIs kHOIs = db.KHOIs.Find(id);
            db.KHOIs.Remove(kHOIs);
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
