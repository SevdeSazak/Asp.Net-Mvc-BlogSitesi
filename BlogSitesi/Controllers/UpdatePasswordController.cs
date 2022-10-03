using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSitesi.Models;

namespace BlogSitesi.Controllers
{
    public class UpdatePasswordController : Controller
    {
        public ActionResult Guncelleme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Guncelleme(User customer)
        {
            using (SiteEntities entities = new SiteEntities())
            {
                User updatedCustomer = (from c in entities.Users
                    where c.KullaniciAdi == customer.KullaniciAdi
                    select c).FirstOrDefault();
     


                if (updatedCustomer != null)
                {
                    updatedCustomer.Sifre = customer.YeniSifre;
                    entities.SaveChanges();
                    ViewBag.SuccessMessage = "Sifre basariyla degistirildi";
                }
                else
                {
                    ViewBag.DuplicateMessage = "Kullanici bulunamadi";
                }

                return View();
            }
        }
    }
}
