using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessioInMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Var1"] = "Data comes from ViewData";
            ViewBag.Var2 = "Data comes from ViewBag";
            TempData["Var3"] = "Data comes from TempData";
            Session["Var4"] = "Data comes from Session";
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}