using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetailsInMVC.Models
{
    public class Purchase
    {
        public long id{ get; set; }
        public string CustomerName{ get; set; }
        public string CustomerContactNo{ get; set; }
        public string Description{ get; set; }
        public DateTime PurchaseDate{ get; set; }
    }
}