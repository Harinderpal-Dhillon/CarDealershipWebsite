using MvcProject.Models;
using MvcProject.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
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

        public bool ValidateUsername(string userName)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");


            object obj = null;
            try
            {
                string sql = "select Username from Users where Username=@userName";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@userName", SqlDbType.VarChar, 50);
                p1.Value = userName;
                PList.Add(p1);


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

        public int Finance(FinanceDetails model)
        {
            try
            {

                int rows = 0;
                string sql = @"insert into FinanceDetails (Username, Firstname, Lastname, Gender,Phone, Email, SSN, City, State, Country, Zip,MonthlyIncome,AdditionalIncome,Employed,FromYear,ToYear,Make, Model,Stock,AvailableDownPayment,DesiredMonthlyPayment) VALUES(@u,@f,@l,@g,@p,@e,@s,@c,@st,@ct,@z,@mi,@ai,@emp,@fy,@ty,@make,@model,@stock,@ad,@dm)";
             
                List<DbParameter> ParamList = new List<DbParameter>();
                SqlParameter p1 = new SqlParameter(" @u", SqlDbType.VarChar);
                SqlParameter p2 = new SqlParameter("@f", SqlDbType.VarChar);
                SqlParameter p3 = new SqlParameter("@l", SqlDbType.VarChar);
                SqlParameter p4 = new SqlParameter(" @g", SqlDbType.VarChar);
                SqlParameter p5 = new SqlParameter("@p", SqlDbType.VarChar);
                SqlParameter p6 = new SqlParameter("@e", SqlDbType.VarChar);
                
                SqlParameter p7 = new SqlParameter("@s", SqlDbType.VarChar);
                SqlParameter p8 = new SqlParameter("@c", SqlDbType.VarChar);
                SqlParameter p9 = new SqlParameter("@st", SqlDbType.VarChar);
                SqlParameter p10 = new SqlParameter("@ct", SqlDbType.VarChar);
                SqlParameter p11 = new SqlParameter("@z", SqlDbType.VarChar);
                SqlParameter p12 = new SqlParameter("@mi", SqlDbType.VarChar);
                SqlParameter p13 = new SqlParameter("@ai ", SqlDbType.VarChar);
                SqlParameter p14 = new SqlParameter("@emp", SqlDbType.VarChar);
                SqlParameter p15 = new SqlParameter("@fy", SqlDbType.VarChar);
                SqlParameter p16 = new SqlParameter("@ty ", SqlDbType.VarChar);
                SqlParameter p17 = new SqlParameter("@make", SqlDbType.VarChar);
                SqlParameter p18 = new SqlParameter("@model", SqlDbType.VarChar);
                SqlParameter p19 = new SqlParameter("@stock ", SqlDbType.VarChar);
                SqlParameter p20 = new SqlParameter("@ad", SqlDbType.VarChar);
                SqlParameter p21 = new SqlParameter("@dm", SqlDbType.VarChar);

                p1.Value = model.Username;
                p2.Value = model.Firstname;
                p3.Value = model.Lastname;
                p4.Value = model.Gender;
                p5.Value = model.Phone;
                p6.Value = model.Email;
                p7.Value = model.SSN;
                p9.Value = model.State;
                p8.Value = model.City;
                p10.Value = model.Country;
                p11.Value = model.Zip;
                p12.Value = model.Income;
                p13.Value = model.AdditionalIncome;
                p14.Value = model.Employed;
                p15.Value = model.FromYear;
                p16.Value = model.ToYear;
                p17.Value = model.Make;
                p18.Value = model.Model;
                p19.Value = model.Stock;
                p20.Value = model.AvailableDownPayment;
                p21.Value = model.DesiredMonthlyPayment;

                ParamList.Add(p1);
                ParamList.Add(p2);
                ParamList.Add(p3);
                ParamList.Add(p4);
                ParamList.Add(p5);
                ParamList.Add(p6);
                ParamList.Add(p7);
                ParamList.Add(p8);
                ParamList.Add(p9);
                ParamList.Add(p10);
                ParamList.Add(p11);
                ParamList.Add(p12);
                ParamList.Add(p13);
                ParamList.Add(p14);
                ParamList.Add(p15);
                ParamList.Add(p16);
                ParamList.Add(p17);
                ParamList.Add(p18);
                ParamList.Add(p19);
                ParamList.Add(p20);
                ParamList.Add(p21);
                
                rows = idataAccess.InsOrUpdOrDel(sql, ParamList);
                return rows;

            }

            catch (Exception)
            {
                throw;
            }
        }

        public List<SearchCar> Cars(string makeType)
        {
            List<SearchCar> carInfo = new List<SearchCar>();
            try
            {
                string sql = "SELECT CarType.MakeType ,CarInfo.Id, CarInfo.Model, CarInfo.Year, CarInfo.Price FROM CarInfo INNER JOIN CarType ON CarInfo.MakeId=CarType.MakeId where CarType.MakeType=@makeType";


                //string sql = "select CarType.MakeType ,Model, Year, Price from CarInfo where CarInfo.MakeId=CarType.MakeId and MakeType=@makeType";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@makeType", SqlDbType.VarChar, 50);
                p1.Value = makeType;
                PList.Add(p1);

                //DataTable dt = idataAccess.GetDataTable(sql, null);
                //List<DbParameter> PList = new List<DbParameter>();
                DataTable dt = idataAccess.GetDataTable(sql, PList);
                carInfo = DBList.ToList<SearchCar>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;
        }

        public List<CarMakeModel> CarMake()
        {
            List<CarMakeModel> carMake = new List<CarMakeModel>();
            try
            {

                string sql = "select * from CarType";

                //DataTable dt = idataAccess.GetDataTable(sql, null);
                //List<DbParameter> PList = new List<DbParameter>();
                DataTable dt = idataAccess.GetDataTable(sql, null);
                carMake = DBList.ToList<CarMakeModel>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carMake;
        }

        public List<CarFullInfoModel> quickSearchResults(string make, string model, int year, double price)
        {
            List<CarFullInfoModel> carInfo = new List<CarFullInfoModel>();
            try
            {
                string sql = "select * from CarInfo, CarType, CarImages where CarInfo.MakeId=CarType.MakeId and CarInfo.Id=CarImages.CarId and MakeType=@make and Model=@model and Year=@year and Price=@price";
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
                carInfo = DBList.ToList<CarFullInfoModel>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;

        }

        public List<CarFullInfoModel> ViewUsedCars()
        {
            List<CarFullInfoModel> carInfo = new List<CarFullInfoModel>();
            string car = "UsedCar";
            try
            {
                string sql = "select * from CarInfo, CarType, CarCategory where CarInfo.MakeId=CarType.MakeId and CarCategory.CategoryId=CarInfo.CarCatId and CarCategory.CategoryName=@car";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@car", SqlDbType.VarChar, 50);
                p1.Value = car;
                PList.Add(p1);

                DataTable dt = idataAccess.GetDataTable(sql, PList);
                carInfo = DBList.ToList<CarFullInfoModel>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;

        }

        public List<CarFullInfoModel> ViewNewCars()
        {
            List<CarFullInfoModel> carInfo = new List<CarFullInfoModel>();
            string car = "NewCar";
            try
            {
                string sql = "select * from CarInfo, CarType, CarCategory where CarInfo.MakeId=CarType.MakeId and CarCategory.CategoryId=CarInfo.CarCatId and CarCategory.CategoryName=@car";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@car", SqlDbType.VarChar, 50);
                p1.Value = car;
                PList.Add(p1);

                DataTable dt = idataAccess.GetDataTable(sql, PList);
                carInfo = DBList.ToList<CarFullInfoModel>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;

        }

        public List<CarFullInfoModel> ViewUsedCarsUnder()
        {
            List<CarFullInfoModel> carInfo = new List<CarFullInfoModel>();
            string car = "UsedCar";
            double price = 10000.00;
            try
            {
                string sql = "select * from CarInfo, CarType, CarCategory where CarInfo.MakeId=CarType.MakeId and CarCategory.CategoryId=CarInfo.CarCatId and CarCategory.CategoryName=@car and CarInfo.Price<=@price";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@car", SqlDbType.VarChar, 50);
                p1.Value = car;
                PList.Add(p1);
                DbParameter p2 = new SqlParameter("@price", SqlDbType.Float);
                p2.Value = price;
                PList.Add(p2);
                DataTable dt = idataAccess.GetDataTable(sql, PList);
                carInfo = DBList.ToList<CarFullInfoModel>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;

        }

        public List<ServiceCategory> ServiceCat()
        {
            List<ServiceCategory> carInfo = new List<ServiceCategory>();
            try
            {
                string sql = "SELECT ServiceCategoryTypes.ServiceCatId, ServiceCategoryTypes.ServiceCatName, ServiceDetails.ServiceName from ServiceCategoryTypes, ServiceDetails";


                //string sql = "select CarType.MakeType ,Model, Year, Price from CarInfo where CarInfo.MakeId=CarType.MakeId and MakeType=@makeType";
                //List<DbParameter> PList = new List<DbParameter>();
                // DbParameter p1 = new SqlParameter("@makeType", null);
                // p1.Value = makeType;
                //PList.Add(p1);

                //DataTable dt = idataAccess.GetDataTable(sql, null);
                //List<DbParameter> PList = new List<DbParameter>();
                DataTable dt = idataAccess.GetDataTable(sql, null);
                carInfo = DBList.ToList<ServiceCategory>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;
        }

        public List<ServiceCategory> ServiceTypes(string serviceCat)
        {
            List<ServiceCategory> carInfo = new List<ServiceCategory>();
            try
            {
                string sql = "SELECT * from ServiceCategoryTypes, ServiceDetails where ServiceCategoryTypes.ServiceCatId=ServiceDetails.ServiceCatId and ServiceCategoryTypes.ServiceCatName=@serviceCat";


                //string sql = "select CarType.MakeType ,Model, Year, Price from CarInfo where CarInfo.MakeId=CarType.MakeId and MakeType=@makeType";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@serviceCat", null);
                p1.Value = serviceCat;
                PList.Add(p1);

                //DataTable dt = idataAccess.GetDataTable(sql, null);
                //List<DbParameter> PList = new List<DbParameter>();
                DataTable dt = idataAccess.GetDataTable(sql, PList);
                carInfo = DBList.ToList<ServiceCategory>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;
        }


        public List<ImageModel> GetImages(string cModel)
        {
            // DataTable dataTable = null;
            List<ImageModel> img = new List<ImageModel>();
            try
            {
                string sql = "select  CarImages.Image, CarImages.Type from CarImages, CarInfo where CarImages.CarID=CarInfo.Id and CarInfo.Model=@carModel";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@carModel", SqlDbType.VarChar, 50);
                p1.Value = cModel;
                PList.Add(p1);

                DataTable dataTable = idataAccess.GetDataTable(sql, PList);
                img = DBList.ToList<ImageModel>(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            return img;
        }

        public List<GalleryModel> CarGallery()
        {
           List<GalleryModel> gModel = new List<GalleryModel>();
            try
            {
                string sql = "select CarInfo.Model, CarType.MakeType, CarImages.Image, CarImages.Type from CarInfo, CarType, CarImages where CarInfo.MakeId=CarType.MakeId and CarInfo.Id=CarImages.CarId ";
                List<DbParameter> PList = new List<DbParameter>();
               ;
                DataTable dt = idataAccess.GetDataTable(sql, PList);
                gModel = DBList.ToList<GalleryModel>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return (gModel);
        }

        //public int GetServiceId(string serviceCat)
        //{

        //}


        public List<EstimateCost> ServiceCost(string make, string model, string cat, string service)
        {
            List<EstimateCost> carInfo = new List<EstimateCost>();

            try
            {
                string sql = "select CarInfo.Model, CarType.MakeType, ServiceCost.EstimateCost from CarInfo, CarType, ServiceDetails, ServiceCategoryTypes, ServiceCost where CarInfo.MakeId=CarType.MakeId and ServiceDetails.ServiceCatId=ServiceCategoryTypes.ServiceCatId and ServiceCost.ServiceId=ServiceDetails.ServiceID and CarType.MakeType=@make and CarInfo.Model=@model and ServiceCategoryTypes.ServiceCatName=@cat and ServiceDetails.ServiceName=@service";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@make", SqlDbType.VarChar, 50);
                p1.Value = make;
                PList.Add(p1);
                DbParameter p2 = new SqlParameter("@model", SqlDbType.VarChar, 50);
                p2.Value = model;
                PList.Add(p2);
                DbParameter p3 = new SqlParameter("@cat", SqlDbType.VarChar, 50);
                p3.Value = cat;
                PList.Add(p3);
                DbParameter p4 = new SqlParameter("@service", SqlDbType.VarChar, 100);
                p4.Value = service;
                PList.Add(p4);
                DataTable dt = idataAccess.GetDataTable(sql, PList);
                carInfo = DBList.ToList<EstimateCost>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carInfo;

        }

        public List<CarCategory> CarCat()
        {
            List<CarCategory> carCat = new List<CarCategory>();
            try
            {

                string sql = "select * from CarCategory";

                //DataTable dt = idataAccess.GetDataTable(sql, null);
                //List<DbParameter> PList = new List<DbParameter>();
                DataTable dt = idataAccess.GetDataTable(sql, null);
                carCat = DBList.ToList<CarCategory>(dt);
            }
            catch (Exception e)
            {
                throw e;
            }

            return carCat;
        }

        public bool AddNewCar(AdminModel model)
        {
            // alert(model.maketypes1.Make);

            bool res = true;
            string ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlTransaction Transaction = null;

            Stream stream = null;
            FileInfo fileInfo = null;
            Byte[] ImageData = null;
            //int ID1 = 7;
            //int ID2 = 6;

            try
            {
                int makeID = 0;
                int catId = 0;
                Connection.Open();
                Transaction = Connection.BeginTransaction();
                if (checkIfCarMakeExists(model))
                {
                    string sqlMakeId = "select MakeId from CarType where MakeType=@makeType";
                    SqlCommand cmd = new SqlCommand(sqlMakeId, Connection);

                    DbParameter p2c = new SqlParameter("@makeType", SqlDbType.VarChar, 50);
                    p2c.Value = model.maketypes1.Make;
                    cmd.Parameters.Add(p2c);
                    cmd.Transaction = Transaction;
                    object objMakeId = cmd.ExecuteScalar();

                    if (objMakeId != null)
                    {
                        makeID = (int)objMakeId;
                    }
                }
                else
                {

                    string sql = "insert into CarType(MakeType) values(@MakeType)";
                    SqlCommand cmd = new SqlCommand(sql, Connection);

                    //DbParameter p1c = new SqlParameter("@MakeId", SqlDbType.Int);
                    //p1c.Value = model.maketypes1.MakeId;
                    //cmd.Parameters.Add(p1c);

                    DbParameter p2c = new SqlParameter("@MakeType", SqlDbType.VarChar, 50);
                    p2c.Value = model.maketypes1.Make;
                    cmd.Parameters.Add(p2c);
                    cmd.Transaction = Transaction;
                    int rows = cmd.ExecuteNonQuery();
                    if (rows <= 0)
                        throw new Exception("Could not insert new car type ");

                    string sql4 = "SELECT top 1 MakeId from CarType order by MakeId desc";
                    SqlCommand cmd0 = new SqlCommand(sql4, Connection);
                    cmd0.Transaction = Transaction;
                    object obj = cmd0.ExecuteScalar();
                    if (obj != null)
                        makeID = (int)obj;

                }
                string sql1 = "insert into CarInfo (MakeId, Model, Year, Price, Mileage, CarCatId, BodyStyle)" +
                    "values (@MakeId, @Model, @Year, @Price, @Mileage, @CarCatId, @BodyStyle)";
                SqlCommand cmd1 = new SqlCommand(sql1, Connection);

                //DbParameter p1 = new SqlParameter("@Id", SqlDbType.Int);
                //p1.Value = model.carDetails1.Id;
                //cmd1.Parameters.Add(p1);

                DbParameter p2 = new SqlParameter("@MakeId", SqlDbType.Int);
                p2.Value = makeID;
                cmd1.Parameters.Add(p2);

                DbParameter p3 = new SqlParameter("@Model", SqlDbType.VarChar, 50);
                p3.Value = model.carDetails1.Model;
                cmd1.Parameters.Add(p3);

                DbParameter p4 = new SqlParameter("@Year", SqlDbType.Int);
                p4.Value = model.carDetails1.Year;
                cmd1.Parameters.Add(p4);

                DbParameter p5 = new SqlParameter("@Price", SqlDbType.Float);
                p5.Value = model.carDetails1.Price;
                cmd1.Parameters.Add(p5);

                DbParameter p6 = new SqlParameter("@Mileage", SqlDbType.VarChar, 50);
                p6.Value = model.carDetails1.Mileage;
                cmd1.Parameters.Add(p6);

                DbParameter p7 = new SqlParameter("@CarCatId", SqlDbType.Int);
                p7.Value = model.carCat1.catId;
                cmd1.Parameters.Add(p7);

                DbParameter p8 = new SqlParameter("@BodyStyle", SqlDbType.VarChar, 50);
                p8.Value = model.carDetails1.BodyStyle;
                cmd1.Parameters.Add(p8);

                cmd1.Transaction = Transaction;
                int rows1 = cmd1.ExecuteNonQuery();
                if (rows1 <= 0)
                {
                    throw new Exception("Could not insert new car information");
                }

                stream = model.imgModel1.ImageFile.InputStream;
                fileInfo = new FileInfo(Path.GetFullPath(model.imgModel1.ImageFile.FileName));
                ImageData = new Byte[model.imgModel1.ImageFile.ContentLength];
                stream.Read(ImageData, 0, model.imgModel1.ImageFile.ContentLength);

                //string sql2 = "select top 1 NewsId from NewsFeed ordered by NewId desc";
                //List<DbParameter> pList = new List<DbParameter>();
                //object obj = dataAccess.GetSingleAnswer(sql2, pList);
                //if (obj == null)
                //    throw new Exception("Could not get top record from NewsFeed");

                // int NewsId = (int)obj;




                //string sql2 = "select Id from CarInfo where Model=@carModel";
                string sql2 = "select top 1 Id from CarInfo order by Id desc";
                SqlCommand cmd01 = new SqlCommand(sql2, Connection);
                //DbParameter p1M = new SqlParameter("@carModel", SqlDbType.VarChar, 50);
                //p1M.Value = model.carDetails1.Model;
                //cmd01.Parameters.Add(p1M);
                //catId = 2;
                cmd01.Transaction = Transaction;
                object obj1 = cmd01.ExecuteScalar();
                if (obj1 != null)
                {
                    catId = (int)obj1;

                }

                else
                {
                    throw new Exception("Could not check for the car model");
                }


                //string sql3a = "select top 1 Id from CarImages order by Id desc";
                //SqlCommand cmd3a = new SqlCommand(sql3a, Connection);
                //cmd3a.Transaction = Transaction;
                //object obj3a = cmd3a.ExecuteScalar();
                //int id = 0;
                //if (obj3a != null)
                //    id = (int)obj3a;
                //++id;

                string sql3 = "insert into CarImages (Name, Type, Image, CarId) values" +
                    "(@Name, @Type, @Image, @CarId)";

                SqlCommand cmd2 = new SqlCommand(sql3, Connection);

                DbParameter p1b = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                p1b.Value = fileInfo.Name;
                cmd2.Parameters.Add(p1b);

                DbParameter p2b = new SqlParameter("@Type", SqlDbType.VarChar, 10);
                p2b.Value = fileInfo.Extension;
                cmd2.Parameters.Add(p2b);

                DbParameter p3b = new SqlParameter("@Image", SqlDbType.VarBinary);
                p3b.Value = ImageData;
                cmd2.Parameters.Add(p3b);

                DbParameter p4b = new SqlParameter("@CarId", SqlDbType.Int);
                p4b.Value = catId;
                cmd2.Parameters.Add(p4b);

                //DbParameter p5b = new SqlParameter("@Id", SqlDbType.Int);
                //p5b.Value = id;
                //cmd2.Parameters.Add(p5b);

                cmd2.Transaction = Transaction;
                int rows3 = cmd2.ExecuteNonQuery();
                if (rows3 <= 0)
                    throw new Exception("Could not insert image.");

                Transaction.Commit();
            }
            catch (Exception e)
            {
                res = false;
                if (Transaction != null)
                    Transaction.Rollback();
                throw e;
            }
            finally
            {
                if (Transaction != null)
                    Transaction.Dispose();

                Connection.Close();
            }
            return res;
        }

        public int ScheduleAppnt(string username, string email, int phone, string comment)
        {
            try
            {

                int rows = 0;
                string sql = @"insert into ScheduleAppointment (Username, Email, Phone, Comment) VALUES(@username,@email,@phone, @comment)";
                List<DbParameter> ParamList = new List<DbParameter>();
                SqlParameter p1 = new SqlParameter("@username", SqlDbType.VarChar);
                SqlParameter p2 = new SqlParameter("@email", SqlDbType.VarChar);
                SqlParameter p3 = new SqlParameter("@phone", SqlDbType.VarChar);
                SqlParameter p4 = new SqlParameter("@comment", SqlDbType.VarChar);
                p1.Value = username;
                p2.Value = email;
                p3.Value = phone;
                p4.Value = comment;
                ParamList.Add(p1);
                ParamList.Add(p2);
                ParamList.Add(p3);
                ParamList.Add(p4);
                rows = idataAccess.InsOrUpdOrDel(sql, ParamList);
                return rows;

            }

            catch (Exception)
            {
                throw;
            }
        }

        public bool checkIfCarMakeExists(AdminModel model)
        {
            object obj = null;
            try
            {
                string sql = "select MakeType from CarType where MakeType=@makeType";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@makeType", SqlDbType.VarChar, 50);
                p1.Value = model.maketypes1.Make;
                PList.Add(p1);


                obj = idataAccess.GetSingleAnswer(sql, PList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return obj != null ? true : false;
        }

        public int GetCarMakeId(AdminModel model)
        {
            int id = 0;
            object obj = null;
            try
            {
                string sql = "select MakeId from CarType where MakeType=@makeType";
                List<DbParameter> PList = new List<DbParameter>();
                DbParameter p1 = new SqlParameter("@makeType", SqlDbType.VarChar, 50);
                p1.Value = model.maketypes1.Make;
                PList.Add(p1);


                obj = idataAccess.GetSingleAnswer(sql, PList);
                id = (int)obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return id;
        }

        public bool DeleteCar(AdminModel model)
        {
            bool res = true;
            int rows = 0;
            string ConnectionString = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlTransaction Transaction = null;
            try
            {
                Connection.Open();
                Transaction = Connection.BeginTransaction();

                int carId = 0;
                string sql2 = "Select CarImages.CarId from CarImages,CarInfo where CarImages.CarId=CarInfo.Id and CarInfo.Model=@model";
                SqlCommand cmd1 = new SqlCommand(sql2, Connection);
                SqlParameter param1 = new SqlParameter("@model", SqlDbType.VarChar);
                param1.Value = model.carDetails1.Model;
                cmd1.Parameters.Add(param1);

                cmd1.Transaction = Transaction;
                object obj = cmd1.ExecuteScalar();
                if (obj != null)
                    carId = (int)obj;

                string sql3 = "Delete from CarImages where CarId=@carId";
                SqlCommand cmd2 = new SqlCommand(sql3, Connection);
                SqlParameter param2 = new SqlParameter("@carId", SqlDbType.Int);
                param2.Value = carId;
                cmd2.Parameters.Add(param2);
                cmd2.Transaction = Transaction;
                int rows1 = cmd2.ExecuteNonQuery();
                if (rows1 <= 0)
                    throw new Exception("Could not delete any car image");

                int id = GetCarMakeId(model);

                string sql = "Delete from CarInfo where MakeId=@makeId and Model=@model";
                SqlCommand cmd = new SqlCommand(sql, Connection);
                SqlParameter p1 = new SqlParameter("@makeId", SqlDbType.Int);
                p1.Value = id;
                cmd.Parameters.Add(p1);

                SqlParameter p2 = new SqlParameter("@model", SqlDbType.VarChar);
                p2.Value = model.carDetails1.Model;
                cmd.Parameters.Add(p2);

                cmd.Transaction = Transaction;
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                    throw new Exception("Could not delete for the car model");

                Transaction.Commit();
            }
            catch (Exception e)
            {
                res = false;
                if (Transaction != null)
                    Transaction.Rollback();
                throw e;
            }
            finally
            {
                if (Transaction != null)
                    Transaction.Dispose();

                Connection.Close();
            }
            return res;
        }
    }
}
