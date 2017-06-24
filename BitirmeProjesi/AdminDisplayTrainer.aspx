<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminDisplayTrainer.aspx.cs" Inherits="BitirmeProjesi.AdminDisplayTrainer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


         <div class="col-lg-10 col-sm-8">

    <div class="row">
        <!-- left column -->
        <div class="col-md-2">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">All Trainers</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                <div class="box-body">
                    <div class="form-group">
                        <label>Search</label>
                        <asp:DropDownList CssClass="form-control select2" ID="DropDownList1" runat="server">
                            <asp:ListItem>TrainerName</asp:ListItem>
                            <asp:ListItem>StatusName</asp:ListItem>
                       
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="textField" placeHolder="SearchQuery" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>

                </div>
                 <div class="box-footer">
                    <button type="button" runat="server" onserverclick="searchButton" class="btn btn-primary">Search</button>
                 
                </div>
                     <br />
            </div>
        </div>
    </div>
                           

             </div>
     
  <br />



    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="Trainer_ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Trainer_ID" Visible="false" SortExpression="Trainer_ID">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Trainer_ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Trainer_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

           <asp:TemplateField HeaderText="SalesProgram" SortExpression="SalesProgram">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxProgramNumber" runat="server" Text='<%# Bind("SalesProgram") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                  <asp:Label ID="LabelProgramNumber" runat="server" Text='<%# Bind("SalesProgram") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField HeaderText="TrainerName" SortExpression="TrainerName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TrainerName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("TrainerName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          

            <asp:TemplateField HeaderText="Intro" Visible="false" SortExpression="Intro">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Intro") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Intro") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bio" Visible="false" SortExpression="Bio">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Bio") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Bio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StatusName" SortExpression="StatusName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("StatusName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("StatusName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="isBanned" Visible="false" SortExpression="isBanned">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("isBanned") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("isBanned") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BannedReason" SortExpression="BannedReason">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("BannedReason") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("BannedReason") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Users].[Name]+ ' ' +[Users].[Surname] as TrainerName,[Trainer_ID], [Intro], [Bio], [Status].[Status_Name] as StatusName, [isBanned], [BannedReason] ,
(
select count(*) from Program p ,  UserProgram up
where up.Program_ID= p.Program_ID
and  p.Trainer_ID= [TrainersData].[Trainer_ID]
) as SalesProgram
FROM [TrainersData],[Users],[Status]
 where [TrainersData].[Status_ID]=[Status].[Status_ID]  and [TrainersData].[Trainer_ID]=[Users].[User_ID]"></asp:SqlDataSource>


</asp:Content>
