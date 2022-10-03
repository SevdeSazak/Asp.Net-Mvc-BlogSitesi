using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSitesi.Models;

namespace BlogSitesi.Controllers
{
    public class KullaniciController : Controller
    {
 
        [HttpGet]
        public ActionResult Sil(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Sil(User userModel, Blog blogModel)
        {
            using (SiteEntities db = new SiteEntities())
            {
                User user = db.Users.Where(x => x.KullaniciAdi == userModel.KullaniciAdi && x.Sifre == userModel.Sifre).FirstOrDefault();
                if (user == null)
                {
                    userModel.LoginErrorMessage = "Kullanıcı adı veya şifre yanlış";
                    return View("Sil", userModel);
                }
                
                db.Users.Remove(user);
                db.SaveChanges();


            }
            ModelState.Clear();
            return RedirectToAction("KullaniciGiris", "Login");
        }        
        }



  
}