<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ServiceTicketRecords.aspx.cs" Inherits="Lab3.ServiceTicketRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->
    <br />
    <asp:Button ID="btnHomePage" runat="server" Text="View Home Page" OnClick="btnHomePage_Click" />
    <asp:Table ID="tblServiceInfo" runat="server">
        <asp:TableRow Height="100px">
            <asp:TableCell ColumnSpan="3">
                <asp:Label ID="lblServiceTicketRecords" runat="server" Text="Service Ticket Records" Font-Bold="true"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
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
                <asp:Label ID="lblServiceDDL" runat="server" Text="Service Type:"></asp:Label>
        </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblAdditionalServiceDDL" runat="server" Text="Additional Service:"></asp:Label>
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
            <asp:TableCell>
                <asp:DropDownList ID="ddlAdditionalService" runat="server" 
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlAdditionalService_SelectedIndexChanged" 
                    DataSourceID="dtasrcAdditionalService"
                    DataTextField="AdditionalServiceType"
                    DataValueField="AdditionalServiceID">
                </asp:DropDownList>
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
                    <asp:Label ID="lblAdditionalService" runat="server" Text="Addtional Service:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAdditionalService" runat="server" Enabled="false"></asp:TextBox>
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
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLookAt" runat="server" Text="Look At Date:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLookAt" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPickup" runat="server" Text="Pick Up Date:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPickup" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="tblServicePageButtons" runat="server">
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
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="5">
                <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNoteTitle" runat="server" Text="Note Title:" Visible="false"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNoteTitle" runat="server" Visible="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNoteContent" runat="server" Text="Note Content:" Visible="false"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNoteContent" runat="server" Height="300px" Width="300px" TextMode="MultiLine" Visible="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnNoteCancel" runat="server" Text="Cancel" OnClick="btnNoteCancel_Click" Visible="false" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnNoteSave" runat="server" Text="Save Note" OnClick="btnNoteSave_Click" Visible="false" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNoteErrorMsg" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:SqlDataSource ID="dtasrcCustomer" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
        SelectCommand="SELECT CustomerID, FirstName + ' ' + LastName as CustomerName FROM Customer">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dtasrcEmployee" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
        SelectCommand="SELECT EmployeeID, FirstName + ' ' + LastName as EmployeeName FROM Employee">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dtasrcService" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
        SelectCommand="SELECT * FROM Service">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dtasrcAdditionalService" runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
        SelectCommand="SELECT * FROM AdditionalService">
    </asp:SqlDataSource>
</asp:Content>
