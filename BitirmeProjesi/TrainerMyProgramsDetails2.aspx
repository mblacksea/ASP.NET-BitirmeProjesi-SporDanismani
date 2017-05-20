<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerMyProgramsDetails2.aspx.cs" Inherits="BitirmeProjesi.TrainerMyProgramsDetails2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="GridView1" runat="server" CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Program_ID" HeaderText="Program_ID" SortExpression="Program_ID" />
            <asp:BoundField DataField="Exercises_ID" HeaderText="Exercises_ID" SortExpression="Exercises_ID" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Program_ID], [ProgramExercise].[Exercises_ID], [ID],[Name] FROM [ProgramExercise],[Exercises] WHERE [ProgramExercise].[Exercises_ID]=[Exercises].[Exercises_ID]  and ([Program_ID] = @Program_ID)">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Program_ID" SessionField="updateProgramID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
