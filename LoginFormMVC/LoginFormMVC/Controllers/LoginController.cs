using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginFormMVC.Models;

namespace LoginFormMVC.Controllers
{
    public class LoginController : Controller
    {
        LoginDB2Entities db=new LoginDB2Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid==true)
            {
                var credentials = db.Users.FirstOrDefault(model => model.Username==u.Username && model.Password==u.Password);
                if (credentials==null)
                {
                    ViewBag.ErrorMessage = "Login failed!";
                    return View();
                }
                else
                {
                    Session["username"] = u.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}