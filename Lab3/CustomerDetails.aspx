<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs"
    Inherits="Lab3.CustomerDetails1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <%--Customer Data View (viewable and editable)--%>
    <asp:GridView ID="grdCustomers" runat="server"
        EmptyDataText="No customer with that name!"
        AutoGenerateSelectButton="true"
        SelectedIndex="1"
        OnSelectedIndexChanged="grdCustomers_SelectedIndexChanged"
        AllowSorting="true"
        OnSorting="grdCustomers_Sorting"
        DataKeyNames="CustomerID"
        AutoGenerateColumns="false">
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

    <%--SQL data source for customer data--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

    <%--Customer current and historical job summaries (viewable and clickable)--%>
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

    <%--SQL data source for customer job data--%>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>

    <%-- Row of action buttons to create new jobs--%>
    <asp:Table ID="tblActionButtons" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnCreateMove" runat="server" Text="Move" OnClick="btnCreateMove_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCreateAuction" runat="server" Text="Auction" OnClick="btnCreateAuction_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCreateStorage" runat="server" Text="Storage" OnClick="btnCreateStorage_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
