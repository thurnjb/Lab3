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
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        protected void grdNotifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["NotificationID"] = grdNotifications.SelectedValue;
            lblSuccessMsg.Text = "Customer Selected!";
            lblErrorMsg.Text = "";
        }

        //
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtCalendarDate.Text = Calendar1.SelectedDate.Date.ToString();
            lblErrorMsg.Text = "";
        }

        //This method adds the selected date in the textbox to the listbox
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lstbxPotentialDates.Items.Add(txtCalendarDate.Text);
            txtCalendarDate.Text = "";
            lblErrorMsg.Text = "";
        }
        //This method takes the dates in the listbox and makes new records in the notificationstable_dates table for each date
        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            int lstbxCount = lstbxPotentialDates.Items.Count;
            if(lstbxPotentialDates.Items.Count != 0 & grdNotifications.SelectedValue != null)
            {
                for(int i = 0; i < lstbxCount; i++)
                {
                    String sqlQuery = "INSERT INTO NotificationTable_Dates(NotificationID, PotentialDate) VALUES (" + grdNotifications.SelectedValue + ", '" + lstbxPotentialDates.Items[i].ToString() + "')";

                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlQuery;

                    sqlCommand.ExecuteNonQuery();
                }
                for(int k = lstbxCount - 1; k >= 0; k--)
                {
                    lstbxPotentialDates.Items.RemoveAt(k);
                }
            }
            else
            {
                lblErrorMsg.Text = "Must select a notification and dates!";
            }
            lblSuccessMsg.Text = "";
        }

        
    }
}