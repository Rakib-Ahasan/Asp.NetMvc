using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewDataInAsp.Net.Models;

namespace ViewDataInAsp.Net.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Message"] = "Message from view data!!";
            ViewData["CurrentTime"] = DateTime.Now.ToShortTimeString();

            string[] Fruits = {"apple", "banana", "Grapes", "Orange"};
            ViewData["FruitsArray"] = Fruits;

            ViewData["SportsList"] =new List<string>()
            {
                "Cricket",
                "Hockey",
                "Football",
                "Volley"
            };

            Employee employee=new Employee();
            employee.EmpId = 101;
            employee.EmpName = "Rakib Ahasan";
            employee.EmpDesignation = "CEO";

            ViewData["Employee"] = employee;
            return View();
        }
    }
}