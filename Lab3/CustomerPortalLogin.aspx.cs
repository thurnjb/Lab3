using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    /*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/
    public partial class CustomerPortalLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("loggedout") == "true")
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "User has successfully logged out";
            }

            if (Session["CustInvalidUse"] != null)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = Session["CustInvalidUse"].ToString();
            }

        }
        protected void btnEmpLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
        }

        //This method checks the users information and logs them in
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if (Application["CustUsername"] != null & Application["CustPassword"] != null)
            //{
            //    String username = Application["CustUsername"].ToString();
            //    String password = Application["CustPassword"].ToString();

            //    if (txtUserName.Text != "" & txtPassWord.Text != "")
            //    {
            //        if (txtUserName.Text == username & txtPassWord.Text == password)
            //        {
            //            Session["CustLogin"] = tbUsernameCreate.Text;
            //            Response.Redirect("CustomerPortalService.aspx");
            //        }
            //    }
            //}

            //else
            //{
            //    lblStatus.Text = "Login Error";
            //}
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
                    if (testemp.Equals("True"))
                    {
                        lblAccountStatus.Text = "Invalid Login.";
                        break;
                    }

                    string storedHash = loginResults["PasswordHash"].ToString();

                    if (PasswordHash.ValidatePassword(txtPassWord.Text, storedHash))
                    {
                        Session["UserName"] = txtUserName.Text;
                        Response.Redirect("~/CustomerPortalService.aspx");
                    }
                }
            }
            else
            {
                lblAccountStatus.Text = "Username/Password incorrect.";
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if(tbFirstNameCreate.Text != "" & tbLastNameCreate.Text != "" & tbUsernameCreate.Text != "" & tbPasswordCreate.Text != "" & tbAddressCreate.Text != "" & tbPhoneCreate.Text != "" & tbHearCreate.Text != "")
            {
                Application["CustUsername"] = tbUsernameCreate.Text;
                Application["CustPassword"] = tbPasswordCreate.Text;
                Application["CustFName"] = tbFirstNameCreate.Text;
                Application["CustLName"] = tbLastNameCreate.Text;
                Application["CustAddress"] = tbAddressCreate.Text;
                Application["CustPhone"] = tbPhoneCreate.Text;
                Application["CustHear"] = tbHearCreate.Text;
                addUser(tbFirstNameCreate.Text, tbLastNameCreate.Text, tbHearCreate.Text, tbAddressCreate.Text, tbPhoneCreate.Text, tbUsernameCreate.Text, tbPasswordCreate.Text);
                lblAccountStatus.Text = "Account Successfully Created";

            }
            else
            {
                lblAccountStatus.Text = "Error: Text Fields Cannot Be Blank";
            }
        }

        protected void addUser(String userFirst, String userLast, String custHear, String userAddress, String userPhone, String userName, String userPass)
        {
            String sqlQueryPerson = "INSERT INTO Person (FirstName, LastName, Username, Employee, CustHear, CustAddress, CustPhone) VALUES (@FirstName, @LastName, @Username, @Employee, @CustHear, @CustAddress, @CustPhone)";
            String sqlQueryPass = "INSERT INTO Pass (UserID, Username, PasswordHash) VALUES (@UserID, @Username, @PasswordHash)";
            //String sqlQuery = "INSERT INTO Users (UserID, UserAddress, UserPhone, UserName, UserEmail, UserPass) VALUES (@UserID, @UserAddress, @UserPhone, @UserName, @UserEmail, @UserPass)";
            String connectionString = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(sqlQueryPerson, sqlConnect);

            sqlCommand.Parameters.AddWithValue("@FirstName", userFirst);
            sqlCommand.Parameters.AddWithValue("@LastName", userLast);
            sqlCommand.Parameters.AddWithValue("@CustHear", custHear);
            sqlCommand.Parameters.AddWithValue("@CustAddress", userAddress);
            sqlCommand.Parameters.AddWithValue("@CustPhone", userPhone);
            sqlCommand.Parameters.AddWithValue("@Username", userName);
            sqlCommand.Parameters.AddWithValue("@Employee", 0);
            //sqlCommand.Parameters.AddWithValue("@UserPass", userPass);

            sqlConnect.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand(sqlQueryPass, sqlConnect);
            sqlCommand.Parameters.AddWithValue("@UserID", getUserID());
            sqlCommand.Parameters.AddWithValue("@Username", userName);
            sqlCommand.Parameters.AddWithValue("@PasswordHash", PasswordHash.HashPassword(userPass));
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();
        }

        protected int getUserID()
        {
            String sqlQuery = "SELECT MAX(UserID) as UserID FROM Person";
            String connectionString = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnect);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            reader.Read();
            int userID;
            userID = (int)reader["UserID"];
            reader.Close();
            sqlConnect.Close();
            return userID;
        }

    }
}