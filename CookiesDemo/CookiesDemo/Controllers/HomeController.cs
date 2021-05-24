using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CookiesDemo.Models;

namespace CookiesDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid==true)
            {
                HttpCookie cookie=new HttpCookie("Username");
                cookie.Value = u.Username;
                HttpContext.Response.Cookies.Add(cookie);
                //If I want to save cookie for a fixed time that's call permanent cookie.
                cookie.Expires = DateTime.Now.AddDays(30);
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}