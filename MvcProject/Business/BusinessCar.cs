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
        public List<SearchCar> Cars()
        {
            //List<SearchCar> listSearchCar = null;
           
               return irepCar.Cars();
            
               
           // return listSearchCar;
        }
        public List<SearchCar> quickSearchResults(string make, string model, int year, double price)
        {
            return irepCar.quickSearchResults(make, model, year, price);
        }
    }
}