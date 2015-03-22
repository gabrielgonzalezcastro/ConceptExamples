using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class DB
    {
        /// <summary>
        /// Last connection statistics gathered
        /// </summary>
        public static ConnectionStatistics LastStatistics { get; set; }

        /// <summary>
        /// Set to true to enable gathering statistics
        /// </summary>
        public static bool EnableStatistics
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["enableSqlStatistics"].ToString()); }
        }


        public static string ConnectionString
        {
            get
            {
                var conneStr = ConfigurationManager.ConnectionStrings["AWConnection"].ToString();

                //SqlConnectionStringBuilder is used to modify or create the connection string in runtime
                var sb = new SqlConnectionStringBuilder(conneStr);
                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;

                return sb.ToString();
            }
        }

        /// <summary>
        /// Property used to override the name of the application in the connectionString
        /// </summary>
        public static string ApplicationName { get; set; }

        /// <summary>
        /// Overrides the connection time out
        /// </summary>
        public static int ConnectionTimeout { get; set; }

        /// <summary>
        /// Returns an opened connection to the caller
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            //enable statistics
            conn.StatisticsEnabled = EnableStatistics;
            conn.StateChange += ConnOnStateChange;

            return conn;
        }

        private static void ConnOnStateChange(object sender, StateChangeEventArgs stateChangeEventArgs)
        {
           //take place when the connection state changes
            if (stateChangeEventArgs.CurrentState == ConnectionState.Closed)
            {
                if(((SqlConnection)sender).StatisticsEnabled)
                    LastStatistics = new ConnectionStatistics(((SqlConnection)sender).RetrieveStatistics());
            }
        }
    }
}
