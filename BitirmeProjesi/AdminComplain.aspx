<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminComplain.aspx.cs" Inherits="BitirmeProjesi.AdminComplain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="/js/notifyit/notifIt.css" />
    <script src="/js/jquery-2.0.3.min.js"></script>
    <script src="/js/notifyit/notifIt.js"></script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
      <div class="col-lg-8 col-sm-8">

    <div class="row">
        <!-- left column -->
        <div class="col-md-3">
            <!-- general form elements -->
            <div class="box box-primary">
                   <div class="header">
                                <h4 class="title">Complain Page</h4>
                                
                            </div>
                <!-- /.box-header -->
                <!-- form start -->

                <div class="box-body">
                    <div class="form-group">
                    
                        <asp:DropDownList CssClass="form-control select2" ID="DropDownList1" runat="server">
                            <asp:ListItem>TrainerName</asp:ListItem>
                            <asp:ListItem>ProgramTittle</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">

                        <asp:TextBox ID="textField" placeHolder="SearchQuery" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>




                </div>
                <div class="box-footer">
                   
                    <button type="button" runat="server" CausesValidation="false" onserverclick="searchButton" class="btn btn-primary">Search</button>
                  
                </div>
                   <br />
            </div>
            </div>
        </div>
                           
          </div>

     
  <br />
    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server"  OnClientClick="return confirm('Are you sure you want to delete?'); " CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User_ID" SortExpression="User_ID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer Name" SortExpression="UserName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Customer Surname" Visible="false" SortExpression="Surname">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Surname") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Surname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Program_ID" SortExpression="Program_ID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("PID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Program Tittle" SortExpression="ProgramTittle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="TUser_ID" SortExpression="TUser_ID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TUser_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("TUser_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trainer Name" SortExpression="TrainerName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TrainerName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("TrainerName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trainer Surname" Visible="false" SortExpression="TSurname">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("TSurname") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("TSurname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ComplainStatus_Name" Visible="false" SortExpression="Status">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
 

    <div runat="server" id="decisionButton" class="box-footer">
        <asp:Button ID="ButtonProgramBan" OnClick="ButtonProgramBan_Click" CausesValidation="false" CssClass="btn btn-danger" Width="150px" runat="server" Text="Program Ban" />
        <asp:Button ID="ButtonTrainerBan" OnClick="ButtonTrainerBan_Click" CausesValidation="false" CssClass="btn btn-warning pull-center" Width="150px" runat="server" Text="Trainer Ban" />

    </div>
       
  
      

    <div runat="server" id="feedBack" class="row">
        <!-- left column -->
        <div class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <!-- /.box-header -->
                <!-- form start -->
               
                    <div class="box-body">
                        <div class="form-group">
                            <label>Program Ban Reason</label>
                            <textarea class="form-control" disabled="disabled" rows="5" runat="server" id="programBanReason"></textarea>
                            
                        </div>
                        <div class="form-group">
                            <label>Trainer Ban Reason</label>
                            <textarea class="form-control" disabled="disabled" rows="5" runat="server"  id="trainerBanReason"></textarea>
                            
                        </div>
                        </div>
                </div>
            </div>
        </div>
  
    
   


 

        <div id="reasonBannedSection" runat="server" class="col-md-6">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 runat="server" id="textBanned" class="box-title">Reason for Banned</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <form  role="form">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Reason</label>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                 runat="server"
                                 ControlToValidate="reasonTextArea"
                                 ErrorMessage="Ban reason is required!"
                                 SetFocusOnError="True" ForeColor="Red" />
                            <asp:TextBox ID="reasonTextArea" Rows="5" TextMode="MultiLine" Placeholder="Max(3000)" CssClass="form-control" runat="server"></asp:TextBox>
                            
                        </div>
                        <div runat="server" id="banForDateSection" class="form-group">
                            <label>Ban Date</label>
                            <div class="col-xs-7">
                                <div class="numbers">
                                    <p>If you do not choose a date, it will be banned indefinitely</p>

                                </div>
                            </div>

                            <asp:TextBox ID="banDate" TextMode="Date" runat="server"></asp:TextBox>
                        </div>

                        <div class="box-footer">
                            <asp:Button ID="ButtonSend"  OnClick="ButtonSend_Click"  CssClass="btn btn-primary" runat="server" Text="Send" />
                    
       

                        </div>
                        </div>
                    </form>
                </div>
            </div>
 
  
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select c.Id,u.User_ID,u.Name+ ' ' +u.Surname as UserName,u.Surname,c.Program_ID as PID,pr.ProgramTittle as ProgramTittle,p.User_ID as TUser_ID,p.Name+ ' ' +p.Surname as TrainerName,p.Surname as TSurname,c.Comment,cs.ComplainStatus_Name as Status from Complain c,ComplainStatus cs,Users u,Users p,Program pr where  cs.ComplainStatus_ID=2 and c.Program_ID=pr.Program_ID and c.User_ID=u.User_ID and pr.Trainer_ID=p.User_ID and cs.ComplainStatus_ID=c.ComplainStatus_ID"  DeleteCommand="DELETE FROM [Complain] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Complain] ([User_ID], [Program_ID], [Comment], [ComplainStatus_ID]) VALUES (@User_ID, @Program_ID, @Comment, @ComplainStatus_ID)" UpdateCommand="UPDATE [Complain] SET [User_ID] = @User_ID, [Program_ID] = @Program_ID, [Comment] = @Comment, [ComplainStatus_ID] = @ComplainStatus_ID WHERE [Id] = @Id">
    
         <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="User_ID" Type="Int32" />
            <asp:Parameter Name="Program_ID" Type="Int32" />
            <asp:Parameter Name="Comment" Type="String" />
            <asp:Parameter Name="ComplainStatus_ID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="User_ID" Type="Int32" />
            <asp:Parameter Name="Program_ID" Type="Int32" />
            <asp:Parameter Name="Comment" Type="String" />
            <asp:Parameter Name="ComplainStatus_ID" Type="Int32" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
 

         </div>
    
 

</asp:Content>
