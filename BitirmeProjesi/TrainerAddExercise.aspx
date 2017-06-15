<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerAddExercise.aspx.cs" Inherits="BitirmeProjesi.TrainerAddExercise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
       <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Add New Exercise</h3>

        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Exercise Name</label>
                        <asp:TextBox ID="exerciseName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="exercisenameReq"
                            runat="server"
                            ControlToValidate="exerciseName"
                            ErrorMessage="Exercise Name is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                     <div class="form-group">
                        <label>Exercise Tittle</label>
                        <asp:TextBox ID="tittleName" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="tittlenameReq"
                            runat="server"
                            ControlToValidate="tittleName"
                            ErrorMessage="Tittle is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                  
                    <div class="form-group">
                        <label>Exercise Description</label>
                         <textarea class="form-control" rows="3" runat="server" id="descriptionarea" maxlength="1500"></textarea>
                         <asp:RequiredFieldValidator ID="descriptionnameReq"
                            runat="server"
                            ControlToValidate="descriptionarea"
                            ErrorMessage="Description is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                  
                     <div class="form-group">
                        <label>Exercise Type</label>
                         <asp:DropDownList ID="DropDownList1" CssClass="form-control select2" runat="server"></asp:DropDownList>
                       
                    </div>
                    
                    <div class="form-group">
                        <label>Video</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Label ID="LabelVideo" runat="server" Visible="false" ForeColor="Red" Text="Please, Upload video!"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Photo 1</label>
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                        <asp:Label ID="LabelPhoto1" runat="server" Visible="false" ForeColor="Red" Text="Please, Upload photo1!"></asp:Label>
                    </div>
                    <div class="form-group">
                        <label>Photo 2</label>
                        <asp:FileUpload ID="FileUpload3" runat="server" />
                        <asp:Label ID="LabelPhoto2" runat="server" Visible="false" ForeColor="Red" Text="Please, Upload photo2!"></asp:Label>
                    </div>
                    <div class="form-group">
                        <button type="button" runat="server" onserverclick="addNewExercise" class="btn btn-block btn-success">Add Exercise</button>
                    </div>

                   
                </div>
            </div>
        </div>
        </div>

</asp:Content>
