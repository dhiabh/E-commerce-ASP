using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

           
            @ViewData["nb_Users"] = db.RealUsers.ToList().Count();
            @ViewData["nb_Products"] =db.Products.ToList().Count();
            @ViewData["nb_Companies"] =db.RealUsers.Where(x=>x.Nature.Equals("Company")).Count();
            @ViewData["nb_Categories"] =db.Categories.ToList().Count();
            @ViewData["nb_Particulars"] = db.RealUsers.Where(x => x.Nature.Equals("Particular")).Count();




            return View();
        }


        /*
        public ActionResult Chart()
        {

            var userslist = new List<String>();
            //string[] x = ;
            //int[] y = { 5, 3 };

            new System.Web.Helpers.Chart(width: 800, height: 200, theme: ChartTheme.Green)
                .AddTitle("Nombre des Prouids par Utilisateur")
                .AddSeries(
                    chartType: "Column",
                    xValue: x,
                    yValues: y
                ).Write("png");
            return null;
        }*/
    }
}