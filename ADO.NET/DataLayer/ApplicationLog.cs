using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataLayer
{
    public class ApplicationLog
    {
        /// <summary>
        /// Add a comment  to the application log in the database
        /// </summary>
        /// <param name="comment"></param>
        public static void AddWithExecuteNonQuery(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100) { Value = comment };
                    cmd.Parameters.Add(p1);

                    //ExecuteNonQuery returns the number of rows affected by THE LAST the sql statement run in the storeprocedure
                    //in order to return the rows affected the set not count shoul be off
                    int res = cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Add a comment and return the last ID generated
        /// </summary>
        /// <param name="comment"></param>
        public static void AddWithExecuteScalar(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog2";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100) { Value = comment };
                    cmd.Parameters.Add(p1);

                    //ExecuteScalar returns the first column of the first row in the result set returned by the query
                    //this statement is used with the sql Select SCOPE_IDENTITY() to get the last id inserted in the database
                    //The following sentence return the last id inserted in the table ApplicationLog
                    object res = cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Add a comment and use an output Parameter
        /// </summary>
        /// <param name="comment"></param>
        public static void AddWithOutputParameter(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog3";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100) { Value = comment };
                    var p2 = new SqlParameter("outid", System.Data.SqlDbType.Int);
                    p2.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();
                    object result = p2.Value;

                }
            }
        }

        /// <summary>
        /// Add a comment and use the RETURN VALUE
        /// </summary>
        /// <param name="comment"></param>
        public static void AddWithReturnValue(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog4";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100) { Value = comment };
                    cmd.Parameters.Add(p1);

                    var p2 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
                    p2.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();
                    object result = p2.Value;

                }
            }
        }

        /// <summary>
        /// Add a comment using XML  to the Stored procedure
        /// </summary>
        /// <param name="comment"></param>
        public static void AddUsingXml(string comment)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"AddAppLog5";
                    cmd.CommandType = CommandType.StoredProcedure;

                     var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100) { Value = comment };
                    cmd.Parameters.Add(p1);

                    //Sending the xml to the stored procedure
                    var p2 = new SqlParameter("extra_data", System.Data.SqlDbType.Xml); 
                    String xml = @"<data username=""{0}"" />";
                    xml = string.Format(xml, "Gabriel");
                    p2.Value = xml;
                    cmd.Parameters.Add(p2);

                    var p3 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
                    p3.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(p3);

                    cmd.ExecuteNonQuery();
                    object result = p2.Value;

                }
            }
        }

        /// <summary>
        /// Delete all comments for a specific application
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentForApp(string appName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DeleteAppLog";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("appName", System.Data.SqlDbType.NVarChar, 100) { Value = appName };
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Delete all comments using SQL transaction 
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentForAppUsingSqlTransaction(string appName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                //creation of the Transaction. This transaction if going to perform two actions(delete and add)
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DeleteAppLog";
                        cmd.CommandType = CommandType.StoredProcedure;

                        var p1 = new SqlParameter("appName", SqlDbType.NVarChar, 100) { Value = appName };
                        cmd.Parameters.Add(p1);

                        //Assign the transaction to the command
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                    }


                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"AddAppLog4";
                        cmd.CommandType = CommandType.StoredProcedure;

                        var p1 = new SqlParameter("comment", System.Data.SqlDbType.NVarChar, 100)
                        {
                            Value = "User Delete All comments using Transaction"
                        };
                        cmd.Parameters.Add(p1);

                        var p2 = new SqlParameter("ReturnValue", System.Data.SqlDbType.Int);
                        p2.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(p2);

                        //Assign the transaction to the command
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                        object result = p2.Value;

                    }

                    //if everything goes well, we can commit the changes
                    tran.Commit();

                }
                catch (Exception e)
                {
                    //if there is any error we can rollback the transaction
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Delete all comments using Transaction Scope (better than SQL transaction)
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentForAppUsingTransactionScope(string appName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                //delete app log
                DeleteCommentForApp(appName);
                
                //add a comment
                AddWithReturnValue("User Delete All comments using Transaction Scope");

                scope.Complete();
            }

        }

        /// <summary>
        /// Delete all comments for a specific application using transaction in the storeprocedure
        /// </summary>
        /// <param name="appName"></param>
        public static void DeleteCommentForAppUsingDatabaseTransaction(string appName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DeleteAppLogUsingDbTransaction";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("appName", System.Data.SqlDbType.NVarChar, 100) { Value = appName };
                    cmd.Parameters.Add(p1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Get all the entries of the application log table
        /// </summary>
        /// <returns></returns>
        public List<Log> GetApplicationLog()
        {
            var logs = new List<Log>();

            //Important to add the 'using' statement to dispose the object
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"GETAPPLOG";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //SqlDataReader is like a cursor that contains the data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(LoadLog(reader));
                        }
                    }
                }
            }

            return logs;
        }

        /// <summary>
        /// Get the log information reading the xml column
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public  DataTable GetLogUsingXml(string appName)
        {
            DataTable table = new DataTable("ApplicationLog");
            SqlDataAdapter da = null;

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("Select id, date_added, comment, application_name, extra_data.value('(/data/@username)[1]', 'nvarchar(100)') as username FROM applicationLog where application_name = @appname",conn);
                cmd.Parameters.Add(new SqlParameter("appname", SqlDbType.NVarChar, 100));
                cmd.Parameters["appname"].Value = appName;

                da = new SqlDataAdapter(cmd);
                int res = da.Fill(table);
            }

            return table;   
        }

        /// <summary>
        /// updates changes to the application in Mass
        /// </summary>
        /// <returns></returns>
        public DataTable updateLogChangesInBatchUsingXml(DataTable tableLog, string appName)
        {
            //Creation of the XML with all the changes
            string xml = "";
            string xmlRow = @"<change op=""{0}"" datetime=""{1}"" comment=""{2}"" id=""{3}"" />";
            DataTable changes = tableLog.GetChanges();

            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                    xml += string.Format(xmlRow, "UPDATE", row["date_added"].ToString(), row["comment"].ToString(),
                        row["id"].ToString());
            }

            //add the root node
            xml = "<changes>" + xml + "</changes>";

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateLogMass";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("xmlchanges", SqlDbType.Xml));
                cmd.Parameters["xmlchanges"].Value = xml;

                //persist changes in bulk
                cmd.ExecuteNonQuery();

                //refresh table
                tableLog = this.GetLogUsingXml(appName);
            }

            return tableLog;
        }


        /// <summary>
        /// updates changes to the application in Mass using MARS (Multiple active result sets)
        /// </summary>
        /// <returns></returns>
        public DataTable updateLogChangesInBatchUsingXmlAndMARS(DataTable tableLog)
        {
            DataSet dsRes = new DataSet();

            //Creation of the XML with all the changes
            string xml = "";
            string xmlRow = @"<change op=""{0}"" datetime=""{1}"" comment=""{2}"" id=""{3}"" />";
            DataTable changes = tableLog.GetChanges();

            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                    xml += string.Format(xmlRow, "UPDATE", row["date_added"].ToString(), row["comment"].ToString(),
                        row["id"].ToString());
            }

            //add the root node
            xml = "<changes>" + xml + "</changes>";

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateLogMass_2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("xmlchanges", SqlDbType.Xml));
                cmd.Parameters["xmlchanges"].Value = xml;

                //persist changes in bulk
               SqlDataAdapter da = new SqlDataAdapter(cmd);
                int res = da.Fill(dsRes);


                //refresh table
                tableLog = dsRes.Tables[1]; //read from the second table
            }

            return tableLog;
        }

        private Log LoadLog(SqlDataReader reader)
        {
            var log = new Log
            {
                Id = Int32.Parse(reader["Id"].ToString()),
                DateAdded = DateTime.Parse(reader["date_added"].ToString()),
                Comment = reader["comment"].ToString(),
                ApplicationName = reader["application_name"].ToString()
            };

            return log;
        }

    }
}
