<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Lab3.LoginForm" %>

<!DOCTYPE html>

<html lang="en">
  <head>
  	<title>LogIn</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<link rel="stylesheet" href="css/styles.css">

	</head>
	<body class="img js-fullheight"
	<section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<img src= "images/greenvalley.jpeg" alt="Green Valley Auctions Logo">
					<h2 class="heading-section"></h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-6 col-lg-4">
					<div class="login-wrap p-0">
		      	<form action="#" class="signin-form" runat="server">
		      		<div class="form-group">
                          <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
		      		</div>
	            <div class="form-group">
                    <asp:TextBox ID="txtPassWord" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
	              <span toggle="#password-field" class="fa fa-fw fa-eye field-icon toggle-password"></span>
	            </div>
	            <div class="form-group">
                     <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" CssClass="form-control btn btn-primary submit px-3" />
	            </div>
	            <div class="form-group d-md-flex">
	            	<div class="w-50">
                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
								</div>
	            </div>
	          </form>
	 
		      </div>
				</div>
			</div>
		</div>
	</section>

  <script src="Scripts/jquery.min.js"></script>
  <script src="Scripts/popper.js"></script>
  <script src="Scripts/bootstrap.min.js"></script>
  <script src="scripts/main.js"></script>

	</body>
</html>