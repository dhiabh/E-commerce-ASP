using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
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
        static string error = "";
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index(int Id)
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }

            Product produit = db.Products.Find(Id);

            //error = produit.User.Address;
            //return RedirectToAction("Error");
            return View(produit);
        }


        public ActionResult Error()
        {
            ViewBag.error = error;
            return View();
        }

        public ActionResult EditProduct()
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

        
        public ActionResult DeleteProduct(int Id)
        {
            string id = User.Identity.GetUserId();
            
            var user = db.Users.Where(u => u.Id.Equals(id)).First();

            var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
            ViewBag.user = realUser;

            

            Product product = db.Products.Find(Id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("MyProducts","Proprietaire",new { Id = realUser.RealId } );
        }
    }
}