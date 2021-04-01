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
    public partial class CustomerDetails1 : System.Web.UI.Page
    {
        private static DataTable grdVwCustomer = new DataTable();
        private static DataTable grdVwTicket = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            grdVwCustomer.Clear();
            grdVwTicket.Clear();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String sqlQuery = "Select * FROM Customer WHERE CustomerID = " + Session["CustomerID"];

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlQuery, connection);
            connection.Open();

            SqlAdapter.Fill(grdVwCustomer);

            grdCustomers.DataSource = grdVwCustomer;
            grdCustomers.DataBind();
            connection.Close();

            sqlQuery = "Select T.ServiceTicketID, C.FirstName + ' ' + C.LastName as CustomerName, E.FirstName + ' ' + E.LastName as EmployeeName, S.ServiceType, T.TicketStatus, T.FromDeadline, T.ToDeadline, T.TicketOpenDate FROM Customer C, Employee E, Service S, ServiceTicket T WHERE T.CustomerID = C.CustomerID AND T.InitiatingEmployeeID = E.EmployeeID AND T.ServiceID = S.ServiceID AND T.CustomerID = " + Session["CustomerID"];

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, connection);
            connection.Open();

            sqlAdapter.Fill(grdVwTicket);

            grdTickets.DataSource = grdVwTicket;
            grdTickets.DataBind();
        }
        protected void btnCreateMove_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateAuction_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreateStorage_Click(object sender, EventArgs e)
        {

        }

        protected void grdCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["TicketID"] = grdTickets.SelectedValue;
            Response.Redirect("Ticket.aspx");
        }

        protected void grdTickets_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdCustomers_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdCustomers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCustomers.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void grdCustomers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndex = e.RowIndex;

            GridViewRow row = grdCustomers.Rows[rowIndex];

        }
    }
}