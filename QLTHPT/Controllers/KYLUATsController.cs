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
    public class KYLUATsController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: KYLUATs
        public ActionResult Index()
        {
            var kYLUATs = db.KYLUATs.Include(k => k.CANBO).Include(k => k.HOCSINH);
            return View(kYLUATs.ToList());
        }

        // GET: KYLUATs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KYLUAT kYLUAT = db.KYLUATs.Find(id);
            if (kYLUAT == null)
            {
                return HttpNotFound();
            }
            return View(kYLUAT);
        }

        // GET: KYLUATs/Create
        public ActionResult Create()
        {
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN");
            return View();
        }

        // POST: KYLUATs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KL_MA,KL_HINHTHUC,KL_NGAYKYLUAT,CB_MA,HS_MA")] KYLUAT kYLUAT)
        {
            if (ModelState.IsValid)
            {
                db.KYLUATs.Add(kYLUAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", kYLUAT.CB_MA);
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", kYLUAT.HS_MA);
            return View(kYLUAT);
        }

        // GET: KYLUATs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KYLUAT kYLUAT = db.KYLUATs.Find(id);
            if (kYLUAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", kYLUAT.CB_MA);
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", kYLUAT.HS_MA);
            return View(kYLUAT);
        }

        // POST: KYLUATs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KL_MA,KL_HINHTHUC,KL_NGAYKYLUAT,CB_MA,HS_MA")] KYLUAT kYLUAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kYLUAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", kYLUAT.CB_MA);
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", kYLUAT.HS_MA);
            return View(kYLUAT);
        }

        // GET: KYLUATs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KYLUAT kYLUAT = db.KYLUATs.Find(id);
            if (kYLUAT == null)
            {
                return HttpNotFound();
            }
            return View(kYLUAT);
        }

        // POST: KYLUATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KYLUAT kYLUAT = db.KYLUATs.Find(id);
            db.KYLUATs.Remove(kYLUAT);
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
