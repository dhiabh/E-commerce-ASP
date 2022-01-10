using E_commerce_ASP.Models;
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

        private Entities db = new Entities();

        // GET: Proprietaire
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.e = new SelectList(db.Categories, "Id","Name");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Products product, HttpPostedFileBase upload)
        {

           
                Product p = new Product();
                //string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                //upload.SaveAs(path);
                //p.Image = upload.FileName;
                p.UserId = "0be37235-0ce3-4a18-8831-bb28c8ff0469";
                p.Price = (decimal)product.Price;
                p.Name = product.Name;
                p.CategoryId = (int)product.CategoryId;
                
                db.Products.Add(product);
                db.SaveChanges();

            return View(product);
        }


        public ActionResult MyProducts()
        {
            
            return View(db.Products.Where(x  => x.UserId== "0be37235-0ce3-4a18-8831-bb28c8ff0469").ToList());
        }

        public ActionResult Historique()
        {
            return View();
        }

        public ActionResult DeclareProblem()
        {
            return View();
        }
    }
}