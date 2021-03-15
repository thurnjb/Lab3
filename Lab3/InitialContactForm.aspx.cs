using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class InitialContactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLookAt_Click(object sender, EventArgs e)
        {
            Response.Redirect("LookAtScheduling.aspx");
        }

        protected void btnTicket_Click(object sender, EventArgs e)
        {

        }

        protected void btnAuction_Click(object sender, EventArgs e)
        {

        }
    }
}