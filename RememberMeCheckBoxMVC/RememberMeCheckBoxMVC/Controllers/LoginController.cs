using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RememberMeCheckBoxMVC.Models;


namespace RememberMeCheckBoxMVC.Controllers
{
    public class LoginController : Controller
    {
        LoginDBEntities db=new LoginDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["User"];
            if (cookie!=null)
            {
                ViewBag.username = cookie["Username"].ToString();
                string EncryptedPassword = cookie["Password"].ToString();
                byte[] b = Convert.FromBase64String(EncryptedPassword);
                string decryptedPassword = ASCIIEncoding.ASCII.GetString(b);
                ViewBag.password = decryptedPassword;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            HttpCookie cookie = new HttpCookie("User");
            if (ModelState.IsValid==true)
            {
                if (u.RememberMe==true)
                {
                    
                    cookie["Username"] = u.Username;
                    byte[] b = ASCIIEncoding.ASCII.GetBytes(u.Password);
                    string EncryptedPassword = Convert.ToBase64String(b);
                    //cookie["Password"] = u.Password;
                    cookie["Password"] = EncryptedPassword;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }

                var row = db.Users.FirstOrDefault(model => model.Username == u.Username && model.Password == u.Password);
                if (row!=null)
                {
                    Session["Username"] = u.Username;
                    TempData["Message"] = "<script>alert('Login Successful!!')</script>";
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["Message"] = "<script>alert('Login Failed!!')</script>";
                }
            }
            return View();
        }
    }
}