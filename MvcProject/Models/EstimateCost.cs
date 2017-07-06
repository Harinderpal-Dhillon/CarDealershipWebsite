using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class EstimateCost:IEntity
    {
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Display(Name = "Estimate Cost")]
        public string Cost { get; set; }

        public void SetFields(DataRow dt)
        {
            Model = (string)dt["Model"];
            Make = (string)dt["MakeType"];
            Cost = (string)dt["EstimateCost"];


        }
    }
}