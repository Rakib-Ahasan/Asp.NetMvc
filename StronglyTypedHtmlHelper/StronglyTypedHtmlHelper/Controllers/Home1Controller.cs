using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StronglyTypedHtmlHelper.Models;

namespace StronglyTypedHtmlHelper.Controllers
{
    public class Home1Controller : Controller
    {
        // GET: Home1
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Calculation calculation)
        {
            int num1 = calculation.num1;
            int num2 = calculation.num2;
            int result = num1 + num2;
            ViewBag.Result = result;
            return View();
        }
    }
}