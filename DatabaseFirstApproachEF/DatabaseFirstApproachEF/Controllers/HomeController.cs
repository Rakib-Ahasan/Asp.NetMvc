using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseFirstApproachEF.Models;

namespace DatabaseFirstApproachEF.Controllers
{
    public class HomeController : Controller
    {
        DbFirstEntities db=new DbFirstEntities();
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
            if (ModelState.IsValid==true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data inserted successfully!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "'Data inserted Failed!";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Students.FirstOrDefault(model => model.id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a=db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "Data updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "Data updated failed!";
                }

            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var DetailsById = db.Students.FirstOrDefault(model => model.id == id);
            return View(DetailsById);
        }

        public ActionResult Delete(int id)
        {
            var DeletedRow = db.Students.FirstOrDefault(model => model.id == id);
            return View(DeletedRow);

        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "Data deleted successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DeleteMessage"] = "Data deleted failed!";
                }

            }
            return View();
        }
    }
}