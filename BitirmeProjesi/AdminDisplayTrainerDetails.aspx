<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminDisplayTrainerDetails.aspx.cs" Inherits="BitirmeProjesi.AdminDisplayTrainerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="col-lg-7 col-sm-6">

    <div class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Trainer Details Page</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->

                    <div class="box-body">
                           <div class="form-group">
                            <label>Trainer</label>
                            <textarea class="form-control" rows="1" disabled="disabled" runat="server" id="trainerName" maxlength="2000"></textarea>
                        </div>
                            <div class="form-group">
                            <label>Introduction</label>
                            <textarea class="form-control" rows="3" disabled="disabled" runat="server"  id="trainerIntro" maxlength="1500"></textarea>
                        </div>

                        <div class="form-group">
                            <label>Biography</label>
                            <textarea class="form-control" rows="4" disabled="disabled" runat="server" id="trainerBio" maxlength="2000"></textarea>
                        </div>
                    

                        <div class="col-lg-6">
                            <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="images/userDefaultImage.jpg" runat="server" />

                        </div>
                      
                    </div>
                    </div>
            </div>
        </div>
            </div>
</asp:Content>
