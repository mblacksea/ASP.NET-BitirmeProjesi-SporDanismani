<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BitirmeProjesi.Login" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="shortcut icon" href="images/ico/favicon.ico"> 
    <title>Add-Life-Health-Fitness</title>
     <style type="text/css">
        pre
        {
            border: solid 1px #ccc;
            background-color: #ffa;
            padding: 5px;
            color: #a00;
            line-height: 1.5em;
        }
    </style>
    <link rel="stylesheet" href="/js/notifyit/notifIt.css" />
    <script src="/js/jquery-2.0.3.min.js"></script>
    <script src="/js/notifyit/notifIt.js"></script>
       <style>
@import url(http://fonts.googleapis.com/css?family=Exo:100,200,400);
@import url(http://fonts.googleapis.com/css?family=Source+Sans+Pro:700,400,300);

body{
	margin: 0;
	padding: 0;
	background: #fff;

	color: #fff;
	font-family: Arial;
	font-size: 12px;
}

.body{
	position: absolute;
	top: -20px;
	left: -20px;
	right: -40px;
	bottom: -40px;
	width: auto;
	height: auto;
	background-image: url(http://www.hdwallpaper.nu/wp-content/uploads/2015/06/2003126.jpg);
	background-size: cover;
	-webkit-filter: blur(5px);
	z-index: 0;
}

.grad{
	position: absolute;
	top: -20px;
	left: -20px;
	right: -40px;
	bottom: -40px;
	width: auto;
	height: auto;
	background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(0,0,0,0)), color-stop(100%,rgba(0,0,0,0.65))); /* Chrome,Safari4+ */
	z-index: 1;
	opacity: 0.7;
}

.header{
	position: absolute;
	top: calc(50% - 35px);
	left: calc(50% - 255px);
	z-index: 2;
}

.header div{
	float: left;
	color: #fff;
	font-family: 'Exo', sans-serif;
	font-size: 35px;
	font-weight: 200;
}

.header div span{
	color: #5379fa !important;
}

.login{
	position: absolute;
	top: calc(50% - 75px);
	left: calc(50% - 50px);
	height: 150px;
	width: 350px;
	padding: 10px;
	z-index: 2;
}

.login input[type=text]{
	width: 290px;
	height: 30px;
	background: transparent;
	border: 1px solid rgba(255,255,255,0.6);
	border-radius: 2px;
	color: #fff;
	font-family: 'Exo', sans-serif;
	font-size: 16px;
	font-weight: 400;
	padding: 4px;
}

.login input[type=password]{
	width: 290px;
	height: 30px;
	background: transparent;
	border: 1px solid rgba(255,255,255,0.6);
	border-radius: 2px;
	color: #fff;
	font-family: 'Exo', sans-serif;
	font-size: 16px;
	font-weight: 400;
	padding: 4px;
	margin-top: 10px;
}

.login input[type=button]{
	width: 300px;
	height: 35px;
	background: #fff;
	border: 1px solid #fff;
	cursor: pointer;
	border-radius: 2px;
	color: #a18d6c;
	font-family: 'Exo', sans-serif;
	font-size: 16px;
	font-weight: 400;
	padding: 6px;
	margin-top: 10px;
   
}

.login input[type=button]:hover{
	opacity: 0.8;
}

.login input[type=button]:active{
	opacity: 0.6;
}

.login input[type=text]:focus{
	outline: none;
	border: 1px solid rgba(255,255,255,0.9);
}

.login input[type=password]:focus{
	outline: none;
	border: 1px solid rgba(255,255,255,0.9);
}

.login input[type=button]:focus{
	outline: none;
}

::-webkit-input-placeholder{
   color: rgba(255,255,255,0.6);
}

::-moz-input-placeholder{
   color: rgba(255,255,255,0.6);
}
</style>
</head>
     <script src='https://www.google.com/recaptcha/api.js'></script>
      <script src='http://codepen.io/assets/libs/fullpage/jquery.js'></script>

<body>
    <form id="form1" runat="server">
    <div>
    <div class="body"></div>
		<div class="grad">
            <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
        </div>
		<div class="header">
			<div>Trainer<span>Login</span></div>
		</div>
		
		<div class="login">
		    <asp:TextBox ID="textboxEmail" placeholder='Email' runat="server"></asp:TextBox>
            <br> <br />
            <asp:RequiredFieldValidator id="emailReq"
              runat="server"
              ControlToValidate="textboxEmail"
              ErrorMessage="Email is required!"
              SetFocusOnError="True" ForeColor="Red" />
            <br> <br />
				 <asp:TextBox ID="textboxPassword"  placeholder='Password' runat="server" TextMode="Password"></asp:TextBox>
            <br> <br />
                 <asp:RequiredFieldValidator id="passwordReq"
                    runat="server"
                    ControlToValidate="textboxPassword"
                    ErrorMessage="Password is required!"
                    SetFocusOnError="True" ForeColor="Red" />
            <br> <br />
                <div class="g-recaptcha"  data-sitekey="6LduRBMUAAAAAOpA-nGf5FdvTTjys708mK5xlmHA"></div>
			    <input id="Submit1" type="button" OnServerClick="btnLogin_Click" runat="server"  value="Login" />
		</div>
       


    </div>
    </form>
</body>
</html>



