using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxHelper2InMVC.Models;

namespace AjaxHelper2InMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Employees.ToList());

        }
        [HttpPost]
        public ActionResult Index(string q)
        {
            if (string.IsNullOrEmpty(q)==false)
            {
                List<Employee> emp = db.Employees.Where(x => x.name.StartsWith(q)).ToList();
                return PartialView("_SearchData", emp);
            }
            else
            {
                List<Employee> emp = db.Employees.ToList();
                return PartialView("_SearchData", emp);
            }

           

        }
    }
}