using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ValidationMessageSummary.Controllers
{
    public class HomeController : Controller
    {
        string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string fName,string age,string email)
        {
            if (fName.Equals("")==true)
            {
                ModelState.AddModelError("fName", "Fullname is required!");
                ViewData["fNameError"] = "*";
            }
            if (age.Equals("")==true)
            {
                ModelState.AddModelError("age", "Age is required!");
                ViewData["ageError"] = "*";
            }
            if (email.Equals("") == true)
            {
                ModelState.AddModelError("email", "Email is required!");
                ViewData["emailError"] = "*";
            }
            else
            {
                if (Regex.IsMatch(email,pattern)==false)
                {
                    ModelState.AddModelError("email", "Invalid email!");
                    ViewData["emailError"] = "*";
                }
            }

            if (ModelState.IsValid==true)
            {
                ViewData["SuccessMessage"] = "<script>alert('Data has been submitted!')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}