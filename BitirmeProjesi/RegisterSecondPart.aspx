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
       <link href="css/stylesheet-pure-css.css" rel="stylesheet" />

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
        <br> </br>
       <input class='animated' runat="server" onserverclick="save" type="button"  value='Save'/>

        <asp:gridview ID="gridview" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Certificate_ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Certificate_ID" HeaderText="Certificate_ID" InsertVisible="False" ReadOnly="True" SortExpression="Certificate_ID" Visible="False" />
                <asp:BoundField DataField="Trainer_ID" HeaderText="Trainer_ID" SortExpression="Trainer_ID" Visible="False" />
                <asp:BoundField DataField="Certificate_Name" HeaderText="Certificate_Name" SortExpression="Certificate_Name" />
                <asp:BoundField DataField="Instution" HeaderText="Instution" SortExpression="Instution" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            </Columns>
      </asp:gridview>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Certificate] WHERE [Certificate_ID] = @original_Certificate_ID AND [Trainer_ID] = @original_Trainer_ID AND [Certificate_Name] = @original_Certificate_Name AND [Instution] = @original_Instution AND [Date] = @original_Date AND (([File] = @original_File) OR ([File] IS NULL AND @original_File IS NULL))" InsertCommand="INSERT INTO [Certificate] ([Trainer_ID], [Certificate_Name], [Instution], [Date], [File]) VALUES (@Trainer_ID, @Certificate_Name, @Instution, @Date, @File)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Certificate] WHERE ([Trainer_ID] = @Trainer_ID)" UpdateCommand="UPDATE [Certificate] SET [Trainer_ID] = @Trainer_ID, [Certificate_Name] = @Certificate_Name, [Instution] = @Instution, [Date] = @Date, [File] = @File WHERE [Certificate_ID] = @original_Certificate_ID AND [Trainer_ID] = @original_Trainer_ID AND [Certificate_Name] = @original_Certificate_Name AND [Instution] = @original_Instution AND [Date] = @original_Date AND (([File] = @original_File) OR ([File] IS NULL AND @original_File IS NULL))">
          <DeleteParameters>
              <asp:Parameter Name="original_Certificate_ID" Type="Int32" />
              <asp:Parameter Name="original_Trainer_ID" Type="Int32" />
              <asp:Parameter Name="original_Certificate_Name" Type="String" />
              <asp:Parameter Name="original_Instution" Type="String" />
              <asp:Parameter DbType="Date" Name="original_Date" />
              <asp:Parameter Name="original_File" Type="Object" />
          </DeleteParameters>
          <InsertParameters>
              <asp:Parameter Name="Trainer_ID" Type="Int32" />
              <asp:Parameter Name="Certificate_Name" Type="String" />
              <asp:Parameter Name="Instution" Type="String" />
              <asp:Parameter DbType="Date" Name="Date" />
              <asp:Parameter Name="File" Type="Object" />
          </InsertParameters>
          <SelectParameters>
              <asp:SessionParameter DefaultValue="-1" Name="Trainer_ID" SessionField="userID" Type="Int32" />
          </SelectParameters>
          <UpdateParameters>
              <asp:Parameter Name="Trainer_ID" Type="Int32" />
              <asp:Parameter Name="Certificate_Name" Type="String" />
              <asp:Parameter Name="Instution" Type="String" />
              <asp:Parameter DbType="Date" Name="Date" />
              <asp:Parameter Name="File" Type="Object" />
              <asp:Parameter Name="original_Certificate_ID" Type="Int32" />
              <asp:Parameter Name="original_Trainer_ID" Type="Int32" />
              <asp:Parameter Name="original_Certificate_Name" Type="String" />
              <asp:Parameter Name="original_Instution" Type="String" />
              <asp:Parameter DbType="Date" Name="original_Date" />
              <asp:Parameter Name="original_File" Type="Object" />
          </UpdateParameters>
      </asp:SqlDataSource>
  </div> 
  

    </form>
</body>

</html>
