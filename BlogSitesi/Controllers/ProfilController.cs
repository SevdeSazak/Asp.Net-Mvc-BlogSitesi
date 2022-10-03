using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSitesi.Models;

namespace BlogSitesi.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        public ActionResult Index()
        {
            string profil = Session["Profil"].ToString();
            Blog imageModel = new Blog();
            using (SiteEntities db = new SiteEntities())
            {



            }

            return View();
        }
          
        }
    }
