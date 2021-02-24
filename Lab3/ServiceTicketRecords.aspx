<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ServiceTicketRecords.aspx.cs" Inherits="Lab2.ServiceTicketRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->
    <br />
    <asp:Button ID="btnHomePage" runat="server" Text="View Home Page" OnClick="btnHomePage_Click" />
    <asp:Table ID="tblServiceInfo" runat="server" HorizontalAlign="Center">
        <asp:TableRow Height="200px">
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                <asp:Label ID="lblServiceTicketRecords" runat="server" Text="Service Ticket Records"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtCustomerName" runat="server" Enabled="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblInitiatingEmployee" runat="server" Text="Initiating Employee:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtInitiatingEmployee" runat="server" Enabled="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblServiceType" runat="server" Text="Service Type:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtServiceType" runat="server" Enabled="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTicketStatus" runat="server" Text="Ticket Status:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTicketStatus" runat="server" Enabled="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTicketOpenDate" runat="server" Text="Open Date:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTicketOpenDate" runat="server" Enabled="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblFromDeadline" runat="server" Text="Deadline From:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtFromDeadline" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblToDeadline" runat="server" Text="Deadline To:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtToDeadline" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="tblServicePageButtons" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnPopulate" runat="server" Text="Populate Cells" OnClick="btnPopulate_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnClear" runat="server" Text="Clear Cells" OnClick="btnClear_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnPrevious" runat="server" Text="Previous" OnClick="btnPrevious_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="5" HorizontalAlign="Center">
                <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" ColumnSpan="3">
                <asp:Label ID="lblInstructions" runat="server" Text="Please select from the lists below to fill the textboxes" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCustomerDDL" runat="server" Text="Customers:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblEmployeeDDL" runat="server" Text="Employee:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblServiceDDL" runat="server" Text="ServiceType:"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:DropDownList ID="ddlCustomerList" runat="server"
                    DataSourceID="dtasrcCustomer" 
                    DataTextField="CustomerName" 
                    DataValueField="CustomerID" 
                    AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlCustomerList_SelectedIndexChanged"></asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlEmployeeList" runat="server" 
                    DataSourceID="dtasrcEmployee" 
                    DataTextField="EmployeeName" 
                    DataValueField="EmployeeID" 
                    AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlEmployeeList_SelectedIndexChanged">
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlService" runat="server" 
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlService_SelectedIndexChanged" 
                    DataSourceID="dtasrcService"
                    DataTextField="ServiceType"
                    DataValueField="ServiceID">
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:SqlDataSource ID="dtasrcCustomer" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab2 %>" 
        SelectCommand="SELECT CustomerID, FirstName + ' ' + LastName as CustomerName FROM Customer">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dtasrcEmployee" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab2 %>" 
        SelectCommand="SELECT EmployeeID, FirstName + ' ' + LastName as EmployeeName FROM Employee">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dtasrcService" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab2 %>" 
        SelectCommand="SELECT * FROM Service">
    </asp:SqlDataSource>
</asp:Content>
