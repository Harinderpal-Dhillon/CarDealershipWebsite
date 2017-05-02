using MvcProject.Business;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private IBusinessAuthenticate iBusiness = null;
        private IBusinessCar iBusinessCar = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            iBusiness = new BusinessAuthenticate();
            iBusinessCar = new BusinessCar();
            base.Initialize(requestContext);
        }

        
        public ActionResult HomePage()
        {
            SignupOrLoginModel model = new SignupOrLoginModel();
            return View(model);
        }

       
        [HttpPost]
        public ActionResult HomePage(SignupOrLoginModel model)
        {
            //model.login = new Login();
            //viewModel.SecondViewModel.month = 13;
          // if (ModelState.IsValid)
            try
            {
                if (Request.Form["btnLogin"] != null)
                {
                    if (iBusiness.ValidateUser(model.login.Username, model.login.Password))
                    {
                        Session["loggedIn"] = model.login.Username;
                        model.login.Status = "User successfully logged in.";
                    }
                    else
                        model.login.Status = "Invalid credentials.";
                }

                else if (Request.Form["btnSignup"] != null)
                {
                    int row = iBusiness.Register(model.signUp.Email, model.signUp.Password, model.signUp.ConfirmPassword);
                    if (row != 0)
                    {
                        model.login.Status = "You are successfully registered.";
                    }
                }
                return View(model);
            }
            catch
            {
                throw;
            }
           
        }

        //public ActionResult Registration()
        //{
        //    SignupOrLoginModel model1 = new SignupOrLoginModel();
        //    return View(model1);
        //}

        
        //public ActionResult Registration(SignupOrLoginModel model1)
        //{
        //    int row = iBusiness.Register(model1.signUp.Email, model1.signUp.Password, model1.signUp.ConfirmPassword);
        //    if(row!=0)
        //    {
        //        model1.login.Status = "You are successfully registered.";
        //    }
            
        //    return View(model1);
        //}
    }
}
