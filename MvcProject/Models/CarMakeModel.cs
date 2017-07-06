using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class CarMakeModel:IEntity
    {
        [Display(Name = "Id")]
        public int MakeId { get; set; }

        [Display(Name = "Make")]
        public string Make { get; set; }

        public void SetFields(DataRow dt)
        {
            MakeId = (int)dt["MakeId"];
            Make = (string)dt["MakeType"];
           
            //throw new NotImplementedException();
        }
    }
}