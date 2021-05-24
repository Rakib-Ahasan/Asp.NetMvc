using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AuthorizeFilterInMvc.Models;

namespace AuthorizeFilterInMvc.Controllers
{
    public class LoginController : Controller
    {
        LoginDBEntities db=new LoginDBEntities();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(User u,string returnUrl)
        {
            if (IsValid(u)==true)
            {
                FormsAuthentication.SetAuthCookie(u.username,false);
                Session["username"] = u.username.ToString();
                if (returnUrl!=null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
           
        }

        public bool IsValid(User u)
        {
            var credentials = db.Users.FirstOrDefault(model => model.username == u.username && model.password == u.password);

            if (credentials!=null)
            {
                return (u.username == credentials.username && u.password == credentials.password);
            }
            else
            {
                return false;
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}