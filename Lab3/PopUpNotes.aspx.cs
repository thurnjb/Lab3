using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class PopUpNotes : System.Web.UI.Page
    {
        private static String sqlCommitQuery = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtNoteContent.Text != ""  & txtNoteTitle.Text != "")
            {
                if(Session["ServiceTicketID"] != null)
                {
                    sqlCommitQuery = "INSERT INTO Notes(ServiceTicketID, NoteTitle, NoteContent) VALUES (" + Session["ServiceTicketID"] + ", '" + txtNoteTitle.Text + "', '" + txtNoteContent.Text + "');";

                    SqlConnection sqlConnect = new SqlConnection("Server=Localhost;Database=Lab3;Trusted_Connection=Yes;");

                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlCommitQuery;

                    sqlCommand.ExecuteNonQuery();
                    lblErrorMsg.Text = "Note was successfully saved";
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script", "window.close()", true);
        }
    }
}