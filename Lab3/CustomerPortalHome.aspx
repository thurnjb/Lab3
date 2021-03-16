<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerPortal.Master" AutoEventWireup="true" CodeBehind="CustomerPortalHome.aspx.cs" Inherits="Lab3.CustomerPortalHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblWelcome" runat="server" Text="Green Valley Auctions Customer Portal" Align="Left"></asp:Label>
        <asp:Table ID="tblStructure" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblWelcomeUser" runat="server" Text="Welcome, "></asp:Label><asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblFiles" runat="server" Text="My Files"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
               <asp:TableCell>
                    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                         <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btn_Upload" />
                     </asp:Panel>
                    <asp:GridView ID="grdFiles" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="File Name" />
                                <asp:TemplateField>
                                     <ItemTemplate>
                                         <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
