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
                txtEmail.Text != "" & txtAddress.Text != "")
            {
                String sqlCommitQuery = "INSERT INTO Customer(FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,SaveDate) VALUES (@FirstName, @LastName, @InitialContact, @HeardFrom, @Phone, @Email, @Address,  '" + DateTime.Now + "');";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlCommitQuery;
                sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtLastName.Text));
                sqlCommand.Parameters.AddWithValue("@InitialContact", HttpUtility.HtmlEncode(txtInitialContact.Text));
                sqlCommand.Parameters.AddWithValue("@HeardFrom", HttpUtility.HtmlEncode(txtHeardFrom.Text));
                sqlCommand.Parameters.AddWithValue("Phone", HttpUtility.HtmlEncode(txtPhone.Text));
                sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtEmail.Text));
                sqlCommand.Parameters.AddWithValue("@Address", HttpUtility.HtmlEncode(txtAddress.Text));
                

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
    }
}