<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerCircleExercise.aspx.cs" Inherits="BitirmeProjesi.TrainerCircleExercise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box-header with-border">
            <h3 class="box-title">Circle Exercise</h3>

        </div>

    <asp:GridView ID="GridView1" runat="server" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="Program_ID" SortExpression="Program_ID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Program_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Program_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Exercises_ID" SortExpression="Exercises_ID" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Exercises_ID") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Exercises_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Circle Exercise">
            <ItemTemplate>
                <asp:DropDownList ID="circleExercise"  CssClass="form-control select2"  runat="server" AutoPostBack="true" ></asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Distinct [ProgramExercise].[Program_ID], [ProgramExercise].[Exercises_ID],[Exercises].[Name],MIN([ProgramExercise].[OrderExercise])  FROM [ProgramExercise],[Exercises] WHERE  [ProgramExercise].[Exercises_ID]=[Exercises].[Exercises_ID]  and ([Program_ID] = @Program_ID) GROUP BY [ProgramExercise].[Exercises_ID],[Exercises].[Name],[ProgramExercise].[Program_ID] ORDER BY MIN([ProgramExercise].[OrderExercise] ) ASC ">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Program_ID" SessionField="programID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="box-body">
        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                    <asp:Button ID="Button1" OnClick="Create" OnClientClick="return confirm('Are you sure you want to create?');" CssClass="btn btn-block btn-success" runat="server" Text="Create" />
                    <asp:Button ID="Button2" OnClick="CreateWithoutCircle" OnClientClick="return confirm('Are you sure you want to create without circle?');"  CssClass="btn btn-block btn-warning" runat="server" Text="Create Without Circle" />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
