using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            if (id != null)
            {
                var user = db.Users.Where(u => u.Id.Equals(id)).First();

                var realUser = db.RealUsers.Where(u => u.RealId == user.RefId).First();
                ViewBag.user = realUser;

            }
            return View(db.Products.ToList());
        }

        public ActionResult DashBoard()
        {
            

            return View(db.RealUsers.ToList());
        }

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult ListeProbleme()
        {
            return View(db.Problems.ToList());
        }

        public ActionResult Historique()
        {
            return View(db.Historiques.ToList());
        }

        public ActionResult ListeNoire()
        {
            ViewBag.UsersList = new SelectList(db.RealUsers.Where(x => !x.IsInBlackList).ToList(), "RealId", "Email");
            ViewBag.usersBlackList = new SelectList(db.RealUsers.Where(x => x.IsInBlackList).ToList(), "RealId", "Email");

            return View();
        }



       
        public ActionResult ListeFavoris()
        {
            ViewBag.RealId = new SelectList(db.RealUsers.Where(x => !x.IsInFavList).ToList(), "RealId", "Email");
            ViewBag.usersFavList = new SelectList(db.RealUsers.Where(x => x.IsInFavList).ToList(), "RealId", "Email");

            return View();
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddListeFavoris([Bind(Include = "RealId")] User user)
        {

            ViewBag.RealId = new SelectList(db.RealUsers.Where(x => !x.IsInFavList).ToList(), "RealId", "Email",user.RealId);
            

            if (ModelState.IsValid)
            {
               
                User realUser = db.RealUsers.Where(u => u.RealId == user.RealId).First();
                user = realUser;
                user.IsInFavList = true;
                db.Entry(realUser).CurrentValues.SetValues(user);
                
                db.SaveChanges();

                return RedirectToAction("ListeFavoris", "Admin", new { Id = user.RealId });
            }


                return View("ListeFavoris");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveListeFavoris([Bind(Include = "RealId")] User user)
        {
           
            ViewBag.usersFavList = new SelectList(db.RealUsers.Where(x => x.IsInFavList).ToList(), "RealId", "Email",user.RealId);

            if (ModelState.IsValid)
            {

                User realUser = db.RealUsers.Where(u => u.RealId == user.RealId).First();
                user = realUser;
                user.IsInFavList = false;
                db.Entry(realUser).CurrentValues.SetValues(user);

                db.SaveChanges();

                return RedirectToAction("ListeFavoris", "Admin", new { Id = user.RealId });
            }


            return View("ListeFavoris");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddListeNoire([Bind(Include = "RealId")] User user)
        {

            ViewBag.RealId = new SelectList(db.RealUsers.Where(x => !x.IsInBlackList).ToList(), "RealId", "Email", user.RealId);


            if (ModelState.IsValid)
            {

                User realUser = db.RealUsers.Where(u => u.RealId == user.RealId).First();
                user = realUser;
                user.IsInBlackList = true;
                db.Entry(realUser).CurrentValues.SetValues(user);

                db.SaveChanges();

                return RedirectToAction("ListeNoire", "Admin", new { Id = user.RealId });
            }


            return View("ListeNoire");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveListeNoire([Bind(Include = "RealId")] User user)
        {

            ViewBag.RealId = new SelectList(db.RealUsers.Where(x => x.IsInBlackList).ToList(), "RealId", "Email", user.RealId);


            if (ModelState.IsValid)
            {

                User realUser = db.RealUsers.Where(u => u.RealId == user.RealId).First();
                user = realUser;
                user.IsInBlackList = false;
                db.Entry(realUser).CurrentValues.SetValues(user);

                db.SaveChanges();

                return RedirectToAction("ListeNoire", "Admin", new { Id = user.RealId });
            }


            return View("ListeNoire");
        }



    }
}