using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.RadioButton;

namespace Lab3
{
    public partial class AuctionAssessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chkBoxListSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String photo = "No"; 
            String whyAuction = ddlAuctionServ.SelectedValue;
            String deadline = rblDeadline.SelectedValue;
            String sched = chkBoxListSchedule.SelectedValue;
            String addServices = chkBoxAddistionalServ.SelectedValue;
            if(chkBoxPhoto.Checked)
            {
                photo = "Yes";
            }

            String sqlCommitQuery = "INSERT INTO AuctionAssessment(whatSell,whyAuction,deadline,deadlineDate,bringIn,walkThrough,pickUp,trashHaul,photos,moving,appraisal,CustomerID) VALUES(@whatSell, @whyAuction, @deadline, @deadlineDate, @bringIn, @walkThrough, @pickUp, @trashHaul, @photos, @moving, @appraisal, @CustomerID);";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandText = sqlCommitQuery;

            sqlCommand.Parameters.AddWithValue("@whatSell", HttpUtility.HtmlEncode(txtSellItem.Text));
            sqlCommand.Parameters.AddWithValue("@whyAuction", HttpUtility.HtmlEncode(whyAuction));
            sqlCommand.Parameters.AddWithValue("@deadline", HttpUtility.HtmlEncode(deadline));
            sqlCommand.Parameters.AddWithValue("@deadlineDate", HttpUtility.HtmlEncode(txtDeadline.Text));
            sqlCommand.Parameters.AddWithValue("@bringIn", HttpUtility.HtmlEncode(sched));
            sqlCommand.Parameters.AddWithValue("@walkThrough", HttpUtility.HtmlEncode(sched));
            sqlCommand.Parameters.AddWithValue("@pickUp", HttpUtility.HtmlEncode(sched));
            sqlCommand.Parameters.AddWithValue("@trashHaul", HttpUtility.HtmlEncode(sched));
            sqlCommand.Parameters.AddWithValue("@photos", HttpUtility.HtmlEncode(photo));
            sqlCommand.Parameters.AddWithValue("@moving", HttpUtility.HtmlEncode(addServices));
            sqlCommand.Parameters.AddWithValue("@appraisal", HttpUtility.HtmlEncode(addServices));
            sqlCommand.Parameters.AddWithValue("@CustomerID", HttpUtility.HtmlEncode(Session["CustomerID"]));
            sqlCommand.ExecuteNonQuery();

            //Response.Redirect("InventoryRegistration.aspx");
        }


        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtSellItem.Text = "Dresser";
            ddlAuctionServ.SelectedValue = "Cleaning House";
            rblDeadline.SelectedValue = "Yes";
            txtDeadline.Text = "6/12/21";
            chkBoxListSchedule.SelectedValue = "Pick Up";
            chkBoxPhoto.Checked = true;
            chkBoxAddistionalServ.SelectedValue = "None";
        }

        protected void btnSave_Click1(EventArgs e)
        {

        }
    }
}