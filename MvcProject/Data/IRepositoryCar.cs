using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Data
{
    public interface IRepositoryCar
    {
        List<SearchCar> Cars(string makeType);
        List<CarMakeModel> CarMake();
        List<CarFullInfoModel> quickSearchResults(string make, string model, int year, double price);
        List<CarFullInfoModel> ViewUsedCars();
        List<CarFullInfoModel> ViewNewCars();
        List<CarFullInfoModel> ViewUsedCarsUnder();
        List<ServiceCategory> ServiceCat();
        List<ServiceCategory> ServiceTypes(string serviceCat);
        List<EstimateCost> ServiceCost(string make, string model, string cat, string service);
        List<CarCategory> CarCat();
        bool AddNewCar(AdminModel model);
        int ScheduleAppnt(string username, string email, int phone, string comment);
        bool checkIfCarMakeExists(AdminModel model);
        List<ImageModel> GetImages(string cModel);
        int GetCarMakeId(AdminModel model);
        bool DeleteCar(AdminModel model);
        List<GalleryModel> CarGallery();
        int Finance(FinanceDetails model);
    }
}