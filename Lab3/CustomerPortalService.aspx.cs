using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class CustomerPortalService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if(tbDate.Text !="" & tbDesc.Text !="")
            {
                lblStatus.Text = "Request Successfully Submitted";
                Application["Request"] = "yes";
                Application["ServiceType"] = ddlType.SelectedValue;
                Application["ServiceDate"] = tbDate.Text;
                Application["ServiceDesc"] = tbDesc.Text;
            }
            else
            {
                lblStatus.Text = "Please input all information";
            }
        }
    }
}