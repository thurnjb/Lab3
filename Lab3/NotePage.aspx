<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NotePage.aspx.cs" Inherits="Lab2.NotePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn
    I have neither given nor received any unauthorized assistance on this assignment-->
    <br />
    <asp:Button ID="btnViewHomePage" runat="server" Text="View Home Page" OnClick="btnViewHomePage_Click" />
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNoteTitle" runat="server" Text="Note Title:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNoteTitle" runat="server" Width ="500px"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNoteContent" runat="server" Text="Note Content:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNoteContent" runat="server" Height="500px" Width="500px" TextMode="MultiLine" ></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                <asp:Button ID="btnSaveNote" runat="server" Text="Save Note" OnClick="btnSaveNote_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center" ColumnSpan="2">
                <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
