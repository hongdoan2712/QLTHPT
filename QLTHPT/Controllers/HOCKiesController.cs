using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHPT.ModelDB;

namespace QLTHPT.Controllers
{
    public class HOCKiesController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: HOCKies
        public ActionResult Index()
        {
            return View(db.HOCKies.ToList());
        }

        // GET: HOCKies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCKy hOCKy = db.HOCKies.Find(id);
            if (hOCKy == null)
            {
                return HttpNotFound();
            }
            return View(hOCKy);
        }

        // GET: HOCKies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOCKies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HK_MA,HK_TEN")] HOCKy hOCKy)
        {
            if (ModelState.IsValid)
            {
                db.HOCKies.Add(hOCKy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOCKy);
        }

        // GET: HOCKies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCKy hOCKy = db.HOCKies.Find(id);
            if (hOCKy == null)
            {
                return HttpNotFound();
            }
            return View(hOCKy);
        }

        // POST: HOCKies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HK_MA,HK_TEN")] HOCKy hOCKy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCKy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOCKy);
        }

        // GET: HOCKies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCKy hOCKy = db.HOCKies.Find(id);
            if (hOCKy == null)
            {
                return HttpNotFound();
            }
            return View(hOCKy);
        }

        // POST: HOCKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOCKy hOCKy = db.HOCKies.Find(id);
            db.HOCKies.Remove(hOCKy);
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
