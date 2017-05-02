using MvcProject.Models;
using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcProject.Data
{
    public class RepositorySql : IRepositoryAuthenticate, IRepositoryCar
    {
        IDataAccessSql idataAccess = null;

        public RepositorySql()
        {

            string CONNSTR = "server=DELL-PC;integrated security=true;database=CarDealershipDB";
            idataAccess = new DataAccessSql(CONNSTR);
            
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            object obj = null;
            try
            {
                string sql = "select Username from Users where Username=@userName" +
                    " and Password=@password";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@userName", SqlDbType.VarChar, 50);
                p1.Value = userName;
                PList.Add(p1);
                DbParameter p2 = new SqlParameter("@password", SqlDbType.VarChar, 50);
                p2.Value = password;
                PList.Add(p2);

                obj = idataAccess.GetSingleAnswer(sql, PList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj != null ? true : false;
        }

        public int Register(string userName, string pass, string confirmPass)
        {
            try
            {

                int rows = 0;
                string sql = @"insert into Users (Username, Password, ConfirmPassword) VALUES(@Username,@Password,@ConfirmPassword)";
                List<DbParameter> ParamList = new List<DbParameter>();
                SqlParameter p1 = new SqlParameter("@Username", SqlDbType.VarChar);
                SqlParameter p2 = new SqlParameter("@Password", SqlDbType.VarChar);
                SqlParameter p3 = new SqlParameter("@ConfirmPassword", SqlDbType.VarChar);
                p1.Value = userName;
                p2.Value = pass;
                p3.Value = confirmPass;
                ParamList.Add(p1);
                ParamList.Add(p2);
                ParamList.Add(p3);
                rows = idataAccess.InsOrUpdOrDel(sql, ParamList);
                return rows;

            }

            catch (Exception)
            {
                throw;
            }
        }
       
        public List<SearchCar> Cars()
        {
            List<SearchCar> carInfo = new List<SearchCar>();
            try
            {

                string sql = "select * from CarInfo";

                //DataTable dt = idataAccess.GetDataTable(sql, null);
                //List<DbParameter> PList = new List<DbParameter>();
                DataTable dt = idataAccess.GetDataTable(sql,null);
                carInfo = DBList.ToList<SearchCar>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
           
            return carInfo;
        }

        public List<SearchCar> quickSearchResults(string make, string model, int year, double price)
        {
            List<SearchCar> carInfo = new List<SearchCar>();
            try
            {
                string sql = "select Make, Model, Year, Price from CarInfo where Make=@make" +
                    " , Model=@model, Year=@year and Price=@price";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@make", SqlDbType.VarChar, 50);
                p1.Value = make;
                PList.Add(p1);
                DbParameter p2 = new SqlParameter("@model", SqlDbType.VarChar, 50);
                p2.Value = model;
                PList.Add(p2);
                DbParameter p3 = new SqlParameter("@year", SqlDbType.VarChar, 50);
                p3.Value = year;
                PList.Add(p3);
                DbParameter p4 = new SqlParameter("@price", SqlDbType.VarChar, 50);
                p4.Value = price;
                PList.Add(p4);
                DataTable dt = idataAccess.GetDataTable(sql, PList);
                carInfo = DBList.ToList<SearchCar>(dt);
                 }
            catch (Exception e)
            {
                throw e;
            }
           
            return carInfo;

            }
        }
    }
