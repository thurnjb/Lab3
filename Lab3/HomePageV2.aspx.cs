using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/

namespace Lab3
{
    public partial class HomePageV2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //This method goes to the Customer Records page
        protected void btnViewCustomerRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerRecordsV2.aspx");
        }

        //This method goes to the Service Ticket Records page
        protected void btnViewServiceTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceTicketRecords.aspx");
        }

        //This method goes to the Customer List page
        protected void btnViewCustomerList_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }

        //This method goes to the Ticket History Page
        protected void btnViewTicketHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicketHistory.aspx");
        }

        protected void btnNotifications_Click(object sender, EventArgs e)
        {
            Response.Redirect("NotificationPage.aspx");
        }
    }
}