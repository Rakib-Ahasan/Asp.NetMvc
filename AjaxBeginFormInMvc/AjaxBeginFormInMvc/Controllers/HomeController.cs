using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxBeginFormInMvc.Models;

namespace AjaxBeginFormInMvc.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db=new EmployeeDBEntities();
        // GET: Home
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid==true)
            {
                db.Employees.Add(e);
                int a=db.SaveChanges();
                if (a>0)
                {
                    return JavaScript("alert('Data inserted!!')"); //JavaScript object notation.
                }
                else
                {
                    return JavaScript("alert('Data not inserted!!')");
                }

            }
            return View();
        }
    }
}