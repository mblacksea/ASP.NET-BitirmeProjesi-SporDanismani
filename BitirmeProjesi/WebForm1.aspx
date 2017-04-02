<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BitirmeProjesi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8">
    <title>MessageBox</title>
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
</head>
<body>
   <form id="form1" runat="server">
    <div style="margin: 100px 0px 30px 0px;">
        <asp:CheckBox ID="cbOtoKapa" runat="server" Text="Otomatik kapansın" />
        <br />
        Gösterim süresi:
        <asp:TextBox ID="txtSure" runat="server" Text="2000" />
        milisaniye
        <br />
        <br />
        <asp:Button ID="btnSuccess" runat="server" Text="Success" OnClick="btnSuccess_Click" />
        &nbsp;
        <asp:Button ID="btnWarning" runat="server" Text="Warning" OnClick="btnWarning_Click" />
        &nbsp;
        <asp:Button ID="btnInfo" runat="server" Text="Info" OnClick="btnInfo_Click" />
        &nbsp;
        <asp:Button ID="btnError" runat="server" Text="Error" OnClick="btnError_Click" />
    </div>
    <hr />
    <b>Örnek kullanımlar</b>
    <pre>
MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Success);
MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Success, false);
MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Success, true, 2000);
MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Success, 2000);
MessageBox.Show(new MessageBox.MessageBoxInfo
{
    Mesaj = "Deneme metni",
    MesajTipi = MessageBox.MesajTipleri.Info,
    OtoKapa = true,
    Sure = 3500
});    </pre>
    </form>
</body>
</html>
