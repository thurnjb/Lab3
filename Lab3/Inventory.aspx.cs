using System;
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
    public partial class Inventory : System.Web.UI.Page
    {
        protected int ticketID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InvTicketID"] == null)
            {
                Response.Redirect("CustomerPortalHome.aspx");
            }
            else
            {
                ticketID = (int)Session["InvTicketID"];
                DataTable invTable = new DataTable();
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                String sqlQuery = "SELECT Ii.ItemName, Ii.ItemDesc, Ii.ItemCost, Ii.InventoryDate FROM InventoryItem as Ii INNER JOIN InventoryService ON Ii.InventoryServiceID = InventoryService.InventoryServiceID WHERE InventoryService.InventoryServiceID = @InventoryServiceID AND Archived = null";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
                sqlCommand.Parameters.AddWithValue("@InventoryServiceID", ticketID);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(invTable);
                connection.Close();

                grdInventory.DataSource = invTable;
                grdInventory.DataBind();
            }
        }

        protected void AddRow(object sender, EventArgs e)
        {
            tblAdd.Visible = true;
            btnAdd.Visible = false;
        }

        protected void fn_add(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
            String sqlQuery = "INSERT INTO InventoryItem(InventoryServiceID, ItemName, ItemDesc, ItemCost, InventoryDate) VALUES (@InventoryServiceID, @ItemName, @ItemDesc, @ItemCost, @InventoryDate)";
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            sqlCommand.Parameters.AddWithValue("@ItemName", txtItemName.Text);
            sqlCommand.Parameters.AddWithValue("@ItemDesc", txtItemDesc.Text);
            sqlCommand.Parameters.AddWithValue("@ItemCost", txtItemCost.Text);
            sqlCommand.Parameters.AddWithValue("@InventoryDate", txtItemDate.Text);
            sqlCommand.Parameters.AddWithValue("@InventoryServiceID", ticketID);

            sqlCommand.ExecuteNonQuery();

            Response.Redirect("Inventory.aspx");
        }

        protected void fn_cancel(object sender, EventArgs e)
        {
            tblAdd.Visible = false;
            btnAdd.Visible = true;
        }
    }
}