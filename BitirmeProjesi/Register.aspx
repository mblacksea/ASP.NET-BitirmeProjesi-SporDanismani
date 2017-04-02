<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  CodeBehind="Register.aspx.cs" Inherits="BitirmeProjesi.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700' rel='stylesheet' type='text/css'>
<link href='http://fonts.googleapis.com/css?family=Sofia' rel='stylesheet' type='text/css'>
<link href="css/register.css" rel="stylesheet">
<link rel="stylesheet" href="css/datepicker.css">
<link rel="stylesheet" href="/js/notifyit/notifIt.css" />
<script src="/js/jquery-2.0.3.min.js"></script>
<script src="/js/notifyit/notifIt.js"></script>
       
 <link rel="stylesheet" href="stylesheet-pure-css.css">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txtDate]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'images/calendar.png'
            });
        });
    </script>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 <div class='login'>
  <h2>Personel Trainer</h2>
     <asp:TextBox ID="textboxName" runat="server" placeholder='Name'></asp:TextBox>
      <asp:RequiredFieldValidator id="nameReq"
              runat="server"
              ControlToValidate="textboxName"
              ErrorMessage="Name is required!"
              SetFocusOnError="True" ForeColor="Red" />


     <asp:TextBox ID="textboxSurname" runat="server" placeholder='Surname'></asp:TextBox>
     <asp:RequiredFieldValidator id="surnameReq"
              runat="server"
              ControlToValidate="textboxSurname"
              ErrorMessage="Surname is required!"
              SetFocusOnError="True" ForeColor="Red" />

     <asp:TextBox ID="textboxEmail" runat="server"  placeholder='Email'></asp:TextBox>
     <asp:RequiredFieldValidator id="emailReq"
              runat="server"
              ControlToValidate="textboxEmail"
              ErrorMessage="Email is required!"
              SetFocusOnError="True" ForeColor="Red" />


     <asp:TextBox ID="textboxPassword" runat="server" placeholder='Password' TextMode="Password"></asp:TextBox>
      <asp:RequiredFieldValidator id="passwordReq"
              runat="server"
              ControlToValidate="textboxPassword"
              ErrorMessage="Password is required!"
              SetFocusOnError="True" ForeColor="Red" Display="Dynamic" />


     <asp:TextBox ID="textboxConfirmPassword" runat="server" placeholder='Confirm Password' TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator id="confirmPasswordReq"
              runat="server" 
              ControlToValidate="textboxConfirmPassword"
              ForeColor="Red"
              ErrorMessage="Password confirmation is required!"
              SetFocusOnError="True" 
              Display="Dynamic" />
      <asp:CompareValidator id="comparePasswords" 
              runat="server"
              ControlToCompare="textboxPassword"
              ControlToValidate="textboxConfirmPassword"
              ErrorMessage="Your passwords do not match up!"
              ForeColor="Red"
              Display="Dynamic" />

     <br> </br>

 <div class="example">
      <div>
        <input id="radio1" type="radio" name="radio" runat="server"  value="M" ><label for="radio1"><span><span></span></span>Male</label>
      </div>
      <div>
        <input id="radio2" type="radio" name="radio" runat="server" value="F"><label for="radio2"><span><span></span></span>Female</label>
      </div>
      
    </div>

  <asp:TextBox ID="txtDate" runat="server"  placeholder='Birthday' ></asp:TextBox>
       <asp:RequiredFieldValidator id="RequiredFieldValidator1"
              runat="server"
              ControlToValidate="txtDate"
              ErrorMessage="Birthday is required!"
              SetFocusOnError="True" ForeColor="Red"  />

     <asp:TextBox ID="textboxBio" runat="server" TextMode="MultiLine" placeholder='Bio' Height="100px" MaxLength="3000"></asp:TextBox>
     <asp:RequiredFieldValidator id="RequiredFieldValidator2"
              runat="server"
              ControlToValidate="textboxBio"
              ErrorMessage="Bio is required!"
              SetFocusOnError="True" ForeColor="Red" />



  <input class='animated' runat="server"  onserverclick="nextButton" type='submit' value='Next'/>
  </div>
        
       
</form>
</body>
</html>
