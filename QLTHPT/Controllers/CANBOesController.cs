using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTHPT.App_Start;
using QLTHPT.Models;

namespace QLTHPT.Controllers
{
    public class CANBOesController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: CANBOes
        public ActionResult Index(string id)
        {
            var cANBOes = db.CANBOes.Include(c => c.CHITIET_CHUCVU).Include(c => c.COQUAN).Include(c => c.KHENTHUONGCB).Include(c => c.KYLUATCB).Include(c => c.THONGTINDAOTAO).Where(c => c.THONGTINDAOTAO_TTDT_MA == id).Include(c => c.THONGTINLUONG).Where(c => c.THONGTINLUONG_TTL_MA == id);
            ViewBag.THONGTINLUONG_TTL_MA = id;
            return View(cANBOes.ToList());
        }

        // GET: CANBOes/Details/5
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

        // GET: CANBOes/Create
        public ActionResult Create()
        {
            ViewBag.CHITIET_CHUCVU_CT_CV_ID = new SelectList(db.CHITIET_CHUCVU, "CT_CV_ID", "CT_CV_TEN");
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN");
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_THANHTICH");
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_HT");
            ViewBag.THONGTINDAOTAO_TTDT_MA = new SelectList(db.THONGTINDAOTAOs, "TTDT_MA", "HINHTHUCs_HT_MA");
            ViewBag.THONGTINLUONG_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG");
            
            CANBO obj = new CANBO();
            obj.CB_MA = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: CANBOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,COQUAN_CQ_MA,CHITIET_CHUCVU_CT_CV_ID,KYLUATCB_KLCB_MA,KHENTHUONGCB_KTCB_MA,THONGTINDAOTAO_TTDT_MA,THONGTINLUONG_TTL_MA")] CANBO cANBO)
        {
            string duongdan = "Index/" + cANBO.THONGTINLUONG_TTL_MA ;
            string duongdan1 = "Index/" + cANBO.THONGTINLUONG_TTL_MA;
            if (ModelState.IsValid)
            {
                db.CANBOes.Add(cANBO);
                db.SaveChanges();
                return RedirectToAction(duongdan, duongdan1);
            }

            ViewBag.CHITIET_CHUCVU_CT_CV_ID = new SelectList(db.CHITIET_CHUCVU, "CT_CV_ID", "CT_CV_TEN", cANBO.CHITIET_CHUCVU_CT_CV_ID);
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_NGAY", cANBO.KHENTHUONGCB_KTCB_MA);
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_NGAY", cANBO.KYLUATCB_KLCB_MA);
            ViewBag.THONGTINDAOTAO_TTDT_MA = new SelectList(db.THONGTINDAOTAOs, "TTDT_MA", "HINHTHUCs_HT_MA", cANBO.THONGTINDAOTAO_TTDT_MA);
            ViewBag.THONGTINLUONG_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG", cANBO.THONGTINLUONG_TTL_MA);
            return RedirectToAction(duongdan);
        }

        // GET: CANBOes/Edit/5
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
            ViewBag.CHITIET_CHUCVU_CT_CV_ID = new SelectList(db.CHITIET_CHUCVU, "CT_CV_ID", "CT_CV_TEN", cANBO.CHITIET_CHUCVU_CT_CV_ID);
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_NGAY", cANBO.KHENTHUONGCB_KTCB_MA);
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_NGAY", cANBO.KYLUATCB_KLCB_MA);
            ViewBag.THONGTINDAOTAO_TTDT_MA = new SelectList(db.THONGTINDAOTAOs, "TTDT_MA", "HINHTHUCs_HT_MA", cANBO.THONGTINDAOTAO_TTDT_MA);
            ViewBag.THONGTINLUONG_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG", cANBO.THONGTINLUONG_TTL_MA);
            return View(cANBO);
        }

        // POST: CANBOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,COQUAN_CQ_MA,CHITIET_CHUCVU_CT_CV_ID,KYLUATCB_KLCB_MA,KHENTHUONGCB_KTCB_MA,THONGTINDAOTAO_TTDT_MA,THONGTINLUONG_TTL_MA")] CANBO cANBO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANBO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CHITIET_CHUCVU_CT_CV_ID = new SelectList(db.CHITIET_CHUCVU, "CT_CV_ID", "CT_CV_TEN", cANBO.CHITIET_CHUCVU_CT_CV_ID);
            ViewBag.COQUAN_CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.COQUAN_CQ_MA);
            ViewBag.KHENTHUONGCB_KTCB_MA = new SelectList(db.KHENTHUONGCBs, "KTCB_MA", "KTCB_NGAY", cANBO.KHENTHUONGCB_KTCB_MA);
            ViewBag.KYLUATCB_KLCB_MA = new SelectList(db.KYLUATCBs, "KLCB_MA", "KLCB_NGAY", cANBO.KYLUATCB_KLCB_MA);
            ViewBag.THONGTINDAOTAO_TTDT_MA = new SelectList(db.THONGTINDAOTAOs, "TTDT_MA", "HINHTHUCs_HT_MA", cANBO.THONGTINDAOTAO_TTDT_MA);
            ViewBag.THONGTINLUONG_TTL_MA = new SelectList(db.THONGTINLUONGs, "TTL_MA", "TTL_NGAYNHANLUONG", cANBO.THONGTINLUONG_TTL_MA);
            return View(cANBO);
        }

        // GET: CANBOes/Delete/5
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

        // POST: CANBOes/Delete/5
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
