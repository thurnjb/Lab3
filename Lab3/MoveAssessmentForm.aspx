<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MoveAssessmentForm.aspx.cs" Inherits="Lab3.MoveAssessmentForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <title>Move</title>
        <link href="css/styles.css" rel="stylesheet">
        <link rel="stylesheet" href="css/heading.css">
        <link rel="stylesheet" href="css/body.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        .label {
        color:#2b613d;
    }
    .form-control {
            border-color: white;
            background-color:#daac00;
            text-align: center;
            color:white;}
            p {
                color:#2b613d;
            }
           a:hover {
  background-color: #ddd;
  color: black;
}

.previous {
  background-color: #f1f1f1;
  color: black;
  border:solid .02em black;
  padding: 5px
}

.next {
  background-color: #2b613d;
  color: white;
  padding:5px;
}

.round {
  border-radius: 50%;
}
hr { color:black; border-style: inset; border-width: 1px;}
    </style>
    <header class="masthead bg-primary text-center">
            <div class="container d-flex align-items-center flex-column">
            <form class="example" action="action_page.php">
    <h1> Move Form</h1>
    <hr><br>
  <h1 class="masthead-heading mb-0"></h1>
                <div class="row">
                       </div>
    &nbsp;<asp:Table ID="Table1" runat="server">
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
                <asp:Button ID="btnPreviousPanel" runat="server" Text="Back" OnClick="btnPreviousPanel_Click" CssClass="next" />
                <asp:Button ID="btnNextPanel" runat="server" Text="Next" OnClick="btnNextPanel_Click" CssClass="next" />
                <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CssClass="next" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <%--Panel 1 (Customer Questions)--%>
    <asp:Panel ID="Panel1" runat="server" Visible="true">
        <asp:Table ID="Table_Page1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <strong><asp:Label ID="lblPanel1Header" runat="server" Text="Customer Questions" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelMoveOutDate" runat="server" Text="What date do you need to be out of current address?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxMoveOutDate" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelWindowDaysMove" runat="server" Text="What is the window of days you can move?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxWindowDaysMove" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAddressMovingTo" runat="server" Text="What is the address you are moving to?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAddressMovingTo" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelMLSListing" runat="server" Text="Is there a MLS Listing?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxMLSListing" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelPhotos" runat="server" Text="Can you send photos if we need them?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPhotos" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAddService" runat="server" Text="Do you need add on services?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListAddService" runat="server" CssClass="label">
                        <asp:ListItem Value="Packing"> Packing Service </asp:ListItem>
                        <asp:ListItem Value="TrashRemoval_Donation"> Trash Removal/Donation Hauling </asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAuctionServices" runat="server" Text="Do you need auction services?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAuctionServices" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 2 (Room Info)--%>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <strong><asp:Label ID="lblPanel2Header" runat="server" Text="Room Info" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelOrderOfRooms" runat="server" Text="Order of Rooms:" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListOrderOfRooms" runat="server" CssClass="label">
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
                    <br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelEachRoomFurniture" runat="server" Text="List of Normal Furniture:" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtRoomFurniture" runat="server" CssClass="input"></asp:TextBox>
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelRoomFloor" runat="server" Text="Select Room Floor:" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxFloor" runat="server" CssClass="label">
                        <asp:ListItem Value="Basement"> Basement </asp:ListItem>
                        <asp:ListItem Value="GroundFloor"> Ground Floor </asp:ListItem>
                        <asp:ListItem Value="2ndFloor"> 2nd Floor </asp:ListItem>
                        <asp:ListItem Value="3rdFloor"> 3rd Floor </asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelPackingBoxes" runat="server" Text="Select Box Sizes Needed:" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="label">
                        <asp:ListItem Value="Small"> Small </asp:ListItem>
                        <asp:ListItem Value="Medium"> Medium </asp:ListItem>
                        <asp:ListItem Value="Large"> Large </asp:ListItem>
                        <asp:ListItem Value="Wardrobe"> Wardrobe </asp:ListItem>
                        <asp:ListItem Value="Art"> Art </asp:ListItem>
                    </asp:CheckBoxList>
                    <br />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 3 (Notes)--%>
    <asp:Panel ID="Panel3" runat="server" Visible="false">
        <asp:Table ID="Table3" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <strong><asp:Label ID="lblPanel3Header" runat="server" Text="Notes" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <%--            IMPORTANT NOTE: The info below (PANEL 3 through end) needs to populate on the service ticket that is attached with this move. --%>
                <asp:TableCell>
                    <asp:Label ID="LabelNotesTitle" runat="server" Width="150" Text="Notes Title: " CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxNoteTitle" Width="200px" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelNotesSection" runat="server" Text="Notes Section" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxNotesMove" Width="200px" Height="100" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 4 (Home Info)--%>
    <asp:Panel ID="Panel4" runat="server" Visible="false">
        <asp:Table ID="Table4" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <strong><asp:Label ID="lblPanel4Header" runat="server" Text="Home Info" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTypeOfHome" runat="server" Text="Enter Type of Home Information Below" CssClass="label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAptFloor" runat="server" Text="What Floor?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAptFloor" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAptElevator" runat="server" Text="Is There an Elevator?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAptElevator" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAptWalk" runat="server" Text="How Far is the Walk From the Apartment?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAptWalk" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelHouse" runat="server" Text="House?" CssClass="label"></asp:Label>
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
                    <strong><asp:Label ID="lblPanel5Header" runat="server" Text="Storage Info" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelClimateC" runat="server" Text="Indoor/Climate Controlled?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxClimateC" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelSelfStorage" runat="server" Text="Outdoor Self Storage?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSelfStorage" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelBusiness" runat="server" Text="Place of Business?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxBusiness" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 6 (Logistics Info)--%>
    <asp:Panel ID="Panel6" runat="server" Visible="false">
        <asp:Table ID="Table6" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <strong><asp:Label ID="lblPanel8Header" runat="server" Text="Logistics Info" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTruckAccess" runat="server" Text="Enter Truck Accessability" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxTruckAccess" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelLoadingDoor" runat="server" Text="How Far is the Walk to the Loading Door?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxLoadingDoor" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelSteps" runat="server" Text="How Many Steps are Leading to House?" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSteps" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%--Panel 7 (Equipment Needed)--%>
    <asp:Panel ID="Panel7" runat="server" Visible="false">
        <asp:Table ID="Table7" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <strong><asp:Label ID="lblPanel9Header" runat="server" Text="Equipment Needed" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelSpecialEquipment" runat="server" Text="Select Special Equipment Below: " CssClass="label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListSpecialEquipment" runat="server" CssClass="label">
                        <asp:ListItem Value="0"> Appliance Cart </asp:ListItem>
                        <asp:ListItem Value="1"> Piano Dolly </asp:ListItem>
                        <asp:ListItem Value="2"> Piano Board </asp:ListItem>
                        <asp:ListItem Value="3"> Gun Safe Cart </asp:ListItem>
                        <asp:ListItem Value="4"> Extra Blankets </asp:ListItem>
                    </asp:CheckBoxList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTrucksUsed" runat="server" Text="Select Trucks Required Below: " CssClass="label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableCell>
                    <asp:CheckBoxList ID="CheckBoxListTrucksRequired" runat="server" CssClass="label">
                        <asp:ListItem Value="0">2015</asp:ListItem>
                        <asp:ListItem Value="1">2011</asp:ListItem>
                        <asp:ListItem Value="2">Cube</asp:ListItem>
                        <asp:ListItem Value="3">Enclosed Trailor</asp:ListItem>
                        <asp:ListItem Value="4">Open Trailor</asp:ListItem>
                        <asp:ListItem Value="5">Van</asp:ListItem>

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
                    <strong><asp:Label ID="lblPanel11Header" runat="server" Text="Cost Estimate" CssClass="label"></asp:Label></strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelCost" runat="server" Text="Costing Out Move Information Below: " CssClass="label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelEstimate" runat="server" Text="Move Estimate" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxEstimate" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelFixed" runat="server" Text="Fixed Rate" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxFixed" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelPackingFees" runat="server" Text="Packing Fees" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPackingFees" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelStorageFees" runat="server" Text="Storage Fees" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxStorageFees" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelTrashRemoval" runat="server" Text="Trash Removal" CssClass="label"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxTrashRemoval" runat="server" CssClass="input"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="ButtonConfirm" runat="server" Text="Confirm" OnClick="ButtonConfirm_Click" CssClass="next" />
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