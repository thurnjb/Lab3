using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class CustomerPortal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustLogin"] != null)
            {
                btnLogOut.Visible = true;
                lblUserLoggedIn.ForeColor = Color.Green;
                lblUserLoggedIn.Text = Session["CustLogin"].ToString() + " logged in.";
            }
            else
            {
                btnLogOut.Visible = false;
                Session["InvalidCust"] = "You must first login to access the application.";
          
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("CustomerPortalLogin.aspx");
        }
    }
}