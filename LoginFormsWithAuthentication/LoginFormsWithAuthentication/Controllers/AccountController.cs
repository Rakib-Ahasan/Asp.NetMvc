using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginFormsWithAuthentication.Models;
using System.Web.Security;

namespace LoginFormsWithAuthentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new OfficeEntities())
            {
                bool isValid = context.Users.Any(x => x.Username == model.Username && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false); 
                    return RedirectToAction("Index","Employees");
                }
                ModelState.AddModelError("", "Invalid Username or Pasword");
            }
            
            return View();
        }

        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User model)
        {
            using(var context=new OfficeEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public object Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}