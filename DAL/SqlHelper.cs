using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace DAL
{
    public class SqlHelper
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public static DataTable GetTable(string sql, CommandType type,params MySqlParameter[] pars)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlDataAdapter apter = new MySqlDataAdapter(sql, conn))
                {
                    apter.SelectCommand.CommandType = type;
                    if (pars != null)
                    {
                        apter.SelectCommand.Parameters.AddRange(pars);
                    }
                    DataTable da = new DataTable();
                    apter.Fill(da);
                    return da;
                }
            }
        }
        public static int ExecuteNonquery(string sql,CommandType type,params MySqlParameter[] pars)
        {
            using(MySqlConnection conn =new MySqlConnection(connString))
            {
                using(MySqlCommand cmd =new MySqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if (pars!=null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable SelectAllDate(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlDataAdapter apter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable da = new DataTable();
                    apter.Fill(da);
                    return da;
                }
            }
        }
    }
}
