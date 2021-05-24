using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxLoadMoreInMvc.Models;

namespace AjaxLoadMoreInMvc.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            int num = 5;
            Session["data"] = num;
            var data = db.Employees.ToList().Take(num);
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(Employee e)
        {
            int rows = Convert.ToInt32(Session["data"]) + 5;
            var data = db.Employees.ToList().Take(rows);
            Session["data"] = rows;
            return PartialView("_EmpData", data);
        }
    }
}