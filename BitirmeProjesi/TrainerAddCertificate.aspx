<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerAddCertificate.aspx.cs" Inherits="BitirmeProjesi.TrainerCreateProgram" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="box box-default">
        <div class="box-header with-border">
          <h3 class="box-title">Add New Certificate</h3>

      
        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Certificate Name</label>
                        <asp:TextBox ID="certificateName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="certificatenameReq"
                            runat="server"
                            ControlToValidate="certificateName"
                            ErrorMessage="Certificate Name is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                     <div class="form-group">
                        <label>Instution</label>
                        <asp:TextBox ID="instutionName" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="instutionnameReq"
                            runat="server"
                            ControlToValidate="instutionName"
                            ErrorMessage="Instution Name is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                     <div class="form-group">
                        <label>Date</label>
                        <asp:TextBox ID="date" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="dateReq"
                            runat="server"
                            ControlToValidate="date"
                            ErrorMessage="Date is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                    <div class="form-group">
                        <label>File(Optional)</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    <div class="form-group">
                        <button type="button" runat="server" onserverclick="addNewCertificate" class="btn btn-block btn-success">Add Certificate</button>
                    </div>

                   
                </div>
            </div>
        </div>
        </div>


 
</asp:Content>
