using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudApplication.Models;

namespace CrudApplication.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDbContext db=new EmployeeDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }

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
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "Data inserted!";
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
            var row = db.Employees.FirstOrDefault(model => model.EmployeeId == id);
            db.Employees.Add(row);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid==true)
            {
                db.Entry(e).State = EntityState.Modified;
                int a=db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "Data Updated!";
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data not updated!')</script>";
                }

            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var detailsById = db.Employees.FirstOrDefault(model => model.EmployeeId == id);
            return View(detailsById);
        }
       

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var EmployeeIdRow = db.Employees.FirstOrDefault(model => model.EmployeeId == id);
                if (EmployeeIdRow != null)
                {
                    db.Entry(EmployeeIdRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        //ViewBag.DeleteMessage = "<script>alert('Data deleted!')</script>";
                        TempData["DeleteMessage"] = "Data Deleted!";
                    }
                    else
                    {
                        ViewBag.DeleteMessage = "<script>alert('Data not deleted!')</script>";
                    }
                }
            }

            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public ActionResult Delete(Employee e)
        //{
        //    db.Entry(e).State = EntityState.Deleted;
        //    int a = db.SaveChanges();
        //    if (a > 0)
        //    {
        //        TempData["DeleteMessage"] = "Data Deleted!";
        //    }
        //    else
        //    {
        //        ViewBag.DeleteMessage = "<script>alert('Data not deleted!')</script>";
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}