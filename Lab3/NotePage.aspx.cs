using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/

namespace Lab2
{
    public partial class NotePage : System.Web.UI.Page
    {
        private static int count = 0;

        //On page load, connect to data
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connectToData();
            }
            
        }

        //Gets count of all records in Notes table
        protected void connectToData()
        {
            String sqlQuery = "SELECT * FROM NOTES";

            SqlConnection connection = new SqlConnection("Server=Localhost;Database=Lab2;Trusted_Connection=Yes;");

            connection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            while (queryResults.Read())
            {
                count++;
            }
            queryResults.Close();
            connection.Close();
        }

        //Creates an insert sql query and executes
        protected void btnSaveNote_Click(object sender, EventArgs e)
        {
            if(txtNoteContent.Text != "" & txtNoteTitle.Text != "")
            {
                String sqlQuery = "INSERT INTO Notes VALUES (" + ++count + ", " + Session["SelectedTicket"] + ", '" + txtNoteTitle.Text + "', '" + txtNoteContent.Text + "');";

                SqlConnection sqlConnect = new SqlConnection("Server=Localhost;Database=Lab3;Trusted_Connection=Yes;");

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlQuery;

                sqlCommand.ExecuteNonQuery();
            }
            else
            {
                lblErrorMsg.Text = "Note Title and Note Content must be filled!";
            }
        }

        //Returns to home page
        protected void btnViewHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }
    }
}