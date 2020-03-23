using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using QLTHPT.ModelDB;

namespace QLTHPT.Controllers
{
    public class CANBOesController : Controller
    {
        private ModelDB.acomptec_qlthptEntities2 db = new ModelDB.acomptec_qlthptEntities2();

        // GET: CANBOes
        public ActionResult Index()
        {
            ViewData["Items"] = from h in db.CANBOes select h;
            var cANBOes = db.CANBOes.Include(c => c.COQUAN).Include(c => c.CHUCVU);
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
            ViewBag.CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN");
            ViewBag.CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN");
            return View();
        }

        // POST: CANBOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,CQ_MA,CV_MA")] CANBO cANBO)
        {
            if (ModelState.IsValid)
            {
                db.CANBOes.Add(cANBO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.CQ_MA);
            ViewBag.CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cANBO.CV_MA);
            return View(cANBO);
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
            ViewBag.CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.CQ_MA);
            ViewBag.CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cANBO.CV_MA);
            return View(cANBO);
        }

        // POST: CANBOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CB_MA,CB_HOTEN,CB_GIOITINH,CB_DIACHI,CB_NGAYSINH,CB_CMND,CQ_MA,CV_MA")] CANBO cANBO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANBO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CQ_MA = new SelectList(db.COQUANs, "CQ_MA", "CQ_TEN", cANBO.CQ_MA);
            ViewBag.CV_MA = new SelectList(db.CHUCVUs, "CV_MA", "CV_TEN", cANBO.CV_MA);
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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
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
