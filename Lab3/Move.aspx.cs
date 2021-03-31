using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) // Original
        {

        }

        protected void ButtonAddNote_Click(object sender, EventArgs e) // Orginial 
        {
            Session["EditTicketPage"] = "true";
            lblNoteTitle.Visible = true;
            txtNoteContent.Visible = true;
            txtNoteTitle.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxCalendar.Text = Calendar1.SelectedDate.Date.ToString();
          
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
