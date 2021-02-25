<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Lab2.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->
    <br />
    <asp:Button ID="btnViewHomePage" runat="server" Text="View Home Page"  OnClick="btnViewHomePage_Click"/>
    <asp:Table ID="Table1" runat="server" HorizontalAlign="center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="grdCustomers" runat="server" DataSourceID="dtasrcCustomerList"></asp:GridView>
                <asp:SqlDataSource ID="dtasrcCustomerList" runat="server" ConnectionString="<%$ ConnectionStrings:Lab3 %>" SelectCommand="SELECT * FROM CUSTOMER"></asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
