using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJAX_HelperInMVC.Models;

namespace AJAX_HelperInMVC.Controllers
{
    public class HomeController : Controller
    {
        EmpolyeeDBEntities db=new EmpolyeeDBEntities();
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid==true)
            {
                db.Employees.Add(e);
               int a= db.SaveChanges();
               if (a>0)
               {
                   return Json("Data inserted!");  //Javascript object notation.
               }
               else
               {
                   return Json("Data not inserted!");
                }
            }
            return View();
        }
    }
}