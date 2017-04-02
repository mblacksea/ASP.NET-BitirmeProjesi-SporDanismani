<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterSecondPart.aspx.cs" Inherits="BitirmeProjesi.RegisterSecondPart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
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
            $("[id$=txtdateCertificate]").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: 'images/calendar.png'
            });
        });
    </script>

<body>
    <form id="form1" runat="server">
  <div class='login'> 

<h2>Add Certificate</h2>
     <asp:TextBox ID="textboxCertificateName" runat="server" placeholder='Certificate Name'></asp:TextBox>
      <asp:RequiredFieldValidator id="certificatenameReq"
              runat="server"
              ControlToValidate="textboxCertificateName"
              ErrorMessage="Certificate Name is required!"
              SetFocusOnError="True" ForeColor="Red" />

         <asp:TextBox ID="textboxInstution" runat="server" placeholder='Instution'></asp:TextBox>
      <asp:RequiredFieldValidator id="instutionReq"
              runat="server"
              ControlToValidate="textboxInstution"
              ErrorMessage="Instution is required!"
              SetFocusOnError="True" ForeColor="Red" />

      <asp:TextBox ID="txtdateCertificate" runat="server"  placeholder='Date' ></asp:TextBox>
       <asp:RequiredFieldValidator id="datecertificateReq"
              runat="server"
              ControlToValidate="txtdateCertificate"
              ErrorMessage="Date is required!"
              SetFocusOnError="True" ForeColor="Red"  />

      <br> </br>

      <asp:Label ID="Label1" runat="server" Text="Certificate File (Optional)" Font-Bold="True" Font-Underline="True"></asp:Label>
      <br> </br>

      <asp:FileUpload ID="FileUpload1" runat="server" />

         <br> </br>
      <input class='animated' runat="server" onserverclick="addCertificate" type='submit' value='Add'/>
  </div> 
    

    </form>
</body>
</html>
