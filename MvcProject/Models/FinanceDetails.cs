using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class FinanceDetails:IEntity
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

       [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [Display(Name = "SSN")]
        public string SSN { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Zip")]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Monthly Income")]
        public int Income { get; set; }

        [Required]
        [Display(Name = "Employed")]
        public string Employed { get; set; }

        [Required]
        [Display(Name = "Additional Income")]
        public int AdditionalIncome { get; set; }

        [Required]
        [Display(Name = "From Year")]
        public int FromYear { get; set; }

        [Required]
        [Display(Name = "To Year")]
        public int ToYear { get; set; }

        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Available Down Payment")]
        public double AvailableDownPayment { get; set; }

        [Required]
        [Display(Name = "Desired Monthly Payment")]
        public double DesiredMonthlyPayment { get; set; }

        public string Status { get; set; }

        public void SetFields(DataRow dt)
        {

            Username = (string)dt["Username"];
            Firstname = (string)dt["Firstname"];
            Lastname = (string)dt["Lastname"];
            Gender = (string)dt["Gender"];
            Phone = (string)dt["Phone"];
            Email = (string)dt["Email"];
            SSN = (string)dt["SSN"];
            City = (string)dt["City"];
            State = (string)dt["State"];
            Country = (string)dt["Country"];
            Zip = (string)dt["Zip"];
            Income = (int)dt["MonthlyIncome"];
            AdditionalIncome = (int)dt["AdditionalIncome"];
            Employed = (string)dt["Employed"];
            FromYear=(int)dt["FromYear"];
            ToYear=(int)dt["ToYear"];
            Make = (string)dt["Make"];
            Model = (string)dt["Model"];
            Stock = (int)dt["Stock"];
            AvailableDownPayment = (float)dt["AvailableDownPayment"];
            DesiredMonthlyPayment = (float)dt["DesiredMonthlyPayment"];




        }
    }
}