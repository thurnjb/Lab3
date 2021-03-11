using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    /*Jay Thurn, Ryan Booth, John Lee
    Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //This method returns to the home page
        protected void btnViewHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        //This method refreshes the page to remove the detailsview and update gridview
        protected void dtlVwUpdateCustomer_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }

        //This method refreshes the page on cancel click to remove detailsview
        protected void dtlVwUpdateCustomer_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("CustomerList.aspx");
            }
        }
    }
}