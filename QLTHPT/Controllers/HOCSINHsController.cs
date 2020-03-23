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
    public class HOCSINHsController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: HOCSINHs
        public ActionResult Index()
        {
            var hOCSINHs = db.HOCSINHs.Include(h => h.DANTOC).Include(h => h.QUANHUYEN).Include(h => h.TINHTHANH).Include(h => h.XAPHUONG).Include(h => h.SODANHGIA);
            return View(hOCSINHs.ToList());
        }

        // GET: HOCSINHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Create
        public ActionResult Create()
        {
            ViewBag.DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN");
            ViewBag.QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN");
            ViewBag.TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN");
            ViewBag.XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN");
            ViewBag.SODANHGIAs_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM");
            return View();
        }

        // POST: HOCSINHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HS_MA,HS_HOTEN,HS_GIOITINH,HS_NGAYSINH,HS_TONGIAO,TT_MA,QH_MA,XP_MA,DT_MA,SODANHGIAs_SDG_MA")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.HOCSINHs.Add(hOCSINH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN", hOCSINH.DT_MA);
            ViewBag.QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN", hOCSINH.QH_MA);
            ViewBag.TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN", hOCSINH.TT_MA);
            ViewBag.XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN", hOCSINH.XP_MA);
            ViewBag.SODANHGIAs_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM", hOCSINH.SODANHGIAs_SDG_MA);
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            ViewBag.DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN", hOCSINH.DT_MA);
            ViewBag.QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN", hOCSINH.QH_MA);
            ViewBag.TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN", hOCSINH.TT_MA);
            ViewBag.XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN", hOCSINH.XP_MA);
            ViewBag.SODANHGIAs_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM", hOCSINH.SODANHGIAs_SDG_MA);
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HS_MA,HS_HOTEN,HS_GIOITINH,HS_NGAYSINH,HS_TONGIAO,TT_MA,QH_MA,XP_MA,DT_MA,SODANHGIAs_SDG_MA")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCSINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DT_MA = new SelectList(db.DANTOCs, "DT_MA", "DT_TEN", hOCSINH.DT_MA);
            ViewBag.QH_MA = new SelectList(db.QUANHUYENs, "QH_MA", "QH_TEN", hOCSINH.QH_MA);
            ViewBag.TT_MA = new SelectList(db.TINHTHANHs, "TT_MA", "TT_TEN", hOCSINH.TT_MA);
            ViewBag.XP_MA = new SelectList(db.XAPHUONGs, "XP_MA", "XP_TEN", hOCSINH.XP_MA);
            ViewBag.SODANHGIAs_SDG_MA = new SelectList(db.SODANHGIAs, "SDG_MA", "SDG_DIEM", hOCSINH.SODANHGIAs_SDG_MA);
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            db.HOCSINHs.Remove(hOCSINH);
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
