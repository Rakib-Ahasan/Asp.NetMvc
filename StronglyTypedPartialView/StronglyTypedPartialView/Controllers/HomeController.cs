using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StronglyTypedPartialView.Models;

namespace StronglyTypedPartialView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        List<Product> productsList=new List<Product>()
        {
            new Product{Id = 1,Name = "Rebook Shoes",Price = 1000.00,Picture ="~/Images/74482227_396023667948201_41130595396354048_n.jpg" },
            new Product{Id = 2,Name = "Sunglasses",Price = 500.00,Picture ="~/Images/76720789_421981498752581_9068861073712480256_n.jpg" },
            new Product{Id = 3,Name = "Watch",Price = 10000.00,Picture ="~/Images/78797524_2373385236105032_8905184899468623872_o.jpg" }
        };
        public ActionResult Index()
        {
            return View(productsList);
        }
    }
}