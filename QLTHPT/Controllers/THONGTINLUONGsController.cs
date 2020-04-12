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
    public class THONGTINLUONGsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THONGTINLUONGs
        public ActionResult Index()
        {
            var tHONGTINLUONGs = db.THONGTINLUONGs.Include(t => t.BACLUONG).Include(t => t.NGACHLUONG);
            return View(tHONGTINLUONGs.ToList());
        }

        // GET: THONGTINLUONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINLUONG tHONGTINLUONG = db.THONGTINLUONGs.Find(id);
            if (tHONGTINLUONG == null)
            {
                return HttpNotFound();
            }
            return View(tHONGTINLUONG);
        }

        // GET: THONGTINLUONGs/Create
        public ActionResult Create()
        {
            ViewBag.BACLUONG_BL_MA = new SelectList(db.BACLUONGs, "BL_MA", "BL_TEN");
            ViewBag.NGACHLUONG_NL_MA = new SelectList(db.NGACHLUONGs, "NL_MA", "NL_TEN");
            return View();
            //THONGTINLUONG obj = new THONGTINLUONG();
            //obj.TTL_MA = CreateID.CreateID_ByteText();
            //return View(obj);
        }

        // POST: THONGTINLUONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TTL_MA,TTL_NGAYNHANLUONG,TTL_HESOLUONG,BACLUONG_BL_MA,NGACHLUONG_NL_MA")] THONGTINLUONG tHONGTINLUONG)
        {
            if (ModelState.IsValid)
            {
                db.THONGTINLUONGs.Add(tHONGTINLUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BACLUONG_BL_MA = new SelectList(db.BACLUONGs, "BL_MA", "BL_TEN", tHONGTINLUONG.BACLUONG_BL_MA);
            ViewBag.NGACHLUONG_NL_MA = new SelectList(db.NGACHLUONGs, "NL_MA", "NL_TEN", tHONGTINLUONG.NGACHLUONG_NL_MA);
            return View(tHONGTINLUONG);
        }

        // GET: THONGTINLUONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINLUONG tHONGTINLUONG = db.THONGTINLUONGs.Find(id);
            if (tHONGTINLUONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.BACLUONG_BL_MA = new SelectList(db.BACLUONGs, "BL_MA", "BL_TEN", tHONGTINLUONG.BACLUONG_BL_MA);
            ViewBag.NGACHLUONG_NL_MA = new SelectList(db.NGACHLUONGs, "NL_MA", "NL_TEN", tHONGTINLUONG.NGACHLUONG_NL_MA);
            return View(tHONGTINLUONG);
        }

        // POST: THONGTINLUONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TTL_MA,TTL_NGAYNHANLUONG,TTL_HESOLUONG,BACLUONG_BL_MA,NGACHLUONG_NL_MA")] THONGTINLUONG tHONGTINLUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHONGTINLUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BACLUONG_BL_MA = new SelectList(db.BACLUONGs, "BL_MA", "BL_TEN", tHONGTINLUONG.BACLUONG_BL_MA);
            ViewBag.NGACHLUONG_NL_MA = new SelectList(db.NGACHLUONGs, "NL_MA", "NL_TEN", tHONGTINLUONG.NGACHLUONG_NL_MA);
            return View(tHONGTINLUONG);
        }

        // GET: THONGTINLUONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THONGTINLUONG tHONGTINLUONG = db.THONGTINLUONGs.Find(id);
            if (tHONGTINLUONG == null)
            {
                return HttpNotFound();
            }
            return View(tHONGTINLUONG);
        }

        // POST: THONGTINLUONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THONGTINLUONG tHONGTINLUONG = db.THONGTINLUONGs.Find(id);
            db.THONGTINLUONGs.Remove(tHONGTINLUONG);
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
