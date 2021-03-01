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
            String sqlQuery = "SELECT C.FirstName + ' ' + C.LastName as CustomerName, T.TicketStatus, T.TicketOpenDate, T.FromDeadline, T.ToDeadline FROM  Customer C, ServiceTicket T WHERE T.CustomerID = " + ddlCustomerList.SelectedValue + " AND T.CustomerID = C.CustomerID";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            DataTable dtCustomer = new DataTable();
            sqlAdapter.Fill(dtCustomer);

            grdCustomerTicket.DataSource = dtCustomer;
            grdCustomerTicket.DataBind();
        }
    }
}