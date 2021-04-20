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
    public partial class MoveScheduling : System.Web.UI.Page
    {

        private static DataTable grdVwMove = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            grdVwMove.Clear();
            String sqlQuery = "SELECT M.MoveNotificationID, C.FirstName + ' ' + C.LastName AS CustomerName, M.PotentialDates, M.SaveDate FROM MoveNotification M, Customer C WHERE M.CustomerID = C.CustomerID AND MoveNotificationID = " + Session["MoveID"];
            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqlConnect.Open();

            sqlAdapter.Fill(grdVwMove);
            grdNotification.DataSource = grdVwMove;
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
                String sqlQuery = "INSERT INTO MoveNotifConfirm(MoveNotificationID, PotentialDates, SaveDate) VALUES (@MoveNotificationID, @PotentialDates, @SaveDate)";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@MoveNotificationID", HttpUtility.HtmlEncode(Session["MoveID"]));
                sqlCommand.Parameters.AddWithValue("@PotentialDates", HttpUtility.HtmlEncode(DateString));
                sqlCommand.Parameters.AddWithValue("@SaveDate", HttpUtility.HtmlEncode(DateTime.Now));

                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                String query = "UPDATE MoveNotification SET Archived = 'True' WHERE MoveNotificationID = @MoveNotificationID";
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@MoveNotificationID", HttpUtility.HtmlEncode(Session["MoveID"]));

                cmd.ExecuteNonQuery();
                connection.Close();

                Response.Redirect("HomePageV2.aspx");
            }
            else
            {
                lblErrorMsg.Text = "Must select date(s)!";
            }
        }
    }
}