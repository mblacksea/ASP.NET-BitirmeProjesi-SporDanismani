<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerCreateProgram1.aspx.cs" Inherits="BitirmeProjesi.TrainerCreateProgram1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script src="js/deneme.js"></script>
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Create Program</h3>

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
                        <label>Program Description</label>
                        <textarea class="form-control" rows="5" placeholder="Max(2000)" runat="server" id="TextBoxArea" maxlength="2000"></textarea>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="TextBoxArea"
                            ErrorMessage="Description is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>

                    <div class="form-group">
                        <label>Program Price</label>
                       <asp:TextBox ID="TextBoxPrice" onblur="checknegative(this)" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="TextBoxPrice"
                            ErrorMessage="Program Price is required!"
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
                        <button type="button" runat="server" onserverclick="next" class="btn btn-block btn-success">Next</button>
                    </div>
                   
               
                   
                   
                </div>
            </div>
        </div>
        </div>

</asp:Content>


   
         