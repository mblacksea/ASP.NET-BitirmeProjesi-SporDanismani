<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerCreateProgram1.aspx.cs" Inherits="BitirmeProjesi.TrainerCreateProgram1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
                        <button type="button" runat="server" onserverclick="next" class="btn btn-block btn-success">Next</button>
                    </div>
                   
               
                   
                   
                </div>
            </div>
        </div>
        </div>

</asp:Content>
