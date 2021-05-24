using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudApplicationWithImageInMVC.Models;

namespace CrudApplicationWithImageInMVC.Controllers
{
    public class HomeController : Controller
    {
        ExampleDBEntities db=new ExampleDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Employees.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid==true)
            {
                string fileName = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                string extension = Path.GetExtension(e.ImageFile.FileName);

                HttpPostedFileBase postedFile = e.ImageFile;

                int length = postedFile.ContentLength;

                if (extension.ToLower()==".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if (length<=1000000)
                    {
                        fileName = fileName + extension;
                        e.image_path = "~/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        e.ImageFile.SaveAs(fileName);
                        db.Employees.Add(e);
                        int a = db.SaveChanges();

                        if (a>0)
                        {
                            TempData["CreateMessage"] = "<script>alert('Data inserted successfully!!')</script>";
                            ModelState.Clear();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data not inserted!!')</script>";
                        }

                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Images size should be 1 MB or less!!')</script>";
                    }
                }
                else
                {
                    TempData["ExtensionMessage"] = "<script>alert('Image format not supported!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var employeeRow = db.Employees.FirstOrDefault(model => model.id == id);
            Session["Image"] = employeeRow.image_path;
            return View(employeeRow);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid==true)
            {
                if (e.ImageFile !=null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                    string extension = Path.GetExtension(e.ImageFile.FileName);

                    HttpPostedFileBase postedFile = e.ImageFile;

                    int length = postedFile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extension;
                            e.image_path = "~/Images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                            e.ImageFile.SaveAs(fileName);
                            db.Entry(e).State = EntityState.Modified;
                            int a = db.SaveChanges();

                            if (a > 0)
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data updated successfully!!')</script>";
                                //If i want to delete picture from Images folder which updated recently.
                                string ImagePath = Request.MapPath(Session["Image"].ToString());
                                if (System.IO.File.Exists(ImagePath))
                                {
                                    System.IO.File.Delete(ImagePath);
                                }
                                ModelState.Clear();
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data not updated!!')</script>";
                            }

                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Images size should be 1 MB or less!!')</script>";
                        }
                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Image format not supported!!')</script>";
                    }
                }
                else
                {
                    e.image_path = Session["Image"].ToString();
                    db.Entry(e).State = EntityState.Modified;
                    int a = db.SaveChanges();

                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data updated successfully!!')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            if (id>0)
            {
                var employeeRow = db.Employees.FirstOrDefault(model => model.id == id);

                if (employeeRow !=null)
                {
                    db.Entry(employeeRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a>0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data deleted successfully!!')</script>";
                        //If i want to delete picture from Images folder which deleted recently.
                        string ImagePath = Request.MapPath(employeeRow.image_path);
                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);
                        }
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data not deleted !!')</script>";
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Details(int id)
        {
            var employeeRow = db.Employees.FirstOrDefault(model => model.id == id);
            Session["Image2"] = employeeRow.image_path.ToString();
            return View(employeeRow);
        }
    }
}