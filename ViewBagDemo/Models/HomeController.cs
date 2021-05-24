using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewBagDemo.Models;

namespace ViewBagDemo.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Message from view bag.";
            ViewBag.CurrentDate = DateTime.Now.ToLongDateString();
            string[] Fruits = {"Apple", "Banana", "Mango", "Orange"};
            ViewBag.fruitsArray = Fruits; 
            ViewBag.sports=new List<string>()
            {
                "Cricket",
                "Football",
                "Hockey",
                "Kabadi"
            };
            Employee employee=new Employee();
            employee.Id = 11;
            employee.Name = "Rakib";
            employee.Designation = "manager";
            ViewBag.Employee = employee;


            return View();
        }
    }
}