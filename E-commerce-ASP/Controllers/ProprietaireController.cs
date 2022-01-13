using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace E_commerce_ASP.Controllers
{
    public class ProprietaireController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        static string error = "";
        // GET: Proprietaire
        public ActionResult Index(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var Authuser = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == Authuser.RefId).First();
                ViewBag.user = realUser;

            }

            var user = db.RealUsers.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
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
        public ActionResult AddProduct([Bind(Include = "Id,Name,Price,CategoryId,Description")] Product product, HttpPostedFileBase upload)
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
                Historique historique = new Historique();
                
                ViewBag.CategoryList = new SelectList(db.Categories, "Id", "Name");

                string pic = Path.GetFileName(upload.FileName);
                string path = Path.Combine(Server.MapPath("~/Uploads"), pic);
                upload.SaveAs(path);
                product.Image = upload.FileName;

                var user = db.Users.Where(u => u.Id.Equals(id)).First();
                product.UserId = user.RefId;
                historique.UserId = user.RefId;
                

                User realUser = db.RealUsers.Where(u => u.RealId == product.UserId).First();
                product.User = realUser;

                int categoryId = Convert.ToInt32(Request.Form["CategoryId"]);

                Category category = db.Categories.Where(c => c.Id == categoryId).First();

                product.Category = category;


                db.Products.Add(product);
                historique.Transaction = "Created";
                historique.Date = DateTime.Now;
                historique.ProductId = product.Id;
                historique.Pname = product.Name;
                db.Historiques.Add(historique);
                db.SaveChanges();

                return RedirectToAction("MyProducts", new { Id = product.UserId });
                
                
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

        [HttpGet]
        public ActionResult Settings(int? Id)
        {

            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var Authuser = db.Users.Where(u => u.Id.Equals(id)).First();

                if(Authuser.RefId != Id)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var realUser = db.RealUsers.Where(u => u.RealId == Authuser.RefId).First();
                ViewBag.user = realUser;

            }

            User user = db.RealUsers.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Settings([Bind(Include = "RealId,FirstName,LastName,Email,PhoneNumber,Address,FullName,Nature,CompanyName,WebSite,NumPatente")] User user)
        {
            var Authuser = db.Users.Where(u => u.RefId == user.RealId).First();

            ViewBag.user = user;
            
                
                if (ModelState.IsValid)
                {
                    Authuser.Email = user.Email;
                    Authuser.UserName = user.Email;
                    Authuser.PhoneNumber = user.PhoneNumber;

                    if (user.Nature == "Particular")
                    {
                        user.FullName = user.FirstName + " " + user.LastName;
                    }

                    db.Entry(user).State = EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("Index","Proprietaire", new { Id = user.RealId });
                }
            
     
            return View(user);

        }

        public ActionResult Error()
        {
            ViewBag.error = error;
            return View();

        }

        public ActionResult Historique()
        {
            string id = User.Identity.GetUserId();
            int  Realid=0;
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;
                Realid = realUser.RealId;
            }

            return View(db.Historiques.Where(x=>x.UserId==Realid).ToList());
        }

        [HttpGet]
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeclareProblem([Bind(Include = "Complaint")] Problem problem)
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

                var user = db.Users.Where(u => u.Id.Equals(id)).First();
                problem.UserId = user.RefId;

                User realUser = db.RealUsers.Where(u => u.RealId == problem.UserId).First();
                problem.User = realUser;

                problem.Date = DateTime.Now;

                db.Problems.Add(problem);

                db.SaveChanges();

                return RedirectToAction("DeclareProblem");
            }

            return View();
        }

       
    }
}