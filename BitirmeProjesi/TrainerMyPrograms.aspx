<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerMyPrograms.aspx.cs" Inherits="BitirmeProjesi.TrainerMyPrograms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="/js/notifyit/notifIt.css" />
    <script src="/js/jquery-2.0.3.min.js"></script>
    <script src="/js/notifyit/notifIt.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">My Programs -> Edit</h3>
            
        </div>
    </div>

     <div class="row">
        <!-- left column -->
            <div class="col-md-3">
                <!-- general form elements -->
                <div class="box box-primary">
                 
                    <!-- /.box-header -->
                    <!-- form start -->

                    <div class="box-body">
                        <div class="form-group">
                            <label>Search</label>
                            <asp:DropDownList CssClass="form-control select2" ID="DropDownList1" runat="server">
                                <asp:ListItem>ProgramTittle</asp:ListItem>
                                <asp:ListItem>ProgramDifficulty</asp:ListItem>
                                <asp:ListItem>ProgramSpec</asp:ListItem>
                                <asp:ListItem>isBanned</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                          <div class="form-group">
                            <asp:TextBox ID="textField2" placeHolder="SearchQuery" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                       
                            <div class="form-group">
                                <label>Start</label>
                            <asp:TextBox ID="DateStart" TextMode="Date" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group">
                                 <label>End  </label>
                            <asp:TextBox ID="DateEnd" TextMode="Date" runat="server"></asp:TextBox>

                        </div>

                      




                    </div>
                    <div class="box-footer">
                         <asp:Button ID ="search" Text="Search" OnClick="searchButton" CssClass="btn btn-primary" CausesValidation="false" runat="server" />
                       
                    </div>

                </div>
            </div>



    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="Program_ID" DataSourceID="SqlDataSource1" AllowPaging="True">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClick="MyButtonClick" runat="server" OnClientClick="return confirm('Are you sure you want to delete?'); " CausesValidation="false" CommandName="" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Publish"  OnClientClick="return confirm('Are you sure you want to publish?'); " CausesValidation="false" CommandName="" Text="Publish"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
       
            <asp:TemplateField HeaderText="Program Tittle" SortExpression="ProgramTittle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Trainer_ID" HeaderText="Trainer_ID" SortExpression="Trainer_ID" Visible="False" />
            <asp:TemplateField HeaderText="Program Difficulty" SortExpression="ProgramDifficulty">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ProgramDifficulty") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProgramDifficulty") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Program Spec" SortExpression="ProgramSpec">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProgramSpec") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProgramSpec") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Trainer_ID" HeaderText="Trainer_ID" SortExpression="Trainer_ID" Visible="False" />
            <asp:TemplateField HeaderText="Program_ID" InsertVisible="False" SortExpression="Program_ID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Program_ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Program_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="isBanned" SortExpression="isBanned">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("isBanned") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("isBanned") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="BannedReason" HeaderText="BannedReason" SortExpression="BannedReason" />
            <asp:TemplateField HeaderText="CreationDate" SortExpression="CreationDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CreationDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("CreationDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                   <asp:TemplateField HeaderText="Status_ID" Visible="false" SortExpression="Status_ID">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Status_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Price" SortExpression="Price">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label8" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="CountOfSales" SortExpression="CountOfSales">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("CountOfSales") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label9" runat="server" Text='<%# Bind("CountOfSales") %>'></asp:Label>
                 </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="" SelectCommand="SELECT [ProgramTittle], [ProgramDifficulty].[ProgramDiff_Name] as ProgramDifficulty, [ProgramSpec].[ProgramSpec_Name] as ProgramSpec, [Trainer_ID], [Program].[Program_ID],[isBanned],[BannedReason],[CreationDate],[Status_ID],[ProgramPrice] as Price,(select count(*) from UserProgram up where up.Program_ID=[Program].[Program_ID]) as CountOfSales FROM [Program],[ProgramSpec],[ProgramDifficulty] WHERE [ProgramDifficulty].[ProgramDiff_ID] = [Program].[ProgramDiff_ID] and [ProgramSpec].[ProgramSpec_ID]=[Program].[ProgramSpec_ID] and ([Trainer_ID] = @Trainer_ID)">
        
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


</asp:Content>
