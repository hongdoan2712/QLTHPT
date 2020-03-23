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
    public class CHUYENNGANHsController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: CHUYENNGANHs
        public ActionResult Index()
        {
            return View(db.CHUYENNGANHs.ToList());
        }

        // GET: CHUYENNGANHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENNGANH cHUYENNGANH = db.CHUYENNGANHs.Find(id);
            if (cHUYENNGANH == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENNGANH);
        }

        // GET: CHUYENNGANHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHUYENNGANHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CN_MA,CN_TEN")] CHUYENNGANH cHUYENNGANH)
        {
            if (ModelState.IsValid)
            {
                db.CHUYENNGANHs.Add(cHUYENNGANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUYENNGANH);
        }

        // GET: CHUYENNGANHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENNGANH cHUYENNGANH = db.CHUYENNGANHs.Find(id);
            if (cHUYENNGANH == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENNGANH);
        }

        // POST: CHUYENNGANHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CN_MA,CN_TEN")] CHUYENNGANH cHUYENNGANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUYENNGANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUYENNGANH);
        }

        // GET: CHUYENNGANHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUYENNGANH cHUYENNGANH = db.CHUYENNGANHs.Find(id);
            if (cHUYENNGANH == null)
            {
                return HttpNotFound();
            }
            return View(cHUYENNGANH);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        // POST: CHUYENNGANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHUYENNGANH cHUYENNGANH = db.CHUYENNGANHs.Find(id);
            db.CHUYENNGANHs.Remove(cHUYENNGANH);
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
