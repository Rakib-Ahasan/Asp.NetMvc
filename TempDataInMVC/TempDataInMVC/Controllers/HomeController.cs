using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TempDataInMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Var1"] = "Message from View Data!!";
            ViewBag.Var2 = "Message from View Bag!!";
            TempData["Var3"] = "Message from Temp Data";

            string[] games = {"Hockey", "Cricket", "Football"};

            TempData["Games"] = games;
            return View();
        }

        public ActionResult About()
        {
            //Keep() is not a best practice for this reason we can use session .
            TempData.Keep();
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}