using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        static string error = "";

        [RequireHttps]
        public ActionResult Index()
        {
            //ViewBag.Products = db.Products.ToList();
            // ViewBag.Categories = new SelectList(db.Categories, "RefId", "Name");

            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            
            return View(db.Products.ToList());
        }

        public ActionResult Error()
        {
            ViewBag.error = error;
            return View();
        }

        public ActionResult About()
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Statistique()
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            return View();
        }
    }
}