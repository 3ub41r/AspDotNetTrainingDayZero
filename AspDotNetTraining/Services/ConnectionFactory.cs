using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspDotNetTraining.Services
{
    public class ConnectionFactory
    {
        private string connectionString;

        public ConnectionFactory()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        /// <summary>
        /// Sila komen :)
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}