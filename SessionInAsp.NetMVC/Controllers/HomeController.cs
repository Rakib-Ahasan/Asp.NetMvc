using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionInAsp.NetMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["var1"] = "Data comes from view data";
            ViewBag.var2 = "Data comes from view bag";
            TempData["var3"] = "Data comes from temp data";
            Session["var4"] = "Data comes from session";

            string[] Students = {"Ali", "Khan", "Kamal","Jamal"};
            Session["var5"] = Students;
            return View();
        }
        public ActionResult About()
        {
            if (Session["var5"] !=null)
            {
                Session["var5"].ToString();
            }
          
            return View();
        }
        public ActionResult Contact()
        {
            if (Session["var5"] != null)
            {
                Session["var5"].ToString();
            }
            return View();
        }

    }
}