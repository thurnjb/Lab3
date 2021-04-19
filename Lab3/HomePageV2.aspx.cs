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
    public partial class HomePageV2 : System.Web.UI.Page
    {
        private static DataTable CustomerGridView = new DataTable();
        private static DataTable grdView = new DataTable();
        private static DataTable grdVwLookAt = new DataTable();
        private static DataTable grdVwLookAtConf = new DataTable();
        private static DataTable grdVwMoveSchedule = new DataTable();
        private static DataTable grdVwMoveConf = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            BindData();
        }

        protected void BindData()
        {
            grdVwLookAt.Clear();
            grdVwLookAtConf.Clear();
            grdVwMoveSchedule.Clear();
            grdVwMoveConf.Clear();

            String sqlQuery = "SELECT N.NotificationID, C.FirstName + ' ' + C.LastName AS CustomerName, C.Address, N.SaveDate FROM Customer C, LookAtNotification N WHERE N.CustomerID = C.CustomerID AND N.Archived IS NULL ORDER BY N.SaveDate";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqlConnect.Open();

            sqlAdapter.Fill(grdVwLookAt);

            grdNotification.DataSource = grdVwLookAt;
            grdNotification.DataBind();

            String sqlquery = "SELECT N.ID, N.NotificationID, C.FirstName + ' ' + C.LastName AS CustomerName, N.PotentialDates, N.SaveDate FROM Customer C, LookAtNotification L, LookAtNotifConfirm N WHERE L.CustomerID = C.CustomerID AND N.NotificationID = L.NotificationID AND N.Archived IS NULL";

            SqlConnection sqlconnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter sqladapter = new SqlDataAdapter(sqlquery, sqlconnect);

            sqlconnect.Open();

            sqladapter.Fill(grdVwLookAtConf);

            grdLookAtConf.DataSource = grdVwLookAtConf;
            grdLookAtConf.DataBind();

            String query = "SELECT M.MoveNotificationID, C.FirstName + ' ' + C.LastName AS CustomerName, M.PotentialDates, M.SaveDate FROM Customer C, MoveNotification M WHERE M.CustomerID = C.CustomerID AND M.Archived IS NULL";
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            connection.Open();
            adapter.Fill(grdVwMoveSchedule);
            grdMoveNotification.DataSource = grdVwMoveSchedule;
            grdMoveNotification.DataBind();

            String sql = "SELECT N.MoveNotifConfirmID, N.MoveNotificationID, C.FirstName + ' ' + C.LastName AS CustomerName, N.PotentialDates, N.SaveDate FROM Customer C, MoveNotifConfirm N, MoveNotification M WHERE M.CustomerID = C.CustomerID AND M.MoveNotificationID = N.MoveNotificationID AND N.Archived IS NULL";
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            SqlDataAdapter adapt = new SqlDataAdapter(sql, con);
            con.Open();
            adapt.Fill(grdVwMoveConf);
            grdMoveConf.DataSource = grdVwMoveConf;
            grdMoveConf.DataBind();
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {

            CustomerGridView.Clear();

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CustomerID,FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,SaveDate FROM CUSTOMER WHERE FirstName=@searchKey OR LastName=@searchKey OR concat(FirstName,' ',LastName)=@searchKey;";
            cmd.Parameters.AddWithValue("@searchKey", hpCustomerSearch.Text);
            cmd.Connection = con;

            SqlDataAdapter SqlAdapter = new SqlDataAdapter(cmd);

            SqlAdapter.Fill(CustomerGridView);

            grdCustomers.DataSource = CustomerGridView;
            grdCustomers.DataBind();
            con.Close();

        }

        protected void grdCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CustomerID"] = grdCustomers.SelectedValue;
            Response.Redirect("CustomerProfile.aspx");
        }

        protected void grdCustomers_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["CustomerSort"] == null)
            {
                ViewState["CustomerSort"] = e.SortExpression + " " + e.SortDirection;
            }

            String[] sortData = ViewState["CustomerSort"].ToString().Trim().Split(' ');

            if (e.SortExpression == sortData[0])
            {
                if (sortData[1] == "Ascending")
                {
                    CustomerGridView.DefaultView.Sort = e.SortExpression + " DESC";
                    this.ViewState["CustomerSort"] = e.SortExpression + " Descending";
                }
                else
                {
                    CustomerGridView.DefaultView.Sort = e.SortExpression + " ASC";
                    this.ViewState["CustomerSort"] = e.SortExpression + " Ascending";
                }
            }
            else
            {
                CustomerGridView.DefaultView.Sort = e.SortExpression + " ASC";
                this.ViewState["CustomerSort"] = e.SortExpression + " Ascending";
            }

            grdCustomers.DataSource = CustomerGridView;
            grdCustomers.DataBind();
        }

        protected void grdNotification_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["LookAtID"] = grdNotification.SelectedValue;
            Response.Redirect("LookAtScheduling.aspx");
        }

        protected void grdLookAtConf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["LookAtConfID"] = grdLookAtConf.SelectedValue;
            Response.Redirect("LookAtConfirmation.aspx");
        }

        protected void grdMoveNotification_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["MoveID"] = grdMoveNotification.SelectedValue;
            Response.Redirect("MoveScheduling.aspx");
        }

        protected void grdMoveConf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["MoveConfID"] = grdMoveConf.SelectedValue;
            Response.Redirect("MoveSchedulingConfirmation.aspx");
        }
    }
}