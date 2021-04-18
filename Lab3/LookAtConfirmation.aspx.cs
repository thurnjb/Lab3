using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class LookAtConfirmation : System.Web.UI.Page
    {
        private static DataTable grdVwNotification = new DataTable();
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
            grdVwNotification.Clear();

            String sqlQuery = "SELECT L.ID, C.FirstName + ' ' + C.LastName AS CustomerName, L.PotentialDates, L.SaveDate FROM Customer C, LookAtNotifConfirm L, LookAtNotification N WHERE L.NotificationID = N.NotificationID AND N.CustomerID = C.CustomerID AND L.ID = " + Session["LookAtConfID"];

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqlConnect.Open();

            sqlAdapter.Fill(grdVwNotification);

            grdNotification.DataSource = grdVwNotification;
            grdNotification.DataBind();

            String query = "SELECT C.CustomerID, C.Address FROM Customer C, LookAtNotification N, LookAtNotifConfirm L WHERE L.NotificationID = N.NotificationID AND N.CustomerID = C.CustomerID AND L.ID = " + Session["LookAtConfID"];

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = query;

            connection.Open();
            queryResults = sqlCommand.ExecuteReader();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtSelectedDate.Text = Calendar1.SelectedDate.ToString();
            lblErrorMsg.Text = "";
        }

        protected void btnConfirmDate_Click(object sender, EventArgs e)
        {
            if(txtSelectedDate.Text != null)
            {
                if (queryResults.Read())
                {
                    String sqlQuery = "INSERT INTO LookAt(CustomerID, Address, Date, SaveDate) VALUES ('" + queryResults["CustomerID"].ToString() + "', '" + queryResults["Address"].ToString() + "', '" + txtSelectedDate.Text + "', '" + DateTime.Now + "')";

                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlQuery;

                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();

                    String sqlquery = "UPDATE LookAtNotifConfirm SET Archived = 'True' WHERE ID = " + Session["LookAtConfID"];

                    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    connection.Open();
                    SqlCommand sqlcommand = new SqlCommand();
                    sqlcommand.Connection = connection;
                    sqlcommand.CommandText = sqlquery;

                    sqlcommand.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("HomePageV2.aspx");
                }
            }
            else
            {
                lblErrorMsg.Text = "Must select dates!";
            }
        }
    }
}