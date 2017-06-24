<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerMyExercises.aspx.cs" Inherits="BitirmeProjesi.TrainerMyExercises" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  


    <div class="col-lg-8 col-sm-8">

        <div class="row">
            <!-- left column -->
            <div class="col-md-5">
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">My Exercise</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                    <div class="box-body">
                        <div class="form-group">
                            <label>Search</label>
                            <asp:DropDownList CssClass="form-control select2" ID="DropDownList1" runat="server">
                                <asp:ListItem>Name</asp:ListItem>
                                <asp:ListItem>Tittle</asp:ListItem>
                                <asp:ListItem>Type_Name</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="textField" placeHolder="SearchQuery" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>




                    </div>
                    <div class="box-footer">
                        <button type="button" runat="server" onserverclick="searchButton" class="btn btn-primary">Search</button>
                    </div>
                </div>
            </div>
        </div>

    </div>





    <asp:GridView ID="GridView1" OnSelectedIndexChanged = "OnSelectedIndexChanged"  CssClass= "table table-striped table-bordered table-condensed"  runat="server" DataSourceID="SqlDataSource1" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Exercises_ID" AllowSorting="True">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                        <asp:LinkButton ID="Button3" runat="server" OnClientClick="return confirm('Are you sure you want to delete?'); " OnClick="Button3_Click" CausesValidation="False"  Text="Delete" />

                   
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
                    <asp:TextBox ID="TextBox3"  runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type Name" SortExpression="Type_Name">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Type_Name") %>'></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Type_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" InsertCommand="INSERT INTO [Exercises] ([Name], [Tittle], [Description]) VALUES (@Name, @Tittle, @Description)" SelectCommand="SELECT [Exercises_ID], [Name], [Tittle], [Description],[Type_Name] FROM [Exercises],[ExercisesType] WHERE [Exercises].[Type_ID]=[ExercisesType].[Type_ID]  and ([Trainer_ID] = @Trainer_ID)" UpdateCommand="UPDATE [Exercises] SET [Name] = @Name, [Tittle] = @Tittle, [Description] = @Description WHERE [Exercises_ID] = @Exercises_ID">
        <DeleteParameters>
            <asp:Parameter Name="Exercises_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Tittle" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerID" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Tittle" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Exercises_ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>



</asp:Content>
