using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class Appointment:IEntity
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public int Phone { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public string Status { get; set; }

        public void SetFields(DataRow dt)
        {
            Id = (int)dt["ID"];
            Username = (string)dt["Username"];
            Email = (string)dt["Email"];
            Phone = (int)dt["Phone"];
            Comment=(string)dt["Comment"];




        }
    }
}