<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerChangePassword.aspx.cs" Inherits="BitirmeProjesi.TrainerChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">Change Password</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
              <form role="form">
                  <div class="box-body">
                      <div class="form-group">
                          <label for="exampleInputPassword1">Old Password</label>
                          <asp:TextBox ID="exampleInputPassword1" placeholder="Old Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="confirmPasswordReq"
                              runat="server"
                              ControlToValidate="exampleInputPassword1"
                              ForeColor="Red"
                              ErrorMessage="Password is required!"
                              SetFocusOnError="True"
                              Display="Dynamic" />
                      </div>
                      <div class="form-group">
                          <label for="exampleInputPassword2">New Password</label>
                          <asp:TextBox ID="exampleInputPassword2" placeholder="New Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                              runat="server"
                              ControlToValidate="exampleInputPassword2"
                              ForeColor="Red"
                              ErrorMessage="Password is required!"
                              SetFocusOnError="True"
                              Display="Dynamic" />
                      </div>
                      <div class="form-group">
                          <label for="exampleInputPassword3">Repeat New Password</label>
                          <asp:TextBox ID="exampleInputPassword3" placeholder="Repeat New Password" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                              runat="server"
                              ControlToValidate="exampleInputPassword3"
                              ForeColor="Red"
                              ErrorMessage="Password is required!"
                              SetFocusOnError="True"
                              Display="Dynamic" />
                           </div>
                      <asp:CompareValidator ID="comparePasswords"
                          runat="server"
                          ControlToCompare="exampleInputPassword2"
                          ControlToValidate="exampleInputPassword3"
                          ErrorMessage="Your passwords do not match up!"
                          ForeColor="Red"
                          Display="Dynamic" />

                  </div>
                  <!-- /.box-body -->

                  <div class="box-footer">
                      <button type="submit" runat="server" onserverclick="Unnamed_ServerClick" class="btn btn-primary">Change</button>
                  </div>
              </form>
          </div>
    </div>
          <!-- /.box -->

         

</asp:Content>
