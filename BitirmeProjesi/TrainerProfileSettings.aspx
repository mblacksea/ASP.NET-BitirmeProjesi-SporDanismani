<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerProfileSettings.aspx.cs" Inherits="BitirmeProjesi.TrainerProfileSettings" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">






    <div class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Profile Settings Page</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Biography</label>
                            <textarea class="form-control" rows="3" runat="server" id="bioTextArea" maxlength="2000"></textarea>
                        </div>
                        <div class="form-group">
                            <label>Introduction</label>
                            <textarea class="form-control" rows="3" runat="server" id="introTextArea" maxlength="1500"></textarea>
                        </div>

                        <div class="col-lg-6">
                            <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="images/userDefaultImage.jpg" runat="server" />

                        </div>
                        <div class="form-group">
                            <label for="FileUpload1">Image</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" />

                        </div>
                    </div>
                    <!-- /.box-body -->

                    <div class="box-footer">
                        <button type="button" runat="server" onserverclick="profileSettingsUpdate" class="btn btn-primary">Update</button>
                    </div>



                </form>
            </div>
        </div>
    </div>
        <!--sag kolon    -->
        
              





</asp:Content>
