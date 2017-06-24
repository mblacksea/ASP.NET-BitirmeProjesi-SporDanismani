<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerMyProgramsDetails.aspx.cs" Inherits="BitirmeProjesi.TrainerMyProgramsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">My Programs Details</h3>

        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="row">
                <div class="col-md-6">
       
                    <div class="form-group">
                        <label>Program Spec</label>
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control select2" runat="server"></asp:DropDownList>
                    </div>

                     <div class="form-group">
                        <label>Program Difficulty</label>
                        <asp:DropDownList ID="DropDownList2" CssClass="form-control select2" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Program Tittle</label>
                        <asp:TextBox ID="TextBoxProgramTittle" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="tittleValidator"
                            runat="server"
                            ControlToValidate="TextBoxProgramTittle"
                            ErrorMessage="Tittle is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>

                     <div class="form-group">
                         <label>Program Image</label>
                         <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="images/userDefaultImage.jpg" runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="FileUpload1">Image</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>

                
                      <div class="form-group">
                        <button type="button" runat="server" id="updateButton" onserverclick="update" class="btn btn-block btn-success">Update</button>
                    </div>

                    
                      <div class="form-group">
                        <button type="button" runat="server" onserverclick="continueWithoutUpdate" class="btn btn-block btn-warning">Continue</button>
                    </div>
                   
               
                   
                   
                </div>
            </div>
        </div>
        </div>


</asp:Content>
