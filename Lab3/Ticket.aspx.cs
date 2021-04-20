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
        private static DataTable grdVwTicket = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            grdVwTicket.Clear();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String sqlQuery = "Select T.ServiceTicketID, C.FirstName + ' ' + C.LastName as CustomerName, E.FirstName + ' ' + E.LastName as EmployeeName, " +
                "T.Service, T.TicketStatus, T.TicketOpenDate " +
                "FROM Customer C, Employee E, ServiceTicket T " +
                "WHERE T.CustomerID = C.CustomerID AND T.InitiatingEmployeeID = E.EmployeeID AND T.Archived IS NULL AND T.CustomerID = " + Session["CustomerID"];

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, connection);
            connection.Open();

            sqlAdapter.Fill(grdVwTicket);

            grdTickets.DataSource = grdVwTicket;
            grdTickets.DataBind();
        }
        //protected void btnAddNote_Click(object sender, EventArgs e)
        //{
             
        //    Session["EditTicketPage"] = "true";
        //    btnNoteCancel.Visible = true;
        //    btnNoteSave.Visible = true;
        //    lblNoteContent.Visible = true;
        //    lblNoteTitle.Visible = true;
        //    txtNoteContent.Visible = true;
        //    txtNoteTitle.Visible = true;

        //}

        //protected void btnAssignEmployee_Click(object sender, EventArgs e)
        //{
        //    ddlEmployee.Visible = true;
        //    btnEmployeeCancel.Visible = true;
        //    btnEmployeeSave.Visible = true;

        //}

        //protected void btnNoteCancel_Click(object sender, EventArgs e)
        //{
        //    lblNoteErrorMsg.Text = "";
        //    btnNoteCancel.Visible = false;
        //    btnNoteSave.Visible = false;
        //    lblNoteContent.Visible = false;
        //    lblNoteTitle.Visible = false;
        //    txtNoteContent.Visible = false;
        //    txtNoteTitle.Visible = false;
        //}

        //protected void btnNoteSave_Click(object sender, EventArgs e)
        //{
        //    if (txtNoteContent.Text != "" & txtNoteTitle.Text != "")
        //    {
        //        if (Session["ServiceTicketID"] != null)
        //        {
        //            //String sqlCommitQuery = "INSERT INTO Notes(ServiceTicketID, NoteTitle, NoteContent) VALUES (" + Session["ServiceTicketID"] + ", @NoteTitle, @NoteContent);";

        //            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

        //            //sqlConnect.Open();
        //            //SqlCommand sqlCommand = new SqlCommand();
        //            //sqlCommand.Connection = sqlConnect;
        //            //sqlCommand.CommandText = sqlCommitQuery;
        //            //sqlCommand.Parameters.AddWithValue("@NoteTitle", HttpUtility.HtmlEncode(txtNoteTitle.Text));
        //            //sqlCommand.Parameters.AddWithValue("@NoteContent", HttpUtility.HtmlEncode(txtNoteContent.Text));

        //            //sqlCommand.ExecuteNonQuery();
        //            //sqlConnect.Close();


        //            //if (Session["EditTicketPage"] != null)
        //            //{
        //            //    sqlCommitQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'Note was added');";

        //            //    SqlCommand sqlcommand = new SqlCommand();
        //            //    sqlConnect.Open();
        //            //    sqlcommand.Connection = sqlConnect;
        //            //    sqlcommand.CommandText = sqlCommitQuery;
        //            //    sqlcommand.ExecuteNonQuery();


        //            //}
        //            Session["SaveNote"] = txtNoteContent.Text;
        //            Session["SaveNoteTitle"] = txtNoteTitle.Text;

        //            lblNoteErrorMsg.Text = "Note was successfully added!";
        //            btnNoteCancel.Visible = false;
        //            btnNoteSave.Visible = false;
        //            lblNoteContent.Visible = false;
        //            lblNoteTitle.Visible = false;
        //            txtNoteContent.Visible = false;
        //            txtNoteTitle.Visible = false;
        //        }
        //        else
        //        {
        //            lblNoteErrorMsg.Text = "No ticket was selected";
        //        }
        //    }
        //        else
        //        {
        //            lblNoteErrorMsg.Text = "Title and Content must be filled";
        //        }
        //    }

        //            protected void btnCompleteTicket_Click(object sender, EventArgs e)
        //{
        //    //Response.Redirect();
        //}

        //protected void btnEmployeeCancel_Click(object sender, EventArgs e)
        //{
        //    ddlEmployee.Visible = false;
        //    btnEmployeeCancel.Visible = false;
        //    btnEmployeeSave.Visible = false;
        //}

        //protected void btnEmployeeSave_Click(object sender, EventArgs e)
        //{
        //    if (ddlEmployee.SelectedValue != null)
        //    {
        //        if (Session["ServiceTicketID"] != null)
        //        {
        //            //String sqlQuery = "UPDATE ServiceTicket SET InitiatingEmployeeID=" + ddlEmployee.SelectedValue + " WHERE ServiceTicketID=" + Session["ServiceTicketID"] + ";";
        //            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

        //            //sqlConnect.Open();
        //            //SqlCommand sqlCommand = new SqlCommand();
        //            //sqlCommand.Connection = sqlConnect;
        //            //sqlCommand.CommandText = sqlQuery;

        //            //sqlCommand.ExecuteNonQuery();
        //            //sqlConnect.Close();

        //            //sqlQuery = "INSERT INTO TicketHistory(ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (" + Session["ServiceTicketID"] + ", " + Session["EmployeeID"] + ", '" + DateTime.Now + "', 'New employee was assigned')";
        //            //sqlConnect.Open();
        //            //sqlCommand.Connection = sqlConnect;
        //            //sqlCommand.CommandText = sqlQuery;

        //            //sqlCommand.ExecuteNonQuery();

        //            Session["Employee"] = ddlEmployee.SelectedValue;

        //            lblErrorMsg.Text = "Employee successfully changed!";
        //            ddlEmployee.Visible = false;
        //            btnEmployeeSave.Visible = false;
        //            btnEmployeeCancel.Visible = false;
        //        }
        //        else
        //        {
        //            lblErrorMsg.Text = "No ticket was selected!";
        //        }
        //    }
        //    else
        //    {
        //        lblErrorMsg.Text = "No employee was selected!";
        //    }
        //}


        protected void btn_addNote(object sender, EventArgs e)
        {
            if (Session["TicketID"] == null)
            {
                lblErrorMsg.Text = "Please select a service ticket.";
            }
            else
            {
                pnlNotes.Visible = true;
            }
            
        }

        protected void fn_add(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String sqlQuery = "INSERT INTO Notes (ServiceTicketID, NoteTitle, NoteContent) VALUES (@TicketID, @NoteTitle, @NoteContent)";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection;
            sqlCommand.CommandText = sqlQuery;
            sqlCommand.Parameters.AddWithValue("@TicketID", Session["TicketID"].ToString());
            sqlCommand.Parameters.AddWithValue("@NoteTitle", txtNoteTitle.Text);
            sqlCommand.Parameters.AddWithValue("@NoteContent", txtNotes.Text);

            sqlCommand.ExecuteNonQuery();
            lblErrorMsg.Text = "Successfully saved to database!";
            pnlNotes.Visible = false;
        }

        protected void fn_cancelNote(object sender, EventArgs e)
        {
            pnlNotes.Visible = false;
        }

        protected void btn_editInventory(object sender, EventArgs e)
        {
            int ticketID = (int)grdTickets.DataKeys[0].Value;
            Session["InvTicketID"] = ticketID;
            Response.Redirect("Inventory.aspx");
        }

        protected void btn_assignEmp(object sender, EventArgs e)
        {
            pnlEmp.Visible = true;

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String sqlQuery = "SELECT concat(LastName, ', ', FirstName) as EmpName, EmployeeID FROM Employee";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(ds);
            connection.Close();

            ddlEmp.DataTextField = ds.Tables[0].Columns["EmpName"].ToString();
            ddlEmp.DataValueField = ds.Tables[0].Columns["EmployeeID"].ToString();

            ddlEmp.DataSource = ds.Tables[0];
            ddlEmp.DataBind();
        }

        protected void fn_addEmp(object sender, EventArgs e)
        {
            if (Session["TicketID"] == null)
            {
                lblErrorMsg.Text = "Please select a service ticket.";
            }
            else
            {
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                String sqlQuery = "UPDATE ServiceTicket SET InitiatingEmployeeID=@EmpID WHERE ServiceTicketID=@TicketID";
                connection.Open();
                SqlCommand sqlCommand2 = new SqlCommand();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.Parameters.AddWithValue("@TicketID", Session["TicketID"].ToString());
                sqlCommand.Parameters.AddWithValue("@EmpID", ddlEmp.SelectedItem.Value);
                sqlCommand.ExecuteNonQuery();


                String sqlQueryHist = "INSERT INTO TicketHistory (ServiceTicketID, EmployeeID, TicketChangeDate, DetailsNote) VALUES (@TicketID, @EmpID, @Date, @Note)";
                sqlCommand2.CommandText = sqlQueryHist;
                sqlCommand2.Connection = connection;
                sqlCommand2.Parameters.AddWithValue("@TicketID", Session["TicketID"].ToString());
                sqlCommand2.Parameters.AddWithValue("@EmpID", ddlEmp.SelectedItem.Value);
                sqlCommand2.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                sqlCommand2.Parameters.AddWithValue("@Note", "Changed Employee to: " + ddlEmp.SelectedItem.Text);
                sqlCommand2.ExecuteNonQuery();

                connection.Close();
                lblErrorMsg.Text = "Successfully saved to database!";
                pnlEmp.Visible = false;
            }
            
        }

        protected void btn_closeTicket(object sender, EventArgs e)
        {
            Session["ServiceTicketID"] = grdTickets.SelectedValue;
            Response.Redirect("CompletionForm.aspx");
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
            Session["TicketID"] = grdTickets.SelectedValue.ToString();
        }

        protected void grdTickets_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void AddRow(object sender, EventArgs e)
        {

        }
    }
}