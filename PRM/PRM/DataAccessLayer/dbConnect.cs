using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections;

namespace PRM
{
    public class dbConnect
    {
        SqlCeConnection sqlConSqlCe;

        public dbConnect()
        {
            OpenConnectionSqlCe();

        }

        public void OpenConnectionSqlCe()
        {
            string app_path = AppDomain.CurrentDomain.BaseDirectory;
            string sdf_path = "PRM.sdf";
            sqlConSqlCe = new SqlCeConnection(@"Data Source=" + app_path + sdf_path);
            sqlConSqlCe.Open();
        }

        public SqlCeResultSet SelectQuerySqlCe(string Table, StringBuilder Fields, StringBuilder Condition,Hashtable Options)
        {
            SqlCeResultSet rs;
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConSqlCe;

            if (Condition.Length != 0)
            {
                cmd.CommandText = "select " + Fields + " from " + Table + " where " + Condition + "";
            }
            else
            {
                cmd.CommandText = "select " + Fields + " from " + Table + "";
            }

            

            if (Options["Updatable"].ToString() == "Y")
            {
                rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable | ResultSetOptions.Updatable | ResultSetOptions.Sensitive);
            }
            else if (Options["Scrollable"].ToString() == "Y")
            {
                rs = cmd.ExecuteResultSet(ResultSetOptions.Scrollable);
            }
            else if (Options["Sensitive"].ToString() == "Y")
            {
                rs = cmd.ExecuteResultSet(ResultSetOptions.Sensitive | ResultSetOptions.Scrollable);
            }
            else if (Options["Insensitive"].ToString() == "Y")
            {
                rs = cmd.ExecuteResultSet(ResultSetOptions.Insensitive);
            }
            else
            {
                rs = cmd.ExecuteResultSet(ResultSetOptions.None);
            }

            return rs;
           
        }

        public DataSet SelectQuerySqlCeDataSet(string Table, StringBuilder Fields, StringBuilder Condition)
        {
            DataSet ds = new DataSet();
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConSqlCe;

            try
            {
                if (Condition.Length != 0)
                {
                    cmd.CommandText = "select " + Fields + " from " + Table + " where " + Condition + "";
                }
                else
                {
                    cmd.CommandText = "select " + Fields + " from " + Table + "";
                }


                SqlCeDataAdapter sqlAdapter = new SqlCeDataAdapter(cmd.CommandText, sqlConSqlCe);
                sqlAdapter.Fill(ds);
            }
            catch
            {
                throw;
            }
            return ds;
        }


    }
}
