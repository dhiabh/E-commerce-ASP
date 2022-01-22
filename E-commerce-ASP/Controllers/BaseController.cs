using E_commerce_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce_ASP.Controllers
{
    public class BaseController : Controller
    {
        /*private ApplicationDbContext db = new ApplicationDbContext();

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

        }*/

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                // pour détecter la culture a partir du navigateur de l'utilisateur
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "") { lang = GestionLanguages.GetDefaultLanguage(); }
            }
            new GestionLanguages().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }





    }
}