using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    /*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/
    public partial class AssignAuction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(ddlAuction.SelectedValue != null)
            {
                if(Session["ServiceTicketID"] != null)
                {
                    if(Session["ServiceType"].ToString() == "Auction")
                    {
                        String sqlQuery = "UPDATE ServiceTicket SET AuctionID = " + ddlAuction.SelectedValue + " WHERE ServiceTicketID = " + Session["ServiceTicketID"] + ";";

                        SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                        sqlConnect.Open();
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = sqlConnect;
                        sqlCommand.CommandText = sqlQuery;

                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();

                        sqlQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'Ticket assigned to auction')";
                        sqlConnect.Open();
                        sqlCommand.Connection = sqlConnect;
                        sqlCommand.CommandText = sqlQuery;

                        sqlCommand.ExecuteNonQuery();

                        ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
                    }
                    else
                    {
                        lblErrorMsg.Text = "Selected ticket must be for an auction!";
                    }
                }
                else
                {
                    lblErrorMsg.Text = "No ticket was selected!";
                }
            }
            else
            {
                lblErrorMsg.Text = "No auction was selected!";
            }
        }
    }
}