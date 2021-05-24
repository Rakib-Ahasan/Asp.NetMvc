using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OutputCacheFilter.Controllers
{
    public class HomeController : Controller
    {
        private PersonDBEntities db = new PersonDBEntities();
        // GET: Home
        [OutputCache(Duration = 10,Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index() 
        {
            ViewBag.Time = DateTime.Now.ToLongTimeString();//1:53:40
            return View();
        }

        [OutputCache(Duration = 40)]
        public ActionResult GetData()
        {
            var data = db.People.ToList();
            return View(data);
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