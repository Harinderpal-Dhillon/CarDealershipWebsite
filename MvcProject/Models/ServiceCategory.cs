using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class ServiceCategory:IEntity
    {
        //[Required]
        [Display(Name = "Id")]
        public int ServiceId { get; set; }

        //[Required]
        [Display(Name = "Category")]
        public string ServiceCategoryName { get; set; }

        [Display(Name = "ServiceName")]
        public string ServiceName { get; set; }

        public void SetFields(DataRow dt)
        {
            ServiceId = (int)dt["ServiceCatId"];
            ServiceCategoryName = (string)dt["ServiceCatName"];
            ServiceName=(string)dt["ServiceName"];

            
        }

    }
}