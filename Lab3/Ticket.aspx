<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="Lab3.TicketPage" %>
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
        background-color: #daac00;
        text-align: center;
        color: white;
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
                        <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" href="calendar">CALENDAR</a>
                        </li>
                          <li class="nav-item mx-0 mx-lg-1"><a class="nav-link py-3 px-0 px-lg-3 rounded js-scroll-trigger" <a href="tickets.html">TICKETS</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <header class="masthead bg-primary text-white text-center">
            <div class="container d-flex align-items-center flex-column">
            <form class="example" action="action_page.php">
                  <h1> OPEN TICKETS </h1>
                <asp:GridView ID="grdTickets" runat="server" 
                    DataKeyNames="ServiceTicketID" 
                    AutoGenerateSelectButton="true" 
                    AllowSorting="true" 
                    AutoGenerateColumns="false" 
                    OnSelectedIndexChanged="grdTickets_SelectedIndexChanged">
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

 <button type="submit" class="form-control btn btn-primary submit px-3">Add Note</button> 
   <form class="example" action="action_page.php">
 <button type="submit" class="form-control btn btn-primary submit px-3">Assign Employee</button> 
   <form class="example" action="action_page.php">
 <button type="submit" class="form-control btn btn-primary submit px-3">Close Ticket</button> 




</div>

             
        </header>
      
          
    </body>
</html>


    <asp:SqlDataSource ID="dtasrcServiceTicketID" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" >
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dtasrcNotes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Lab3 %>" 
        SelectCommand="SELECT * FROM Notes WHERE ServiceTicketID = @ServiceTicketID" 
        UpdateCommand="UPDATE Notes SET NoteTitle=@NoteTitle, NoteContent=@NoteContent WHERE NoteID=@NoteID">
        <SelectParameters>
            <asp:ControlParameter name="ServiceTicketID" ControlID="grdTickets"/>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter type="String" Name="NoteTitle"/>
            <asp:Parameter Type="String" Name="NoteContent"/>
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dtasrcEmployee" runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT EmployeeID, FirstName + ' ' + LastName + ' ' + Position AS NamePosition FROM Employee">
    </asp:SqlDataSource>



</asp:Content>
