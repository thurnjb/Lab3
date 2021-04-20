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
            Session["CustomerID"] = grdCustomers.SelectedValue;
            Response.Redirect("CustomerDetails.aspx");

        }

        protected void grdCustomers_Sorting(object sender, GridViewSortEventArgs e)
        {
            if(ViewState["CustomerSort"] == null)
            {
                ViewState["CustomerSort"] = e.SortExpression + " " + e.SortDirection;
            }

            String[] sortData = ViewState["CustomerSort"].ToString().Trim().Split(' ');

            if(e.SortExpression == sortData[0])
            {
                if(sortData[1] == "Ascending")
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

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("InitialContactForm.aspx");
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("InitialContactForm.aspx");
        }
    }
}