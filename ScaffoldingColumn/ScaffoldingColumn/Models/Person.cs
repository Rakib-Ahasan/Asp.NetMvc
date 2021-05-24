using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ScaffoldingColumn.Models
{
    public class Person
    {
        public string Name{ get; set; }
        public string Gender{ get; set; }
        public string Age{ get; set; }

        [ScaffoldColumn(false)]
        public string Contact{ get; set; }
        [ScaffoldColumn(false)]
        public string Address{ get; set; }
    }
}