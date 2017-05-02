using MvcProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class SignUp
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        //public void SetFeilds(DataRow dataRow)
        //{
        //    Email = (string)dataRow["Email"];
        //    Password = (string)dataRow["Password"];
        //    ConfirmPassword = (string)dataRow["ConfirmPassword"];
            

        //}
    }
}