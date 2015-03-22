using DataLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DB.ApplicationName = "Web Demo App";
                DB.ConnectionTimeout = 30;
                var conn = DB.GetSqlConnection();
                RefreshAppLog();
            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }

        protected void linkBtnGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeRepository = new EmployeeRepository();
                var employee = employeeRepository.GetEmployee(int.Parse(txtEmployeeId.Text));
                ShowStatistics(DB.LastStatistics);

                if (employee != null)
                {
                    txtFirstName.Text = employee.FirstName;
                    txtLastName.Text = employee.LastName;
                    txtDepartment.Text = employee.DepartmentName;
                    lblDepartmentId.Text = employee.DepartmentId.ToString();
                    hdfDepartmentName.Value = employee.DepartmentName;

                }

                //ApplicationLog.AddWithExecuteNonQuery("Searched for user id: " + txtEmployeeId.Text);
                //ApplicationLog.AddWithExecuteScalar("Searched for user id: " + txtEmployeeId.Text);
                //ApplicationLog.AddWithOutputParameter("Searched for user id: " + txtEmployeeId.Text);
                //ApplicationLog.AddWithReturnValue("Searched for user id: " + txtEmployeeId.Text);
                ApplicationLog.AddUsingXml("Searched for user id: " + txtEmployeeId.Text);

                RefreshAppLog();
            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }



        protected void btnDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationLog.DeleteCommentForApp("Web Demo App");
                RefreshAppLog();
            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }

        protected void linkBtnUpdateDeptName_Click(object sender, EventArgs e)
        {
            try
            {
                //A search must first be performed
                if (txtDepartment.Text.Length > 0 && txtEmployeeId.Text.Length > 0)
                {
                    var employeeRepo = new EmployeeRepository();

                    int deptId = int.Parse(lblDepartmentId.Text);
                    employeeRepo.UpdateDepartmentName(deptId, txtDepartment.Text);
                    ShowStatistics(DB.LastStatistics);

                }
            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }

        protected void btnSqlException_Click(object sender, EventArgs e)
        {
            try
            {
                var employeeRepo = new EmployeeRepository();
                employeeRepo.CallStoreProcedureThatThrowACustomError();
            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }

        protected void linkBtnUpdateWithConcurrencyCheckWithWhere_Click(object sender, EventArgs e)
        {
            try
            {
                //A search must first be performed
                if (txtDepartment.Text.Length > 0 && txtEmployeeId.Text.Length > 0)
                {
                    var employeeRepo = new EmployeeRepository();

                    int deptId = int.Parse(lblDepartmentId.Text);
                    employeeRepo.UpdateDepartmentNameWithConcurrencyCheckWithWhereClause(deptId, txtDepartment.Text, hdfDepartmentName.Value);
                    ShowStatistics(DB.LastStatistics);

                    //reload the data to refresh the hidden fields
                    linkBtnGetEmployee_Click(sender,null);

                }
            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }

        protected void btnDeleteUsingSQLTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationLog.DeleteCommentForAppUsingSqlTransaction("Web Demo App");
                RefreshAppLog();

            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }

        protected void btnDeleteUsingTransactionScope_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationLog.DeleteCommentForAppUsingTransactionScope("Web Demo App");
                RefreshAppLog();

            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }

        protected void btnDeleteUsingDatabaseTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationLog.DeleteCommentForAppUsingDatabaseTransaction("Web Demo App");
                RefreshAppLog();

            }
            catch (SqlException sqlex)
            {
                ShowMeesage(sqlex.Message);
            }
        }


        protected void btnUpdateLog_Click(object sender, EventArgs e)
        {
            var data = (DataTable)GridViewAppLog.DataSource;
            foreach (DataRow row in data.Rows)
            {
                row["comment"] = "comment update in code at " + DateTime.UtcNow;
                row["date_added"] = DateTime.Now;
                Thread.Sleep(new TimeSpan(0,0,0,1));
            }

            var appLog = new ApplicationLog();
            //var result = appLog.updateLogChangesInBatchUsingXml(data, "Web Demo App");
            var result = appLog.updateLogChangesInBatchUsingXmlAndMARS(data);

            GridViewAppLog.DataSource = result;
            GridViewAppLog.DataBind();
        }


        #region Private Methods

        private void ShowStatistics(ConnectionStatistics connectionStatistics)
        {
            if (DB.EnableStatistics)
            {
                ListBoxStats.Items.Clear();
                foreach (var key in connectionStatistics.OriginalStats.Keys)
                {
                    var listItem = new ListItem();
                    listItem.Text = key.ToString() + " " + connectionStatistics.OriginalStats[key].ToString();
                    ListBoxStats.Items.Add(listItem);
                }
            }
        }

        private void ShowMeesage(string message)
        {
            var myScript = "\n<script type=\"text/javascript\" language=\"Javascript\" id=\"EventScriptBlock\">\n";
            myScript += "alert('" + message + "');";
            myScript += "\n\n </script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", myScript, false);
        }

        private void RefreshAppLog()
        {
            var appLog = new ApplicationLog();
            //GridViewAppLog.DataSource = appLog.GetApplicationLog();
            GridViewAppLog.DataSource = appLog.GetLogUsingXml("Web Demo App");
            GridViewAppLog.DataBind();
        }

        #endregion


       

       

       

        


        


    }
}