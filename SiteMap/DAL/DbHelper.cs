using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SiteMap.DAL
{
    public class DbHelper
    {
        private readonly string dbName;
        private readonly string cnstr;

        public DbHelper(string dbName = "SiteMapDb")
        {
            this.dbName = dbName;
            cnstr = ConfigurationManager.ConnectionStrings[this.dbName].ConnectionString;
        }

        private SqlConnection OpenSqlConnection()
        {
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();

            return cn;
        }

        public DataSet ExecuteQueryByStoredProc(string storedProc, Dictionary<string, SqlParameter> parameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = OpenSqlConnection())
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProc;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }

            return ds;
        }

        public DataTable ExecuteQueryToDataTableByStoredProc(string storedProc, Dictionary<string, SqlParameter> parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = OpenSqlConnection())
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProc;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param.Value);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public int ExecuteCommandByStoredProc(string storedProc, Dictionary<string, SqlParameter> parameters)
        {
            int cmdResult = 0;
            using (SqlConnection cn = OpenSqlConnection())
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProc;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param.Value);
                    }

                    cmdResult = cmd.ExecuteNonQuery();
                }
            }

            return cmdResult;
        }

    }
}