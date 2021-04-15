using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class MoveAssessmentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        //Loops through array and checks if a panel is visible
        //If panel is visible, make all panels invisible
        //If next was clicked, make next panel visible
        protected void ChangePanelVisible(Boolean goNext)
        {
            //this is awful programming
            //update with loop
            Panel[] arr = new Panel[] { Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8, Panel9, Panel10, Panel11 };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Visible == true)
                {
                    if (goNext && i != arr.Length - 1)
                    {
                        arr[i].Visible = false;
                        arr[i + 1].Visible = true;
                        break;
                    }
                    if (!goNext && i != 0)
                    {
                        arr[i].Visible = false;
                        arr[i - 1].Visible = true;
                        break;
                    }
                }

            }

        }


        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            //String sqlCommitQuery = "INSERT INTO";

            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //sqlConnect.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnect;
            //sqlCommand.CommandText = sqlCommitQuery;
            //sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));

            //sqlCommand.ExecuteNonQuery();
        }

        protected void btnPreviousPanel_Click(object sender, EventArgs e)
        {
            ChangePanelVisible(false);
        }

        protected void btnNextPanel_Click(object sender, EventArgs e)
        {
            ChangePanelVisible(true);
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            //eek I don't want to do this
        }
    }


}