using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/

namespace Lab3
{
    public partial class AssignEmployee : System.Web.UI.Page
    {
        private static String sqlQuery;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //This method updates a ServiceTicket with a new employee that was selected from a ddl
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(ddlEmployee.SelectedValue != null)
            {
                if (Session["ServiceTicketID"] != null)
                {
                    sqlQuery = "UPDATE ServiceTicket SET InitiatingEmployeeID=" + ddlEmployee.SelectedValue + " WHERE ServiceTicketID=" + Session["ServiceTicketID"] + ";";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlQuery;

                    sqlCommand.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
                }
                else
                {
                    lblErrorMsg.Text = "No ticket was selected!";
                }
            }
            else
            {
                lblErrorMsg.Text = "No employee was selected!";
            }
        }

        //This method closes the popup window
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
        }
    }
}