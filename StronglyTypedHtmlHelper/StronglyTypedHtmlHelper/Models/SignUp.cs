using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StronglyTypedHtmlHelper.Models
{
    public class SignUp
    {
        public int UserId{ get; set; }
        public string Username{ get; set; }
        public string Password{ get; set; }
        public string Gender{ get; set; }
        public string Email{ get; set; }
        public string Comment{ get; set; }
    }
}