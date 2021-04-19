<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MoveAssessmentForm.aspx.cs" Inherits="Lab3.MoveAssessmentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    &nbsp;<asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTitle" runat="server" Text="Move Assessment"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%--Navigation buttons--%>

                <asp:DropDownList ID="ddlSkipToSection" runat="server" OnSelectedIndexChanged="ddlSkipToSection_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" Text="Select" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Customer Questions" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Room Info" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Notes" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Home Info" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Storage Info" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Logistics Info" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Equipment Needed" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Estimate Cost" Value="8"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnPreviousPanel" runat="server" Text="Back" OnClick="btnPreviousPanel_Click" />
                <asp:Button ID="btnNextPanel" runat="server" Text="Next" OnClick="btnNextPanel_Click" />
                <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <%--Panel 1 (Customer Questions)--%>
    <asp:Panel ID="Panel1" runat="server" Visible="true">
        <asp:Table ID="Table_Page1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel1Header" runat="server" Text="Customer Questions"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelMoveOutDate" runat="server" Text="What date do you need to be out of current address?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxMoveOutDate" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelWindowDaysMove" runat="server" Text="What is the window of days you can move?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxWindowDaysMove" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAddressMovingTo" runat="server" Text="What is the address you are moving to?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAddressMovingTo" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelMLSListing" runat="server" Text="Is there a MLS Listing?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxMLSListing" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelPhotos" runat="server" Text="Can you send photos if we need them?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPhotos" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAddService" runat="server" Text="Do you need add on services?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListAddService" runat="server" CssClass="Service">
                        <asp:ListItem Value="Packing"> Packing Service </asp:ListItem>
                        <asp:ListItem Value="TrashRemoval_Donation"> Trash Removal/Dontation Hauling </asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAuctionServices" runat="server" Text="Do you need auction services?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAuctionServices" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 2 (Room Info)--%>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel2Header" runat="server" Text="Room Info"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelOrderOfRooms" runat="server" Text="Order of Rooms:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListOrderOfRooms" runat="server" CssClass="Rooms">
                        <asp:ListItem Value="LivingRoom"> Living Room </asp:ListItem>
                        <asp:ListItem Value="DiningRoom"> Dining Room </asp:ListItem>
                        <asp:ListItem Value="Kitchen"> Kitchen </asp:ListItem>
                        <asp:ListItem Value="Den"> Den </asp:ListItem>
                        <asp:ListItem Value="Office"> Office </asp:ListItem>
                        <asp:ListItem Value="Bedrooms"> Bedrooms </asp:ListItem>
                        <asp:ListItem Value="Attic"> Attic </asp:ListItem>
                        <asp:ListItem Value="Basement"> Basement </asp:ListItem>
                        <asp:ListItem Value="Garage"> Garage </asp:ListItem>
                        <asp:ListItem Value="Patio/Porch"> Patio/Porch </asp:ListItem>
                        <asp:ListItem Value="OutBuildings"> OutBuildings </asp:ListItem>
                        <asp:ListItem Value="Bedrooms"> Bedrooms </asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelEachRoomFurniture" runat="server" Text="List of Normal Furniture"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:ListBox ID="ListBoxEachRoomFurniture" Width="200" runat="server"></asp:ListBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelRoomFloor" runat="server" Text="Select Room Floor"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxFloor" runat="server" CssClass="Floor">
                        <asp:ListItem Value="Basement"> Basement </asp:ListItem>
                        <asp:ListItem Value="GroundFloor"> Ground Floor </asp:ListItem>
                        <asp:ListItem Value="2ndFloor"> 2nd Floor </asp:ListItem>
                        <asp:ListItem Value="3rdFloor"> 3rd Floor </asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelPackingBoxes" runat="server" Text="Select Box Sizes Needed"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="Box">
                        <asp:ListItem Value="Small"> Small </asp:ListItem>
                        <asp:ListItem Value="Medium"> Medium </asp:ListItem>
                        <asp:ListItem Value="Large"> Large </asp:ListItem>
                        <asp:ListItem Value="Wardrobe"> Wardrobe </asp:ListItem>
                        <asp:ListItem Value="Art"> Art </asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 3 (Notes)--%>
    <asp:Panel ID="Panel3" runat="server" Visible="false">
        <asp:Table ID="Table3" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel3Header" runat="server" Text="Notes"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <%--            IMPORTANT NOTE: The info below (PANEL 3 through end) needs to populate on the service ticket that is attached with this move. --%>
                <asp:TableCell>
                    <asp:Label ID="LabelNotesTitle" runat="server" Width="150" Text="Notes Title: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxNoteTitle" Width="200px" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelNotesSection" runat="server" Text="Notes Section"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxNotesMove" Width="200px" Height="100" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 4 (Home Info)--%>
    <asp:Panel ID="Panel4" runat="server" Visible="false">
        <asp:Table ID="Table4" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel4Header" runat="server" Text="Home Info"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTypeOfHome" runat="server" Text="Enter Type of Home Information Below"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelApartment" runat="server" Text="If Apartment"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAptFloor" runat="server" Text="What Floor?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAptFloor" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAptElevator" runat="server" Text="Is There an Elevator?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAptElevator" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAptWalk" runat="server" Text="How Far is the Walk From the Apartment?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAptWalk" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelHouse" runat="server" Text="House?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxHouse" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 5 (Storage Info)--%>
    <asp:Panel ID="Panel5" runat="server" Visible="false">
        <asp:Table ID="Table5" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel5Header" runat="server" Text="Storage Info"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelStorage" runat="server" Text="If Storage"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelClimateC" runat="server" Text="Indoor/Climate Controlled?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxClimateC" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelSelfStorage" runat="server" Text="Outdoor Self Storage?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSelfStorage" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelBusiness" runat="server" Text="Place of Business?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxBusiness" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 6 (Logistics Info)--%>
    <asp:Panel ID="Panel6" runat="server" Visible="false">
        <asp:Table ID="Table6" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel8Header" runat="server" Text="Logistics Info"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTruckInfo" runat="server" Text="Enter Logistics Questions Below"></asp:Label>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTruckAccess" runat="server" Text="Enter Truck Accessability"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxTruckAccess" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelLoadingDoor" runat="server" Text="How Far is the Walk to the Loading Door?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxLoadingDoor" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelSteps" runat="server" Text="How Many Steps are Leading to House?"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSteps" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 7 (Equipment Needed)--%>
    <asp:Panel ID="Panel7" runat="server" Visible="false">
        <asp:Table ID="Table7" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel9Header" runat="server" Text="Equipment Needed"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelSpecialEquipment" runat="server" Text="Select Special Equipment Below: "></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListSpecialEquipment" runat="server">
                        <asp:ListItem Value="Appliance Cart"> Appliance Cart </asp:ListItem>
                        <asp:ListItem Value="Piano Dolly"> Piano Dolly </asp:ListItem>
                        <asp:ListItem Value="Piano Board"> Piano Board </asp:ListItem>
                        <asp:ListItem Value="Gun Safe Cart"> Gun Safe Cart </asp:ListItem>
                        <asp:ListItem Value="Extra Blankets"> Extra Blankets </asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTrucksUsed" runat="server" Text="Select Trucks Required Below: "></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListTrucksRequired" runat="server">
                        <asp:ListItem Value="2015">2015</asp:ListItem>
                        <asp:ListItem Value="2011">2011</asp:ListItem>
                        <asp:ListItem Value="Cube">Cube</asp:ListItem>
                        <asp:ListItem Value="Enclosed Trailor">Enclosed Trailor</asp:ListItem>
                        <asp:ListItem Value="Open Trailor">Open Trailor</asp:ListItem>
                        <asp:ListItem Value="Van">Van</asp:ListItem>

                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 8 (Cost Estimate)--%>
    <asp:Panel ID="Panel8" runat="server" Visible="false">
        <asp:Table ID="Table8" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblPanel11Header" runat="server" Text="Cost Estimate"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelCost" runat="server" Text="Costing Out Move Information Below: "></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelEstimate" runat="server" Text="Move Estimate"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxEstimate" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelFixed" runat="server" Text="Fixed Rate"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxFixed" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelPackingFees" runat="server" Text="Packing Fees"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPackingFees" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelStorageFees" runat="server" Text="Storage Fees"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxStorageFees" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTrashRemoval" runat="server" Text="Trash Removal"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxTrashRemoval" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="ButtonConfirm" runat="server" Text="Confirm" OnClick="ButtonConfirm_Click" />

                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <%--Panel 9 (ENTER NAME HERE)--%>
    <%--<asp:Panel ID="Panel9" runat="server" Visible="false">
        <asp:Table ID="Table9" runat="server">
        </asp:Table>
    </asp:Panel>--%>
    <%--Panel 10 (ENTER NAME HERE)--%>
    <%-- <asp:Panel ID="Panel10" runat="server" Visible="false">
        <asp:Table ID="Table10" runat="server">
        </asp:Table>
    </asp:Panel>--%>
    <%--Panel 11 (ENTER NAME HERE)--%>
    <%-- <asp:Panel ID="Panel11" runat="server" Visible="false">
        <asp:Table ID="Table11" runat="server">
        </asp:Table>
    </asp:Panel>--%>
</asp:Content>









