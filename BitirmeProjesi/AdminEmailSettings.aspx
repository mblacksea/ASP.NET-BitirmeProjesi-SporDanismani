<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminEmailSettings.aspx.cs" Inherits="BitirmeProjesi.AdminEmailSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/js/notifyit/notifIt.css" />
    <script src="/js/jquery-2.0.3.min.js"></script>
    <script src="/js/notifyit/notifIt.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Email Settings Page</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form">
                    <div class="box-body">
                         <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox ID="textEmail" TextMode="Email" placeHolder="Email" CssClass="form-control" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="surnameReq"
                                 runat="server"
                                 ControlToValidate="textEmail"
                                 ErrorMessage="Email is required!"
                                 SetFocusOnError="True" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <label>Email Password</label>
                            <asp:TextBox ID="textPassword" TextMode="Password" placeHolder="Email" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                 runat="server"
                                 ControlToValidate="textPassword"
                                 ErrorMessage="Password is required!"
                                 SetFocusOnError="True" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <label>Port</label>
                           <asp:TextBox ID="textPort"  placeHolder="Port" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                           <div class="form-group">
                            <label>SmtpServer</label>
                            <asp:DropDownList CssClass="form-control select2" AutoPostBack="true" ID="DropDownList1" runat="server">
                                <asp:ListItem>smtp.gmail.com</asp:ListItem>
                                <asp:ListItem>smtp.live.com</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                       
                        
                    </div>
                    <!-- /.box-body -->

                    <div class="box-footer">
                        <button type="button" onserverclick="ServerClick_Update" runat="server" class="btn btn-primary">Update</button>
                    </div>



                </form>
            </div>
        </div>
    </div>
</asp:Content>
