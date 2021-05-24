using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EfCodeFirstApproach.Models;

namespace EfCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        StudentDbContext db=new StudentDbContext();
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
                    //ViewBag.InsertMessage = "<script>alert('Data inserted!')</script>";
                    //TempData["InsertMessage"] = "<script>alert('Data inserted!')</script>";
                    TempData["InsertMessage"] = "Data inserted!";
                    //ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data not inserted!')</script>";
                }
            }
           
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Students.FirstOrDefault(model => model.Id==id);
            db.Students.Add(row);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid==true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "Data Updated!";
                    //ViewBag.UpdateMessage = "<script>alert('Data updated!')</script>";
                    //ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data not updated!')</script>";
                }
            }
           
            return View();
        }

        ///*Another approach for delete*/
        //public ActionResult Delete(int id)
        //{
        //    if (id>0)
        //    {
        //        var StudentIdRow = db.Students.FirstOrDefault(model => model.Id == id);
        //        if (StudentIdRow!=null)
        //        {
        //            db.Entry(StudentIdRow).State = EntityState.Deleted;
        //            int a = db.SaveChanges();
        //            if (a > 0)
        //            {
        //                //ViewBag.DeleteMessage = "<script>alert('Data deleted!')</script>";
        //                TempData["DeleteMessage"] = "Data Deleted!";
        //            }
        //            else
        //            {
        //                ViewBag.DeleteMessage = "<script>alert('Data not deleted!')</script>";
        //            }
        //        }
        //    }
            
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int id)
        {
            var StudentIdRow = db.Students.FirstOrDefault(model => model.Id == id);
            return View(StudentIdRow);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a=db.SaveChanges();
            if (a>0)
            {
                //ViewBag.DeleteMessage = "<script>alert('Data deleted!')</script>";
                TempData["DeleteMessage"] = "Data Deleted!";
            }
            else
            {
                ViewBag.DeleteMessage = "<script>alert('Data not deleted!')</script>";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var DetailsById = db.Students.FirstOrDefault(model => model.Id == id);

            return View(DetailsById);
        }
    }
}