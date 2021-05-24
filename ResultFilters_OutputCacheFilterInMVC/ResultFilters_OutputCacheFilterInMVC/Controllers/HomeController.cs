using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultFilters_OutputCacheFilterInMVC.Controllers
{
    public class HomeController : Controller
    {
        PercentDBEntities db = new PercentDBEntities();
        // GET: Home
        [OutputCache(Duration =10,Location =System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            ViewBag.Time = DateTime.Now.ToLongTimeString();
            return View();
        }
        [OutputCache(Duration =40)]
        public ActionResult GetData()
        {
            var data = db.People.ToList();
            return View(data);
        }
    }
}