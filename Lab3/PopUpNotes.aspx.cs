using System;
using System.Collections.Generic;
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
                sqlCommitQuery = 
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}