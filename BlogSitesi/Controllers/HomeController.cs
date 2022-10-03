using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSitesi.Models;

namespace BlogSitesi.Controllers
{
    public class HomeController : Controller
    {
        private SiteEntities u = new SiteEntities();
        public ActionResult AnaSayfa()
        {
            var deger = u.Blogs.ToList();
            return View(deger);
        }

        public ActionResult IcerikYaz()
        {
            return View(new Models.Blog());
        }

        [HttpPost]
        public ActionResult IcerikYaz(Blog imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.imagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            string session = Session["KullaniciAdi"].ToString();
            string pp = Session["Profil"].ToString();
            int sessionid = Convert.ToInt32(Session["KullaniciID"]);
                
            using (SiteEntities db = new SiteEntities())
            {
                imageModel.UserID = sessionid;
                imageModel.isim = session;
                imageModel.profilPath = pp;
                imageModel.Tarih = DateTime.Now;
                db.Blogs.Add(imageModel);
                db.SaveChanges();
            
            }
            ModelState.Clear();
            return RedirectToAction("AnaSayfa", "Home");
        }

        [HttpGet]
        public ActionResult BlogDetay(int id)
        {
            Blog imageModel = new Blog();
            using (SiteEntities db = new SiteEntities())
            {
                imageModel = db.Blogs.Where(x => x.KullaniciID == id).FirstOrDefault();
            }

            return View(imageModel);
        }

        public ActionResult HesapDetay(int id)
        {
            Blog imageModel = new Blog();
            using (SiteEntities db = new SiteEntities())
            {
                imageModel = db.Blogs.Where(x => x.UserID == id).FirstOrDefault();
            }
            return View(imageModel);
        }

    
       
    }
}