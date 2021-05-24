using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StronglyTypedViewInMVC.Models;

namespace StronglyTypedViewInMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Employee employee=new Employee();
            employee.Id = 101;
            employee.Name = "Rakib Ahasan";
            employee.Age = 25;

            Employee employee1=new Employee();
            employee1.Id = 102;
            employee1.Name = "Sagor Ali";
            employee1.Age = 26;

            Employee employee2=new Employee();
            employee2.Id = 103;
            employee2.Name = "Jamal Uddin";
            employee2.Age = 27;

            List<Employee> employeeList=new List<Employee>();
            employeeList.Add(employee);
            employeeList.Add(employee1);
            employeeList.Add(employee2);

            ViewData["Var1"] = employee;
            ViewBag.Var2 = employee;
            return View(employeeList);
        }
    }
}