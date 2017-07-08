<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminDisplayPrograms.aspx.cs" Inherits="BitirmeProjesi.AdminDisplayPrograms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
    <div class="content">
   
            

                <div class="row">

                    <!-- left column -->
                    <div class="col-md-3">
                            <div class="header">
                                <h4 class="title">All Programs</h4>
                                
                            </div>
                        <!-- general form elements -->
                        <div class="box box-primary">
                                          

                <div class="box-body">
                    <div class="form-group">

                        <asp:DropDownList CssClass="form-control select2" ID="DropDownList1" runat="server">
                            <asp:ListItem>TrainerName</asp:ListItem>
                            <asp:ListItem>ProgramSpec_Name</asp:ListItem>
                            <asp:ListItem>ProgramDiff_Name</asp:ListItem>
                            <asp:ListItem>ProgramTittle</asp:ListItem>
                            <asp:ListItem>Status_Name</asp:ListItem>
                            <asp:ListItem>isBanned</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                     <div class="form-group">
                                <label>Start</label>
                            <asp:TextBox ID="DateStart" TextMode="Date" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group">
                                 <label>End  </label>
                            <asp:TextBox ID="DateEnd" TextMode="Date" runat="server"></asp:TextBox>

                        </div>
                    <div class="form-group">
                        <asp:TextBox ID="textField2" placeHolder="SearchQuery" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>




                </div>
                            <div class="box-footer">
                                <button type="button" runat="server" onserverclick="searchButton" causesvalidation="false"  class="btn btn-primary">Search</button>
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                
              
                    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="Program_ID" DataSourceID="SqlDataSource1" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Program_ID" InsertVisible="False" SortExpression="Program_ID" Visible="False">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Program_ID") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Program_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="TrainerName" SortExpression="TrainerName">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("TrainerName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("TrainerName") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="ProgramSpec Name" SortExpression="ProgramSpec_Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ProgramSpec_Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProgramSpec_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProgramDiff Name" SortExpression="ProgramDiff_Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProgramDiff_Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProgramDiff_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User_ID" SortExpression="User_ID" Visible="False">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProgramTittle" SortExpression="ProgramTittle">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProgramDescription" SortExpression="ProgramDescription">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ProgramDescription") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("ProgramDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ProgramPrice" SortExpression="ProgramPrice">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("ProgramPrice") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("ProgramPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status Name" SortExpression="Status_Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Status_Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Status_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="isBanned" SortExpression="isBanned">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("isBanned") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label10"   runat="server" Text='<%# Bind("isBanned") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BannedReason" SortExpression="BannedReason">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("BannedReason") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("BannedReason") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CreationDate" SortExpression="CreationDate">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("CreationDate","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("CreationDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Users].[Name]+ ' ' + [Users].[Surname] as TrainerName ,[Program].[Program_ID],[Program].[Trainer_ID],[ProgramSpec].[ProgramSpec_Name],[ProgramDifficulty].[ProgramDiff_Name],[Program].[User_ID],[Program].[ProgramTittle],[Program].[ProgramDescription],[Program].[ProgramPrice],[Status].[Status_Name],[Program].[isBanned],[Program].[BannedReason],[Program].[CreationDate] FROM [Program],[ProgramSpec],[ProgramDifficulty],[Status],[Users] where [Users].[User_ID]=[Program].[Trainer_ID] and [Program].[Status_ID]=[Status].[Status_ID]  and [ProgramDifficulty].[ProgramDiff_ID]=[Program].[ProgramDiff_ID] and [ProgramSpec].[ProgramSpec_ID]=[Program].[ProgramSpec_ID]"></asp:SqlDataSource>

                </div>
            </div>
        </div>

</asp:Content>
