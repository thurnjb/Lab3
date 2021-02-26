using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/

namespace Lab3
{
    public partial class LoginForm : System.Web.UI.Page
    {

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

        //This method tests the entered username and password against the AUTH Database and displays accordingly
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT COUNT(1) FROM Credentials WHERE UserName=@UserName AND Password=@Password";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);

            sqlCommand.Parameters.AddWithValue("UserName", HttpUtility.HtmlEncode(txtUserName.Text));
            sqlCommand.Parameters.AddWithValue("Password", HttpUtility.HtmlEncode(txtPassWord.Text));

            sqlConnect.Open();

            int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

            if(count == 1)
            {
                Session["UserName"] = txtUserName.Text;
                Response.Redirect("HomePageV2.aspx");
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Login Failed: issue with Username and/or Password";
            }
        }
    }
}