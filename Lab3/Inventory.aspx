<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Lab3.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
    .notstyle{
        text-align: center;
        float: right;
    }
</style>
        <h1 class="notstyle">INVENTORY</h1>
        <asp:Table ID="tblInventory" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:GridView ID="grdInventory" runat="server" 
                    HeaderStyle-BackColor="#000000"
                    AutoGenerateSelectButton="true" 
                    AllowSorting="true" 
                    AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Item Name" DataField="ItemName" SortExpression="ItemName" />
                            <asp:BoundField HeaderText="Item Description" DataField="ItemDesc" SortExpression="ItemDesc" />
                            <asp:BoundField HeaderText="Cost" DataField="ItemCost" SortExpression="ItemCost" />
                            <asp:BoundField HeaderText="Date Inventoried" DataField="InventoryDate" SortExpression="InventoryDate" />
                         </Columns>
                    </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddRow" Visible="true" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Table ID="tblAdd" runat="server" Visible="false">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>
                                <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                <asp:Label ID="lblItemDesc" runat="server" Text="Item Description"></asp:Label>
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                <asp:Label ID="lblItemCost" runat="server" Text="Cost"></asp:Label>
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                                <asp:Label ID="lblItemDate" runat="server" Text="Date Inventoried"></asp:Label>
                            </asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtItemDesc" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtItemCost" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtItemDate" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btn_add" runat="server" OnClick="fn_add" Text="Add" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button ID="btn_cancel" runat="server" OnClick="fn_cancel" Text="Cancel" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        

<%--    <asp:SqlDataSource ID="sqlInventory" runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT Ii.ItemName, Ii.ItemDesc, Ii.ItemCost, Ii.InventoryDate FROM InventoryItem as Ii INNER JOIN InventoryService ON Ii.InventoryItemID = InventoryService.InventoryItemID WHERE InventoryService.InventoryServiceID = @InventoryServiceID"
        InsertCommand="INSERT INTO InventoryItem (ItemName, ItemDesc, ItemCost, InventoryDate) VALUES (@ItemName, @ItemDesc, @ItemCost, @InventoryDate)"
        UpdateCommand="UPDATE InventoryItem SET ItemName=@ItemName, ItemDesc=@ItemDesc, InventoryDate=@InventoryDate WHERE InventoryItemID=@InventoryItemID">
        <SelectParameters>
            <asp:ControlParameter Name="InventoryServiceID" ControlID="grdInventory" DefaultValue='<%= Int32.Parse(Session["InvTicketID"]) %>' />
        </SelectParameters>
        <InsertParameters>
            <asp:ControlParameter Type="String" Name="ItemName" />
            <asp:ControlParameter Type="String" Name="ItemDesc" />
            <asp:ControlParameter Type="String" Name="InventoryDate" />
        </InsertParameters>
        <UpdateParameters>
            <asp:ControlParameter Type="String" Name="ItemName" />
            <asp:ControlParameter Type="String" Name="ItemDesc" />
            <asp:ControlParameter Type="String" Name="InventoryDate" />
        </UpdateParameters>
    </asp:SqlDataSource>--%>
</asp:Content>
