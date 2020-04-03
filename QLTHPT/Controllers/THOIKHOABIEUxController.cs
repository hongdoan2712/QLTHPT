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
    public class THOIKHOABIEUxController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: THOIKHOABIEUx
        public ActionResult Index()
        {
            var tHOIKHOABIEUs = db.THOIKHOABIEUs.Include(t => t.LOP);
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
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN");
            //THOIKHOABIEU obj = new THOIKHOABIEU();
            //obj.TKB_MA = CreateID.CreateID_ByteText();
            return View();
        }

        // POST: THOIKHOABIEUx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TKB_MA,LOP_LOP_MA")] THOIKHOABIEU tHOIKHOABIEU)
        {
            if (ModelState.IsValid)
            {
                db.THOIKHOABIEUs.Add(tHOIKHOABIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", tHOIKHOABIEU.LOP_LOP_MA);
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
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", tHOIKHOABIEU.LOP_LOP_MA);
            return View(tHOIKHOABIEU);
        }

        // POST: THOIKHOABIEUx/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TKB_MA,LOP_LOP_MA")] THOIKHOABIEU tHOIKHOABIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHOIKHOABIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LOP_LOP_MA = new SelectList(db.LOPs, "LOP_MA", "LOP_TEN", tHOIKHOABIEU.LOP_LOP_MA);
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
