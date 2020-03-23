using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTHPT.Controllers
{
    public class HomeController : Controller
    {
        ModelDB.acomptec_qlthptEntities2 obj = new ModelDB.acomptec_qlthptEntities2();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc, HttpPostedFileBase file)
        {
            ModelDB.UpdateImage updateImage = new ModelDB.UpdateImage();
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
        };
            updateImage.Id = fc["Id"].ToString();
            updateImage.Image_url = file.ToString();
            updateImage.Name_im = fc["Name"].ToString();
            var fileName = Path.GetFileName(file.FileName);
            var ext = Path.GetExtension(file.FileName); 
            if (allowedExtensions.Contains(ext)) 
            {
                string name = Path.GetFileNameWithoutExtension(fileName);
                string myfile = name + "_" + updateImage.Id + ext;  
                var path = Path.Combine(Server.MapPath("~/images/img"), myfile);
                string pathstring = "/images/img/" + myfile;
                updateImage.Image_url = pathstring;
                obj.UpdateImages.Add(updateImage);
                obj.SaveChanges();
                file.SaveAs(path);
            }
            else
            {
                ViewBag.message = "Vui lòng chọn duy nhất một file!";
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

