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
    public class LOPsController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: LOPs
        public ActionResult Index()
        {
            var lOPs = db.LOPs.Include(l => l.KHOIs).Include(l => l.NAMHOC);
            return View(lOPs.ToList());
        }

        // GET: LOPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP lOP = db.LOPs.Find(id);
            if (lOP == null)
            {
                return HttpNotFound();
            }
            return View(lOP);
        }

        // GET: LOPs/Create
        public ActionResult Create()
        {
            ViewBag.KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN");
            ViewBag.NH_MA = new SelectList(db.NAMHOCs, "NH_MA", "NH_NAMHOC");
            return View();
        }

        // POST: LOPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOP_MA,LOP_TEN,KHOI_MA,NH_MA")] LOP lOP)
        {
            if (ModelState.IsValid)
            {
                db.LOPs.Add(lOP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN", lOP.KHOI_MA);
            ViewBag.NH_MA = new SelectList(db.NAMHOCs, "NH_MA", "NH_NAMHOC", lOP.NH_MA);
            return View(lOP);
        }

        // GET: LOPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP lOP = db.LOPs.Find(id);
            if (lOP == null)
            {
                return HttpNotFound();
            }
            ViewBag.KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN", lOP.KHOI_MA);
            ViewBag.NH_MA = new SelectList(db.NAMHOCs, "NH_MA", "NH_NAMHOC", lOP.NH_MA);
            return View(lOP);
        }

        // POST: LOPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOP_MA,LOP_TEN,KHOI_MA,NH_MA")] LOP lOP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KHOI_MA = new SelectList(db.KHOIs, "KHOI_MA", "KHOI_TEN", lOP.KHOI_MA);
            ViewBag.NH_MA = new SelectList(db.NAMHOCs, "NH_MA", "NH_NAMHOC", lOP.NH_MA);
            return View(lOP);
        }

        // GET: LOPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOP lOP = db.LOPs.Find(id);
            if (lOP == null)
            {
                return HttpNotFound();
            }
            return View(lOP);
        }

        // POST: LOPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LOP lOP = db.LOPs.Find(id);
            db.LOPs.Remove(lOP);
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
