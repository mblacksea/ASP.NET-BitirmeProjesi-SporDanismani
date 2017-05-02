<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminConfirmationTrainerDetails.aspx.cs" Inherits="BitirmeProjesi.AdminConfirmationTrainerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


    <div class="content">
            <div class="container-fluid">
                <div class="row">
                     <div class="card">
                            <div class="header">
                                <h4 class="title">Trainer Details</h4>
                               
                            </div>
                         <div class="content">
                         
                                       
                                 
                                
                             
                                       <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Bio</label>
                                                <textarea id="TextArea1" disabled="disabled" runat="server" class="form-control border-input"  cols="20" rows="10"></textarea>
                                            </div>
                                        </div>
                                 
                                    </div>

                             <asp:GridView ID="GridView1" OnSelectedIndexChanged = "OnSelectedIndexChanged"  CssClass= "table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="Certificate_ID" DataSourceID="SqlDataSource1" AllowPaging="True">
                                 <Columns>
                                     <asp:CommandField SelectText="Download" ShowSelectButton="True" />
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
                                     <asp:TemplateField HeaderText="Certificate Name" SortExpression="Certificate_Name">
                                         <EditItemTemplate>
                                             <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Certificate_Name") %>'></asp:TextBox>
                                         </EditItemTemplate>
                                         <ItemTemplate>
                                             <asp:Label ID="Label3" runat="server" Text='<%# Bind("Certificate_Name") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Instution" SortExpression="Instution">
                                         <EditItemTemplate>
                                             <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Instution") %>'></asp:TextBox>
                                         </EditItemTemplate>
                                         <ItemTemplate>
                                             <asp:Label ID="Label4" runat="server" Text='<%# Bind("Instution") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                         <EditItemTemplate>
                                             <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                                         </EditItemTemplate>
                                         <ItemTemplate>
                                             <asp:Label ID="Label5" runat="server" Text='<%# Bind("Date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                                       </asp:GridView>   
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Certificate] WHERE ([Trainer_ID] = @Trainer_ID)">
                                 <SelectParameters>
                                     <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerDetailsID" Type="Int32" />
                                 </SelectParameters>
                                       </asp:SqlDataSource>
                             <asp:Button ID="Button1" CssClass="btn btn-success" OnClientClick="return confirm('Are you sure you want to confirm?'); " runat="server" Text="Confirm" OnClick="Button1_Click" />
                             <asp:Button ID="Button2" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to decline?'); " runat="server" Text="Decline" OnClick="Button2_Click" />
                         </div>
                    </div>
                </div>
        </div>


</asp:Content>
