using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSitesi.Models;

namespace BlogSitesi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        // GET: Login
        public ActionResult KullaniciGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(BlogSitesi.Models.User userModel)
        {
            using (SiteEntities db = new SiteEntities())
            {
                var userDetails = db.Users.Where(x => x.KullaniciAdi == userModel.KullaniciAdi && x.Sifre == userModel.Sifre).FirstOrDefault();

                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Kullanıcı adı veya şifre yanlış";
                    return View("KullaniciGiris", userModel);
                }
                else
                {
                    Session["KullaniciID"] = userDetails.KullaniciID;
                    Session["KullaniciAdi"] = userDetails.KullaniciAdi;
                    Session["Profil"] = userDetails.Profil;
                    return RedirectToAction("AnaSayfa", "Home");
                }
            }

            
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("KullaniciGiris", "Login");
        }
    }
}