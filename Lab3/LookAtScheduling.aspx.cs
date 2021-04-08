﻿using System;
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
    public partial class LookAtScheduling : System.Web.UI.Page
    {
        private static DataTable grdVwNotification = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            
        }

        protected void BindData()
        {
            grdVwNotification.Clear();

            String sqlQuery = "Select N.NotificationID, C.FirstName, C.LastName, N.SaveDate FROM Customer C, LookAtNotification N WHERE N.CustomerID = C.CustomerID AND N.NotificationID = " + Session["LookAtID"];

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlQuery, sqlConnect);

            sqlConnect.Open();

            sqlAdapter.Fill(grdVwNotification);

            grdNotification.DataSource = grdVwNotification;
            grdNotification.DataBind();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtCalendarDate.Text = Calendar1.SelectedDate.Date.ToString();
            lblErrorMsg.Text = "";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lstbxPotentialDates.Items.Add(txtCalendarDate.Text);
            txtCalendarDate.Text = "";
            lblErrorMsg.Text = "";
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            int lstbxCount = lstbxPotentialDates.Items.Count;
            if (lstbxPotentialDates.Items.Count != 0)
            {
                for (int i = 0; i < lstbxCount; i++)
                {
                    String sqlQuery = "INSERT INTO NotificationTable_Dates(NotificationID, PotentialDate) VALUES (" + Session["LookAtID"] + ", '" + lstbxPotentialDates.Items[i].ToString() + "')";

                    SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    sqlConnect.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnect;
                    sqlCommand.CommandText = sqlQuery;

                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                for (int k = lstbxCount - 1; k >= 0; k--)
                {
                    lstbxPotentialDates.Items.RemoveAt(k);
                }
                //String deleteQuery = "DELETE FROM LookAtNotification WHERE NotificationID = " + Session["LookAtID"];
                //SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                //connection.Open();
                //SqlCommand command = new SqlCommand();
                //command.Connection = connection;
                //command.CommandText = deleteQuery;

                //command.ExecuteNonQuery();
                //connection.Close();
            }
            else
            {
                lblErrorMsg.Text = "Must select a notification and dates!";
            }
        }
    }
}