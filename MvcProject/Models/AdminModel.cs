using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Models
{
    public class AdminModel
    {
        public List<CarFullInfoModel> carDetails = new List<CarFullInfoModel>();
        public List<CarMakeModel> maketypes = new List<CarMakeModel>();
        public List<CarCategory> carCat = new List<CarCategory>();
        public List<ImageModel> imgModel = new List<ImageModel>();
        public List<GalleryModel> gModel = new List<GalleryModel>();

        public CarFullInfoModel carDetails1 { get; set; }
        public CarMakeModel maketypes1 { get; set; }
        public CarCategory carCat1 { get; set; }
        public ImageModel imgModel1 { get; set; }
        public GalleryModel gModel1 { get; set; }
        public string Status { get; set; }


        public AdminModel()
        {
            CarFullInfoModel carDetails1 = new CarFullInfoModel();
            CarMakeModel maketypes1 = new CarMakeModel();
            CarCategory carCat1 = new CarCategory();
            ImageModel imgModel1 = new ImageModel();
            GalleryModel gModel1 = new GalleryModel();
        }
    }
}