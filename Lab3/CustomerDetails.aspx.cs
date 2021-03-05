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
    public partial class CustomerDetails : System.Web.UI.Page
    {
        private static SqlDataReader queryResults;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //This method returns to home page
        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        //This method fills a gridview with ticket information of the selected customer
        protected void btnView_Click(object sender, EventArgs e)
        {
            grdTickets.Visible = false;
            grdNotes.Visible = false;
            grdTicketHistory.Visible = false;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String sqlquery = "SELECT CustomerID,FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,DestAddress,SaveDate FROM CUSTOMER WHERE FirstName='" + txtCustomerSearch.Text + "' OR LastName='" + txtCustomerSearch.Text + "';";
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlquery, connection);
            connection.Open();

            DataTable dtForGridView = new DataTable();
            SqlAdapter.Fill(dtForGridView);

            grdCustomers.DataSource = dtForGridView;
            grdCustomers.DataBind();

        }

        protected void grdCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdNotes.Visible = false;
            grdTicketHistory.Visible = false;
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String sqlQuery = "SELECT T.ServiceTicketID, C.FirstName + ' ' + C.LastName as CustomerName, E.FirstName + ' ' + E.LastName as EmployeeName, S.ServiceType, T.TicketStatus, T.TicketOpenDate, T.FromDeadline, T.ToDeadline FROM Customer C, Employee E, Service S, ServiceTicket T WHERE T.CustomerID = C.CustomerID AND T.InitiatingEmployeeID = E.EmployeeID AND T.ServiceID = S.ServiceID AND T.ServiceTicketID = " + grdCustomers.SelectedValue;

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlConnection.Open();

            DataTable dtTicket = new DataTable();
            sqlAdapter.Fill(dtTicket);

            grdTickets.DataSource = dtTicket;
            grdTickets.DataBind();
            grdTickets.Visible = true;
        }

        protected void grdTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT  N.NoteTitle, N.NoteContent FROM ServiceTicket T, Notes N WHERE T.ServiceTicketID = N.ServiceTicketID AND T.ServiceTicketID = " + grdTickets.SelectedValue + ";";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            SqlAdapter.Fill(dtForGridView);

            grdNotes.DataSource = dtForGridView;
            grdNotes.DataBind();

            sqlQuery = "SELECT E.FirstName + ' ' + E.LastName as EmployeeContact, T.TicketChangeDate, T.DetailsNote FROM TicketHistory T, Employee E WHERE T.EmployeeID = E.EmployeeID AND T.ServiceTicketID = " + grdTickets.SelectedValue + ";";

            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dt = new DataTable();
            sqladapter.Fill(dt);

            grdTicketHistory.DataSource = dt;
            grdTicketHistory.DataBind();
            grdNotes.Visible = true;
            grdTicketHistory.Visible = true;
        }
    }
}