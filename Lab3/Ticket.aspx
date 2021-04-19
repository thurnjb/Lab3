<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="Lab3.TicketPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <title>Customer Database</title>
        <link href="css/styles.css" rel="stylesheet">
        <link rel="stylesheet" href="css/heading.css">
        <link rel="stylesheet" href="css/body.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
    .form-control {
        border-color: white;
        background-color: #daac00;
        text-align: center;
        color: white;
    }
</style>
    </head>
    <body>
        <header class="masthead bg-primary text-black text-center">
            <div class="container d-flex align-items-center flex-column">
            <form class="example" action="action_page.php">
                  <h1> OPEN TICKETS </h1>
                <asp:GridView ID="grdTickets" runat="server" 
                    HeaderStyle-BackColor="#000000"
                    DataKeyNames="ServiceTicketID" 
                    AutoGenerateSelectButton="true" 
                    AllowSorting="true" 
                    AutoGenerateColumns="false" 
                    OnSelectedIndexChanged="grdTickets_SelectedIndexChanged" 
                    OnSorting="grdTickets_Sorting">
                    <Columns>
                        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" SortExpression="CustomerName" />
                        <asp:BoundField HeaderText="Employee Name" DataField="EmployeeName" SortExpression="EmployeeName" />
                        <asp:BoundField HeaderText="Service Type" DataField="Service" SortExpression="Service" />
                        <asp:BoundField HeaderText="Ticket Status" DataField="TicketStatus" SortExpression="TicketStatus" />
                        <asp:BoundField HeaderText="Ticket Open Date" DataField="TicketOpenDate" SortExpression="TicketOpenDate" />

                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
 <button type="button" class="form-control btn btn-primary submit px-3" runat="server" OnServerClick="btn_addNote">Add Note</button> 
                <asp:Panel ID="pnlNotes" runat="server" Visible="false">
                    <asp:Label ID="lblNoteTitle" runat="server" Text="Title:"></asp:Label>
                    <asp:TextBox ID="txtNoteTitle" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtNotes" Rows="10" runat="server"></asp:TextBox>
                    <button type="button" runat="server" OnServerClick="fn_add">Add</button>
                    <button type="button" runat="server" OnServerClick="fn_cancelNote">Cancel</button>
                </asp:Panel>
   <form class="example" action="action_page.php">
 <button type="button" class="form-control btn btn-primary submit px-3" runat="server" OnServerClick="btn_editInventory">Edit Inventory</button> 
<%--                <asp:Panel ID="pnlInv" runat="server" Visible="false">
                   <asp:GridView ID="grdInventory" runat="server" 
                    HeaderStyle-BackColor="#000000"
                    DataKeyNames="InventoryItemID" 
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
                </asp:Panel>--%>
   <form class="example" action="action_page.php">
 <button type="submit" class="form-control btn btn-primary submit px-3" runat="server" OnServerClick="btn_assignEmp">Assign Employee</button> 
                <asp:Panel ID="pnlEmp" runat="server" Visible="false">
                    <asp:Label ID="lblChooseEmp" runat="server" Text="Select Employee:"></asp:Label>
                    <asp:DropDownList ID="ddlEmp" runat="server"></asp:DropDownList><br />
                    <button type="button" runat="server" OnServerClick="fn_addEmp">Assign</button>
                </asp:Panel>
   <form class="example" action="action_page.php">
 <button type="button" class="form-control btn btn-primary submit px-3" runat="server" OnServerClick="btn_closeTicket">Close Ticket</button> 




</div>

             
        </header>
      
          
    </body>
</html>


    <asp:SqlDataSource ID="dtasrcServiceTicketID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" >
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dtasrcNotes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
        SelectCommand="SELECT * FROM Notes WHERE ServiceTicketID = @ServiceTicketID" 
        UpdateCommand="UPDATE Notes SET NoteTitle=@NoteTitle, NoteContent=@NoteContent WHERE NoteID=@NoteID">
        <SelectParameters>
            <asp:ControlParameter name="ServiceTicketID" ControlID="grdTickets"/>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter type="String" Name="NoteTitle"/>
            <asp:Parameter Type="String" Name="NoteContent"/>
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dtasrcEmployee" runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT EmployeeID, FirstName + ' ' + LastName + ' ' + Position AS NamePosition FROM Employee">
    </asp:SqlDataSource>

        <asp:SqlDataSource ID="sqlInventory" runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT Ii.ItemName, Ii.ItemDesc, Ii.ItemCost, Ii.InventoryDate FROM InventoryItem as Ii WHERE InventoryService INNER JOIN InventoryService ON Ii.InventoryItemID = InventoryService.InventoryItemID"
        InsertCommand="INSERT INTO InventoryItem (ItemName, ItemDesc, ItemCost, InventoryDate) VALUES (@ItemName, @ItemDesc, @ItemCost, @InventoryDate)"
        UpdateCommand="UPDATE InventoryItem SET ItemName=@ItemName, ItemDesc=@ItemDesc, InventoryDate=@InventoryDate WHERE InventoryItemID=@InventoryItemID">
        <SelectParameters>
<%--            <asp:ControlParameter Name=""--%>
        </SelectParameters>
    </asp:SqlDataSource>



</asp:Content>
