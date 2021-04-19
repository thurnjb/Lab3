using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

/*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/

namespace Lab3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        //On page load if there is no UserName in session, then returns to login page
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserName"] != null)
            {
                btnLogOut.Visible = true;
                lblUserLoggedIn.ForeColor = Color.Gray;
                lblUserLoggedIn.Text = Session["UserName"].ToString() + " logged in.";
            }
            else
            {
                btnLogOut.Visible = false;
                Session["InvalidUse"] = "You must first login to access the application.";
                Response.Redirect("LoginForm.aspx");
            }
        }

        //This method abandons the session and returns to login page
        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginForm.aspx?loggedout=true");
        }
    }
}