<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NotificationPage.aspx.cs" Inherits="Lab3.NotificationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">
        <asp:Table ID="Table1" runat="server" Height="300px" HorizontalAlign="Center">

                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblTitle" runat="server" Text="Notifications"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    
            </asp:Table>
    </div>
</asp:Content>
