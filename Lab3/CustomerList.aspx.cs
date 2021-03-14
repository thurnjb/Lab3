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
    /*Jay Thurn, Ryan Booth, John Lee
    Our submission of this assignment indicates that we have neither received nor given unauthorized assistance in writing this program. All design and coding is our own work.*/
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //This method returns to the home page
        protected void btnViewHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageV2.aspx");
        }

        //This method refreshes the page to remove the detailsview and update gridview
        protected void dtlVwUpdateCustomer_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("CustomerList.aspx");
        }

        //This method refreshes the page on cancel click to remove detailsview
        protected void dtlVwUpdateCustomer_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("CustomerList.aspx");
            }
        }

        //Method to populate file gridview with files owned by a particular customer
        protected void dltSelect(Object sender, EventArgs e)
        {
            GridViewRow row = grdCustomers.SelectedRow;
            Panel1.Visible = true;
            grdFiles.Visible = true;
            String customerName = row.Cells[2].Text + ", " + row.Cells[1].Text;
            int custID = getCustID(customerName);
            BindGrid(custID);
        }
        
        //Method to bind gridview using the selected customerID
        protected void BindGrid(int custID)
        {
            string constr = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Id, Name from tblFiles WHERE CustomerID = @CustomerID";
                    cmd.Parameters.AddWithValue("@CustomerID", custID);
                    cmd.Connection = con;
                    con.Open();
                    grdFiles.DataSource = cmd.ExecuteReader();
                    grdFiles.DataBind();
                    con.Close();
                }
            }
        }

        //Method drives the upload button. Uploads file to the DB.
        protected void btn_Upload(object sender, EventArgs e)
        {
            String filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            String contentType = FileUpload1.PostedFile.ContentType;
            GridViewRow row = grdCustomers.SelectedRow;
            String customerName = row.Cells[2].Text + ", " + row.Cells[1].Text;
            int custID = getCustID(customerName);
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    String constr = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        String query = "INSERT INTO tblFiles values (@CustomerID, @Name, @ContentType, @Data)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@CustomerID", custID);
                            cmd.Parameters.AddWithValue("@Name", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            BindGrid(custID);
        }

        //Method behind the download button. Uses selected file ID to grab and download file.
        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            String filename, contentType;
            String constr = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select Name, Data, ContentType from tblFiles where ID=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];
                        contentType = sdr["ContentType"].ToString();
                        filename = sdr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        protected int getCustID(String customerName)
        {
            String constr = ConfigurationManager.ConnectionStrings["Lab3"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CustomerID FROM Customer WHERE concat(LastName, ', ', FirstName) = @customerName";
            cmd.Parameters.AddWithValue("@customerName", customerName);
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int custID;
            custID = (int)reader["CustomerID"];
            reader.Close();
            con.Close();
            return custID;
        }
    }
}