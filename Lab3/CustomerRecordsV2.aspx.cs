using System;
using System.Collections.Generic;
using System.Configuration;
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
                String[] info = getCustomerInfo(Application["CustUsername"].ToString());
                txtFirstName.Text = Application["CustFName"].ToString();
                txtLastName.Text = Application["CustLName"].ToString();
                txtInitialContact.Text = "Web App";
                txtHeardFrom.Text = info[0];
                txtPhone.Text = info[1];
                txtEmail.Text = Application["CustUsername"].ToString();
                txtAddress.Text = Application["CustAddress"].ToString();
                txtSaveDate.Text = "";
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                con.Open();
                String Username = Application["CustUsername"].ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM Notifications WHERE Username='" + Username + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
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
        protected String[] getCustomerInfo(String userName)
        {
            String[] info = new String[2];
            String constr = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CustHear, CustPhone FROM Person WHERE Username = @Username";
            cmd.Parameters.AddWithValue("@Username", userName);
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            info[0] = reader["CustHear"].ToString();
            info[1] = reader["CustPhone"].ToString();
            reader.Close();
            con.Close();
            return info;
            //txtHeardFrom.Text = Application["CustHear"].ToString();
            //txtPhone.Text = Application["CustPhone"].ToString();
        }
    }
}