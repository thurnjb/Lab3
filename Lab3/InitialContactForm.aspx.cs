using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class InitialContactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLookAt_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT CustomerID FROM Customer WHERE CustomerID=(SELECT max(CustomerID) FROM Customer)";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandText = sqlQuery;

            SqlDataReader queryResults = sqlCommand.ExecuteReader();

            while (queryResults.Read())
            {
                Session["Notification"] = queryResults["CustomerID"].ToString();
            }

            sqlConnect.Close();
            sqlQuery = "INSERT INTO NotificationTable(CustomerID) VALUES (" + Session["Notification"] + ")";
            sqlConnect.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlConnect;
            sqlcommand.CommandText = sqlQuery;
            sqlcommand.ExecuteNonQuery();

            Response.Redirect("HomePageV2.aspx");
        }

        protected void btnTicket_Click(object sender, EventArgs e)
        {

        }

        protected void btnAuction_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (txtFirstName.Text != "" & txtLastName.Text != "" &
                txtInitialContact.Text != "" & txtHeardFrom.Text != "" & txtPhone.Text != "" &
                txtEmail.Text != "" & txtAddress.Text != "" & txtRequestedService.Text != "")
            {
                String sqlCommitQuery = "INSERT INTO Customer(FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,RequestedService,SaveDate) VALUES (@FirstName, @LastName, @InitialContact, @HeardFrom, @Phone, @Email, @Address,@RequestedService, '" + DateTime.Now + "');";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlCommitQuery;
                sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
                sqlCommand.Parameters.AddWithValue("@InitialContact", HttpUtility.HtmlEncode(txtInitialContact.Text));
                sqlCommand.Parameters.AddWithValue("@HeardFrom", HttpUtility.HtmlEncode(txtHeardFrom.Text));
                sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtPhone.Text));
                sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtEmail.Text));
                sqlCommand.Parameters.AddWithValue("@Address", HttpUtility.HtmlEncode(txtAddress.Text));
                sqlCommand.Parameters.AddWithValue("@RequestedService", HttpUtility.HtmlEncode(txtRequestedService.Text));
                

                sqlCommand.ExecuteNonQuery();
                lblError.Text = "Successfully saved to database!";
            }

            else
            {
                lblError.Text = "Text fields cannot be blank";
            }
        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "Jimbo";
            txtLastName.Text = "Jam";
            txtInitialContact.Text = "Phone";
            txtHeardFrom.Text = "Referral";
            txtPhone.Text = "1234567890";
            txtEmail.Text = "JimboJam99@aol.com";
            txtAddress.Text = "99 Jimbo Ln.,Harrisonburg,VA,22801";
            txtRequestedService.Text = "Moving";
        }
    }
}