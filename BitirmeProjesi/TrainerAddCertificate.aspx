<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerAddCertificate.aspx.cs" Inherits="BitirmeProjesi.TrainerCreateProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="js/notifyit/notifIt.css" rel="stylesheet" />
        <script src="js/notifyit/notifIt.js"></script>
        <script src="js/jquery-2.0.3.min.js"></script>
</asp:Content>

     

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
                        <asp:TextBox ID="certificateName" onkeyup="textCounter(this, this.form.remLenCertificateName, 200);" CssClass="form-control" placeholder="Max(200)" maxlength="200" runat="server"></asp:TextBox>
                            Rest character:

                <input readonly="readonly" class="form-control" name="remLenCertificateName" readonly="readonly" type="text" value="200" />
                        <asp:RequiredFieldValidator ID="certificatenameReq"
                            runat="server"
                            ControlToValidate="certificateName"
                            ErrorMessage="Certificate Name is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                     <div class="form-group">
                        <label>Instution</label>
                        <asp:TextBox ID="instutionName" onkeyup="textCounter(this, this.form.remLenIns, 100);" placeholder="Max(100)" maxlength="100" CssClass="form-control" runat="server"></asp:TextBox>
                            Rest character:   
                                    <input readonly="readonly" class="form-control" name="remLenIns" readonly="readonly" type="text" value="100" />

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
