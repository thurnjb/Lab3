<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="Lab3.CustomerDetails1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<html>
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
    .form-control {
            border-color: white;
            background-color:#daac00;
            text-align: center;
            color:white;
</style>
    </head>
    <body>
        <nav class="navbar navbar-expand-lg bg-secondary fixed-top" id="mainNav">
            <div class="container"><a class="navbar-brand js-scroll-trigger" href="#page-top"><img id="brandImage" <img src="images/greenvalleyauctions.jpeg" alt="Green Valley Auctions logo"> </a>
                <button class="navbar-toggler navbar-toggler-right font-weight-bold bg-primary text-white rounded" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">Menu <i class="fas fa-bars"></i></button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" <a href="customerdatabase.html">HOME</a>
                        </li>
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" <a href="CustomerSearch.aspx">CUSTOMER INFO</a>
                        </li>
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger">CALENDAR</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <header class="masthead bg-primary text-black text-center">
            <div class="container d-flex align-items-center flex-column">
            <form class="example" action="action_page.php">
<asp:GridView ID="grdCustomers" runat="server"
        HeaderStyle-BackColor="#000000"
        EmptyDataText="No customer with that name!"
        AutoGenerateSelectButton="true"
        OnSelectedIndexChanged="grdCustomers_SelectedIndexChanged"
        AllowSorting="true"
        OnSorting="grdCustomers_Sorting"
        DataKeyNames="CustomerID"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="FirstName" DataField="FirstName" SortExpression="FirstName" />
            <asp:BoundField HeaderText="LastName" DataField="LastName" SortExpression="LastName" />
            <asp:BoundField HeaderText="InitialContact" DataField="InitialContact" SortExpression="InitialContact" />
            <asp:BoundField HeaderText="HeardFrom" DataField="HeardFrom" SortExpression="HeardFrom" />
            <asp:BoundField HeaderText="Phone" DataField="Phone" SortExpression="Phone" />
            <asp:BoundField HeaderText="Email" DataField="Email" SortExpression="Email" />
            <asp:BoundField HeaderText="Address" DataField="Address" SortExpression="Address" />
            <asp:BoundField HeaderText="DestAddress" DataField="DestAddress" SortExpression="DestAddress" />
            <asp:BoundField HeaderText="SaveDate" DataField="SaveDate" SortExpression="SaveDate" />
        </Columns>
    </asp:GridView>
   <form class="example" action="action_page.php">
       <asp:GridView ID="grdTickets" runat="server"
        HeaderStyle-BackColor="#000000"
        EmptyDataText="This customer has no tickets!"
        AutoGenerateColumns="false"
        AutoGenerateSelectButton="true"
        AllowSorting="true"
        DataKeyNames="ServiceTicketID"
        OnSelectedIndexChanged="grdTickets_SelectedIndexChanged"
        OnSorting="grdTickets_Sorting">
        <Columns>
            <asp:BoundField HeaderText="CustomerName" DataField="CustomerName" SortExpression="CustomerName" />
            <asp:BoundField HeaderText="EmployeeName" DataField="EmployeeName" SortExpression="EmployeeName" />
            <asp:BoundField HeaderText="ServiceType" DataField="ServiceType" SortExpression="ServiceType" />
            <asp:BoundField HeaderText="TicketStatus" DataField="TicketStatus" SortExpression="TicketStatus" />
            <asp:BoundField HeaderText="TicketOpenDate" DataField="TicketOpenDate" SortExpression="TicketOpenDate" />
            <asp:BoundField HeaderText="FromDeadline" DataField="FromDeadline" SortExpression="FromDeadline" />
            <asp:BoundField HeaderText="ToDeadline" DataField="ToDeadline" SortExpression="ToDeadline" />
        </Columns>
    </asp:GridView>

<button class="btn move"> Create Move </button>
<button class="btn auction">Auction</button></a>
<a href="storage.html"> <button class="btn storage">Storage</button></a>


</div>

             
        </header>
      
          
    </body>
</html>
</asp:Content>
