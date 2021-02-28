using System;
using System.Collections.Generic;
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
    public partial class PopUpNotes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //This method creates a new Note object and associates it with the ServiceTicket selected on the previous page
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtNoteContent.Text != ""  & txtNoteTitle.Text != "")
            {
                if(Session["ServiceTicketID"] != null)
                {
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

                    sqlCommitQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'Note was added');";

                    SqlCommand sqlcommand = new SqlCommand();
                    sqlConnect.Open();
                    sqlcommand.Connection = sqlConnect;
                    sqlcommand.CommandText = sqlCommitQuery;
                    sqlcommand.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
                }
                else
                {
                    lblErrorMsg.Text = "No ticket was selected";
                }
            }
            else
            {
                lblErrorMsg.Text = "Title and Content must be filled";
            }
        }

        //This method closes the popup window
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
        }
    }
}