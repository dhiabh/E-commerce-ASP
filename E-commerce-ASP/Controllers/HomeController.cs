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
        private Entities db = new Entities();

        [RequireHttps]
        public ActionResult Index()
        {
            //ViewBag.Products = db.Products.ToList();
           // ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View(db.Products.ToList());
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

        public ActionResult Statistique()
        {

            return View();
        }
    }
}