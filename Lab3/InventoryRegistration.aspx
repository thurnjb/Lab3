<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InventoryRegistration.aspx.cs" Inherits="Lab3.InventoryRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTitle" runat="server" Text="Inventory Registration"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblName" runat="server" Text="Item Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDesc" runat="server" Text="Item Description"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblCost" runat="server" Text="Item Cost"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbCost" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDate" runat="server" Text="Item Storage Date"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbDate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
