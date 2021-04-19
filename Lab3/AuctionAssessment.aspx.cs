using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtSellItem.Text = "Dresser";
            ddlAuctionServ.SelectedValue = "1";
            chkBoxConfirm.Checked = true;
            chkBoxDeny.Checked = false;
            txtDeadline.Text = "6/12/21";
            chkBoxListSchedule.SelectedValue = "Value1";
            chkBoxPhoto.Checked = true;
            chkBoxItemList.Checked = true;
            chkBoxAddistionalServ.SelectedValue = "4";
        }
    }
}