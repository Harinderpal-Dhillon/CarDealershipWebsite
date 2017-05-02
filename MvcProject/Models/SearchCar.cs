using MvcProject.Data;
using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class SearchCar:IEntity
    {
        //[Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Make")]
        public string Make { get; set; }

        //[Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        //[Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        //[Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

        #region IEntity members
        
        #endregion


        public void SetFields(DataRow dt)
        {
            Id = (int)dt["Id"];
            Make = (string)dt["Make"];
            Model = (string)dt["Model"];
            Year = (int)dt["Year"];
            Price = (double)dt["Price"];
            //throw new NotImplementedException();
        }
    }
}