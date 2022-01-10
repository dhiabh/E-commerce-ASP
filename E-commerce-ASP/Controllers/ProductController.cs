using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
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