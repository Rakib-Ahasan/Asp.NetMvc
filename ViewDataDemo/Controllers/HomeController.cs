using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewDataDemo.Models;

namespace ViewDataDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Message"] = "Message from view data.";
            ViewData["CurrentTime"] = DateTime.Now.ToLongTimeString();

            string[] Fruits = {"Apple", "Banana", "Mango", "Orange"};
            ViewData["FruitsArray"] = Fruits;
            ViewData["SportsList"]=new List<string>()
            {
                "Cricket",
                "Hockey",
                "Football",
                "Volleyball"
            };
            Employee Rakib=new Employee();
            Rakib.Id = 11;
            Rakib.Name = "Rakib Ahasan";
            Rakib.Designation = "Owner";
            ViewData["employee"] = Rakib;
            
            return View();
        }
    }
}