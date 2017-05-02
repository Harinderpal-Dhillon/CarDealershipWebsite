using MvcProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Status { get; set; }

        //public void SetFeilds(DataRow dataRow)
        //{
        //    Username = (string)dataRow["Username"];
        //    Password = (string)dataRow["Password"];
          

        //}
    }
}