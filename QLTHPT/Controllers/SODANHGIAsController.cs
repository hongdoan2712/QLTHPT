﻿using System;
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
    public class SODANHGIAsController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: SODANHGIAs
        public ActionResult Index()
        {
            var sODANHGIAs = db.SODANHGIAs.Include(s => s.HOCKy);
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
            ViewBag.HOCKy_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN");
            return View();
        }

        // POST: SODANHGIAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SDG_MA,SDG_DIEM,SDG_GHICHU,HOCKy_HK_MA")] SODANHGIA sODANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.SODANHGIAs.Add(sODANHGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HOCKy_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", sODANHGIA.HOCKy_HK_MA);
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
            ViewBag.HOCKy_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", sODANHGIA.HOCKy_HK_MA);
            return View(sODANHGIA);
        }

        // POST: SODANHGIAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SDG_MA,SDG_DIEM,SDG_GHICHU,HOCKy_HK_MA")] SODANHGIA sODANHGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sODANHGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HOCKy_HK_MA = new SelectList(db.HOCKies, "HK_MA", "HK_TEN", sODANHGIA.HOCKy_HK_MA);
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