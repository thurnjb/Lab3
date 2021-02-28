<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignAuction.aspx.cs" Inherits="Lab3.AssignAuction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="tblAuction" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlAuction" runat="server" 
                            AutoPostBack="true"
                            DataSourceID="dtasrcAuction" 
                            DataTextField="AuctionPair" 
                            DataValueField="AuctionID">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:SqlDataSource ID="dtasrcAuction" runat="server" 
                ConnectionString="<%$ConnectionStrings:Lab3 %>"
                SelectCommand="SELECT AuctionID, AuctionName + ' - ' + CONVERT(varchar(255), AuctionDate) as AuctionPair FROM Auction">
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
