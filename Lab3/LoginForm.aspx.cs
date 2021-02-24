using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Jay Thurn
My submission of this assignment indicates that I have neither received nor given unauthorized assistance in writing this program. All design and coding is my own work.*/

namespace Lab2
{
    public partial class LoginForm : System.Web.UI.Page
    {

        private Employee currentUser;

        //On page load, if the page loads with loggedout=true, display user logged out. If user tries to access application without logging in, displays invaliduse session string
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Get("loggedout") == "true")
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "User has successfully logged out";
            }

            if(Session["InvalidUse"] != null)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = Session["InvalidUse"].ToString();
            }
        }

        //This method tests the entered password and displays accordingly
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtPassWord.Text == "dukedog")
            {
                currentUser = new Employee(txtUserName.Text, txtPassWord.Text);
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Successful login for " + currentUser.UserName;
                Session["UserName"] = txtUserName.Text;
                Response.Redirect("HomePageV2.aspx");
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Login Failed: issue with username and/or password";
            }
        }
    }
}