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
    public class CANBOsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: CANBOs
        public ActionResult Index()
        {
            var cANBOes = db.CANBOes.Include(c => c.THONGTINLUONG).Include(c => c.COQUAN);
            return View(cANBOes.ToList());
        }

        // GET: CANBOs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANBO cANBO = db.CANBOes.Find(id);
            if (cANBO == null)
            {
                return HttpNotFound();
            }
            return View(cANBO);
        }

        // GET: CANBOs/Create
        public ActionResult Create()
        {
            ViewBag.THONGTINLUONGs_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG");
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN");
            //THOIKHOABIEU obj = new THOIKHOABIEU();
            //obj.TKB_MA = CreateID.CreateID_ByteText();
            return View();
        }

        // POST: CANBOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,THONGTINLUONGs_TTL_MA,COQUAN_CQ_MA,KHENTHUONGCB_KTCB_MA,KYLUATCB_KLCB_MA")] CANBO cANBO)
        {
            if (ModelState.IsValid)
            {
                db.CANBOes.Add(cANBO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.THONGTINLUONGs_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG", cANBO.THONGTINLUONGs_TTL_MA);
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            return View(cANBO);
        }

        // GET: CANBOs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANBO cANBO = db.CANBOes.Find(id);
            if (cANBO == null)
            {
                return HttpNotFound();
            }
            ViewBag.THONGTINLUONGs_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG", cANBO.THONGTINLUONGs_TTL_MA);
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            return View(cANBO);
        }

        // POST: CANBOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,THONGTINLUONGs_TTL_MA,COQUAN_CQ_MA,KHENTHUONGCB_KTCB_MA,KYLUATCB_KLCB_MA")] CANBO cANBO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANBO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.THONGTINLUONGs_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG", cANBO.THONGTINLUONGs_TTL_MA);
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            return View(cANBO);
        }

        // GET: CANBOs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANBO cANBO = db.CANBOes.Find(id);
            if (cANBO == null)
            {
                return HttpNotFound();
            }
            return View(cANBO);
        }

        // POST: CANBOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CANBO cANBO = db.CANBOes.Find(id);
            db.CANBOes.Remove(cANBO);
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
