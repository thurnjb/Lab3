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
    public partial class MoveSchedulingConfirmation : System.Web.UI.Page
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
            String sqlQuery = "SELECT N.MoveNotifConfirmID, C.FirstName + ' ' + C.LastName AS CustomerName, M.PotentialDates, M.SaveDate FROM Customer C, MoveNotifConfirm N, MoveNotification M WHERE N.MoveNotificationID = M.MoveNotificationID AND M.CustomerID = C.CustomerID AND N.MoveNotifConfirmID = " + Session["MoveConfID"];
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            sqlConnect.Open();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqlAdapter.Fill(grdVwNotification);

            grdNotification.DataSource = grdVwNotification;
            grdNotification.DataBind();

            String query = "SELECT C.CustomerID, C.Address FROM Customer C, MoveNotifConfirm M, MoveNotification N WHERE C.CustomerID = N.CustomerID AND N.MoveNotificationID = M.MoveNotificationID AND M.MoveNotifConfirmID = " + Session["MoveConfID"];
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
            if(txtSelectedDate.Text != null & ddlEmployee.SelectedValue != null)
            {
                if (queryResults.Read())
                {
                    String sqlQuery = "INSERT INTO ServiceTicket(CustomerID, InitiatingEmployeeID, Service, TicketStatus, TicketOpenDate, Address, Date) VALUES (@CustomerID, @InitiatingEmployeeID, @Service, @TicketStatus, @TicketOpenDate, @Address, @Date)";

                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlQuery;
                    sqlCommand.Parameters.AddWithValue("@CustomerID", HttpUtility.HtmlEncode(queryResults["CustomerID"].ToString()));
                    sqlCommand.Parameters.AddWithValue("@InitiatingEmployeeID", HttpUtility.HtmlEncode(ddlEmployee.SelectedValue));
                    sqlCommand.Parameters.AddWithValue("@Service", HttpUtility.HtmlEncode("Move"));
                    sqlCommand.Parameters.AddWithValue("@TicketStatus", HttpUtility.HtmlEncode("Open"));
                    sqlCommand.Parameters.AddWithValue("@TicketOpenDate", HttpUtility.HtmlEncode(DateTime.Now));
                    sqlCommand.Parameters.AddWithValue("@Address", HttpUtility.HtmlEncode(queryResults["Address"]));
                    sqlCommand.Parameters.AddWithValue("@Date", HttpUtility.HtmlEncode(txtSelectedDate.Text));

                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();

                    String sqlquery = "UPDATE MoveNotifConfirm SET Archived = 'True' WHERE MoveNotifConfirmID = " + Session["MoveConfID"];
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
        }
    }
}