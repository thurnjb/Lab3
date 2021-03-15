<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="Lab3.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Button ID="btnHomePage" runat="server" Text="View Home Page" OnClick="btnHomePage_Click" />
    <asp:GridView ID="grdNotifications" runat="server" 
        EmptyDataText="There are no notifications!"
        AutoGenerateColumns="false"
        DataSourceID="dtasrcNotifications" 
        DataKeyNames="NotificationID" 
        AutoGenerateSelectButton="true" 
        OnSelectedIndexChanged="grdNotifications_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
            <asp:BoundField HeaderText="LastName" DataField="LastName" />
            <asp:BoundField HeaderText="Phone" DataField="Phone" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Address" DataField="Address" />
            <asp:BoundField HeaderText="RequestedService" DataField="RequestedService" />
            <asp:BoundField HeaderText="SaveDate" DataField="SaveDate" />
        </Columns>
    </asp:GridView>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Calendar ID="Calendar1" runat="server" DayNameFormat="Shortest" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtCalendarDate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnConfirm" runat="server" Text="Enter Potential Date" OnClick="btnConfirm_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:ListBox ID="lstbxPotentialDates" runat="server"></asp:ListBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnSendRequest" runat="server" Text="Send Request" OnClick="btnSendRequest_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:SqlDataSource ID="dtasrcNotifications" runat="server"
         ConnectionString="<%$ ConnectionStrings:Lab3 %>"
         SelectCommand="SELECT N.NotificationID, N.CustomerID, C.FirstName, C.LastName, C.Phone, C.Email, C.Address, C.RequestedService, C.SaveDate FROM Customer C, NotificationTable N WHERE N.CustomerID = C.CustomerID"
         DeleteCommand="">

    </asp:SqlDataSource>
</asp:Content>
