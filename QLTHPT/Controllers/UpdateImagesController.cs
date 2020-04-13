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
    public class UpdateImagesController : Controller
    {
        private acomptec_qlthptEntities db = new acomptec_qlthptEntities();

        // GET: UpdateImages
        public ActionResult Index()
        {
            return View(db.UpdateImages.ToList());
        }

        // GET: UpdateImages/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateImage updateImage = db.UpdateImages.Find(id);
            if (updateImage == null)
            {
                return HttpNotFound();
            }
            return View(updateImage);
        }

        // GET: UpdateImages/Create
        public ActionResult Create()
        {
            UpdateImage obj = new UpdateImage();
            obj.Id = CreateID.CreateID_ByteText();
            return View(obj);
        }

        // POST: UpdateImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image_url,Name_im")] UpdateImage updateImage)
        {
            if (ModelState.IsValid)
            {
                db.UpdateImages.Add(updateImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(updateImage);
        }

        // GET: UpdateImages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateImage updateImage = db.UpdateImages.Find(id);
            if (updateImage == null)
            {
                return HttpNotFound();
            }
            return View(updateImage);
        }

        // POST: UpdateImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image_url,Name_im")] UpdateImage updateImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updateImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updateImage);
        }

        // GET: UpdateImages/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateImage updateImage = db.UpdateImages.Find(id);
            if (updateImage == null)
            {
                return HttpNotFound();
            }
            return View(updateImage);
        }

        // POST: UpdateImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UpdateImage updateImage = db.UpdateImages.Find(id);
            db.UpdateImages.Remove(updateImage);
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
