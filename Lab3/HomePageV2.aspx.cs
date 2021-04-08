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

        private static DataTable grdVwLookAt = new DataTable();
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

            String sqlQuery = "SELECT N.CustomerID, C.FirstName, C.LastName, C.Address, N.SaveDate FROM Customer C, LookAtNotification N WHERE N.CustomerID = C.CustomerID ORDER BY N.SaveDate";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqlConnect.Open();

            sqlAdapter.Fill(grdVwLookAt);

            grdNotification.DataSource = grdVwLookAt;
            grdNotification.DataBind();
        }

        protected void btnLookAtConfirm_Click(object sender, EventArgs e)
        {

            Session["LookAtID"] = ((GridViewRow)((Control)sender).NamingContainer).RowIndex + 1;
            Response.Redirect("LookAtScheduling.aspx");
        }
    }
}