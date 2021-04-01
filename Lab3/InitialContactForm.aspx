<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InitialContactForm.aspx.cs" Inherits="Lab3.InitialContactForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <title>Customer Database</title>
        <link href="css/styles.css" rel="stylesheet">
        <link rel="stylesheet" href="css/heading.css">
        <link rel="stylesheet" href="css/body.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <style>
            .form-group {
                color:black;
                 }
            
        </style>
    </head>
    <body id="page-top">
        <nav class="navbar navbar-expand-lg bg-secondary fixed-top" id="mainNav">
            <div class="container"><a class="navbar-brand js-scroll-trigger" href="#page-top"><img id="brandImage" <img src="images/greenvalleyauctions.jpeg" alt="Green Valley Auctions logo"> </a>
                <button class="navbar-toggler navbar-toggler-right font-weight-bold bg-primary text-white rounded" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">Menu <i class="fas fa-bars"></i></button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" <a href="HomePageV2.aspx">HOME</a>
                        </li>
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" <a href="customers.html">CUSTOMER INFO</a>
                        </li>
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" href="calendar">CALENDAR</a>
                        </li>
                         <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" <a href="tickets.html">TICKETS</a>
                    </ul>
                </div>
            </div>
        </nav>
        <header class="masthead bg-primary text-white text-center">
            <div class="container d-flex align-items-center flex-column">
        
                <h1> Add New Customer </h1>

                <h1 class="masthead-heading mb-0"></h1>
                <div class="row">
                       </div>

            <div class="form-group">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control item" placeholder="First Name"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control item" placeholder="Last Name"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control item" placeholder="Phone Number"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control item" placeholder="Email"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtInitialContact" runat="server" CssClass="form-control item" placeholder="Contact Method"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtHeardFrom" runat="server" CssClass="form-control item" placeholder="How They Heard About Us"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control item" placeholder="Address"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtRequestedService" runat="server" CssClass="form-control item" placeholder="Requested Service"></asp:TextBox>
                <br />
            </div>
               
         
<div class="form-group">
<asp:Table ID="tblButtons" runat="server">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" />
            </asp:TableCell>
            <asp:TableCell >
                <asp:Button ID="btnSave" runat="server" Text="Save New Customer" OnClick="btnSave_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnLookAt" runat="server" Text="Schedule Look At" OnClick="btnLookAt_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnMove" runat="server" Text="Schedule Move" OnClick="btnTicket_Click" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnAuction" runat="server" Text="Schedule Auction" OnClick="btnAuction_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblError" runat="server" Text="" ></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
             
        </header>
      
          
    </body>
</html>



</asp:Content>
