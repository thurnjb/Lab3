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
    public partial class TicketHistory : System.Web.UI.Page
    {
        //On first page load, Fills grid view with all tickets
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //String sqlQuery = "SELECT C.FirstName + ' ' + C.LastName as CustomerName, E.FirstName + ' ' + E.LastName as EmployeeName, S.ServiceType, T.TicketStatus, T.TicketOpenDate, T.FromDeadline, T.ToDeadline FROM Customer C, Employee E, Service S, ServiceTicket T WHERE T.CustomerID = C.CustomerID AND T.InitiatingEmployeeID = E.EmployeeID AND T.ServiceID = S.ServiceID";
                //SqlConnection sqlConnect = new SqlConnection("Server=Localhost;Database=Lab3;Trusted_Connection=Yes;");
                //SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                //DataTable dtForGridView = new DataTable();
                //sqlAdapter.Fill(dtForGridView);

                //grdTickets.DataSource = dtForGridView;
                //grdTickets.DataBind();
            }
        }

        //This method fills the SelectedTicket and SelectedTicketHistory gridviews
        protected void btnViewTicketNotes_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT T.ServiceTicketID, N.NoteTitle, N.NoteContent FROM ServiceTicket T, Notes N WHERE T.ServiceTicketID = N.ServiceTicketID AND T.ServiceTicketID = " + ddlServiceTicketID.SelectedValue;
            SqlConnection sqlConnect = new SqlConnection("Server=Localhost;Database=Lab3;Trusted_Connection=Yes;");
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtForGridView = new DataTable();
            sqlAdapter.Fill(dtForGridView);

            grdSelectedTicket.DataSource = dtForGridView;
            grdSelectedTicket.DataBind();

            sqlQuery = "SELECT Employee.FirstName + ' ' + Employee.LastName as EmployeeContact, TicketChangeDate, DetailsNote FROM TicketHistory, Employee WHERE TicketHistory.EmployeeID = Employee.EmployeeID AND ServiceTicketID = " + ddlServiceTicketID.SelectedValue;

            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dt = new DataTable();
            sqladapter.Fill(dt);

            grdSelectedTicketHistory.DataSource = dt;
            grdSelectedTicketHistory.DataBind();
        }

        //This method saved the selected value in the ddl in session and redirects to the notes page
        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            Session["SelectedTicket"] = ddlServiceTicketID.SelectedValue;
            Response.Redirect("NotePage.aspx");
        }

        //This method returns to home page
        protected void btnViewHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }
    }
}