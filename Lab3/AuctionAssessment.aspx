<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuctionAssessment.aspx.cs" Inherits="Lab3.AuctionAssessment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSellItem" runat="server" Text="What do you have to sell?"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtSellItem" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblAuctionServDDL" runat="server" Text="Why are you considering auction services?"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlAuctionServ" runat="server" Width="165px">
                    <asp:ListItem Value="Cleaning House">I am cleaning house</asp:ListItem>
                    <asp:ListItem Value="Best Price">I want the best price</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDeadline" runat="server" Text="Is there a deadline?"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RadioButtonList ID="rblDeadline" runat="server">
                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                    <asp:ListItem Value="No">No</asp:ListItem>

                </asp:RadioButtonList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDeadlineDate" runat="server" Text="Deadline Date:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDeadline" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSchedule" runat="server" Text="What needs to be scheduled? "></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBoxList ID="chkBoxListSchedule"
                    runat="server"
                    AutoPostBack="true"
                    CellPadding="5" CellSpacing="5"
                    RepeatDirection="Vertical"
                    RepeatLayout="Flow"
                    TextAlign="Right"
                    OnSelectedIndexChanged="chkBoxListSchedule_SelectedIndexChanged">
                    <asp:ListItem Value="Bring In">Bring In</asp:ListItem>
                    <asp:ListItem Value="Auction Walk Though">Auction Walk Through</asp:ListItem>
                    <asp:ListItem Value="Pick Up">Pick Up</asp:ListItem>
                    <asp:ListItem Value="Trash Removal">Trash Removal &  Donation Hauling</asp:ListItem>
                </asp:CheckBoxList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPhoto" runat="server" Text="Photos:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBox ID="chkBoxPhoto" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblAdditionalServ" runat="server" Text="Do you need additional services?"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:CheckBoxList ID="chkBoxAddistionalServ" runat="server">
                    <asp:ListItem Value="Moving">Moving</asp:ListItem>
                    <asp:ListItem Value="Appraisal">Appraisal</asp:ListItem>
                    <asp:ListItem Value="None">None</asp:ListItem>
                </asp:CheckBoxList>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="tblbtn" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" />
            </asp:TableCell>
        </asp:TableRow>


    </asp:Table>

</asp:Content>
