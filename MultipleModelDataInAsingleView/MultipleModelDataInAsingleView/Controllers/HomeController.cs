using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultipleModelDataInAsingleView.Models;

namespace MultipleModelDataInAsingleView.Controllers
{
    public class HomeController : Controller
    {
        SchoolDBEntities db=new SchoolDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            //var std = GetStudents();
            //var tchr = GeTeachers();
            //MultiModelData data=new MultiModelData();
            //data.MyStudents=std;
            //data.MyTeachers = tchr;
           // return View(data);
           //ViewBag.student = std;
           //ViewBag.teacher = tchr; 
           return View();

        }

        public PartialViewResult students()
        {
            var std = GetStudents();
            return PartialView("_students", std);
        }

        public PartialViewResult teachers()
        {
            var tchr = GeTeachers();
            return PartialView("_teachers", tchr);
        }
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public List<Teacher> GeTeachers()
        {
            return db.Teachers.ToList();
        }
    }
}