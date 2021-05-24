using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotationsAndRequiredDataAnnotation.Models
{
    public class Employee
    {
        [DisplayName("Employee Id")]
        [Required(ErrorMessage = "Id is mandatory")]
        public int Id{ get; set; }
        [DisplayName("Employee Name")]
        [Required (ErrorMessage = "Name Is mandatory")]
        [StringLength(maximumLength:20,MinimumLength = 3,ErrorMessage = "Name should be in between 3-20 letter.")]
        public string Name{ get; set; }
        [DisplayName("Employee Age")]
        [Required(ErrorMessage = "Age Is mandatory")]
        [Range(20,60,ErrorMessage = "Age should be 20-60.")]
        public int? Age{ get; set; }
        [DisplayName("Employee Gender")]
        [Required(ErrorMessage = "Gender Is mandatory")]
        public string Gender{ get; set; }
        [DisplayName("Employee Email")]
        [Required(ErrorMessage = "Email Is mandatory")]
        [RegularExpression(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$",ErrorMessage = "Invalid Email!")]
        public string Email{ get; set; }
        [DisplayName("Employee Password")]
        [Required(ErrorMessage = "Password Is mandatory")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",ErrorMessage = "Password must be 8 char in alphabet number and symbol ")]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [DisplayName("Employee Confirm Password")]
        [Required(ErrorMessage = "Confirm password Is mandatory")]
        [Compare("Password",ErrorMessage = "Password dose not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword{ get; set; }

        [DisplayName("Employee Organization")]
        [ReadOnly(true)]
        public string EmployeeOrganizationName{ get; set; }
        [DisplayName("Employee Address")]
        [Required(ErrorMessage = "Address is mandatory")]
        [DataType(DataType.MultilineText)]
        public string Address{ get; set; }
        [DisplayName("Employee Joining Date")]
        [Required(ErrorMessage = "Date is mandatory")]
        [DataType(DataType.Date)]
        public string JoiningDate{ get; set; }

        [DisplayName("Employee Joining Time")]
        [Required(ErrorMessage = "Time is mandatory")]
        [DataType(DataType.Time)]
        public string JoiningTime{ get; set; }
    }
}