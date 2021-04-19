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
        }

        protected void btnLookAtConfirm_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string pk = grdNotification.DataKeys[row.RowIndex].Values[0].ToString();

            Session["LookAtID"] = Convert.ToInt32(pk);
            
            Response.Redirect("LookAtScheduling.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("LookAtScheduling.aspx");
        }

        protected void btnLookAtConfConfirm_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            string pk = grdLookAtConf.DataKeys[row.RowIndex].Values[0].ToString();

            Session["LookAtConfID"] = Convert.ToInt32(pk);
            Response.Redirect("LookAtConfirmation.aspx");
        }


        protected void searchBtn_Click(object sender, EventArgs e)
        {
            
                CustomerGridView.Clear();

                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                String sqlquery = "SELECT CustomerID,FirstName,LastName,InitialContact,HeardFrom,Phone,Email,Address,DestAddress,SaveDate FROM CUSTOMER WHERE FirstName='" + hpCustomerSearch.Text + "' OR LastName='" + hpCustomerSearch.Text + "';";
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(sqlquery, connection);
                connection.Open();

                SqlAdapter.Fill(CustomerGridView);

                grdCustomers.DataSource = CustomerGridView;
                grdCustomers.DataBind();

            
        }

        protected void grdCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CustomerID"] = grdCustomers.SelectedValue;
            //Response.Redirect("CustomerDetails.aspx");

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

     
    }
}