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
    public partial class TicketHistory : System.Web.UI.Page
    {
        //On first page load, Fills grid view with all tickets
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        //This method fills the SelectedTicket and SelectedTicketHistory gridviews
        protected void btnViewTicketDetails_Click(object sender, EventArgs e)
        {
            if (grdTickets.SelectedValue == null)
            {
                lblErrorMsg.Text = "Please select a service ticket.";
            }
            else
            {
                lblErrorMsg.Text = "";
                object pageIndex = grdTickets.SelectedValue;
                lblErrorMsg.Text = "";
                String sqlQuery = "SELECT T.InitiatingEmployeeID, S.ServiceType FROM ServiceTicket T, Service S WHERE T.ServiceTicketID = " + pageIndex + "AND T.ServiceID = S.ServiceID";
                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);
                DataSet dsEmployee = new DataSet();
                sqlAdapter.Fill(dsEmployee);

                //DataBindNotes();

                sqlQuery = "SELECT A.AuctionName FROM Auction A, ServiceTicket T WHERE T.AuctionID = A.AuctionID AND T.ServiceTicketID = " + pageIndex + ";";
                SqlDataAdapter Adapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dtAuction = new DataTable();
                Adapter.Fill(dtAuction);
                //grdAuction.DataSource = dtAuction;
                //grdAuction.DataBind();

                sqlQuery = "SELECT Employee.FirstName + ' ' + Employee.LastName as EmployeeContact, TicketChangeDate, DetailsNote FROM TicketHistory, Employee WHERE TicketHistory.EmployeeID = Employee.EmployeeID AND ServiceTicketID = " + pageIndex;

                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlQuery, sqlConnect);

                DataTable dt = new DataTable();
                sqladapter.Fill(dt);

                grdSelectedTicketHistory.DataSource = dt;
                grdSelectedTicketHistory.DataBind();

                Session["ServiceTicketID"] = pageIndex;
                Session["EmployeeID"] = dsEmployee.Tables[0].Rows[0]["InitiatingEmployeeID"].ToString();
                Session["ServiceType"] = dsEmployee.Tables[0].Rows[0]["ServiceType"].ToString();
            }
        }

        //This method saved the selected value in the ddl in session and redirects to the notes page
        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            Session["EditTicketPage"] = "true";
            btnNoteCancel.Visible = true;
            btnNoteSave.Visible = true;
            lblNoteContent.Visible = true;
            lblNoteTitle.Visible = true;
            txtNoteContent.Visible = true;
            txtNoteTitle.Visible = true;
        }

        //This method returns to home page
        protected void btnViewHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        protected void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            ddlEmployee.Visible = true;
            btnEmployeeCancel.Visible = true;
            btnEmployeeSave.Visible = true;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Response.Redirect("TicketHistory.aspx");
        }

        protected void btnAssignAuction_Click1(object sender, EventArgs e)
        {
            string s = "window.open('AssignAuction.aspx', 'popup_window', 'width=500, height=500, resizable=yes')";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void btnEmployeeCancel_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            ddlEmployee.Visible = false;
            btnEmployeeSave.Visible = false;
            btnEmployeeCancel.Visible = false;
        }

        protected void btnEmployeeSave_Click(object sender, EventArgs e)
        {
            if (ddlEmployee.SelectedValue != null)
            {
                if (Session["ServiceTicketID"] != null)
                {
                    String sqlQuery = "UPDATE ServiceTicket SET InitiatingEmployeeID=" + ddlEmployee.SelectedValue + " WHERE ServiceTicketID=" + Session["ServiceTicketID"] + ";";
                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlQuery;

                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();

                    sqlQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'New employee was assigned')";
                    sqlConnect.Open();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlQuery;

                    sqlCommand.ExecuteNonQuery();

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

                    if (Session["EditTicketPage"] != null)
                    {
                        sqlCommitQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'Note was added');";

                        SqlCommand sqlcommand = new SqlCommand();
                        sqlConnect.Open();
                        sqlcommand.Connection = sqlConnect;
                        sqlcommand.CommandText = sqlCommitQuery;
                        sqlcommand.ExecuteNonQuery();
                    }
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

        protected void dtlVwTicketNotes_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            dtlVwTicketNotes.PageIndex = e.NewPageIndex;
        }

        protected void dtlVwEditTicket_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("TicketHistory.aspx");
        }

        protected void dtlVwEditTicket_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("TicketHistory.aspx");
            }
        }

        protected void dtlVwTicketNotes_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dtlVwTicketNotes.ChangeMode(DetailsViewMode.Edit);
        }

        protected void grdTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ServiceTicketID"] = grdTickets.SelectedValue;

            String temp = ((HiddenField)grdTickets.SelectedRow.FindControl("hdnEmployee")).Value;
            Session["EmployeeID"] = temp;
        }
    }
}