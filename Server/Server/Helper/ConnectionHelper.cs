using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Server.Helper
{
    public class ConnectionHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["con"].ToString();

        public static SqlConnection GetNewConnection()
        {
            SqlConnection newConnection = new SqlConnection(connectionString);
            return newConnection;
        }
    }
}