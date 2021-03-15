using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

            String userName = Session["UserName"].ToString();
            String[] info = getCustomerInfo(userName);
            String firstName = info[0];
            String lastName = info[1];
            String service;
            if (ddlType.SelectedValue.Equals("1"))
            {
                service = "Move";
            }
            else
            {
                service = "Auction";
            }
            String date = tbDate.Text;
            String description = tbDesc.Text;
            String custAddress = info[2];

            addNotification(userName, firstName, lastName, service, date, description, custAddress);
            //if(tbDate.Text !="" & tbDesc.Text !="")
            //{
            lblStatus.Text = "Request Successfully Submitted";
            //    Application["Request"] = "yes";
            //    Application["ServiceType"] = ddlType.SelectedValue;
            //    Application["ServiceDate"] = tbDate.Text;
            //    Application["ServiceDesc"] = tbDesc.Text;
            //}
            //else
            //{
            //    lblStatus.Text = "Please input all information";
            //}
        }

        protected String[] getCustomerInfo(String userName)
        {
            String[] info = new String[3];
            String constr = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT FirstName, LastName, CustAddress FROM Person WHERE Username = @Username";
            cmd.Parameters.AddWithValue("@Username", userName);
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            info[0] = reader["FirstName"].ToString();
            info[1] = reader["LastName"].ToString();
            info[2] = reader["CustAddress"].ToString();
            reader.Close();
            con.Close();
            return info;
        }

        protected void addNotification(String userName, String firstName, String lastName, String service, String date, String description, String custAddress)
        {
            String constr = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Notifications(Username, FirstName, Lastname, ServiceNeeded, DateNeeded, NoteDescription, CustAddress)" +
                              " VALUES (@Username, @firstName, @lastName, @service, @date, @description, @custAddress)";
            cmd.Parameters.AddWithValue("@Username", userName);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            cmd.Parameters.AddWithValue("@service", service);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@custAddress", custAddress);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}