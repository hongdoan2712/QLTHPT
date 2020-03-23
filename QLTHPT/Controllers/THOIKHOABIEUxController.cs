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
    public class THOIKHOABIEUxController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: THOIKHOABIEUx
        public ActionResult Index()
        {
            var tHOIKHOABIEUs = db.THOIKHOABIEUs.Include(t => t.CANBO).Include(t => t.MONHOC).Include(t => t.TIETHOC).Include(t => t.THU);
            return View(tHOIKHOABIEUs.ToList());
        }

        // GET: THOIKHOABIEUx/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUs.Find(id);
            if (tHOIKHOABIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHOIKHOABIEU);
        }

        // GET: THOIKHOABIEUx/Create
        public ActionResult Create()
        {
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN");
            ViewBag.TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN");
            ViewBag.THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN");
            return View();
        }

        // POST: THOIKHOABIEUx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TKB_MA,CB_MA,MH_MA,THU_MA,TH_MA")] THOIKHOABIEU tHOIKHOABIEU)
        {
            if (ModelState.IsValid)
            {
                db.THOIKHOABIEUs.Add(tHOIKHOABIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHOIKHOABIEU.CB_MA);
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", tHOIKHOABIEU.MH_MA);
            ViewBag.TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN", tHOIKHOABIEU.TH_MA);
            ViewBag.THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN", tHOIKHOABIEU.THU_MA);
            return View(tHOIKHOABIEU);
        }

        // GET: THOIKHOABIEUx/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUs.Find(id);
            if (tHOIKHOABIEU == null)
            {
                return HttpNotFound();
            }
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHOIKHOABIEU.CB_MA);
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", tHOIKHOABIEU.MH_MA);
            ViewBag.TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN", tHOIKHOABIEU.TH_MA);
            ViewBag.THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN", tHOIKHOABIEU.THU_MA);
            return View(tHOIKHOABIEU);
        }

        // POST: THOIKHOABIEUx/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TKB_MA,CB_MA,MH_MA,THU_MA,TH_MA")] THOIKHOABIEU tHOIKHOABIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHOIKHOABIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", tHOIKHOABIEU.CB_MA);
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", tHOIKHOABIEU.MH_MA);
            ViewBag.TH_MA = new SelectList(db.TIETHOCs, "TH_MA", "TH_TEN", tHOIKHOABIEU.TH_MA);
            ViewBag.THU_MA = new SelectList(db.THUs, "THU_MA", "THU_TEN", tHOIKHOABIEU.THU_MA);
            return View(tHOIKHOABIEU);
        }

        // GET: THOIKHOABIEUx/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUs.Find(id);
            if (tHOIKHOABIEU == null)
            {
                return HttpNotFound();
            }
            return View(tHOIKHOABIEU);
        }

        // POST: THOIKHOABIEUx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THOIKHOABIEU tHOIKHOABIEU = db.THOIKHOABIEUs.Find(id);
            db.THOIKHOABIEUs.Remove(tHOIKHOABIEU);
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
