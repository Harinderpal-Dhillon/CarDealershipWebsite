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
            List<SearchCar> carsList = null;
            //int i = 1;
            carsList = iBusiness.Cars();
            return View(carsList);
        }

        [HttpPost]
        public ActionResult SearchCarResults(SearchCar model)
        {
            List<SearchCar> CList = null;
            CList = iBusiness.quickSearchResults(model.Make, model.Model, model.Year, model.Price);
            return View(CList);
        }
        //public ActionResult CarInfo()
        //{
            
        //    List<SearchCar> carsList = null;
        //    //int i = 1;
        //    carsList = iBusiness.Cars();
        //    return View(carsList);
        //}



    }
}
