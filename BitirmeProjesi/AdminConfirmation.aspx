<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminConfirmation.aspx.cs" Inherits="BitirmeProjesi.AdminConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




     <div class="content">
            <div class="container-fluid">
                  <div class="header">
                                <h4 class="title">Trainer Confirmation</h4>
                                
                            </div>
                <div class="row">
                     <div class="card">
                          
                         <asp:GridView ID="GridView1" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed"  runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="User_ID" DataSourceID="SqlDataSource1">
                             <Columns>
                                 <asp:CommandField SelectText="Details" ShowSelectButton="True" />
                                 <asp:TemplateField HeaderText="User_ID" InsertVisible="False" SortExpression="User_ID" Visible="False">
                                     <EditItemTemplate>
                                         <asp:Label ID="Label1" runat="server" Text='<%# Eval("User_ID") %>'></asp:Label>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label1" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Surname" SortExpression="Surname">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Surname") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("Surname") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Sex" SortExpression="Sex">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Sex") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label5" runat="server" Text='<%# Bind("Sex") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Birthday" SortExpression="Birthday">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Birthday") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label6" runat="server" Text='<%# Bind("Birthday","{0:dd/MM/yyyy}") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select u.User_ID,u.Name,u.Surname,u.Email,u.Sex,u.Birthday from Users u,TrainersData t where u.User_ID=t.Trainer_ID and t.Status_ID=2"></asp:SqlDataSource>
                        </div>


                </div>
            </div>
        </div>




</asp:Content>
