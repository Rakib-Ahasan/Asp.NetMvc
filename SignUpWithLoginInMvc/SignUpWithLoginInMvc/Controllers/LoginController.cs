using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignUpWithLoginInMvc.Models;

namespace SignUpWithLoginInMvc.Controllers
{
    public class LoginController : Controller
    {
        SignUpLoginEntities db = new SignUpLoginEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(User u)
        {
            var user = db.Users.FirstOrDefault(model => model.Username == u.Username && model.Password == u.Password);
            if (user!=null)
            {
                Session["UserId"] = u.Id.ToString();
                Session["UserName"] = u.Username.ToString();
                TempData["LoginSuccessMessage"]= "<script>alert('Login Successful!!')</script>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or password is incorrect !!')</script>";
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            if (ModelState.IsValid == true)
            {
                db.Users.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registration Successful!!')</script>";
                    ModelState.Clear();

                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registration Successful!!')</script>";
                }
            }
            return View();
        }
    }
}