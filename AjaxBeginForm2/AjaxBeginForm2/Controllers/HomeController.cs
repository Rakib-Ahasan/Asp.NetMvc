using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxBeginForm2.Models;

namespace AjaxBeginForm2.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string q)
        {
            if (string.IsNullOrEmpty(q)==false)
            {
                List<Employee> emp = db.Employees.Where(model => model.name.StartsWith(q)).ToList();
                return PartialView("_SearchData", emp);
            }
            else
            {
                List<Employee> emp = db.Employees.ToList();
                return PartialView("_SearchData", emp);
            }
            return View();
        }
    }
}