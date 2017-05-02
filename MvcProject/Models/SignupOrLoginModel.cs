using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class SignupOrLoginModel
    {
       
            public Login login { get; set; }
            public SignUp signUp { get; set; }
            public SearchCar sCar { get; set; }

        public SignupOrLoginModel()
         {
            Login login= new Login();
            SignUp signUp = new SignUp();
            SearchCar sCar = new SearchCar();
        }
       
    }
}