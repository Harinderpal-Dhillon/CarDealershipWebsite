using MvcProject.Business;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CarsController : Controller
    {
        //
        // GET: /Cars/
        private IBusinessCar iBusiness = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            iBusiness = new BusinessCar();
             
            base.Initialize(requestContext);
        }

        //public ActionResult SearchCar()
        //{
        //    SearchCar model = new SearchCar();
        //    return View(model);
        //}
        //public ActionResult SearchCar()
        //{
            
        //    //SearchCar model = new SearchCar();
        //    //return View("SearchCar");
        //}

        public ActionResult SearchForCar()
        {
            //List<SearchCar> carsList = null;
           
            //carsList = iBusiness.Cars();
            //CarResultsModel model = new CarResultsModel();
            //model.sCar = carsList;
            //return View(model);
            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
            CarResultsModel model = new CarResultsModel();
            model.carMake = carM;
            return View(model);
        }

        public ActionResult CarModelInfo(string value)
        {


            List<SearchCar> carsList = null;
           //value = Request.Form["ddlMake"].ToString();
            
            carsList = iBusiness.Cars(value);
            // CarResultsModel model = new CarResultsModel();
            //carModel.sCar = carsList;
            SelectList objList = new SelectList(carsList, "Id", "Model", 0);

            return Json(objList);
        }

        public ActionResult CarYearInfo(string value)
        {


            List<SearchCar> carsList = null;
            //value = Request.Form["ddlMake"].ToString();

            carsList = iBusiness.Cars(value);
            // CarResultsModel model = new CarResultsModel();
            //carModel.sCar = carsList;
            SelectList objList = new SelectList(carsList, "Id", "Year", 0);

            return Json(objList);
        }

        public ActionResult CarPriceInfo(string value)
        {


            List<SearchCar> carsList = null;
            //value = Request.Form["ddlMake"].ToString();

            carsList = iBusiness.Cars(value);
            // CarResultsModel model = new CarResultsModel();
            //carModel.sCar = carsList;
            SelectList objList = new SelectList(carsList, "Id", "Price", 0);

            return Json(objList);
        }

        [HttpPost]
        public ActionResult SearchForCar(CarResultsModel CarResModel)
        {
            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
            CarResModel.carMake = carM;

            //List<SearchCar> carsList = null;
            //int i = 1;
            //carsList = iBusiness.Cars();
            //CarResultsModel cmodel = new CarResultsModel();
           // CarResModel.sCar = carsList;

            //List<SearchCar> carsList = null;
            //string make = Request.Form["makeListbox"].ToString();
            //carsList = iBusiness.Cars(make);
            // CarResultsModel model = new CarResultsModel();
            //CarResModel.sCar = carsList;

            List<CarFullInfoModel> CList = null;
            //int make = Convert.ToInt32(Request.Form["makeListbox"].ToString());
            string make = Request.Form["carMake"].ToString();
            string model = Request.Form["ddlModel"].ToString();
            int year = Convert.ToInt32(Request.Form["ddlYear"]);
            double price = Convert.ToDouble(Request.Form["ddlPrice"]);
            CList = iBusiness.quickSearchResults(make, model, year, price);
            CarResModel.carInfo = CList;
            return View(CarResModel);
        }

        //[HttpPost]
        //public ActionResult SearchCar(SearchCar scar)
        //{
        //    List<SearchCar> CList = null;
        //    string make = Request.Form["makeListbox"].ToString();
        //    string model = Request.Form["modelListbox"].ToString();
        //    int year = Convert.ToInt32(Request.Form["yearListbox"]);
        //    double price = Convert.ToDouble(Request.Form["priceListbox"]);
        //    CList = iBusiness.quickSearchResults(make, model, year, price);
        //    return View(CList);
        //}
        //public ActionResult CarInfo()
        //{
            
        //    List<SearchCar> carsList = null;
        //    //int i = 1;
        //    carsList = iBusiness.Cars();
        //    return View(carsList);
        //}

        public ActionResult ViewUsedCars(CarResultsModel CarResModel)
        {
            List<CarFullInfoModel> UsedCars = null;
            UsedCars=iBusiness.ViewUsedCars();
           // CarFullInfoModel model = new CarFullInfoModel();
           // model = UsedCars;
            CarResModel.carInfo = UsedCars;
            return View(CarResModel);
        }

        public ActionResult ViewNewCars(CarResultsModel CarResModel)
        {
            List<CarFullInfoModel> NewCars = null;
            NewCars = iBusiness.ViewNewCars();
            // CarFullInfoModel model = new CarFullInfoModel();
            // model = UsedCars;
            CarResModel.carInfo = NewCars;
            return View(CarResModel);
        }

        public ActionResult ViewUsedCarsUnder(CarResultsModel CarResModel)
        {
            List<CarFullInfoModel> UsedCarsUnder = null;
            UsedCarsUnder = iBusiness.ViewUsedCarsUnder();
            // CarFullInfoModel model = new CarFullInfoModel();
            // model = UsedCars;
            CarResModel.carInfo = UsedCarsUnder;
            return View(CarResModel);
        }



    }
}
