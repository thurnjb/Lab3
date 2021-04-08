﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePageV2.aspx.cs" Inherits="Lab3.HomePageV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Jay Thurn, Ryan Booth, John Lee
    We have neither given nor received any unauthorized assistance on this assignment-->
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
        <style>
            .mobile-wrapper{
                color:black;
 
}
        </style>
    </head>
    <body>
        <nav class="navbar navbar-expand-lg bg-secondary fixed-top" id="mainNav">
            <div class="container"><a class="navbar-brand js-scroll-trigger" href="#page-top"><img id="brandImage" <img src="images/greenvalleyauctions.jpeg" alt="Green Valley Auctions logo"> </a>
                <button class="navbar-toggler navbar-toggler-right font-weight-bold bg-primary text-white rounded" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">Menu <i class="fas fa-bars"></i></button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item mx-0 mx-lg-1"><a href="HomePageV2.aspx"> <a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" >HOME</a> 
                        </li>
                      <li class="nav-item mx-0 mx-lg-1>"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" <a href="CustomerSearch.aspx">CUSTOMER INFO </a></li></a>
                        </li>
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" >CALENDAR</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <header class="masthead bg-primary text-white text-center">
            <div class="container d-flex align-items-center flex-column">
                <img class="masthead-avatar mb-5" <img src="images/greenvalleyauctions.jpeg" alt="Green Valley Auctions Logo" width="300">
                <h1> Customer Database </h1>
                <h1 class="masthead-heading mb-0"></h1>
                <div class="row">
  <div class="column">
    <img src="images/box.jpeg" alt="box" style="width:100%">
  </div>
  <div class="column">
    <img src="images/greeting.jpeg" alt="greeting" style="width:100%">
  </div>
  <div class="column">
    <img src="images/typing.jpeg" alt="laptop" style="width:100%">
  </div>
    <div class="column">
    <img src="images/moving.jpeg" alt="moving" style="width:100%">
  </div>
</div>
             <div class="mobile-wrapper">
   <header class="header">
      <div class="container">
          <asp:Label ID="lblLookAtNotifications" runat="server" Text="Look Ats To Be Scheduled:"></asp:Label>
          <br />
          <asp:GridView ID="grdNotification" runat="server" AutoGenerateColumns="false" DataKeyNames="CustomerID" >
                <Columns>
                    <asp:BoundField HeaderText="SaveDate" DataField="SaveDate" />
                    <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
                    <asp:BoundField HeaderText="LastName" DataField="LastName" />
                    <asp:BoundField HeaderText="Address" DataField="Address" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnLookAtConfirm" runat="server" Text="Confirm" CommandName="Select" OnClick="btnLookAtConfirm_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
          <br />
          <asp:Label ID="lblLookAtConfirmations" runat="server" Text="Look Ats To Be Confirmed With Customer:"></asp:Label>
          <br />

         <h1>Calendar </h1>

         <div class="menu-toggle">
            <div>
            
               <span></span>
               <span></span>
               <span></span>
            </div>
         </div>
      </div>
   </header>

   <section class="today-box" id="today-box">
      <span class="breadcrumb">Today</span>
      <h3 class="date-title">March 30, 2021</h3>

      <div class="plus-icon">
         <i class="ion ion-ios-add"></i>
      </div>
   </section>

   <section class="upcoming-events">
      <div class="container">
         <h3>
            This Morning's Events

         </h3>
         <div class="events-wrapper">
            <div class="event">
               <i class="ion ion-ios-flame hot"></i>
               <h4 class="event__point">9:00 am</h4>
               <p class="event__description">
                  Tuesday briefing with the team.
               </p>
            </div>
            <div class="event">
               <i class="ion ion-ios-flame done"></i>
               <h4 class="event__point">12:00 pm</h4>
               <p class="event__description">
                  Meeting with CIS/SMAD Groups
               </p>
            </div>
            <div class="event active">
               <i class="ion ion-ios-radio-button-on icon-in-active-mode"></i>
               <h4 class="event__point">2:00 pm</h4>
               <p class="event__description">
                  Meet clients from project.
               </p>
            </div>
            <div class="event">
               <i class="ion ion-ios-flame-outline upcoming"></i>
               <h4 class="event__point">4:45 pm</h4>
               <span class="event__duration">in 45 minutes.</span>
               <p class="event__description">
                  Check in with customer (Billy Bob Jenkins).
               </p>
            </div>
            <div class="event">
               <i class="ion ion-ios-flame-outline upcoming"></i>
               <h4 class="event__point">5:15 pm</h4>
               <p class="event__description">
                  Customer dialog on Zoom.
               </p>
            </div>
         </div>
         <button class="add-event-button">
            <span class="add-event-button__title">Add Event</span>

            <span class="add-event-button__icon">
               <i class="ion ion-ios-star-outline"></i>
            </span> 


         </button>
      </div>
   </section>
</div>
        </header>
      
          
    </body>
</html>

</asp:Content>
