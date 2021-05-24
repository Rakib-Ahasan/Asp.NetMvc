using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimilaritiesAndDifferencesBetweenViewBagAndViewData.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Message1"] = "Data comes form ViewData";
            ViewBag.Message2 = "Data form ViewBag";

            ViewData["CurrentDate1"] = DateTime.Now.ToString();
            ViewBag.CurrentDate2 = DateTime.Now.ToString();

            string[] games = {"Hockey", "Cricket", "BaseBall", "Football"};

            ViewData["Game1"] = games;
            ViewBag.Game2 = games;
            return View();
        }
    }
}