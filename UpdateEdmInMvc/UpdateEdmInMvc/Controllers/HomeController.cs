using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpdateEdmInMvc.Models;

namespace UpdateEdmInMvc.Controllers
{
    public class HomeController : Controller
    {
        EdmExampleMVCEntities db=new EdmExampleMVCEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Employee()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}