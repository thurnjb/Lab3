using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{

    /*Jay Thurn, Ryan Booth, John Lee
Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/
    public partial class CustomerPortalService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //This method sends the data to the notifications page
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