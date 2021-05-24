using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleModelDataInAsingleView.Models
{
    public class MultiModelData
    {
        public List<Student> MyStudents { get; set; }
        public List<Teacher> MyTeachers { get; set; }
    }
}