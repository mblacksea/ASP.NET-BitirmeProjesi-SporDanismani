<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerProfileSettings.aspx.cs" Inherits="BitirmeProjesi.TrainerProfileSettings" %>




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
                    <h3 class="box-title">Profile Settings Page</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form role="form">
                    <div class="box-body">
                         <div class="form-group">
                            <label>Email</label>
                            <textarea class="form-control" rows="1" onkeyup="textCounter(this, this.form.remLenEmail, 100);" placeholder="Max(100)" runat="server" id="emailTextArea" maxlength="100"></textarea>
                             Rest character:
                             <input readonly="readonly" class="form-control" name="remLenEmail" readonly="readonly" type="text" value="100" />
                             <asp:RequiredFieldValidator ID="surnameReq"
                                 runat="server"
                                 ControlToValidate="emailTextArea"
                                 ErrorMessage="Email is required!"
                                 SetFocusOnError="True" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <label>Biography</label>
                            <textarea class="form-control" rows="3" onkeyup="textCounter(this, this.form.remLenBio, 2000);" placeholder="Max(2000)" runat="server" id="bioTextArea" maxlength="2000"></textarea>
                       Rest character:
                             <input readonly="readonly" class="form-control" name="remLenBio" readonly="readonly" type="text" value="2000" />
                              </div>
                        <div class="form-group">
                            <label>Introduction</label>
                            <textarea class="form-control" onkeyup="textCounter(this, this.form.remLenIntro, 1500);" rows="3" runat="server" placeholder="Max(1500)" id="introTextArea" maxlength="1500"></textarea>
                       Rest character:
                             <input readonly="readonly" class="form-control" name="remLenIntro" readonly="readonly" type="text" value="1500" />
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
