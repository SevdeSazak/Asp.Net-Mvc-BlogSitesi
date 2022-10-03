using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSitesi.Models;
using System.IO;


namespace BlogSitesi.Controllers
{
    public class RecordController : Controller
    {
            [HttpGet]
            public ActionResult Kayit(int id = 0)
            {
                User userModel = new User();
                return View(userModel);
            }

            [HttpPost]
            public ActionResult Kayit(User userModel)
            {
        
            using (SiteEntities dbModel1 = new SiteEntities())
            {
                string fileName = Path.GetFileNameWithoutExtension(userModel.Imagefile.FileName);
                string extension = Path.GetExtension(userModel.Imagefile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                userModel.Profil = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                userModel.Imagefile.SaveAs(fileName); 
                    if (dbModel1.Users.Any(x => x.KullaniciAdi == userModel.KullaniciAdi))
                    {
                        ViewBag.DuplicateMessage = "Kullanıcı Adı Alınmış";
                        return View("Kayit", userModel);
                    }

                    dbModel1.Users.Add(userModel);
                    dbModel1.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "KAYIT BAŞARILI";
                return View("Kayit", new User());

            }
        }
}