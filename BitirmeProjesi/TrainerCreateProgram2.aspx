<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerCreateProgram2.aspx.cs" Inherits="BitirmeProjesi.TrainerCreateProgram2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function ($) {
            $("[id*=GridView2]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'pointer',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <!-- left column -->
        <div class="col-md-3">
            <!-- general form elements -->
         
                <div class="box-header with-border">
                    <h3  id="header" runat="server"  class="box-title">Select Exercise --> </h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->

                <div id="searchBox" runat="server" class="box-body">
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
                      <div class="box-footer">
       
                         <button type="button" runat="server"  onserverclick="searchButton" class="btn btn-primary">Search</button> 
                    </div>
         
                </div>
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

    <asp:GridView ID="GridView2" runat="server"  OnRowDataBound="gvMaint_RowDataBound"   CssClass= "table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" ToolTip="You can re-order added exercises with drag and drop">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButtonUpdate"  runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButtonCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonEdit"  runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete?'); " CommandName="Delete" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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
            <asp:TemplateField HeaderText="Name"  >
              
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="OrderExercise" SortExpression="OrderExercise">
               
                <ItemTemplate>     
                          <%# Eval("OrderExercise") %>
                        <input type="hidden" name="Siralama" value='<%# Eval("OrderExercise") %>' />
                </ItemTemplate>
            </asp:TemplateField>



              <asp:TemplateField HeaderText="SetNumber" SortExpression="SetNumber">
                
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("SetNumber") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


              <asp:TemplateField HeaderText="Repeat" SortExpression="Repeat">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxRepeat" runat="server" Text='<%# Bind("Repeat") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Repeat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Weight" SortExpression="Weight">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxWeight" runat="server" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="RestTime" SortExpression="RestTime">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxRestTime" runat="server" Text='<%# Bind("RestTime") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("RestTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="ExerciseTime" SortExpression="ExerciseTime">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxExerciseTime" runat="server" Text='<%# Bind("ExerciseTime") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("ExerciseTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>




          
        </Columns>
      </asp:GridView>
    <br />
       <div class="col-md-3">
        <div class="form-group" id="nextStepButtonID" runat="server">
            <asp:Button ID="Button1" CssClass="btn btn-block btn-warning" OnClick="Next_Step"  runat="server" Text="Next Step" />
        </div>

    </div>

     <div class="col-md-3">
        <asp:Button Text="ReOrder" ID="ReOrder" CssClass="btn btn-block btn-success" runat="server" OnClick="UpdatePreference" ToolTip="You can re-order added exercises with drag and drop" />
         </div>

      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [ProgramExercise] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ProgramExercise] ([Program_ID], [Exercises_ID]) VALUES (@Program_ID, @Exercises_ID)" SelectCommand="SELECT [Program_ID], [Exercises].[Exercises_ID], [ID],[Exercises].[Name],[ProgramExercise].[OrderExercise],[ProgramExercise].[SetSayisi] as SetNumber,[ProgramExercise].[TekrarSayisi] as Repeat, [ProgramExercise].[Agirlik] as Weight,[ProgramExercise].[RestTime] as RestTime,[ProgramExercise].[ExerciseTime] as ExerciseTime FROM [ProgramExercise],[Exercises] WHERE [ProgramExercise].[Exercises_ID]=[Exercises].[Exercises_ID] and ([Program_ID] = @Program_ID) ORDER BY OrderExercise " UpdateCommand="UPDATE [ProgramExercise] SET [TekrarSayisi] = @Repeat, [Agirlik] = @Weight,[RestTime]=@RestTime,[ExerciseTime]=@ExerciseTime WHERE [ID] = @ID">
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

 


    </asp:Content>
