using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class NotificationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Application["Request"] != null)
            {
                btnAccept.Visible = true;
                btnDeny.Visible = true;
                lblStatus.Text = "New Request from Customer: " +  Application["CustUsername"].ToString();
                lblDetail.Text = "Customer Name: " + Application["CustFName"].ToString() + Application["CustLName"].ToString();
                lblDetail1.Text = "Customer Address: " + Application["CustAddress"].ToString();
                if(Application["ServiceType"].ToString() == "1")
                {
                    lblService.Text = "Service Type: Moving";
                }
                else
                {
                    lblService.Text = "Service Type: Auction";
                }
                lblService1.Text = "Service Description: " + Application["ServiceDesc"];
                lblService2.Text = "Service Date: " + Application["ServiceDate"];

                
            }

            else
            {
                lblStatus.Text = "No New Notifications";
                lblDetail.Text = "";
                lblDetail1.Text = "";
                lblService.Text = "";
                lblService1.Text = "";
                lblService2.Text = "";

                if(Application["Added"] != null)
                {
                    lblDetail.Text = "New Customer and Service Ticket Successfully Added";
                }
            }
        }

        protected void gridViewCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = grdNotifications.Rows[index];
                Application["CustUsername"] = selectedRow.Cells[2].Text;
                Application["CustFName"] = selectedRow.Cells[3].Text;
                Application["CustLName"] = selectedRow.Cells[4].Text;
                Application["CustService"] = selectedRow.Cells[5].Text;
                Application["DateNeeded"] = selectedRow.Cells[6].Text;
                Application["Description"] = selectedRow.Cells[7].Text;
                Application["CustAddress"] = selectedRow.Cells[8].Text;
                Application["NewAdd"] = "yes";

                Response.Redirect("CustomerRecordsV2.aspx");

            }
            else if (e.CommandName == "Deny")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = grdNotifications.Rows[index];
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                con.Open();
                String Username = selectedRow.Cells[2].Text;
                SqlCommand cmd = new SqlCommand("DELETE FROM Notifications WHERE Username='" + Username + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                lblDetail.Text = "Notification removed!";
                Response.Redirect("NotificationPage.aspx");
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            Application["NewAdd"] = "yes";
            Response.Redirect("CustomerRecordsV2.aspx");
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            Application["Request"] = null;

 
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }
    }
}