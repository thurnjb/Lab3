﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Lab2.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->
    <br />
    <asp:Button ID="btnViewHomePage" runat="server" Text="View Home Page"  OnClick="btnViewHomePage_Click"/>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="grdCustomers" runat="server" 
                    DataSourceID="dtasrcCustomerList" 
                    AutoGenerateEditButton="true" 
                    DataKeyNames="CustomerID"
                    AutoGenerateColumns="false"
                    AllowSorting="true">
                    <Columns>
                        <asp:BoundField HeaderText="FirstName" DataField="FirstName" SortExpression="FirstName" />
                        <asp:BoundField HeaderText="LastName" DataField="LastName" SortExpression="LastName" />
                        <asp:BoundField HeaderText="InitialContact" DataField="InitialContact" SortExpression="InitialContact" />
                        <asp:BoundField HeaderText="HeardFrom" DataField="HeardFrom" SortExpression="HeardFrom" />
                        <asp:BoundField HeaderText="Phone" DataField="Phone" SortExpression="Phone" />
                        <asp:BoundField HeaderText="Email" DataField="Email" SortExpression="Email" />
                        <asp:BoundField HeaderText="Address" DataField="Address" SortExpression="Address" />
                        <asp:BoundField HeaderText="DestAddress" DataField="DestAddress" SortExpression="DestAddress" />
                        <asp:BoundField ReadOnly="true" HeaderText="SaveDate" DataField="SaveDate" SortExpression="SaveDate" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="dtasrcCustomerList" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
                    SelectCommand="SELECT * FROM CUSTOMER"
                     UpdateCommand="UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, InitialContact=@InitialContact, HeardFrom=@HeardFrom, Phone=@Phone, Email=@Email, Address=@Address, DestAddress=@DestAddress WHERE CustomerID=@CustomerID">
                    <UpdateParameters>
                        <asp:Parameter Type="String" Name="FirstName" />
                        <asp:Parameter Type="String" Name="LastName" />
                        <asp:Parameter Type="String" Name="InitialContact" />
                        <asp:Parameter Type="String" Name="HeardFrom" />
                        <asp:Parameter Type="String" Name="Phone" />
                        <asp:Parameter Type="String" Name="Email" />
                        <asp:Parameter Type="String" Name="Address" />
                        <asp:Parameter Type="String" Name="DestAddress" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
