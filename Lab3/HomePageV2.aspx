<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePageV2.aspx.cs" Inherits="Lab3.HomePageV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->
    <div style="text-align: center">
        <asp:Table ID="Table1" runat="server" Height="300px" HorizontalAlign="Center">

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" Font-Bold="true" Font-Size="X-Large">
                    <asp:Label ID="lblCompany" runat="server" Text="Green Valley Auctions"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Label ID="lblHomePage" runat="server" Text="Home Page" Font-Bold="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="btnGregNotifications" runat="server" Text="Admin Notifications" OnClick="btnGregNotifications_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnInitialContact" runat="server" Text="Initial Contact Form" OnClick="btnInitialContact_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnCustomerSearch" runat="server" Text="Customer Search" OnClick="btnCustomerSearch_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnViewCustomerRecord" runat="server" Text="Create New Customer Records" OnClick="btnViewCustomerRecord_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnViewServiceTicket" runat="server" Text="Create New Tickets" OnClick="btnViewServiceTicket_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnViewCustomerList" runat="server" Text="Edit Customers" OnClick="btnViewCustomerList_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnViewTicketHistory" runat="server" Text="Edit Tickets" OnClick="btnViewTicketHistory_Click" />
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </div>
</asp:Content>
