﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcProject.Data
{
    public class DataAccessSql:IDataAccessSql
    {
        //private string CONNSTR = ConfigurationManager.ConnectionStrings["CarDealershipDB"].ConnectionString;
        public string CONNSTR = "server=DELL-PC;integrated security=true;database=CarDealershipDB";

        public DataAccessSql()
        {

        }
          
            public DataAccessSql(string connstr) // to be able to change the connectionstring
            {
                this.CONNSTR = connstr;
            }

        #region IDataAccess Members
        public object GetSingleAnswer(string sql, List<DbParameter> PList)
        {
            object obj = null;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (DbParameter p in PList)
                    cmd.Parameters.Add(p);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return obj;
        }

        public DataTable GetDataTable(string sql, List<DbParameter> PList)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (PList != null)
                {
                    foreach (DbParameter p in PList)
                        cmd.Parameters.Add(p);
                }
                
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public int InsOrUpdOrDel(string sql, List<DbParameter> PList)
        {
            int rows = 0;
            SqlConnection conn = new SqlConnection(CONNSTR);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                foreach (DbParameter p in PList)
                    cmd.Parameters.Add(p);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
        #endregion
    }
    }
