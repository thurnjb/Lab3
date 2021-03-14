<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerSearch.aspx.cs" Inherits="Lab3.CustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Button ID="btnHomePage" runat="server" Text="View Home Page" OnClick="btnHomePage_Click"/>
     <div style="text-align: center">
         <asp:Table ID="detailTable" runat="server">

             <asp:TableRow Height="100px">
                 <asp:TableCell ColumnSpan="3">
                     <asp:Label ID="lblCustDetail" runat="server" Text="Customer Search"></asp:Label>
                 </asp:TableCell>
             </asp:TableRow>

             <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblSelect" runat="server" Text="Enter first or last name"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
             <asp:TableRow>
                 <asp:TableCell ColumnSpan="5">
                     <asp:TextBox ID="txtCustomerSearch" runat="server"></asp:TextBox>
                 </asp:TableCell>
             </asp:TableRow>
             <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Button ID="btnView" runat="server" Text="View Customers" OnClick="btnView_Click" />
                        </asp:TableCell>
             </asp:TableRow>
         </asp:Table>
         <br />
         <asp:GridView ID="grdCustomers" runat="server" 
             EmptyDataText="No customer with that name!" 
             AutoGenerateSelectButton="true" 
             SelectedIndex="1"
             OnSelectedIndexChanged="grdCustomers_SelectedIndexChanged"
             AllowSorting="true" 
             OnSorting="grdCustomers_Sorting"
             DataKeyNames="CustomerID" 
             AutoGenerateColumns="false" >
             <Columns>
                 <asp:BoundField HeaderText="FirstName" DataField="FirstName" SortExpression="FirstName" />
                 <asp:BoundField HeaderText="LastName" DataField="LastName" SortExpression="LastName" />
                 <asp:BoundField HeaderText="InitialContact" DataField="InitialContact" SortExpression="InitialContact" />
                 <asp:BoundField HeaderText="HeardFrom" DataField="HeardFrom" SortExpression="HeardFrom" />
                 <asp:BoundField HeaderText="Phone" DataField="Phone" SortExpression="Phone" />
                 <asp:BoundField HeaderText="Email" DataField="Email" SortExpression="Email" />
                 <asp:BoundField HeaderText="Address" DataField="Address" SortExpression="Address" />
                 <asp:BoundField HeaderText="DestAddress" DataField="DestAddress" SortExpression="DestAddress" />
                 <asp:BoundField HeaderText="SaveDate" DataField="SaveDate" SortExpression="SaveDate" />
             </Columns>
         </asp:GridView>
         <br />
         <asp:GridView ID="grdTickets" runat="server" 
             EmptyDataText="This customer has no tickets!" 
             AutoGenerateColumns="false"
             AutoGenerateSelectButton="true"
             SelectedIndex="1" 
             AllowSorting="true" 
             DataKeyNames="ServiceTicketID" 
             OnSelectedIndexChanged="grdTickets_SelectedIndexChanged" 
             OnSorting="grdTickets_Sorting">
            <Columns>
                <asp:BoundField HeaderText="CustomerName" DataField="CustomerName" SortExpression="CustomerName" />
                <asp:BoundField HeaderText="EmployeeName" DataField="EmployeeName" SortExpression="EmployeeName" />
                <asp:BoundField HeaderText="ServiceType" DataField="ServiceType" SortExpression="ServiceType" />
                <asp:BoundField HeaderText="TicketStatus" DataField="TicketStatus" SortExpression="TicketStatus" />
                <asp:BoundField HeaderText="TicketOpenDate" DataField="TicketOpenDate" SortExpression="TicketOpenDate" />
                <asp:BoundField HeaderText="FromDeadline" DataField="FromDeadline" SortExpression="FromDeadline" />
                <asp:BoundField HeaderText="ToDeadline" DataField="ToDeadline" SortExpression="ToDeadline" />
            </Columns> 
         </asp:GridView>
         <br />
         <asp:GridView ID="grdNotes" runat="server" EmptyDataText="This ticket has no notes!" AutoGenerateColumns="false" DataKeyNames="NoteID">
             <Columns>
                 <asp:BoundField HeaderText="NoteTitle" DataField="NoteTitle"/>
                 <asp:BoundField HeaderText="NoteContent" DataField="NoteContent"/>
             </Columns>
         </asp:GridView>
         <br />
         <asp:GridView ID="grdTicketHistory" runat="server" EmptyDataText="This ticket has no history!" AutoGenerateColumns="false" DataKeyNames="TicketHistoryID">
             <Columns>
                 <asp:BoundField HeaderText="EmployeeContact" DataField="EmployeeContact"/>
                 <asp:BoundField HeaderText="TicketChangeDate" DataField="TicketChangeDate"/>
                 <asp:BoundField HeaderText="DetailsNote" DataField="DetailsNote"/>
             </Columns>
         </asp:GridView>
     </div>
</asp:Content>
