<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerMyPrograms.aspx.cs" Inherits="BitirmeProjesi.TrainerMyPrograms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">My Programs</h3>
            
        </div>
    </div>


    <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="Program_ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClick="MyButtonClick" runat="server" OnClientClick="return confirm('Are you sure you want to delete?'); " CausesValidation="false" CommandName="" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ProgramTittle" HeaderText="Program Tittle" SortExpression="ProgramTittle" />
            <asp:BoundField DataField="Trainer_ID" HeaderText="Trainer_ID" SortExpression="Trainer_ID" Visible="False" />
            <asp:BoundField DataField="ProgramDiff_Name" HeaderText="Program Difficulty" SortExpression="ProgramDiff_Name" />
            <asp:BoundField DataField="ProgramSpec_Name" HeaderText="Program Spec" SortExpression="ProgramSpec_Name" />
            <asp:BoundField DataField="Trainer_ID" HeaderText="Trainer_ID" SortExpression="Trainer_ID" Visible="False" />
            <asp:TemplateField HeaderText="Program_ID" InsertVisible="False" SortExpression="Program_ID" Visible="False">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Program_ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Program_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="" SelectCommand="SELECT [ProgramTittle], [ProgramDifficulty].[ProgramDiff_Name], [ProgramSpec].[ProgramSpec_Name], [Trainer_ID], [Program_ID] FROM [Program],[ProgramSpec],[ProgramDifficulty] WHERE [ProgramDifficulty].[ProgramDiff_ID] = [Program].[ProgramDiff_ID] and [ProgramSpec].[ProgramSpec_ID]=[Program].[ProgramSpec_ID] and ([Trainer_ID] = @Trainer_ID)">
        
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


</asp:Content>
