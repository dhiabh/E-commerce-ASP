using E_commerce_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        private Entities db = new Entities();

        // GET: Admin
        public ActionResult Index()
        {
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
            return View();
        }

        public ActionResult DetailUtilisateur()
        {
            return View();
        }


        public ActionResult ListeNoire()
        {
            return View();
        }

        public ActionResult ListeFavoris()
        {
            return View();
        }
    }
}