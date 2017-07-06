using MvcProject.Business;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        private IBusinessCar iBusiness = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            iBusiness = new BusinessCar();

            base.Initialize(requestContext);
        }
        public ActionResult AdminView()
        {
            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
            AdminModel model = new AdminModel();
           // CarResultsModel model = new CarResultsModel();
            model.maketypes = carM;
                   
            List<CarCategory> Cat = iBusiness.CarCat();
            model.carCat = Cat;
            return View(model);
        }

        public ActionResult UpdateCar()
        {
            
            return View();
        }

        public ActionResult DeleteCar()
        {
            AdminModel model = new AdminModel();
            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
            model.maketypes = carM;

            List<CarCategory> Cat = iBusiness.CarCat();
            model.carCat = Cat;
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteCar(AdminModel model)
        {
            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
            model.maketypes = carM;

            List<CarCategory> Cat = iBusiness.CarCat();
            model.carCat = Cat;

            string make = Request.Form["maketypes"].ToString();
            model.maketypes1 = new CarMakeModel();
            model.carDetails1 = new CarFullInfoModel();
            model.maketypes1.Make = make;
            string cModel = Request.Form["ddlModel"].ToString();
            model.carDetails1.Model = cModel;

            if(iBusiness.DeleteCar(model))
            {
                model.Status = "Delete Successful";
            }

            else
            {
                model.Status = "Failed to delete";
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AdminView(AdminModel model)
        {
            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
            //AdminModel model = new AdminModel();
            // CarResultsModel model = new CarResultsModel();
            model.maketypes = carM;

            List<CarCategory> Cat = iBusiness.CarCat();
            model.carCat = Cat;
            
            // when you fetch carCat
            int catID = Convert.ToInt32(Request.Form["carCat"]);
            model.carCat1 = new CarCategory();
            model.carCat1.catId = catID;
            //if (ModelState.IsValid)
            if (model.maketypes1.Make == null && model.carDetails1.Model == null && model.carDetails1.Year == 0 && model.carDetails1.Price == 0.0 && model.carDetails1.Mileage == null)
            {
                model.Status = "Fill all of the Fields above in the form";
            }
            else
            {
                
                {
                    if (iBusiness.AddNewCar(model))
                    {
                        ModelState.Clear();
                        model.Status = "Car information has been added successfully.";

                    }
                    else
                        model.Status = "Car could not be added.";
                }
                
            }
            return View(model);
        }
        public ActionResult CarModel(string value)
        {


            List<SearchCar> carsList = null;
            //value = Request.Form["ddlMake"].ToString();

            carsList = iBusiness.Cars(value);
            // CarResultsModel model = new CarResultsModel();
            //carModel.sCar = carsList;
            SelectList objList = new SelectList(carsList, "Id", "Model", 0);

            return Json(objList);
        }

        //public ActionResult CarDetails()
        //{
        //    //List<CarMakeModel> carM = null;
        //    //carM = iBusiness.CarMake();
        //    //AdminModel model = new AdminModel();
        //    //model.maketypes=carM;
            
        //    //return PartialView(model);
        //}

    }
}
