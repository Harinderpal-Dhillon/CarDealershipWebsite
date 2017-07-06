using MvcProject.Business;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CarServiceController : Controller
    {
        //
        // GET: /CarService/

        private IBusinessCar iBusiness = null;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            iBusiness = new BusinessCar();

            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceEstimate()
        {

            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
            CarResultsModel model = new CarResultsModel();
            model.carMake = carM;

            List<ServiceCategory> serviceCat = null;
            serviceCat = iBusiness.ServiceCat();
            model.catList = serviceCat;
            return View(model);
        }


        public ActionResult ServiceCat(string value)
        {
            List<ServiceCategory> carsList = null;
            //value = Request.Form["ddlMake"].ToString();

            carsList = iBusiness.ServiceTypes(value);
            // CarResultsModel model = new CarResultsModel();
            //carModel.sCar = carsList;
            SelectList objList = new SelectList(carsList, "ServiceId", "ServiceName", 0);

            return Json(objList);
        }

        [HttpPost]
        public ActionResult ServiceEstimate(CarResultsModel carRes)
        {
            //List<CarMakeModel> carM = null;
            //carM = iBusiness.CarMake();
            //CarResModel.carMake = carM;
            List<CarMakeModel> carM = null;
            carM = iBusiness.CarMake();
           // CarResultsModel model = new CarResultsModel();
            carRes.carMake = carM;

            List<ServiceCategory> serviceCat = null;
            serviceCat = iBusiness.ServiceCat();
            carRes.catList = serviceCat;
            List<ImageModel> imgList = null;
           

            List<EstimateCost> CList = null;
            //int make = Convert.ToInt32(Request.Form["makeListbox"].ToString());
            string make = Request.Form["carMake"].ToString();
            string model = Request.Form["ddlModel"].ToString();
            string category = Request.Form["catList"].ToString();
            string service = Request.Form["ddlService"].ToString();
            CList = iBusiness.ServiceCost(make, model, category, service);
            imgList = iBusiness.GetImages(model);
            carRes.imgModel = imgList;
            if (imgList[0] != null)
                carRes.imgModelObj = imgList[0];
            carRes.costList = CList;
            return View(carRes);
        }

        
      

    }
}
