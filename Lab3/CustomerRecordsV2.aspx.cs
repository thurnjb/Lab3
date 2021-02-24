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

namespace Lab2
{
    public partial class CustomerRecordsV2 : System.Web.UI.Page
    {
        private static SqlDataReader queryResults;
        private static int current = -1;
        private static DataSet dataset = new DataSet("Customers");
        public static String sqlCommitQuery;

        //Page_Load method opens a sql connection and counts # of records in the customer table then calls connectToData method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                current = -1;
                connectToData();
            }
        }

        //connectToData method opens a sql connection and fills dataset with the query
        protected void connectToData()
        {
            String sqlQuery = "Select * from Customer";

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab2"].ConnectionString);

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
            current = 0;
            txtFirstName.Text = dataset.Tables[0].Rows[current]["FirstName"].ToString();
            txtLastName.Text = dataset.Tables[0].Rows[current]["LastName"].ToString();
            txtInitialContact.Text = dataset.Tables[0].Rows[current]["InitialContact"].ToString();
            txtHeardFrom.Text = dataset.Tables[0].Rows[current]["HeardFrom"].ToString();
            txtPhone.Text = dataset.Tables[0].Rows[current]["Phone"].ToString();
            txtEmail.Text = dataset.Tables[0].Rows[current]["Email"].ToString();
            txtAddress.Text = dataset.Tables[0].Rows[current]["Address"].ToString();
            txtDestAddress.Text = dataset.Tables[0].Rows[current]["DestAddress"].ToString();
            txtSaveDate.Text = dataset.Tables[0].Rows[current]["SaveDate"].ToString();
        }

        //btnSave_Click method saves the data in the textboxes to a sql String on Save button click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            if (txtFirstName.Text != "" & txtLastName.Text != "" &
                txtInitialContact.Text != "" & txtHeardFrom.Text != "" & txtPhone.Text != "" &
                txtEmail.Text != "" & txtAddress.Text != "")
            {
                sqlCommitQuery = "INSERT INTO Customer(FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,DestAddress,SaveDate) VALUES ('" + txtFirstName.Text +
                "', '" + txtLastName.Text + "', '" + txtInitialContact.Text + "', '" + txtHeardFrom.Text + "', '" +
                txtPhone.Text + "', '" + txtEmail.Text + "', '" + txtAddress.Text + "', '" + txtDestAddress.Text + "', '" + DateTime.Now + "');";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab2"].ConnectionString);

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlCommitQuery;

                sqlCommand.ExecuteNonQuery();
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

        //btnPrevious_Click method goes back one record in the dataset on Previous button click
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                current--;
                txtFirstName.Text = dataset.Tables[0].Rows[current]["FirstName"].ToString();
                txtLastName.Text = dataset.Tables[0].Rows[current]["LastName"].ToString();
                txtInitialContact.Text = dataset.Tables[0].Rows[current]["InitialContact"].ToString();
                txtHeardFrom.Text = dataset.Tables[0].Rows[current]["HeardFrom"].ToString();
                txtPhone.Text = dataset.Tables[0].Rows[current]["Phone"].ToString();
                txtEmail.Text = dataset.Tables[0].Rows[current]["Email"].ToString();
                txtAddress.Text = dataset.Tables[0].Rows[current]["Address"].ToString();
                txtDestAddress.Text = dataset.Tables[0].Rows[current]["DestAddress"].ToString();
                txtSaveDate.Text = dataset.Tables[0].Rows[current]["SaveDate"].ToString();
            }
            catch (Exception)
            {
                lblErrorMsg.Text = "No more previous data";
                current++;
            }
        }

        //btnNext_Click method goes forward one record in the dataset on Next button click
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                lblErrorMsg.Text = "";
                current++;
                txtFirstName.Text = dataset.Tables[0].Rows[current]["FirstName"].ToString();
                txtLastName.Text = dataset.Tables[0].Rows[current]["LastName"].ToString();
                txtInitialContact.Text = dataset.Tables[0].Rows[current]["InitialContact"].ToString();
                txtHeardFrom.Text = dataset.Tables[0].Rows[current]["HeardFrom"].ToString();
                txtPhone.Text = dataset.Tables[0].Rows[current]["Phone"].ToString();
                txtEmail.Text = dataset.Tables[0].Rows[current]["Email"].ToString();
                txtAddress.Text = dataset.Tables[0].Rows[current]["Address"].ToString();
                txtDestAddress.Text = dataset.Tables[0].Rows[current]["DestAddress"].ToString();
                txtSaveDate.Text = dataset.Tables[0].Rows[current]["SaveDate"].ToString();
            }
            catch (Exception)
            {
                lblErrorMsg.Text = "No more data left";
                current--;
            }
        }
    }
}