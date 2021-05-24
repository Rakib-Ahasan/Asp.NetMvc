using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptoinFilterMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Home

       
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        } 
        
        public ActionResult About()
        {
            return View();
        } 
       
    }
}