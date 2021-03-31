<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs"
    Inherits="Lab3.CustomerDetails1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">
    <%--Customer Data View (viewable and editable)--%>
    <asp:GridView runat="server">
    </asp:GridView>
    <%--SQL data source for customer data--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

    <%--Customer current and historical job summaries (viewable and clickable)--%>
    <asp:GridView runat="server">
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
                <asp:Button ID="btnCreateAuction" runat="server" Text="Auction"
                    OnClick="btnCreateAuction_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCreateStorage" runat="server" Text="Storage"
                    OnClick="btnCreateStorage_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
