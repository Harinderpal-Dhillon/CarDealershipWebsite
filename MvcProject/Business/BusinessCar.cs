using MvcProject.Data;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Business
{
    public class BusinessCar:IBusinessCar
    {
        public IRepositoryCar irepCar = null;
        
        public BusinessCar()
        {
            
            irepCar = new RepositorySql() as IRepositoryCar;
            
        }
        public List<SearchCar> Cars(string makeType)
        {
            //List<SearchCar> listSearchCar = null;
           
               return irepCar.Cars(makeType);
            
               
           // return listSearchCar;
        }

        public List<CarMakeModel> CarMake()
        {
            return irepCar.CarMake();
        }

        public List<CarFullInfoModel> quickSearchResults(string make, string model, int year, double price)
        {
            return irepCar.quickSearchResults(make, model, year, price);
        }

        public List<CarFullInfoModel> ViewUsedCars()
        {
            return irepCar.ViewUsedCars();
        }

        public List<CarFullInfoModel> ViewNewCars()
        {
            return irepCar.ViewNewCars();
        }

        public List<CarFullInfoModel> ViewUsedCarsUnder()
        {
            return irepCar.ViewUsedCarsUnder();
        }

        public List<ServiceCategory> ServiceCat()
        {
            return irepCar.ServiceCat();
        }

        public List<ServiceCategory> ServiceTypes(string serviceCat)
        {
            return irepCar.ServiceTypes(serviceCat);
        }

        public List<EstimateCost> ServiceCost(string make, string model, string cat, string service)
        {
            return irepCar.ServiceCost(make, model, cat, service);
        }

        public List<CarCategory> CarCat()
        {
            return irepCar.CarCat();
        }

        public bool AddNewCar(AdminModel model)
        {
            return irepCar.AddNewCar(model);
        }

        public int ScheduleAppnt(string username, string email, int phone, string comment)
        {
            return irepCar.ScheduleAppnt(username, email, phone, comment);
        }

        public bool checkIfCarMakeExists(AdminModel model)
        {
           return  irepCar.checkIfCarMakeExists(model);
        }

        public List<ImageModel> GetImages(string cModel)
        {
            return irepCar.GetImages(cModel);
        }
        public int GetCarMakeId(AdminModel model)
        {
            return irepCar.GetCarMakeId(model);
        }

        public bool DeleteCar(AdminModel model)
        {
            return irepCar.DeleteCar(model);
        }

         public List<GalleryModel> CarGallery()
        {
            return irepCar.CarGallery();
        }

        public int Finance(FinanceDetails model)
         {
             return irepCar.Finance(model);
         }
    }
}