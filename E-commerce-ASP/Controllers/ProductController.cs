using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    public class ProductController : BaseController
    {
        static string error = "";
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }

            Product produit = db.Products.Find(Id);

            if (produit == null)
            {
                return HttpNotFound();
            }

            //error = produit.User.Address;
            //return RedirectToAction("Error");
            return View(produit);
        }


        public ActionResult Error()
        {
            ViewBag.error = error;
            return View();
        }

        [HttpGet]
        public ActionResult EditProduct(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            ViewBag.CategoryList = new SelectList(db.Categories.ToList(), "Id", "Name");

            Product product = db.Products.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "Id,Name,Price,CategoryId,Description")] Product product, HttpPostedFileBase upload)
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }

            ViewBag.CategoryList = new SelectList(db.Categories.ToList(), "Id", "Name");

            if (ModelState.IsValid)
            {
                string pic = Path.GetFileName(upload.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads"), pic);
                upload.SaveAs(path);
                product.Image = upload.FileName;

                var user = db.Users.Where(u => u.Id.Equals(id)).First();
                product.UserId = user.RefId;

                User realUser = db.RealUsers.Where(u => u.RealId == product.UserId).First();
                product.User = realUser;

                int categoryId = Convert.ToInt32(Request.Form["CategoryId"]);

                Category category = db.Categories.Where(c => c.Id == categoryId).First();

                product.Category = category;

                db.Entry(product).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index",new { id = product.Id });
            }

            return View(product);
        }


            public ActionResult DeleteProduct(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string id = User.Identity.GetUserId();
            
            var user = db.Users.Where(u => u.Id.Equals(id)).First();

            var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
            ViewBag.user = realUser;

            

            Product product = db.Products.Find(Id);

            if (product == null)
            {
                return HttpNotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("MyProducts","Proprietaire",new { Id = realUser.RealId } );
        }
    }
}