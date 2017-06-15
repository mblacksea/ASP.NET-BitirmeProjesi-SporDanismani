<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="BitirmeProjesi.ForgotPassword" %>

<!DOCTYPE html>
<html >
<head>
  <meta charset="UTF-8">
  <title>Log'n Load</title>
  <script src="http://s.codepen.io/assets/libs/modernizr.js" type="text/javascript"></script>


  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">

    <link href="dist/css/styleforgotpassword.css" rel="stylesheet" />
    <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>
  
</head>

<body>
  <div class="login">
  <header class="header">
      <span class="text">Refresh</span>
    <span class="loader"></span>
  </header>
  <form runat="server" class="form">  
        <textarea class="form-control" rows="3" runat="server" placeholder="Your Email" id="introTextArea" maxlength="1500"></textarea>
 
 
    <button class="btn" runat="server" onserverclick="sendEmail" type="submit"></button>
  </form>
</div>

  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

    <script src="js/index.js"></script>

</body>
</html>