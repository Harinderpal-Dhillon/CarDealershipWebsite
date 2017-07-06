using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class CarCategory:IEntity
    {
        [Required]
        [Display(Name = "catId")]
        public int catId { get; set; }

        [Required]
        [Display(Name = "catName")]
        public string catName { get; set; }

        

        public void SetFields(DataRow dt)
        {
            catId = (int)dt["CategoryId"];
            catName = (string)dt["CategoryName"];
            


        }
    }
}