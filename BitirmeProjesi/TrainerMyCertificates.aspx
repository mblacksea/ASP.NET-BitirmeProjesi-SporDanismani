<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerMyCertificates.aspx.cs" Inherits="BitirmeProjesi.TrainerMyCertificates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged1" CssClass= "table table-striped table-bordered table-condensed"   AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Certificate_ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" Visible="False" CausesValidation="True"  CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" Visible="False" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" Visible="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete?'); " CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Certificate_ID" InsertVisible="False" SortExpression="Certificate_ID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Certificate_ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Certificate_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trainer_ID" SortExpression="Trainer_ID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Trainer_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Trainer_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Certificate Name" SortExpression="Certificate Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Certificate_Name") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="textabc"
                            runat="server"
                            ControlToValidate="TextBox2"
                            ErrorMessage="Certificate Name is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Certificate_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Instution" SortExpression="Instution">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Instution") %>'></asp:TextBox>
                     <asp:RequiredFieldValidator ID="textabcd"
                            runat="server"
                            ControlToValidate="TextBox3"
                            ErrorMessage="Instution is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Instution") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date" SortExpression="Date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Date","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Certificate] WHERE [Certificate_ID] = @original_Certificate_ID" InsertCommand="INSERT INTO [Certificate] ([Trainer_ID], [Certificate_Name], [Instution], [Date], [CertificateFile]) VALUES (@Trainer_ID, @Certificate_Name, @Instution, @Date, @CertificateFile)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Certificate] WHERE ([Trainer_ID] = @Trainer_ID)" UpdateCommand="UPDATE [Certificate] SET [Certificate_Name] = @Certificate_Name, [Instution] = @Instution, [Date] = @Date WHERE [Certificate_ID] = @original_Certificate_ID">
        <DeleteParameters>
            <asp:Parameter Name="Certificate_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Trainer_ID" Type="Int32" />
            <asp:Parameter Name="Certificate_Name" Type="String" />
            <asp:Parameter Name="Instution" Type="String" />
            <asp:Parameter DbType="Date" Name="Date" />
            <asp:Parameter Name="CertificateFile" Type="Object" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerID" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Trainer_ID" Type="Int32" />
            <asp:Parameter Name="Certificate_Name" Type="String" />
            <asp:Parameter Name="Instution" Type="String" />
            <asp:Parameter DbType="Date" Name="Date" />
            <asp:Parameter Name="CertificateFile" Type="Object" />
            <asp:Parameter Name="Certificate_ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

     <div class="box-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label>Certificate Name</label>
                        <asp:TextBox ID="certificateName" CssClass="form-control" placeholder="Max(200)" maxlength="200" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="certificatenameReq"
                            runat="server"
                            ControlToValidate="certificateName"
                            ErrorMessage="Certificate Name is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                     <div class="form-group">
                        <label>Instution</label>
                        <asp:TextBox ID="instutionName" placeholder="Max(100)" maxlength="100" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <button type="button" id="updateID" runat="server" onserverclick="updateCertificate" class="btn btn-block btn-success">Update Certificate</button>
                    </div>
                    <div class="form-group">
                        <button type="button" id="showCertificateID" onserverclick="showCertificate" runat="server" class="btn btn-block btn-warning">Show Certificate File</button>
                    </div>
                    </div>
                </div>
         </div>


</asp:Content>
