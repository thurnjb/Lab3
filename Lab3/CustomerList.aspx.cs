using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2
{
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
    }
}