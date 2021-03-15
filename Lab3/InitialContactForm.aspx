<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InitialContactForm.aspx.cs" Inherits="Lab3.InitialContactForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
         <asp:Button ID="btnHomePage" runat="server" Text="View Home Page" OnClick="btnHomePage_Click"/>
    <asp:Table ID="tblContent" runat="server">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <asp:Label ID="lblContactForm" runat="server" Text="Initial Contact Form"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPhone" runat="server" Text="Phone Number:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblInitialContact" runat="server" Text="Contact Method:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtInitialContact" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblHeardFrom" runat="server" Text="How they heard about us:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtHeardFrom" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblRequestedService" runat="server" Text="Requested Service:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtRequestedService" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="tblButtons" runat="server">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" />
            </asp:TableCell>
            <asp:TableCell >
                <asp:Button ID="btnSave" runat="server" Text="Save New Customer" OnClick="btnSave_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnLookAt" runat="server" Text="Schedule Look At" OnClick="btnLookAt_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnMove" runat="server" Text="Schedule Move" OnClick="btnTicket_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnAuction" runat="server" Text="Schedule Auction" OnClick="btnAuction_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblError" runat="server" Text="" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        </div>
</asp:Content>
