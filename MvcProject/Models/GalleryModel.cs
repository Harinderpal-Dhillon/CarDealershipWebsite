using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class GalleryModel:IEntity
    {
        

        public Byte[] ImageData { get; set; }

        public string Type { get; set; }

        [Display(Name = "Make")]
        public string Make { get; set; }

        [Required]
        [Display(Name = "catName")]
        public string carModel { get; set; }

        public void SetFields(DataRow dt)
        {
            ImageData = (Byte[])dt["Image"];
            Type = (string)dt["Type"];
            Make=(string)dt["MakeType"];
            carModel = (string)dt["Model"];

            // throw new NotImplementedException();
        }
    }
}