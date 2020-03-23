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
    public class THONGTINDAOTAOsController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: THONGTINDAOTAOs
        public ActionResult Index()
        {
            var tHONGTINDAOTAOs = db.THONGTINDAOTAOs.Include(t => t.CANBO).Include(t => t.CHUYENNGANH).Include(t => t.HINHTHUC).Include(t => t.VANBANG);
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
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN");
            ViewBag.HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN");
            ViewBag.VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN");
            return View();
        }

        // POST: THONGTINDAOTAOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TTDT_MA,CN_MA,VB_MA,CB_MA,HT_MA")] THONGTINDAOTAO tHONGTINDAOTAO)
        {
            if (ModelState.IsValid)
            {
                db.THONGTINDAOTAOs.Add(tHONGTINDAOTAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CB_MA);
            ViewBag.CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN", tHONGTINDAOTAO.CN_MA);
            ViewBag.HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HT_MA);
            ViewBag.VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN", tHONGTINDAOTAO.VB_MA);
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
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CB_MA);
            ViewBag.CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN", tHONGTINDAOTAO.CN_MA);
            ViewBag.HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HT_MA);
            ViewBag.VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN", tHONGTINDAOTAO.VB_MA);
            return View(tHONGTINDAOTAO);
        }

        // POST: THONGTINDAOTAOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TTDT_MA,CN_MA,VB_MA,CB_MA,HT_MA")] THONGTINDAOTAO tHONGTINDAOTAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHONGTINDAOTAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHONGTINDAOTAO.CB_MA);
            ViewBag.CN_MA = new SelectList(db.CHUYENNGANHs, "CN_MA", "CN_TEN", tHONGTINDAOTAO.CN_MA);
            ViewBag.HT_MA = new SelectList(db.HINHTHUCs, "HT_MA", "HT_TEN", tHONGTINDAOTAO.HT_MA);
            ViewBag.VB_MA = new SelectList(db.VANBANGs, "VB_MA", "VB_TEN", tHONGTINDAOTAO.VB_MA);
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
