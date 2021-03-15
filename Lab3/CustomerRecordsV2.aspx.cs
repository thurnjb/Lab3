using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/

namespace Lab3
{
    public partial class CustomerRecordsV2 : System.Web.UI.Page
    {
        private static int current = -1;
        private static DataSet dataset = new DataSet("Customers");
        public static String sqlCommitQuery;

        //Page_Load method calls connectToData method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                current = -1;
                connectToData();
            }

            if(Application["NewAdd"] != null)
            {
                txtFirstName.Text = Application["CustFName"].ToString();
                txtLastName.Text = Application["CustLName"].ToString();
                txtInitialContact.Text = "Web App";
                txtHeardFrom.Text = Application["CustHear"].ToString();
                txtPhone.Text = Application["CustPhone"].ToString();
                txtEmail.Text = Application["CustUsername"].ToString();
                txtAddress.Text = Application["CustAddress"].ToString();
                txtDestAddress.Text = "";
                txtSaveDate.Text = "";
            }
        }

        //connectToData method opens a sql connection and fills dataset with the query
        protected void connectToData()
        {
            String sqlQuery = "Select * from Customer";

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.TableMappings.Add("Table", "Customer");

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = sqlQuery;
            adapter.SelectCommand = command;
            if(dataset.Tables.Count == 0)
            {
                adapter.Fill(dataset);
            }
        }

        //Redirect to home page
        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        //btnPopulate_Click method fills textboxes with data from the dataset on Populate button click
        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            current = -1;
            txtFirstName.Text = "Jimbo";
            txtLastName.Text = "Jam";
            txtInitialContact.Text = "Phone";
            txtHeardFrom.Text = "Email";
            txtPhone.Text = "1234567890";
            txtEmail.Text = "JimJam99@aol.com";
            txtAddress.Text = "99 Jimbob Ln.,Harrisonburg,Virginia,22801";
            txtDestAddress.Text = "800 S Main St.,Harrisonburg,Virginia,22801";
            txtSaveDate.Text = "01/01/1999";
        }

        //btnSave_Click method saves the data in the textboxes to a sql String and executes the query
        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            if (txtFirstName.Text != "" & txtLastName.Text != "" &
                txtInitialContact.Text != "" & txtHeardFrom.Text != "" & txtPhone.Text != "" &
                txtEmail.Text != "" & txtAddress.Text != "")
            {
                sqlCommitQuery = "INSERT INTO Customer(FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,DestAddress,SaveDate) VALUES (@FirstName, @LastName, @InitialContact, @HeardFrom, @Phone, @Email, @Address, @DestAddress, '" + DateTime.Now + "');";

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
                sqlCommand.Parameters.AddWithValue("@DestAddress", HttpUtility.HtmlEncode(txtDestAddress.Text));

                sqlCommand.ExecuteNonQuery();
                lblErrorMsg.Text = "Successfully saved to database!";

                if(Application["NewAdd"] != null)
                {
                    Response.Redirect("ServiceTicketRecords.aspx");
                }
            }
            else
            {
                lblErrorMsg.Text = "Text field cannot be blank";
            }
        }

        //btnClear_Click method clears all textboxes of data on Clear button click
        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtInitialContact.Text = "";
            txtHeardFrom.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtDestAddress.Text = "";
            txtSaveDate.Text = "";
            current = -1;
        }
    }
}