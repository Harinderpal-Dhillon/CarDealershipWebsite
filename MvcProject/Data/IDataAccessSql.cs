﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace MvcProject.Data
{
    public interface IDataAccessSql
    {
        object GetSingleAnswer(string sql, List<DbParameter> PList);
        DataTable GetDataTable(string sql, List<DbParameter> PList);
        int InsOrUpdOrDel(string sql, List<DbParameter> PList);
    }
}