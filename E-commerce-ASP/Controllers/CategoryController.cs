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
    public class CategoryController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Category
        [RequireHttps]
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

            if(db.Categories.Find(Id) == null)
            {
                return HttpNotFound();
            }
                        
            List<Product> products = db.Products.Where(p => p.CategoryId == Id).ToList();

            ViewBag.category = db.Categories.Find(Id).Name;

            return View(products);
            


        }
    }
}