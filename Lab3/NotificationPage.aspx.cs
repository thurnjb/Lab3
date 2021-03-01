using System;
using System.Collections.Generic;
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