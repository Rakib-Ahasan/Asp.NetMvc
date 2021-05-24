using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StronglyTypedHtmlInAsp.NetMVC.Models
{
    public class SignUp
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Password{ get; set; }
        public string Gender{ get; set; }
        public string Email{ get; set; }
        public string Comment{ get; set; }
    }
}