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
        private static DataTable CustomerGridView = new DataTable();
        private static DataTable TicketGridView = new DataTable();
        private static DataTable NotesGridView = new DataTable();
        private static DataTable HistoryGridView = new DataTable();

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
            CustomerGridView.Clear();
            
            grdTickets.Visible = false;
            grdNotes.Visible = false;
            grdTicketHistory.Visible = false;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String sqlquery = "SELECT CustomerID,FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,DestAddress,SaveDate FROM CUSTOMER WHERE FirstName='" + txtCustomerSearch.Text + "' OR LastName='" + txtCustomerSearch.Text + "';";
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlquery, connection);
            connection.Open();

            
            SqlAdapter.Fill(CustomerGridView);

            grdCustomers.DataSource = CustomerGridView;
            grdCustomers.DataBind();

        }

        protected void grdCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            TicketGridView.Clear();

            grdTickets.DataSource = null;
            grdTickets.DataBind();

            grdNotes.Visible = false;
            grdTicketHistory.Visible = false;
            SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            String sqlQuery = "SELECT T.ServiceTicketID, C.FirstName + ' ' + C.LastName as CustomerName, E.FirstName + ' ' + E.LastName as EmployeeName, S.ServiceType, T.TicketStatus, T.TicketOpenDate, T.FromDeadline, T.ToDeadline FROM Customer C, Employee E, Service S, ServiceTicket T WHERE T.CustomerID = C.CustomerID AND T.InitiatingEmployeeID = E.EmployeeID AND T.ServiceID = S.ServiceID AND T.CustomerID = " + grdCustomers.SelectedValue;

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlConnection.Open();

            sqlAdapter.Fill(TicketGridView);

            grdTickets.DataSource = TicketGridView;
            grdTickets.DataBind();
            grdTickets.Visible = true;
        }

        protected void grdTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotesGridView.Clear();

            String sqlQuery = "SELECT  N.NoteID, N.NoteTitle, N.NoteContent FROM ServiceTicket T, Notes N WHERE T.ServiceTicketID = N.ServiceTicketID AND T.ServiceTicketID = " + grdTickets.SelectedValue + ";";
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            
            SqlAdapter.Fill(NotesGridView);

            grdNotes.DataSource = NotesGridView;
            grdNotes.DataBind();

            HistoryGridView.Clear();

            sqlQuery = "SELECT T.TicketHistoryID, E.FirstName + ' ' + E.LastName as EmployeeContact, T.TicketChangeDate, T.DetailsNote FROM TicketHistory T, Employee E WHERE T.EmployeeID = E.EmployeeID AND T.ServiceTicketID = " + grdTickets.SelectedValue + ";";

            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqladapter.Fill(HistoryGridView);

            grdTicketHistory.DataSource = HistoryGridView;
            grdTicketHistory.DataBind();
            grdNotes.Visible = true;
            grdTicketHistory.Visible = true;
        }

        protected void grdCustomers_Sorting(object sender, GridViewSortEventArgs e)
        {
            if(ViewState["SortExpression"] == null)
            {
                ViewState["SortExpression"] = e.SortExpression + " " + e.SortDirection;
            }

            String[] sortData = ViewState["SortExpression"].ToString().Trim().Split(' ');

            if(e.SortExpression == sortData[0])
            {
                if(sortData[1] == "Ascending")
                {
                    CustomerGridView.DefaultView.Sort = e.SortExpression + " DESC";
                    this.ViewState["SortExpression"] = e.SortExpression + " Descending";
                }
                else
                {
                    CustomerGridView.DefaultView.Sort = e.SortExpression + " ASC";
                    this.ViewState["SortExpression"] = e.SortExpression + " Ascending";
                }
            }
            else
            {
                CustomerGridView.DefaultView.Sort = e.SortExpression + " ASC";
                this.ViewState["SortExpression"] = e.SortExpression + " Ascending";
            }

            grdCustomers.DataSource = CustomerGridView;
            grdCustomers.DataBind();
        }

        protected void grdTickets_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortExpression"] == null)
            {
                ViewState["SortExpression"] = e.SortExpression + " " + e.SortDirection;
            }

            String[] sortData = ViewState["SortExpression"].ToString().Trim().Split(' ');

            if (e.SortExpression == sortData[0])
            {
                if (sortData[1] == "Ascending")
                {
                    TicketGridView.DefaultView.Sort = e.SortExpression + " DESC";
                    this.ViewState["SortExpression"] = e.SortExpression + " Descending";
                }
                else
                {
                    TicketGridView.DefaultView.Sort = e.SortExpression + " ASC";
                    this.ViewState["SortExpression"] = e.SortExpression + " Ascending";
                }
            }
            else
            {
                TicketGridView.DefaultView.Sort = e.SortExpression + " ASC";
                this.ViewState["SortExpression"] = e.SortExpression + " Ascending";
            }

            grdTickets.DataSource = TicketGridView;
            grdTickets.DataBind();
        }
    }
}