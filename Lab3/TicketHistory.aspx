<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TicketHistory.aspx.cs" Inherits="Lab2.TicketHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn
    I have neither given nor received any unauthorized assistance on this assignment-->
    <br />
    <asp:Button ID="btnViewHomePage" runat="server" Text="View Home Page" OnClick="btnViewHomePage_Click" />
    <fieldset>
        <legend>All Tickets</legend>
        <asp:GridView ID="grdTickets" runat="server" HorizontalAlign="Center"></asp:GridView>
    </fieldset>
    <fieldset>
        <legend>Select ServiceTicketID to View Details</legend>
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:DropDownList ID="ddlServiceTicketID" runat="server" 
                    AutoPostBack="true" 
                    DataSourceID="dtasrcServiceTicketID" 
                    DataTextField="ServiceTicketID" 
                    DataValueField="ServiceTicketID"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnViewTicketDetails" runat="server" Text="View Ticket Details" OnClick="btnViewTicketDetails_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </fieldset>
    <fieldset>
        <legend>Selected Ticket</legend>
        <asp:GridView ID="grdSelectedTicket" runat="server" EmptyDataText="This ticket has no notes!" HorizontalAlign="Center"></asp:GridView>
    </fieldset>
    <fieldset>
        <legend>Selected Ticket History</legend>
        <asp:GridView ID="grdSelectedTicketHistory" runat="server" EmptyDataText="This ticket has no history!" HorizontalAlign="Center"></asp:GridView>
    </fieldset>
    <asp:Button ID="btnAddNote" runat="server" Text="Add Note:" OnClick="btnAddNote_Click" />
    <asp:SqlDataSource ID="dtasrcServiceTicketID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab2 %>" 
        SelectCommand="SELECT ServiceTicketID FROM ServiceTicket">
    </asp:SqlDataSource>
</asp:Content>
