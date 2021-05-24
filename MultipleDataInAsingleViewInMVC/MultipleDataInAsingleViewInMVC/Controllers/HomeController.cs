using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultipleDataInAsingleViewInMVC.Models;

namespace MultipleDataInAsingleViewInMVC.Controllers
{
    public class HomeController : Controller
    {
        SchoolDBEntities db=new SchoolDBEntities(); 
        // GET: Home
        public ActionResult Index()
        {
            var std = GetStudents();
            var tchr = GetTeachers();
            
            //MultiModelData data=new MultiModelData();
            //data.myStudents = std;
            //data.MyTeachers = tchr;
            //return View(data);

            //ViewBag.student = std;
            //ViewBag.teacher = tchr;

            //ViewData["student"] = std;
            //ViewData["teacher"] = tchr;
            return View();
        }

        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        } 
        public List<Teacher> GetTeachers()
        {
            return db.Teachers.ToList();
        }

        public PartialViewResult Students()
        {
            var std = GetStudents();
            return PartialView("_student", std);
        } 
        public PartialViewResult Teachers()
        {
            var tchr = GetTeachers();
            return PartialView("_teacher", tchr);
        }
    }
}