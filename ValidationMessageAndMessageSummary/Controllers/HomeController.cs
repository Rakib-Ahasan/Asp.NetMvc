using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ValidationMessageAndMessageSummary.Controllers
{
    public class HomeController : Controller
    {
        string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Fullname, string Age, string Email)
        {
            if (Fullname.Equals("") == true)
            {
                ModelState.AddModelError("fullname", "Fullname is required!");
                ViewData["fullNameError"] = "*";
            }

            if (Age.Equals("") == true)
            {
                ModelState.AddModelError("Age", "Age is required!");
                ViewData["AgeError"] = "*";
            }

            if (Email.Equals("") == true)
            {
                ModelState.AddModelError("Email", "Email is required!");
                ViewData["emailError"] = "*";
            }

            else
            {

                if (Regex.IsMatch(Email,pattern)==false)
                {
                    ModelState.AddModelError("Email", "Invalid eamil!");
                    ViewData["emailError"] = "*";
                }
            }

            if (ModelState.IsValid == true)
            {
                ViewData["SuccessMessage"] = "<script>alert('Data has been submitted.')</script>";
                ModelState.Clear();

            }

            return View();
        }
    }
}