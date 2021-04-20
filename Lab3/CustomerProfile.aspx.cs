using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab3
{
    public partial class CustomerProfile : System.Web.UI.Page
    {

        private static SqlDataReader queryResults;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            String sqlQuery = "SELECT * FROM CUSTOMER WHERE CustomerID = " + Session["CustomerID"];

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandText = sqlQuery;

            queryResults = sqlCommand.ExecuteReader();

            if (queryResults.Read())
            {
                txtCustomerFirstName.Text = queryResults["FirstName"].ToString();
                txtCustomerLastName.Text = queryResults["LastName"].ToString();
                txtEmail.Text = queryResults["Email"].ToString();
                txtHeardFrom.Text = queryResults["HeardFrom"].ToString();
                txtInitialContact.Text = queryResults["InitialContact"].ToString();
                txtPhone.Text = queryResults["Phone"].ToString();
                txtAddress.Text = queryResults["Address"].ToString();
            }
            sqlConnect.Close();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("./");
            // Get the name of the file that is posted.
            strFileName = oFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (oFile.Value != "")
            {
                // Create the directory if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    lblImageUpload.Text = strFileName + " already exists on the server!";
                }
                else
                {
                    oFile.PostedFile.SaveAs(strFilePath);
                    lblImageUpload.Text = strFileName + " has been successfully uploaded.";
                }
            }
            else
            {
                lblImageUpload.Text = "Click 'Browse' to select the file to upload.";
            }
            //// Display the result of the upload.
            //frmConfirmation.Visible = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerFirstName.Text != "" & txtCustomerLastName.Text != "" &
                txtEmail.Text != "" & txtHeardFrom.Text != "" & txtInitialContact.Text != "" &
                txtPhone.Text != "" & txtAddress.Text != "")
            {
                String sqlQuery = "UPDATE Customer SET FirstName = '" + txtCustomerFirstName.Text + "', LastName = '" +
                    txtCustomerLastName.Text + "', Email = '" + txtEmail.Text + "',Phone = '" + txtPhone.Text + "', HeardFrom = '" +
                    txtHeardFrom.Text + "', InitialContact = '" + txtInitialContact.Text + "', Address = '" + txtAddress.Text + "' WHERE CustomerID = " + Session["CustomerID"] + ";";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlQuery;

                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
        }

        protected void btnViewTickets_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ticket.aspx");
        }

        protected void btnScheduleLookAt_Click(object sender, EventArgs e)
        {
            String sqlQuery = "INSERT INTO LookAtNotification(CustomerID, SaveDate) VALUES (@CustomerID,@SaveDate)";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            sqlConnect.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlConnect;
            sqlcommand.CommandText = sqlQuery;
            sqlcommand.Parameters.AddWithValue("@CustomerID", Session["CustomerID"]);
            sqlcommand.Parameters.AddWithValue("@SaveDate", DateTime.Now.ToString());
            sqlcommand.ExecuteNonQuery();
            sqlConnect.Close();

            Response.Redirect("HomePageV2.aspx");
        }

        protected void btnCreateMove_Click(object sender, EventArgs e)
        {
            Response.Redirect("MoveAssessmentForm.aspx");
        }

        protected void btnCreateAuction_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuctionAssessment.aspx");
        }
    }
}