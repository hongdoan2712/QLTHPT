using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHPT.Models;

namespace QLTHPT.Controllers
{
    public class THONGTINDAOTAOsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THONGTINDAOTAOs
        public ActionResult Index()
        {
            var tHONGTINDAOTAOs = db.THONGTINDAOTAOs.Include(t => t.CANBO).Include(t => t.HINHTHUC);
            return View(tHONGTINDAOTAOs.ToList());
        }

        // GET: THONGTINDAOTAOs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            if (tHONGTINDAOTAO == null)
            {
                return HttpNotFound();
            }
            return View(tHONGTINDAOTAO);
        }

        // GET: THONGTINDAOTAOs/Create
        public ActionResult Create()
        {
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN");
            return View();
        }

        // POST: THONGTINDAOTAOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TTDT_MA,CANBO_CB_MA,HINHTHUCs_HT_MA")] THONGTINDAOTAO tHONGTINDAOTAO)
        {
            if (ModelState.IsValid)
            {
                db.THONGTINDAOTAOs.Add(tHONGTINDAOTAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CANBO_CB_MA);
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HINHTHUCs_HT_MA);
            return View(tHONGTINDAOTAO);
        }

        // GET: THONGTINDAOTAOs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            if (tHONGTINDAOTAO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CANBO_CB_MA);
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HINHTHUCs_HT_MA);
            return View(tHONGTINDAOTAO);
        }

        // POST: THONGTINDAOTAOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TTDT_MA,CANBO_CB_MA,HINHTHUCs_HT_MA")] THONGTINDAOTAO tHONGTINDAOTAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHONGTINDAOTAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CANBO_CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CANBO_CB_MA);
            ViewBag.HINHTHUCs_HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HINHTHUCs_HT_MA);
            return View(tHONGTINDAOTAO);
        }

        // GET: THONGTINDAOTAOs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            if (tHONGTINDAOTAO == null)
            {
                return HttpNotFound();
            }
            return View(tHONGTINDAOTAO);
        }

        // POST: THONGTINDAOTAOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THONGTINDAOTAO tHONGTINDAOTAO = db.THONGTINDAOTAOs.Find(id);
            db.THONGTINDAOTAOs.Remove(tHONGTINDAOTAO);
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
