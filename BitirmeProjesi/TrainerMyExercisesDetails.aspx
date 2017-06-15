<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerMyExercisesDetails.aspx.cs" Inherits="BitirmeProjesi.TrainerMyExercisesDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Exercise Details</h3>
        </div>


           <form role="form">
                    <div class="box-body">
                        <div class="col-md-8">

                            <div class="form-group">
                                <label for="Name">Name</label>
                                <asp:TextBox ID="Name" placeholder="Name" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="confirmPasswordReq"
                                    runat="server"
                                    ControlToValidate="Name"
                                    ForeColor="Red"
                                    ErrorMessage="Name is required!"
                                    SetFocusOnError="True"
                                    Display="Dynamic" />
                            </div>
                            <div class="form-group">
                                <label for="Tittle">Tittle</label>
                                <asp:TextBox ID="Tittle" placeholder="Tittle" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                    runat="server"
                                    ControlToValidate="Tittle"
                                    ForeColor="Red"
                                    ErrorMessage="Tittle is required!"
                                    SetFocusOnError="True"
                                    Display="Dynamic" />
                            </div>
                            <div class="form-group">
                                <label for="Description">Description</label>
                                <asp:TextBox ID="Description" placeholder="Description" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    runat="server"
                                    ControlToValidate="Description"
                                    ForeColor="Red"
                                    ErrorMessage="Description is required!"
                                    SetFocusOnError="True"
                                    Display="Dynamic" />
                            </div>
                            <div class="form-group">
                                <label>Exercise Type Name</label>
                                <asp:DropDownList ID="DropDownList2" CssClass="form-control select2" runat="server"></asp:DropDownList>
                            </div>

                        </div>
             

                        <div class="col-lg-6">
                            <asp:Image ID="Image1" CssClass="img-responsive" ImageUrl="images/userDefaultImage.jpg" runat="server" />
                            <label for="FileUpload1">Photo1</label>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>

                         <div class="col-lg-6">
                            <asp:Image ID="Image2" CssClass="img-responsive" ImageUrl="images/userDefaultImage.jpg" runat="server" />
                             <label for="FileUpload2">Photo2</label>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </div>

                        <div class="col-lg-6">
                            <label>Video</label>
                            <asp:FileUpload ID="FileUpload3" runat="server" />
                            <asp:Label ID="LabelVideo" runat="server" Visible="false" ForeColor="Red" Text="Please, Upload video!"></asp:Label>
                            <video id="videoExercise" width="400" height="400" runat="server" controls="controls">
                                <source src="movie.mp4" type="video/mp4" />
                            </video>
                        </div>
                        
                     
                        
                        <div class="col-lg-6">
                         
                        </div>
               </div>
                    </div>
                    <!-- /.box-body -->



               <div class="row">
                   <div class="col-md-3">
                       <div class="form-group">
                           <button type="button" runat="server" onserverclick="updateExerciseDetails" class="btn btn-block btn-success">Update</button>
                       </div>
                   </div>
               </div>


                </form>




 


</asp:Content>
