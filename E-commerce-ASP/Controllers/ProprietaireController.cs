using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace E_commerce_ASP.Controllers
{
    public class ProprietaireController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proprietaire
        public ActionResult Index()
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

        [HttpGet]
        public ActionResult AddProduct()
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Name");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct([Bind(Include = "Id,Name,Price,CategoryId")] Product product, HttpPostedFileBase upload)
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            if (ModelState.IsValid)
            {
                
                ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Name");

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


                db.Products.Add(product);
                db.SaveChanges();

                ModelState.Clear();

                return View(product);
                
                
            }

            return View();
            
        }

        


        public ActionResult MyProducts(int Id)
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var Authuser = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == Authuser.RefId).First();
                ViewBag.user = realUser;

            }


            //var user = db.Users.Where(u => u.Id.Equals(id)).First();
            return View(db.Products.Where(x => x.UserId == Id).ToList());
        }

        public ActionResult Historique()
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

        public ActionResult DeclareProblem()
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