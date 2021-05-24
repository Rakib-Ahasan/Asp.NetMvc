using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryDataTableMVC.Controllers
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
    }
}