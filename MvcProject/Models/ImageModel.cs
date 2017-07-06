using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class ImageModel:IEntity
    {
        [Display(Name = "Car Picture")]
        public HttpPostedFileBase ImageFile { get; set; }

        public Byte[] ImageData { get; set; }

        public string Type { get; set; }

       


        public void SetFields(DataRow dt)
        {
            ImageData = (Byte[])dt["Image"];
            Type = (string)dt["Type"];
           // throw new NotImplementedException();
        }
    }
}