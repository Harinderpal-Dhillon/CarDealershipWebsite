using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class CarResultsModel
    {
        public List<CarMakeModel> carMake = new List<CarMakeModel>();
        public List<SearchCar> sCar = new List<SearchCar>();
        public List<CarFullInfoModel> carInfo = new List<CarFullInfoModel>();
        public List<ServiceCategory> catList = new List<ServiceCategory>();
        public List<EstimateCost> costList = new List<EstimateCost>();
        public List<ImageModel> imgModel = new List<ImageModel>();

        public CarFullInfoModel carDetailObj { get; set; }
        public ImageModel imgModelObj { get; set; }
        public SearchCar sCarObj { get; set; }

        public CarResultsModel(){
        CarFullInfoModel carDetailObj =new CarFullInfoModel();
        ImageModel imgModelObj= new ImageModel();
        SearchCar sCarObj=new SearchCar();

    }
    }
}