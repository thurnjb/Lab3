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
    public partial class TicketPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNote_Click(object sender, EventArgs e)
        {
             
            Session["EditTicketPage"] = "true";
            btnNoteCancel.Visible = true;
            btnNoteSave.Visible = true;
            lblNoteContent.Visible = true;
            lblNoteTitle.Visible = true;
            txtNoteContent.Visible = true;
            txtNoteTitle.Visible = true;

        }

        protected void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            ddlEmployee.Visible = true;
            btnEmployeeCancel.Visible = true;
            btnEmployeeSave.Visible = true;

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
                if (Session["ServiceTicketID"] != null)
                {
                    //String sqlCommitQuery = "INSERT INTO Notes(ServiceTicketID, NoteTitle, NoteContent) VALUES (" + Session["ServiceTicketID"] + ", @NoteTitle, @NoteContent);";

                    //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    //sqlConnect.Open();
                    //SqlCommand sqlCommand = new SqlCommand();
                    //sqlCommand.Connection = sqlConnect;
                    //sqlCommand.CommandText = sqlCommitQuery;
                    //sqlCommand.Parameters.AddWithValue("@NoteTitle", HttpUtility.HtmlEncode(txtNoteTitle.Text));
                    //sqlCommand.Parameters.AddWithValue("@NoteContent", HttpUtility.HtmlEncode(txtNoteContent.Text));

                    //sqlCommand.ExecuteNonQuery();
                    //sqlConnect.Close();


                    //if (Session["EditTicketPage"] != null)
                    //{
                    //    sqlCommitQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'Note was added');";

                    //    SqlCommand sqlcommand = new SqlCommand();
                    //    sqlConnect.Open();
                    //    sqlcommand.Connection = sqlConnect;
                    //    sqlcommand.CommandText = sqlCommitQuery;
                    //    sqlcommand.ExecuteNonQuery();


                    //}
                    Session["SaveNote"] = txtNoteContent.Text;
                    Session["SaveNoteTitle"] = txtNoteTitle.Text;

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
                    lblNoteErrorMsg.Text = "No ticket was selected";
                }
            }
                else
                {
                    lblNoteErrorMsg.Text = "Title and Content must be filled";
                }
            }

                    protected void btnCompleteTicket_Click(object sender, EventArgs e)
        {
            //Response.Redirect();
        }

        protected void btnEmployeeCancel_Click(object sender, EventArgs e)
        {
            ddlEmployee.Visible = false;
            btnEmployeeCancel.Visible = false;
            btnEmployeeSave.Visible = false;
        }

        protected void btnEmployeeSave_Click(object sender, EventArgs e)
        {
            if (ddlEmployee.SelectedValue != null)
            {
                if (Session["ServiceTicketID"] != null)
                {
                    //String sqlQuery = "UPDATE ServiceTicket SET InitiatingEmployeeID=" + ddlEmployee.SelectedValue + " WHERE ServiceTicketID=" + Session["ServiceTicketID"] + ";";
                    //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    //sqlConnect.Open();
                    //SqlCommand sqlCommand = new SqlCommand();
                    //sqlCommand.Connection = sqlConnect;
                    //sqlCommand.CommandText = sqlQuery;

                    //sqlCommand.ExecuteNonQuery();
                    //sqlConnect.Close();

                    //sqlQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'New employee was assigned')";
                    //sqlConnect.Open();
                    //sqlCommand.Connection = sqlConnect;
                    //sqlCommand.CommandText = sqlQuery;

                    //sqlCommand.ExecuteNonQuery();

                    Session["Employee"] = ddlEmployee.SelectedValue;

                    lblErrorMsg.Text = "Employee successfully changed!";
                    ddlEmployee.Visible = false;
                    btnEmployeeSave.Visible = false;
                    btnEmployeeCancel.Visible = false;
                }
                else
                {
                    lblErrorMsg.Text = "No ticket was selected!";
                }
            }
            else
            {
                lblErrorMsg.Text = "No employee was selected!";
            }
        }

        protected void dtlVwTicketNotes_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("Ticket.aspx");
            }
        }

        protected void grdTickets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}