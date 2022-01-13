using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [RequireHttps]
        public ActionResult Index(string search)
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

        public ActionResult LiveSearch(string search)
        {
            // Call your method to search your data source here.
            // I'll use entity framework to query my DB
            List<Product> res = (
                from p in db.Products
                where p.Name.Contains(search)
                select p
                ).ToList();

            // Pass the List of results to a Partial View 
            return PartialView(res);
        }

        
        public ActionResult Search(string search)
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }

            List<Product> products = (
                from p in db.Products
                where p.Name.Equals(search)
                select p
                ).ToList();

            return View(products);
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