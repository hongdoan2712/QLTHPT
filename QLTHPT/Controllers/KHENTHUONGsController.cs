﻿using System;
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
    public class KHENTHUONGsController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: KHENTHUONGs
        public ActionResult Index()
        {
            var kHENTHUONGs = db.KHENTHUONGs.Include(k => k.CANBO).Include(k => k.HOCSINH);
            return View(kHENTHUONGs.ToList());
        }

        // GET: KHENTHUONGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONG kHENTHUONG = db.KHENTHUONGs.Find(id);
            if (kHENTHUONG == null)
            {
                return HttpNotFound();
            }
            return View(kHENTHUONG);
        }

        // GET: KHENTHUONGs/Create
        public ActionResult Create()
        {
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN");
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN");
            return View();
        }

        // POST: KHENTHUONGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KT_MA,KT_THANHTICH,KT_NGAYKHENTHUONG,KT_GHICHU,CB_MA,HS_MA")] KHENTHUONG kHENTHUONG)
        {
            if (ModelState.IsValid)
            {
                db.KHENTHUONGs.Add(kHENTHUONG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", kHENTHUONG.CB_MA);
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", kHENTHUONG.HS_MA);
            return View(kHENTHUONG);
        }

        // GET: KHENTHUONGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONG kHENTHUONG = db.KHENTHUONGs.Find(id);
            if (kHENTHUONG == null)
            {
                return HttpNotFound();
            }
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", kHENTHUONG.CB_MA);
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", kHENTHUONG.HS_MA);
            return View(kHENTHUONG);
        }

        // POST: KHENTHUONGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KT_MA,KT_THANHTICH,KT_NGAYKHENTHUONG,KT_GHICHU,CB_MA,HS_MA")] KHENTHUONG kHENTHUONG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHENTHUONG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CB_MA = new SelectList(db.CANBOes, "CB_MA", "CB_HOTEN", kHENTHUONG.CB_MA);
            ViewBag.HS_MA = new SelectList(db.HOCSINHs, "HS_MA", "HS_HOTEN", kHENTHUONG.HS_MA);
            return View(kHENTHUONG);
        }

        // GET: KHENTHUONGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHENTHUONG kHENTHUONG = db.KHENTHUONGs.Find(id);
            if (kHENTHUONG == null)
            {
                return HttpNotFound();
            }
            return View(kHENTHUONG);
        }

        // POST: KHENTHUONGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHENTHUONG kHENTHUONG = db.KHENTHUONGs.Find(id);
            db.KHENTHUONGs.Remove(kHENTHUONG);
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
