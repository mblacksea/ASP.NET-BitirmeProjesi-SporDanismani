<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deneme.aspx.cs" Inherits="BitirmeProjesi.Deneme1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <asp:FileUpload ID="FileUpload3" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
