<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="Lab3.CustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->
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
                            <asp:Label ID="lblSelect" runat="server" Text="Customer Lookup"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
             <asp:TableRow>
                 <asp:TableCell ColumnSpan="5">
                     <asp:DropDownList ID="ddlCustomerList" runat="server"
                         DataSourceID="dtasrcCustomer"
                         DataTextField="CustomerName"
                         DataValueField="CustomerID"
                         AutoPostBack="true">
                     </asp:DropDownList>
                 </asp:TableCell>
             </asp:TableRow>
             <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Button ID="btnView" runat="server" Text="View Customer Details" OnClick="btnView_Click" />
                        </asp:TableCell>
             </asp:TableRow>
         </asp:Table>
         <asp:GridView ID="grdCustomerTicket" runat="server" 
             EmptyDataText="This customer has no tickets!" >
         </asp:GridView>
     </div>
    <asp:SqlDataSource ID="dtasrcCustomer" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
        SelectCommand="SELECT CustomerID, FirstName + ' ' + LastName as CustomerName FROM Customer">
    </asp:SqlDataSource>
</asp:Content>
