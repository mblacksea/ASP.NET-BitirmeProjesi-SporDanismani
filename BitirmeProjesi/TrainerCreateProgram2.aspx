<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerCreateProgram2.aspx.cs" Inherits="BitirmeProjesi.TrainerCreateProgram2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Create Program</h3>
        </div>
    </div>

    <asp:GridView ID="GridView1"  OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataKeyNames="Exercises_ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Exercises_ID" InsertVisible="False" SortExpression="Exercises_ID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Exercises_ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Exercises_ID") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Tittle" SortExpression="Tittle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Tittle") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Tittle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type Name" SortExpression="Type_Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Type_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Type_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Exercises_ID], [Name], [Tittle], [Description],[Type_Name] FROM [Exercises],[ExercisesType] WHERE [Exercises].[Type_ID]=[ExercisesType].[Type_ID]  and ([Trainer_ID] = @Trainer_ID)" >
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
     <div class="box-header with-border">
            <h3 class="box-title">Added Exercises</h3>
      </div>

    <asp:GridView ID="GridView2" runat="server" OnRowDeleting="OnRowDeleting"  CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
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
            <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="OrderExercise" SortExpression="OrderExercise">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OrderExercise") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>      
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("OrderExercise") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
      </asp:GridView>


      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [ProgramExercise] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ProgramExercise] ([Program_ID], [Exercises_ID]) VALUES (@Program_ID, @Exercises_ID)" SelectCommand="SELECT [Program_ID], [Exercises].[Exercises_ID], [ID],[Exercises].[Name],[ProgramExercise].[OrderExercise] FROM [ProgramExercise],[Exercises] WHERE [ProgramExercise].[Exercises_ID]=[Exercises].[Exercises_ID] and ([Program_ID] = @Program_ID)" UpdateCommand="UPDATE [ProgramExercise] SET [Program_ID] = @Program_ID, [Exercises_ID] = @Exercises_ID WHERE [ID] = @ID">
          <DeleteParameters>
              <asp:Parameter Name="ID" Type="Int32" />
          </DeleteParameters>
          <InsertParameters>
              <asp:Parameter Name="Program_ID" Type="Int32" />
              <asp:Parameter Name="Exercises_ID" Type="Int32" />
          </InsertParameters>
          <SelectParameters>
              <asp:SessionParameter DefaultValue="0" Name="Program_ID" SessionField="programID" Type="Int32" />
          </SelectParameters>
          <UpdateParameters>
              <asp:Parameter Name="Program_ID" Type="Int32" />
              <asp:Parameter Name="Exercises_ID" Type="Int32" />
              <asp:Parameter Name="ID" Type="Int32" />
          </UpdateParameters>
      </asp:SqlDataSource>
    <div class="col-md-3">
        <div class="form-group" id="nextStepButtonID" runat="server">
            <asp:Button ID="Button1" CssClass="btn btn-block btn-warning" OnClick="Next_Step" OnClientClick="return confirm('Are you sure you want to next?');" runat="server" Text="Next Step" />
        </div>

    </div>


    </asp:Content>
