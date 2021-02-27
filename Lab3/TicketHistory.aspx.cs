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
    public partial class TicketHistory : System.Web.UI.Page
    {
        private static SqlDataReader queryResults;

        //On first page load, Fills grid view with all tickets
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //This method fills the SelectedTicket and SelectedTicketHistory gridviews
        protected void btnViewTicketNotes_Click(object sender, EventArgs e)
        {
            String sqlQuery = "SELECT  N.NoteTitle, N.NoteContent FROM ServiceTicket T, Notes N WHERE T.ServiceTicketID = N.ServiceTicketID AND T.ServiceTicketID = " + ddlServiceTicketID.SelectedValue;
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
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
            Session["ServiceTicketID"] = ddlServiceTicketID.SelectedValue;

            string s = "window.open('PopUpNotes.aspx', 'popup_window', 'width=500, height=500, resizable=yes')";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        //This method returns to home page
        protected void btnViewHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        protected void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            Session["ServiceTicketID"] = ddlServiceTicketID.SelectedValue;

            string s = "window.open('AssignEmployee.aspx', 'popup_window', 'width=500, height=500, resizable=yes')";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicketHistory.aspx");
        }
    }
}