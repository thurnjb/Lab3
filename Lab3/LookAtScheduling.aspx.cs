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
    public partial class LookAtScheduling : System.Web.UI.Page
    {
        private static DataTable grdVwNotification = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            
        }

        protected void BindData()
        {
            grdVwNotification.Clear();

            String sqlQuery = "Select N.NotificationID, C.FirstName, C.LastName, N.SaveDate FROM Customer C, LookAtNotification N WHERE N.CustomerID = C.CustomerID AND N.NotificationID = " + Session["LookAtID"];

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqlConnect.Open();

            sqlAdapter.Fill(grdVwNotification);

            grdNotification.DataSource = grdVwNotification;
            grdNotification.DataBind();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtCalendarDate.Text = Calendar1.SelectedDate.Date.ToString();
            lblErrorMsg.Text = "";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lstbxPotentialDates.Items.Add(txtCalendarDate.Text);
            txtCalendarDate.Text = "";
            lblErrorMsg.Text = "";
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            string DateString = lstbxPotentialDates.Items[0].ToString();
            int lstbxCount = lstbxPotentialDates.Items.Count;
            if (lstbxPotentialDates.Items.Count != 0)
            {
                for (int i = 1; i < lstbxCount; i++)
                {
                    DateString += ", " + lstbxPotentialDates.Items[i].ToString();
                }
                for (int k = lstbxCount - 1; k >= 0; k--)
                {
                    lstbxPotentialDates.Items.RemoveAt(k);
                }
                String sqlQuery = "INSERT INTO LookAtNotifConfirm(NotificationID, PotentialDates, SaveDate) VALUES (" + Session["LookAtID"] + ", '" + DateString + "', '" + DateTime.Now + "')";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlQuery;

                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                String sqlquery = "UPDATE LookAtNotification SET Archived = 'True' WHERE NotificationID = " + Session["LookAtID"];

                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                connection.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = connection;
                sqlcommand.CommandText = sqlquery;

                sqlcommand.ExecuteNonQuery();
                connection.Close();

                Response.Redirect("HomePageV2.aspx");
            }
            else
            {
                lblErrorMsg.Text = "Must select dates!";
            }
        }
    }
}