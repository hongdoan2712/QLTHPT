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
    public class SODANHGIAsController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: SODANHGIAs
        public ActionResult Index()
        {
            var sODANHGIAs = db.SODANHGIAs.Include(s => s.HOCKy).Include(s => s.MONHOC);
            return View(sODANHGIAs.ToList());
        }

        // GET: SODANHGIAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SODANHGIA sODANHGIA = db.SODANHGIAs.Find(id);
            if (sODANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(sODANHGIA);
        }

        // GET: SODANHGIAs/Create
        public ActionResult Create()
        {
            ViewBag.HOCKYHK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN");
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN");
            return View();
        }

        // POST: SODANHGIAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SDG_MA,SDG_DIEM,SDG_GHICHU,MH_MA,HOCKYHK_MA")] SODANHGIA sODANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.SODANHGIAs.Add(sODANHGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HOCKYHK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", sODANHGIA.HOCKYHK_MA);
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", sODANHGIA.MH_MA);
            return View(sODANHGIA);
        }

        // GET: SODANHGIAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SODANHGIA sODANHGIA = db.SODANHGIAs.Find(id);
            if (sODANHGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.HOCKYHK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", sODANHGIA.HOCKYHK_MA);
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", sODANHGIA.MH_MA);
            return View(sODANHGIA);
        }

        // POST: SODANHGIAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SDG_MA,SDG_DIEM,SDG_GHICHU,MH_MA,HOCKYHK_MA")] SODANHGIA sODANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sODANHGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HOCKYHK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", sODANHGIA.HOCKYHK_MA);
            ViewBag.MH_MA = new SelectList(db.MONHOCs, "MH_MA", "MH_TEN", sODANHGIA.MH_MA);
            return View(sODANHGIA);
        }

        // GET: SODANHGIAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SODANHGIA sODANHGIA = db.SODANHGIAs.Find(id);
            if (sODANHGIA == null)
            {
                return HttpNotFound();
            }
            return View(sODANHGIA);
        }

        // POST: SODANHGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SODANHGIA sODANHGIA = db.SODANHGIAs.Find(id);
            db.SODANHGIAs.Remove(sODANHGIA);
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
