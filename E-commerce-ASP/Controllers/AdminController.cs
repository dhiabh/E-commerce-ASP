using E_commerce_ASP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult Historique()
        {
            return View(db.Historiques.ToList());
        }

        public ActionResult DetailUtilisateur()
        {
            return View(db.Users.ToList());
        }


        public ActionResult ListeNoire()
        {
            return View(db.RealUsers.Where(x => x.IsInBlackList).ToList());
        }

        public ActionResult ListeFavoris()
        {
            return View(db.RealUsers.Where(x => x.IsInFavList).ToList());
        }
    }
}