using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurdApplicationUsingLinqToSql.Models;

namespace CurdApplicationUsingLinqToSql.Controllers
{
    public class HomeController : Controller
    {
        StudentDbDataContext db = new StudentDbDataContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
       
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            db.Students.InsertOnSubmit(s);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var student = db.Students.Single(m => m.Id == id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(int id,Student s)
        {
            Student student = db.Students.Single(m => m.Id == id);
            student.Name = s.Name;
            student.Gender = s.Gender;
            student.Age = s.Age;
            student.Standard = s.Standard;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var student = db.Students.Single(m => m.Id == id);
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            var student = db.Students.Single(m => m.Id == id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(int id,Student s)
        {
            Student student = db.Students.Single(m => m.Id == id);
            db.Students.DeleteOnSubmit(student);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}