using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadingAndRetrivingImages.Models;

namespace UploadingAndRetrivingImages.Controllers
{
    public class HomeController : Controller
    {
        NewDBEntities db=new NewDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            //fileName is going to folder.
            string fileName = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
            string extension = Path.GetExtension(s.ImageFile.FileName);
            HttpPostedFileBase postedFile = s.ImageFile;
            int length = postedFile.ContentLength;
            if (extension.ToLower()==".jpg" || extension.ToLower() == ".png"|| extension.ToLower() ==".jpeg")
            {
                if (length<=1000000)
                {
                    fileName = fileName + extension;

                    //image_path is going to database.
                    //"~" symbol is use for instigate my project.
                    s.image_path = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);


                    s.ImageFile.SaveAs(fileName);
                    db.Students.Add(s);
                    int a = db.SaveChanges();

                    if (a > 0)
                    {
                        ViewBag.Message = "<script>alert('Record Inserted Successfully!!')</script>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "<script>alert('Record Not Inserted !!')</script>";
                    }
                }
                else
                {
                    ViewBag.SizeMessage = "<script>alert('Size Should be of 1 MB or less!!')</script>";
                }
            }
            else
            {
                ViewBag.ExtensionMessage = "<script>alert('Image Not Supported !!')</script>";
            }
            
            return View();
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