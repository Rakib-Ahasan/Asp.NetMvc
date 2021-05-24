using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MultipleDataInAsingleViewInMVC.Models
{
    public class MultiModelData
    {
        public List<Student> myStudents{ get; set; }
        public List<Teacher> MyTeachers{ get; set; }
    }
}