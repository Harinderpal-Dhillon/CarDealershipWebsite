using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Business
{
    public interface IBusinessCar
    {
         List<SearchCar> Cars();
         List<SearchCar> quickSearchResults(string make, string model, int year, double price);
    }
}