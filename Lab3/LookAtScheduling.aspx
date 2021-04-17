<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LookAtScheduling.aspx.cs" Inherits="Lab3.LookAtScheduling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <title>Customer Database</title>
        <link href="css/styles.css" rel="stylesheet">
        <link rel="stylesheet" href="css/heading.css">
        <link rel="stylesheet" href="css/body.css">
        <style>
            .mobile-wrapper {
                color: black;
            }
        </style>
    </head>
    <body>
        <header class="masthead bg-primary text-black text-center">
            <div class="container d-flex align-items-center flex-column">
                <img class="masthead-avatar mb-5" <img src="images/greenvalleyauctions.jpeg" alt="Green Valley Auctions Logo" width="300">

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSelectedNotif" runat="server" Text="Selected Notification:"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="grdNotification" runat="server" AutoGenerateColumns="false" DataKeyNames="NotificationID" HeaderStyle-BackColor="black" HeaderStyle-ForeColor="white">
                    <Columns>
                        <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
                        <asp:BoundField HeaderText="LastName" DataField="LastName" />
                        <asp:BoundField HeaderText="SaveDate" DataField="SaveDate" />
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
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
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</body>
</html>
</asp:Content>
