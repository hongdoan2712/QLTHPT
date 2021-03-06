﻿using System;
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
    public class CHITIET_CHUCVUController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: CHITIET_CHUCVU
        public ActionResult Index()
        {
            var cHITIET_CHUCVU = db.CHITIET_CHUCVU.Include(c => c.CHUCVU);
            return View(cHITIET_CHUCVU.ToList());
        }

        // GET: CHITIET_CHUCVU/Details/5
        public ActionResult Details(TimeSpan id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            if (cHITIET_CHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_CHUCVU);
        }

        // GET: CHITIET_CHUCVU/Create
        public ActionResult Create()
        {
            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN");
            return View();
            //CHITIET_CHUCVU obj = new CHITIET_CHUCVU();
            //obj.CT_CV_ID = CreateID.CreateID_ByteText();
            //return View(obj);
        }

        // POST: CHITIET_CHUCVU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CT_CV_ID,CT_CV_TEN,CHUCVU_CV_MA")] CHITIET_CHUCVU cHITIET_CHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.CHITIET_CHUCVU.Add(cHITIET_CHUCVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cHITIET_CHUCVU.CHUCVU_CV_MA);
            return View(cHITIET_CHUCVU);
        }

        // GET: CHITIET_CHUCVU/Edit/5
        public ActionResult Edit(TimeSpan id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            if (cHITIET_CHUCVU == null)
            {
                return HttpNotFound();
            }
            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cHITIET_CHUCVU.CHUCVU_CV_MA);
            return View(cHITIET_CHUCVU);
        }

        // POST: CHITIET_CHUCVU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CT_CV_ID,CT_CV_TEN,CHUCVU_CV_MA")] CHITIET_CHUCVU cHITIET_CHUCVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIET_CHUCVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CHUCVU_CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cHITIET_CHUCVU.CHUCVU_CV_MA);
            return View(cHITIET_CHUCVU);
        }

        // GET: CHITIET_CHUCVU/Delete/5
        public ActionResult Delete(TimeSpan id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            if (cHITIET_CHUCVU == null)
            {
                return HttpNotFound();
            }
            return View(cHITIET_CHUCVU);
        }

        // POST: CHITIET_CHUCVU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TimeSpan id)
        {
            CHITIET_CHUCVU cHITIET_CHUCVU = db.CHITIET_CHUCVU.Find(id);
            db.CHITIET_CHUCVU.Remove(cHITIET_CHUCVU);
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
