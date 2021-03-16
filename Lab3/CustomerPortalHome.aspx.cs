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
    public partial class CustomerPortalHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session["UserName"].ToString();
            BindGrid(getCustID(Session["UserName"].ToString()));
        }

        protected void btn_Upload(object sender, EventArgs e)
        {
            String filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            String contentType = FileUpload1.PostedFile.ContentType;
            String customerName = Session["UserName"].ToString();
            int custID = getCustID(customerName);
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    String constr = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
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

        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            String filename, contentType;
            String constr = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
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
        protected void BindGrid(int custID)
        {
            string constr = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
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

        protected int getCustID(String userName)
        {
            String constr = ConfigurationManager.ConnectionStrings["AUTH"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT UserID FROM Person WHERE Username = @Username";
            cmd.Parameters.AddWithValue("@Username", userName);
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int custID = (int)reader["UserID"];
            reader.Close();
            con.Close();
            return custID;
        }
    }
}