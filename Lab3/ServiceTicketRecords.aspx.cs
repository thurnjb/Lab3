using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class ServiceTicketRecords : System.Web.UI.Page
    {
        private static DataSet dataset = new DataSet("ServiceTicket");
        private String sqlCommitQuery = "";

        //On page load, connect to data
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Application["NewAdd"] != null)
            {
                txtCustomerName.Text = Application["CustFName"].ToString() + " " + Application["CustLName"].ToString();
                txtServiceType.Text = Application["CustService"].ToString();
                txtFromDeadline.Text = "2021-03-05";
                txtToDeadline.Text = "2021-03-07";
            }
        }

        //This method goes to the home page
        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("customerdatabase.html");
        }

        //This method fills the textboxes with the first data entry in the table
        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtCustomerName.Text = "Jimbo Jam";
            txtInitiatingEmployee.Text = "Jane Doe";
            txtServiceType.Text = "Moving";
            txtAdditionalService.Text = "Trash Removal";
            txtTicketStatus.Text = "Open";
            txtTicketOpenDate.Text = "01/01/1999 00:00:00";
            txtFromDeadline.Text = "01/01/1999 00:00:00";
            txtToDeadline.Text = "01/01/1999 00:00:00";
            txtLookAt.Text = "01/01/1999 00:00:00";
            txtPickup.Text = "01/01/1999 00:00:00";
        }

        //This method creates an insert sql statement and executes
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCustomerName.Text != "" & txtInitiatingEmployee.Text != "" & txtServiceType.Text != "" & txtFromDeadline.Text != "" & txtToDeadline.Text != "")
            {

                sqlCommitQuery = "INSERT INTO ServiceTicket(CustomerID, InitiatingEmployeeID, ServiceID, AdditionalServiceID, TicketStatus, TicketOpenDate, FromDeadline, ToDeadline, LookAt, Pickup)" +
                    "VALUES (@CustomerID, @InitiatingEmployeeID, @ServiceID, @AdditionalServiceID, @TicketStatus, @TicketOpenDate, @FromDeadline, @ToDeadline, @LookAt, @Pickup)";

                //sqlCommitQuery = "INSERT INTO ServiceTicket(CustomerID, InitiatingEmployeeID, ServiceID, AdditionalServiceID, " +
                //    "TicketStatus, TicketOpenDate, FromDeadline, ToDeadline, LookAt, Pickup)  " +
                //    "VALUES (" + ddlCustomerList.SelectedValue + ", " + ddlEmployeeList.SelectedValue + ", " +
                //    ddlService.SelectedValue + ", "+ dataset.Tables[0].Rows[current]["AdditionalServiceID"].ToString() + ", 'Open', '" + DateTime.Now + "', '" + HttpUtility.HtmlEncode(txtFromDeadline.Text) + "', '" + HttpUtility.HtmlEncode(txtToDeadline.Text) + "', '"+ txtLookAt.Text+ "', '"+ txtPickup.Text+ "');";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlCommitQuery;
                sqlCommand.Parameters.AddWithValue("@CustomerID", ddlCustomerList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@InitiatingEmployeeID", ddlEmployeeList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@ServiceID", ddlService.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AdditionalServiceID", getAdditionalServiceID(HttpUtility.HtmlEncode(txtAdditionalService.Text)));
                sqlCommand.Parameters.AddWithValue("@TicketStatus", "Open");
                sqlCommand.Parameters.AddWithValue("@TicketOpenDate", DateTime.Now.ToString());
                sqlCommand.Parameters.AddWithValue("@FromDeadline", HttpUtility.HtmlEncode(txtFromDeadline.Text));
                sqlCommand.Parameters.AddWithValue("@ToDeadline", HttpUtility.HtmlEncode(txtToDeadline.Text));
                sqlCommand.Parameters.AddWithValue("@LookAt", HttpUtility.HtmlEncode(txtLookAt.Text));
                sqlCommand.Parameters.AddWithValue("@Pickup", HttpUtility.HtmlEncode(txtPickup.Text));

                sqlCommand.ExecuteNonQuery();

                Session["EmployeeID"] = ddlEmployeeList.SelectedValue;

                btnNoteCancel.Visible = true;
                btnNoteSave.Visible = true;
                lblNoteContent.Visible = true;
                lblNoteTitle.Visible = true;
                txtNoteContent.Visible = true;
                txtNoteTitle.Visible = true;

                if (Application["NewAdd"] != null)
                {
                    Application["Request"] = null;
                    Application["NewAdd"] = null;
                    Application["Added"] = "yes";
                    Response.Redirect("NotificationPage.aspx");
                }
            }
            else
            {
                lblErrorMsg.Text = "Only Ticket Status and Open Date may be left blank";
            }
        }

        //This method clears all textboxes
        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtCustomerName.Text = "";
            txtInitiatingEmployee.Text = "";
            txtServiceType.Text = "";
            txtAdditionalService.Text = "";
            txtTicketStatus.Text = "";
            txtTicketOpenDate.Text = "";
            txtFromDeadline.Text = "";
            txtToDeadline.Text = "";
            txtLookAt.Text = "";
            txtPickup.Text = "";
        }

        //Fills textboxes on ddlIndexChange
        protected void ddlCustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtCustomerName.Text = ddlCustomerList.SelectedItem.Text;
        }
        protected void ddlService_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtServiceType.Text = ddlService.SelectedItem.Text;
        }

        protected void ddlEmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtInitiatingEmployee.Text = ddlEmployeeList.SelectedItem.Text;
        }

        protected void ddlAdditionalService_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            txtAdditionalService.Text = ddlAdditionalService.SelectedItem.Text;
        }

        protected void btnNoteCancel_Click(object sender, EventArgs e)
        {
            lblNoteErrorMsg.Text = "";
            btnNoteCancel.Visible = false;
            btnNoteSave.Visible = false;
            lblNoteContent.Visible = false;
            lblNoteTitle.Visible = false;
            txtNoteContent.Visible = false;
            txtNoteTitle.Visible = false;
        }

        protected void btnNoteSave_Click(object sender, EventArgs e)
        {
            if (txtNoteContent.Text != "" & txtNoteTitle.Text != "")
            {
                String sqlQuery = "SELECT ServiceTicketID FROM ServiceTicket WHERE ServiceTicketID=(SELECT max(ServiceTicketID) FROM ServiceTicket)";

                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sqlQuery;
                SqlDataReader queryResults = command.ExecuteReader();

                while (queryResults.Read())
                {
                    Session["ServiceTicketID"] = queryResults["ServiceTicketID"].ToString();
                }
                


                String sqlCommitQuery = "INSERT INTO Notes(ServiceTicketID, NoteTitle, NoteContent) VALUES (" + Session["ServiceTicketID"] + ", @NoteTitle, @NoteContent);";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandText = sqlCommitQuery;
                sqlCommand.Parameters.AddWithValue("@NoteTitle", HttpUtility.HtmlEncode(txtNoteTitle.Text));
                sqlCommand.Parameters.AddWithValue("@NoteContent", HttpUtility.HtmlEncode(txtNoteContent.Text));

                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                sqlCommitQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'Ticket Created');";

                SqlCommand sqlcommand = new SqlCommand();
                sqlConnect.Open();
                sqlcommand.Connection = sqlConnect;
                sqlcommand.CommandText = sqlCommitQuery;
                sqlcommand.ExecuteNonQuery();
                
                lblNoteErrorMsg.Text = "Note was successfully added!";
                btnNoteCancel.Visible = false;
                btnNoteSave.Visible = false;
                lblNoteContent.Visible = false;
                lblNoteTitle.Visible = false;
                txtNoteContent.Visible = false;
                txtNoteTitle.Visible = false;
            }
            else
            {
                lblNoteErrorMsg.Text = "Title and Content must be filled";
            }
        }

        protected int getAdditionalServiceID(String serviceType)
        {
            String constr = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT AdditionalServiceID FROM AdditionalService WHERE AdditionalServiceType = @ServiceType";
            cmd.Parameters.AddWithValue("@ServiceType", serviceType);
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int serviceID = (int)reader["AdditionalServiceID"];
            reader.Close();
            con.Close();
            return serviceID;

        }
    }
}