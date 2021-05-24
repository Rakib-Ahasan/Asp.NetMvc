using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudApplication.Models
{
    public class Employee
    {
        [Key]
        public int  EmployeeId{ get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Time is mandatory!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name should be 5-20 character allowed.")]
        public string  EmployeeName{ get; set; }

        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Address is mandatory!")]
        public string  EmployeeAddress{ get; set; }

        [DisplayName("Contact No")]
        [Required(ErrorMessage = "Contact number is mandatory!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact number must be 11 characters allowed.")]
        public string  EmployeeContact{ get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of birth")]
        [Required(ErrorMessage = "Date of birth is mandatory!")]
        public DateTime  EmployeeDateOfBirth{ get; set; }

        [DisplayName("Payable Amount")]
        [Required(ErrorMessage = "Payable amount is mandatory!")]
        public double  EmployeePayableAmount{ get; set; }

        [DisplayName("Company Name")]
        [ReadOnly(true)]
        public string EmployeeOrganization{ get; set; }
    }
}