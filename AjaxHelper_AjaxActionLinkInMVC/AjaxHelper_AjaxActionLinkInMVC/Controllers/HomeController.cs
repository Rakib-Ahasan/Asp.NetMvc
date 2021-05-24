using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxHelper_AjaxActionLinkInMVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult AllEmployees()
        {
            var data = db.Employees.ToList();
            return PartialView("_Employees",data);
        }
        public ActionResult Top3Emp()
        {
            var data = db.Employees.OrderByDescending(x => x.salary).Take(3).ToList();
            return PartialView("_Employees", data);
        }

        public ActionResult Buttom3Emp()
        {

            var data = db.Employees.OrderBy(x => x.salary).Take(3).ToList();
            return PartialView("_Employees", data);
        }

    }
}