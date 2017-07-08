<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminDisplayUsersDetails.aspx.cs" Inherits="BitirmeProjesi.AdminDisplayUsersDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <div class="col-lg-10 col-sm-8">

            <div class="row">
                    <div class="col-md-12">
                    <!-- general form elements -->

                    <div class="header">
                        <h4 class="title">
                            <asp:Label ID="Label1" runat="server" Text="All Users -> "></asp:Label>
                           
                        </h4>

                    </div>
                   
              
                    <br />

                </div>

            </div>
            <div class="row">
                <!-- left column -->
                <div class="col-md-3">
                          
                         <div class="card">
                            <div class="content">
                                <div class="row">
                                    <div class="col-xs-5">
                                        <div class="icon-big icon-warning text-center">
                                            <i class="ti-money"></i>
                                        </div>
                                    </div>
                                    <div class="col-xs-7">
                                        <div class="numbers">
                                            <p>Total Payment</p>
                                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label> 
                                        </div>
                                    </div>
                                </div>
                           
                            </div>
                        </div>
                    
                               
                    <div class="box-body">
                        <div class="form-group">
                            <label>Search</label>
                            <asp:DropDownList CssClass="form-control select2" ID="DropDownList1" runat="server">
                                <asp:ListItem>ProgramTittle</asp:ListItem>
                                <asp:ListItem>TrainerName</asp:ListItem>
                            

                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="textField"  placeHolder="SearchQuery" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>
                           
                    <div class="box-footer">
                        <button type="button" onserverclick="searchButton" runat="server"  class="btn btn-primary">Search</button>

                    </div>
                    <br />
             

                </div>
            </div>


        </div>

        <br />

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CssClass="table table-striped table-bordered table-condensed" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" PageSize="5">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User_ID" Visible="false" SortExpression="User_ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="ProgramTittle" SortExpression="ProgramTittle">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProgramTittle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                      <asp:TemplateField HeaderText="ProgramPrice" SortExpression="ProgramPrice">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ProgramPrice") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("ProgramPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Trainer" SortExpression="TrainerName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TrainerName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("TrainerName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Program_ID" Visible="false" SortExpression="Program_ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Program_ID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Program_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BuyDate" SortExpression="BuyDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("BuyDate","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("BuyDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [UserProgram].[User_ID], [UserProgram].[Program_ID],[Program].[ProgramTittle],[Program].[ProgramPrice],[Users].[Name]+ ' ' +[Users].[Surname] as TrainerName,[UserProgram].[BuyDate] FROM [UserProgram],[Program],[Users] WHERE [Users].[User_ID]=[Program].[Trainer_ID] and ([UserProgram].[User_ID] = @User_ID) and [Program].[Program_ID]=[UserProgram].[Program_ID]">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="User_ID" SessionField="userDisplayID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>



</asp:Content>
