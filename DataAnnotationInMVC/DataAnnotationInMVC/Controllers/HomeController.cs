using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationInMVC.Models;

namespace DataAnnotationInMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee e)
        {
            if (ModelState.IsValid==true)
            {
                ViewData["SuccessMessage"] = "<script>alert('Data has been submitted!')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}