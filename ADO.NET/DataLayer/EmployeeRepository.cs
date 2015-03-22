using System.Data;
using System.Security.Cryptography;
using Domain;
using System;
using System.Data.SqlClient;

namespace DataLayer
{
    public class EmployeeRepository
    {

        /// <summary>
        /// Returns a Employee using a StoreProcedure (good Practise: better performance and security)
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployee(int employeeId)
        {
            var employee = new Employee();

            //Important to add the 'using' statement to dispose the object
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"GETEMPPLOYEEDETAILS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("businessEntityId", System.Data.SqlDbType.Int) {Value = employeeId};
                    cmd.Parameters.Add(p1);

                    //SqlDataReader is like a cursor that contains the data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LoadEmployee(employee, reader);
                        }
                    }
                }
            }

            return employee;
        }

        /// <summary>
        /// Returns an Employee using Inline SQL (BAD PRACTICE)
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployeeDoNoTCall(int employeeId)
        {
            var employee = new Employee();

            //Important to add the 'using' statement to dispose the object
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from HumanResources.Employee E
			                            JOIN Person.Person P ON E.BusinessEntityId = P.BusinessEntityId AND P.PersonType = 'EM'
			                            JOIN HumanResources.EmployeeDepartmentHistory EH ON E.BusinessEntityId = EH.BusinessEntityId
			                            JOIN HumanResources.Department D ON D.DepartmentId = EH.DepartmentId
                                        where
	                                        E.BusinessEntityId = {0}";

                    cmd.CommandText = string.Format(cmd.CommandText, employeeId);
                    //SqlDataReader is like a cursor that contains the data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LoadEmployee(employee, reader);
                        }
                    }
                }
            }

            return employee;
        }

        /// <summary>
        /// Update the name of the department
        /// </summary>
        /// <param name="departmentId"></param>
        public void UpdateDepartmentName(int departmentId, string newDepartmentName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UpdateDepartmentName";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("id", System.Data.SqlDbType.Int) { Value = departmentId };
                    cmd.Parameters.Add(p1);

                    var p2 = new SqlParameter("name", System.Data.SqlDbType.NVarChar, 100) { Value = newDepartmentName };
                    cmd.Parameters.Add(p2);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Update department name with concurrency check using WHERE clause 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="newDepartmentName"></param>
        /// <param name="oldDepartmentName"></param>
        public void UpdateDepartmentNameWithConcurrencyCheckWithWhereClause(int departmentId, string newDepartmentName, string oldDepartmentName)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UpdateDepartmentNameWithConcurrencyCheckWhere";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var p1 = new SqlParameter("id", System.Data.SqlDbType.Int) { Value = departmentId };
                    cmd.Parameters.Add(p1);

                    var p2 = new SqlParameter("name", System.Data.SqlDbType.NVarChar, 100) { Value = newDepartmentName };
                    cmd.Parameters.Add(p2);

                    var p3 = new SqlParameter("oldname", System.Data.SqlDbType.NVarChar, 100) { Value = oldDepartmentName };
                    cmd.Parameters.Add(p3);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Throw a custom exception. Is used to show how to handle a exception throw from the database
        /// </summary>
        public void CallStoreProcedureThatThrowACustomError()
        {
            //Important to add the 'using' statement to dispose the object
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SP_ThrowException";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void LoadEmployee(Employee employee, SqlDataReader reader)
        {
            employee.EmployeeId = Int32.Parse(reader["BusinessEntityId"].ToString());
            employee.FirstName = reader["FirstName"].ToString();
            employee.LastName = reader["LastName"].ToString();
            employee.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
            employee.DepartmentName = reader["Name"].ToString();
        }
    }
}
