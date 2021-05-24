using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  StronglyTypedViewInAsp.NetMVC.Models;

namespace StronglyTypedViewInAsp.NetMVC.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Employee emp1=new Employee();
            emp1.Id = 12;
            emp1.Name = "Rakib";
            emp1.Age = 25;
            ViewData["var1"] = emp1;
            ViewBag.var2 = emp1;

            Employee emp2=new Employee();
            emp2.Id = 15;
            emp2.Name = "Khan";
            emp2.Age = 30;

            Employee emp3=new Employee();
            emp3.Id = 17;
            emp3.Name = "Ahmed";
            emp3.Age = 28;

            List<Employee> employeesList=new List<Employee>();
            employeesList.Add(emp1);
            employeesList.Add(emp2);
            employeesList.Add(emp3);
            return View(employeesList);
        }
    }
}