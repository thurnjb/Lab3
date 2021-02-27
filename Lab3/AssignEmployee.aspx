<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignEmployee.aspx.cs" Inherits="Lab3.AssignEmployee" %>

<!DOCTYPE html>

<!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="tblAssign" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlEmployee" runat="server" 
                            AutoPostBack="true" 
                            DataSourceID="dtasrcEmployee" 
                            DataTextField="NamePosition" 
                            DataValueField="EmployeeID">
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
            <asp:SqlDataSource ID="dtasrcEmployee" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
                SelectCommand="SELECT EmployeeID, FirstName + ' ' + LastName + ' ' + Position AS NamePosition FROM Employee">
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
