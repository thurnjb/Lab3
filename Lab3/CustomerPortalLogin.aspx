<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPortalLogin.aspx.cs" Inherits="Lab3.CustomerPortalLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" Font-Bold="true" Font-Size="X-Large" HorizontalAlign="Center">
                        <asp:Label ID="lblCompany" runat="server" Text="Green Valley Auctions"></asp:Label>
                        <br />
                    </asp:TableCell>
         </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblTitle" runat="server" Text="Customer Login Portal"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblLogin" runat="server" Text="Please enter your login information"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblUserName" runat="server" Text="Username:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPassWord" runat="server" Text="Password:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPassWord" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblOr" runat="server" Text="OR"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblCreate" runat="server" Text="Create a Customer Account"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblFNameCreate" runat="server" Text="First Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbFirstNameCreate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLNameCreate" runat="server" Text="Last Name:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbLastNameCreate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblUsernameCreate" runat="server" Text="Email (This will be your username):"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbUsernameCreate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPasswordCreate" runat="server" Text="Password:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbPasswordCreate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblAddressCreate" runat="server" Text="Address:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbAddressCreate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPhoneCreate" runat="server" Text="Phone Number:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbPhoneCreate" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblHearCreate" runat="server" Text="How Did You Hear of Us?:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbHearCreate" runat="server"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click"/>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" OnClick="btnCreateAccount_Click" />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblAccountStatus" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="btnEmpLogin" runat="server" Text="EMPLOYEE LOGIN PORTAL" OnClick="btnEmpLogin_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
    </form>
</body>
</html>
