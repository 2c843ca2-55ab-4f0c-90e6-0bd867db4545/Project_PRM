using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections;

namespace PRM.BusinessAccessLayer
{
    public class SelfServicebusinessLayer
    {
        public SqlCeResultSet SelectQuerySqlCe(string Table, StringBuilder Fields, StringBuilder Condition, Hashtable Options)
        {
            SqlCeResultSet rs;
            try
            {
                dbConnect ObjConn = new dbConnect();
                rs = ObjConn.SelectQuerySqlCe(Table, Fields, Condition, Options);
                
            }
            catch
            {
                throw;
            }

            return rs;
        }


        public DataSet SelectQuerySqlCeDataSet(string Table, StringBuilder Fields, StringBuilder Condition)
        {
            DataSet ds;
            try
            {
                dbConnect ObjConn = new dbConnect();
                ds = ObjConn.SelectQuerySqlCeDataSet(Table, Fields, Condition);

            }
            catch
            {
                    throw;
            }

            return ds;
        }

    }
}
