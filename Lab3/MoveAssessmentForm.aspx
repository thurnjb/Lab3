<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerPortal.Master" AutoEventWireup="true" CodeBehind="MoveAssessmentForm.aspx.cs" Inherits="Lab3.MoveAssessmentForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="TableAssessment" runat="server">
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
                <asp:Label ID="LabelEachRoomFurniture"  runat="server" Text="List of Normal Furniture" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="ListBoxEachRoomFurniture" Width="200" runat="server">

                </asp:ListBox>
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
        <asp:TableHeaderRow>
<%--            IMPORTANT NOTE: The info below needs to populate on the service ticket that is attached with this move. --%>
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
                   <asp:TextBox ID="TextBoxNotesMove"  Width="200px"  Height="100" runat="server"></asp:TextBox>
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
   <asp:TableRow>
       <asp:TableCell>
           <asp:Label ID="LabelSpecialEquipment" runat="server" Text="Select Special Equipment Below: "></asp:Label>
       </asp:TableCell>
   </asp:TableRow>
<asp:TableRow>
    <asp:TableCell>
        <asp:CheckBoxList ID="CheckBoxListSpecialEquipment" runat="server">
            <asp:ListItem> Appliance Cart </asp:ListItem>
            <asp:ListItem> Piano Dolly </asp:ListItem>
            <asp:ListItem> Piano Board </asp:ListItem>
            <asp:ListItem> Gun Safe Cart </asp:ListItem>
            <asp:ListItem> Extra Blankets </asp:ListItem>
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
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2011</asp:ListItem>
                <asp:ListItem>Cube</asp:ListItem>
                <asp:ListItem>Enclosed Trailor</asp:ListItem>
                <asp:ListItem>Open Trailor</asp:ListItem>
                <asp:ListItem>Van</asp:ListItem>

            </asp:CheckBoxList>
        </asp:TableCell>
</asp:TableHeaderRow>
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
                <asp:Button ID="ButtonConfirm" runat="server" Text="Confirm" />
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Content>









