using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotationInMVC.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Id is mandatory!")]
        [DisplayName("Id")]
        public int EmployeeId{ get; set; }

        [Required(ErrorMessage = "Name is mandatory!")]
        [DisplayName("Name")]
        [StringLength(20,MinimumLength =5,ErrorMessage = "Name should be 5-20 character allowed.")]
        public string EmployeeName{ get; set; }

        //? this symbol means its allow to nullable.
        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is mandatory!")]
        [Range(20,60,ErrorMessage = "EmployeeAge must be between 20 and 60")]
        public int? EmployeeAge{ get; set; }

        [Required(ErrorMessage = "Gender is mandatory!")]
        [DisplayName("Gender")]
        public string EmployeeGender{ get; set; }

        [Required(ErrorMessage = "Email is mandatory!")]
        [DisplayName("Email")]
        [RegularExpression(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$",ErrorMessage = "Email is not correct format!")]
        public string EmployeeEmail{ get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Employee password is mandatory!")]
        [RegularExpression("^(?!.*([A-Za-z0-9]))(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,15}$",ErrorMessage = "Password Length 8 and Maximum 15 character,Require Unique Chars,Require Digit,Require Lower Case, Require Upper Case!")]
        [DataType(DataType.Password)]
        public string EmployeePassword{ get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Employee password is mandatory!")]
        [Compare("EmployeePassword",ErrorMessage = "Password dose not match!")]
        public string EmployeeConfirmPassword { get; set; }

        [DisplayName("Organization Name")]
        [ReadOnly(true)]
        public string EmployeeOrganizationName{ get; set; }

        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Address is mandatory!")]
        public string EmployeeAddress{ get; set; }

        [DisplayName("Joining Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is mandatory!")]
        public string EmployeeJoiningDate{ get; set; }

        [DisplayName("Joining Time")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Time is mandatory!")]
        public string EmployeeJoiningTime { get; set; }
    }
}