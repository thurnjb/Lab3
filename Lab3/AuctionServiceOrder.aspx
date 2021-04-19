<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuctionServiceOrder.aspx.cs" Inherits="Lab3.AuctionServiceOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:Table runat="server"> 

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelDateTime" runat="server" Text="Date & Time of Service"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxDateTime" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelContactInformationAuto" runat="server" Text="Contact Information & Notes"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxContactInformationAuto" Width="120" Height="200" runat="server"></asp:TextBox>
<%--                First Name, Last Name, Home Phone, Mobile Phone, Current Address--%>
                </asp:TableCell>
            </asp:TableRow>
                   <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelPickupAdd" runat="server" Text="If Address for Pick Up is Different, Fill in Here"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPickUpAddress" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>



            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Service Type"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
<%--                    If there is packing, a Packing Service Order Section will appear if that service was checked on the Auction Assessment Form and it will include --%>
       <asp:Label ID="LabelPackingServiceOrderForm" runat="server" Text="Packing Service Order Information"></asp:Label>
                    </asp:TableCell>
                <asp:TableCell>
        <asp:TextBox ID="TextBox1" Width="120" Height="200" runat="server"></asp:TextBox>
<%--                    Must Include, each type of box and a total for each kind AND Assign Crew (If we can edit this list later, then we want it to be a drop down menu where we can choose more than one person. If editing is going to be impossible, then we want this to be a text box)--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTrashRemovalServiceOrder" runat="server" Text="Trash Removal Service Order"></asp:Label>
                </asp:TableCell>
               <asp:TableCell>
<%--                Do we need a dumpster? (yes/no)
                Address (Populates from contact info OR #3 above)
                How many men (text box)
                How much we are charging (text box)
                Scheduling – use pop up
                Trash Description (populates from Auction Assessment Form)--%>
              <asp:TextBox ID="TextBoxTrashRemovalServiceOrder" Width="120" Height="200" runat="server"></asp:TextBox>

                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAuctionPickUpService" runat="server" Text="Auction Pick Up Service"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListAssignCrew" runat="server">
                        <asp:ListItem><-- Select Item --></asp:ListItem>
                        <asp:ListItem>Type of Home</asp:ListItem>
                        <asp:ListItem>Truck Accessibility</asp:ListItem>
                        <asp:ListItem>Walk From Loading Door</asp:ListItem>
                        <asp:ListItem>Steps Leading to House</asp:ListItem>
                        <asp:ListItem>Special Equipment</asp:ListItem>
                        <asp:ListItem>Trucks We are Taking</asp:ListItem>
                        <asp:ListItem>Boxes and Packing Material</asp:ListItem>
                        <asp:ListItem>Estimated Rate & Fees</asp:ListItem>
                    </asp:DropDownList>
<%--                Assign Crew (If we can edit this list later, then we want it to be a drop down menu where we can choose more than one person. If editing is going to be impossible, then we want this to be a text box)
                Link to Inventory that was gathered in Auction Assessment step
                Information that is populated from Auction Assessment – only items that were checked/filled out
                Type of home
                Truck accessibility (text box)
                How far walk is to loading door (text box)
                Steps leading up to house? How many? (text box)
                Special equipment
                Trucks we are taking
                Boxes & Packing Materials (check box, w/ space to add #)
                Estimated Rates and Fees --%>

<%--                    <asp:TextBox ID="TextBoxAuctionPickUpService" Width="120" Height="200" runat="server"></asp:TextBox>                --%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAssignedStorage" runat="server" Text="Assigned Storage"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
            <asp:TextBox ID="TextBoxAssignedStorage" Width="120" Height="100" runat="server"></asp:TextBox>                
<%--                    Information was sent earlier--%>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAuctionDateSet" runat="server" Text="Set Auction Date"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Calendar ID="CalendarAuctionDateSet" runat="server"></asp:Calendar>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxCalendar" Height="50px" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

                    </asp:Table>


</asp:Content>


