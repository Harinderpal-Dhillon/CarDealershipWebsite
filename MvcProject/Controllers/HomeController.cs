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

        public ActionResult Gallery()
         {
             List<GalleryModel> galleryM = new List<GalleryModel>();
             galleryM = iBusinessCar.CarGallery();
             AdminModel  aM=new AdminModel();
             aM.gModel = galleryM;
             return View(aM);
        }

        [HttpPost]
        public ActionResult HomePage(SignupOrLoginModel model)
        {
            //model.login = new Login();
            //viewModel.SecondViewModel.month = 13;
           
                try
                {
              
                    if (Request.Form["btnLogin"] != null)
                    {
                        if (model.login.Username == null && model.login.Password == null)
                        {
                            model.login.Status = "Username and Password Required";
                        }
                        else
                        {
                            if (iBusiness.ValidateUser(model.login.Username, model.login.Password))
                            {
                                Session["loggedIn"] = model.login.Username;
                                model.login.Status = "User successfully logged in.";
                                if (model.login.Username == "Admin" && model.login.Password == "admin234")
                                {

                                    return RedirectToAction("AdminView", "Admin");
                                }
                            }

                            else
                                model.login.Status = "Invalid credentials.";
                        }
                    }

                     

                    else if (Request.Form["btnSignup"] != null)
                    {
                        if (model.signUp.Email == null && model.signUp.Password == null && model.signUp.ConfirmPassword == null)
                        {
                            model.login.Status = "Fill all the Fields";
                        }
                        else
                        {
                            if (model.signUp.Password == model.signUp.ConfirmPassword)
                            {
                                if (iBusiness.ValidateUsername(model.signUp.Email))
                                {
                                    model.login.Status = "Username already Exists.";
                                }
                                else
                                {
                                    int row = iBusiness.Register(model.signUp.Email, model.signUp.Password, model.signUp.ConfirmPassword);
                                    if (row != 0)
                                    {
                                        model.login.Status = "You are successfully registered.";
                                    }
                                }
                            }
                            else
                            {
                                model.login.Status = "Password doesnot match with the Confirm Password field";
                            }
                        }
                    }
                    return View(model);
                }
                catch
                {
                    throw;
                }

            }
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
    

