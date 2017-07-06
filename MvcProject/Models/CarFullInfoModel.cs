using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class CarFullInfoModel:IEntity
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        //[Required]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Display(Name = "Make Id")]
        public int MakeId { get; set; }


        //[Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        //[Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        //[Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

        //[Required]
        [Display(Name = "Body Type")]
        public string BodyStyle { get; set; }

        //[Required]
        [Display(Name = "Mileage")]
        public string Mileage { get; set; }

        [Display(Name = "Car Category Id")]
        public int CarCatId { get; set; }
        
        #region IEntity members

        #endregion


        public void SetFields(DataRow dt)
        {
            Id = (int)dt["Id"];
            MakeId = (int)dt["MakeId"];
            Make = (string)dt["MakeType"];
            Model = (string)dt["Model"];
            Year = (int)dt["Year"];
            Price = (double)dt["Price"];
            BodyStyle = (string)dt["BodyStyle"];
            Mileage = (string)dt["Mileage"];
            CarCatId = (int)dt["CarCatId"];
            //throw new NotImplementedException();
        }
    }
}