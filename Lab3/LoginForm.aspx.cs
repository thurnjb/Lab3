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
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
            SqlCommand LoginCommand = new SqlCommand();
            LoginCommand.Connection = dbConnection;
            LoginCommand.CommandType = System.Data.CommandType.StoredProcedure;
            LoginCommand.CommandText = "JeremyEzellLab3";
            LoginCommand.Parameters.AddWithValue("@Username", txtUserName.Text);

            dbConnection.Open();
            SqlDataReader loginResults = LoginCommand.ExecuteReader();
            if (loginResults.HasRows)
            {
                while (loginResults.Read())
                {
                    String testemp = loginResults["Employee"].ToString();
                    if (testemp.Equals("False"))
                    {
                        lblStatus.Text = "Username/Password incorrect";
                        break;
                    }

                    string storedHash = loginResults["PasswordHash"].ToString();

                    if (PasswordHash.ValidatePassword(txtPassWord.Text, storedHash))
                    {
                        Session["UserName"] = txtUserName.Text;
                        Response.Redirect("HomePageV2.aspx");
                    }
                    else
                    {
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "Username/Password incorrect";
                    }
                }
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Username/Password incorrect.";
            }
        }

        protected void btnCustLogin_Click(object sender, EventArgs e)
        {
            Session["UserName"] = "Customer";
            Response.Redirect("CustomerPortalLogin.aspx");
        }
    }
}