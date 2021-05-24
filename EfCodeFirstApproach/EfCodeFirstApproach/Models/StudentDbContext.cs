using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EfCodeFirstApproach.Models
{
    public class StudentDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}