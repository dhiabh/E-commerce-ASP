using E_commerce_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    public class ProductController : Controller
    {
        private Entities db = new Entities();

        // GET: Product
        public ActionResult Index(string Id)
        {
            
            Products produit = db.Products.Find(Id);
            
            return View(produit);
        }

        public ActionResult DeleteProduct()
        {

            return View();
        }

        public ActionResult EditProduct()
        {
            return View();
        }
    }
}