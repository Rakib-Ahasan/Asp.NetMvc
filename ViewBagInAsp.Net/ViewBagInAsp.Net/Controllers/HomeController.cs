using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewBagInAsp.Net.Models;

namespace ViewBagInAsp.Net.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Hello I am from view bag!!";
            ViewBag.CurrentDate = DateTime.Now.ToLongDateString();
            string[] fruits = {"apple", "banana", "grape", "orange"};
            ViewBag.FruitsArray = fruits;

            ViewBag.SportsList=new List<string>()
            {
                "Cricket",
                "Football",
                "Hockey",
                "Volley"
            };

            Employee employee=new Employee();
            employee.Id = 101;
            employee.Name = "Rakib Ahasan";
            employee.Designation = "CEO";

            ViewBag.Employee = employee;

            return View();
        }
    }
}