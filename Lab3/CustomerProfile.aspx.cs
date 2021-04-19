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
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           if (txtCustomerFirstName.Text != "" & txtCustomerLastName.Text !="" &
                txtEmail.Text != "" & txtHeardFrom.Text != "" & txtInitialContact.Text != "" &
                txtPhone.Text != "" & txtAddress.Text != "")
            {
                String sqlCommitQuery = "INSERT INTO Customer(FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address) VALUES (@FirstName, @LastName, @InitialContact, @HeardFrom, @Phone, @Email, @Address);";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlCommitQuery;
                sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtCustomerFirstName.Text));
                sqlCommand.Parameters.AddWithValue("@LastName", HttpUtility.HtmlEncode(txtCustomerLastName.Text));
                sqlCommand.Parameters.AddWithValue("@InitialContact", HttpUtility.HtmlEncode(txtInitialContact.Text));
                sqlCommand.Parameters.AddWithValue("@HeardFrom", HttpUtility.HtmlEncode(txtHeardFrom.Text));
                sqlCommand.Parameters.AddWithValue("@Phone", HttpUtility.HtmlEncode(txtPhone.Text));
                sqlCommand.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(txtEmail.Text));
                sqlCommand.Parameters.AddWithValue("@Address", HttpUtility.HtmlEncode(txtAddress.Text));
                


                sqlCommand.ExecuteNonQuery();
            }
        }

        protected void lnkbtnAuctionForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceTicketRecords.aspx");
        }

        protected void lnkbtnMoveForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceTicketRecords.aspx");
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
    }
}