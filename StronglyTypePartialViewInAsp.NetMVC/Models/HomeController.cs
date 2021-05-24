using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StronglyTypePartialViewInAsp.NetMVC.Models
{
    public class HomeController : Controller
    {
        // GET: Home

        List<Product>productsList=new List<Product>()
        {
            new Product{Id = 1,Name = "Rebook Shoes",Price = 10000,Picture ="~/Images/68272839_490970644815698_5833767087889186816_n.jpg" },
            new Product{Id = 2,Name = "Boss Top",Price = 13000,Picture ="~/Images/69987076_435342687013925_8871534273086095360_n.jpg" },
            new Product{Id = 3,Name = "Gentleman",Price = 15000,Picture ="~/Images/70133944_720334025154585_1613030111097913344_n.jpg" },
        };
        public ActionResult Index()
        {
            return View(productsList);
        }

    }
}