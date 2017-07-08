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
                        <label>Program Description</label>
                            <textarea class="form-control" rows="3"   runat="server" id="TextBoxDescription"></textarea>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="TextBoxDescription"
                            ErrorMessage="Description is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                    </div>
                     <div class="form-group">
                        <label>Program Price</label>
                        <asp:TextBox ID="TextBoxPrice" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="TextBoxPrice"
                            ErrorMessage="Price is required!"
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

                 <div class="col-md-6">
         <div class="box-header with-border">
            <h3 class="box-title">Buyers</h3>

        </div>
                   
                     <asp:GridView ID="GridView1" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="127px" AllowPaging="True">
                         <Columns>
                               
                                 <asp:TemplateField ShowHeader="False">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                               
                                 <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="User_ID" SortExpression="User_ID" Visible="False">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                               <asp:TemplateField HeaderText="Rating" SortExpression="Rating">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Rating") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("Rating") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                   
                   
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select case u.isPrivate when 'Y' then SUBSTRING(u.Name,1,1)+ ' ' +SUBSTRING(u.Surname,1,1) else u.Name+ ' ' +U.Surname end as UserName,u.User_ID ,r.Comment,r.Rating from Users u,UserProgram up left join Rating r on r.Program_ID=up.Program_ID and r.User_ID=up.User_ID where (up.Program_ID= @Program_ID) and u.User_ID = up.User_ID ">
                         <SelectParameters>
                             <asp:SessionParameter DefaultValue="0" Name="Program_ID" SessionField="updateProgramID" Type="Int32" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                   
                   
                </div>
            </div>
        </div>
        </div>


</asp:Content>
