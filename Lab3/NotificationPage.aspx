<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NotificationPage.aspx.cs" Inherits="Lab3.NotificationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Button ID="btnHomePage" runat="server" Text="View Home Page"  OnClick="btnHomePage_Click"/>
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
            <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblDetail" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
            <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblDetail1" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

            <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblService" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
            <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblService1" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
            <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Label ID="lblService2" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

            <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Button ID="btnAccept" runat="server" Text="Accept New Customer to the System?" Visible="false" OnClick="btnAccept_Click" />
                        </asp:TableCell>
                    </asp:TableRow>

            <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                            <asp:Button ID="btnDeny" runat="server" Text="Deny New Cutsomer and Service" Visible="false" OnClick="btnDeny_Click"  />
                        </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>

                </asp:TableCell>
            </asp:TableRow>
                    
            </asp:Table>
                   <asp:GridView ID="grdNotifications" runat="server"
                        DataSourceID="sqlSourceNotifications"
                        DataKeyNames="NotificationID"
                        AutoGenerateColumns="false"
                        OnRowCommand="gridViewCommand"
                        AllowSorting="true">
                        <Columns>
                            <asp:ButtonField buttontype="Button"
                                commandname="Add"
                                headertext="Add Customer"
                                text="Add"/>
                            <asp:ButtonField ButtonType="Button"
                                commandname="Deny"
                                headertext="Deny Customer"
                                text="Deny" />
                            <asp:BoundField HeaderText="Username" DataField="Username" SortExpression="Username" />
                            <asp:BoundField HeaderText="First Name" DataField="FirstName" SortExpression="FirstName" />
                            <asp:BoundField HeaderText="Last Name" DataField="Lastname" SortExpression="LastName" />
                            <asp:BoundField HeaderText="Service Needed" DataField="ServiceNeeded" SortExpression="ServiceNeeded" />
                            <asp:BoundField HeaderText="Date Needed" DataField="DateNeeded" SortExpression="DateNeeded" />
                            <asp:BoundField HeaderText="Description" DataField="NoteDescription" SortExpression="NoteDescription" />
                            <asp:BoundField HeaderText="Address" DataField="CustAddress" SortExpression="CustAddress" />
                        </Columns>
                    </asp:GridView>
        <asp:SqlDataSource ID="sqlSourceNotifications" runat="server"
            ConnectionString="<%$ ConnectionStrings:Lab3 %>"
            SelectCommand="SELECT * FROM Notifications"></asp:SqlDataSource>
    </div>
</asp:Content>
