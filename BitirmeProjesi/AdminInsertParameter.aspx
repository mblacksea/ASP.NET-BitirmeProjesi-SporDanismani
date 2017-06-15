<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminInsertParameter.aspx.cs" Inherits="BitirmeProjesi.AdminInsertParameter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-sm-6">
           <div class="header">
                                <h4 class="title">Insert Parameters</h4>
                                
                            </div>
                        <div class="card">
                          
                            <div class="content">
                                <div class="row">
                                    
                                    <div class="col-xs-12">
                                         <asp:DropDownList ID="DropDownList1" AutoPostBack="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="footer">
                                    <hr>
                                  
                                </div>
                            </div>
                        </div>
                    </div>


    <div id="FirstGridview" runat="server" class="col-md-12">
        <div class="card">
            <div class="header">
                <h4 class="title">Users Behavior</h4>
            
            </div>
            <div class="content">
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged1" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="ProgramDiff_ID" DataSourceID="SqlDataSource3" >
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete?'); " CommandName="Select" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProgramDiff_ID" InsertVisible="False" SortExpression="ProgramDiff_ID" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProgramDiff_ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProgramDiff_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProgramDiff_Name" SortExpression="ProgramDiff_Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProgramDiff_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProgramDiff_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [ProgramDifficulty] WHERE [ProgramDiff_ID] = @ProgramDiff_ID" InsertCommand="INSERT INTO [ProgramDifficulty] ([ProgramDiff_Name]) VALUES (@ProgramDiff_Name)" SelectCommand="SELECT * FROM [ProgramDifficulty]" UpdateCommand="UPDATE [ProgramDifficulty] SET [ProgramDiff_Name] = @ProgramDiff_Name WHERE [ProgramDiff_ID] = @ProgramDiff_ID">
                    <DeleteParameters>
                        <asp:Parameter Name="ProgramDiff_ID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProgramDiff_Name" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProgramDiff_Name" Type="String" />
                        <asp:Parameter Name="ProgramDiff_ID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>


        </div>


    </div>


    
      
    <div id="SecondGridview" runat="server" class="col-md-12">
        <div class="card">
            <div class="header">
                <h4 class="title">Users Behavior</h4>

            </div>
            <div class="content">
                <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged = "OnSelectedIndexChanged2" CssClass="table table-striped table-bordered table-condensed" AutoGenerateColumns="False" DataKeyNames="ProgramSpec_ID" DataSourceID="SqlDataSource2">
                    <Columns>
                        
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClientClick="return confirm('Are you sure you want to delete?'); " CommandName="Select" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProgramSpec_ID" InsertVisible="False" SortExpression="ProgramSpec_ID" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProgramSpec_ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProgramSpec_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ProgramSpec_Name" SortExpression="ProgramSpec_Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProgramSpec_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProgramSpec_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>


        </div>


    </div>

        <div  id="textID" runat="server" class="col-lg-3 col-sm-6">
                        <div class="card">
                            <div class="content">
                                <div class="row">
                                    
                                    <div  class="col-xs-12">
                                          <asp:TextBox ID="TextBox1" placeHolder="" CssClass="form-control border-input" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="tittleValidator"
                            runat="server"
                            ControlToValidate="TextBox1"
                            ErrorMessage="This field is required!"
                            SetFocusOnError="True" ForeColor="Red" /> 
                                        <br>

                                        </br>
                                         <asp:Button ID="Button1" OnClick="Button1_Click"  CssClass="btn btn-block btn-success" runat="server" Text="Add New Item" />
                                    </div>
                                </div>
                                <div class="footer">
                                    <hr>
                                  
                                </div>
                            </div>
                        </div>
                    </div>

   

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [ProgramSpec] WHERE [ProgramSpec_ID] = @ProgramSpec_ID" InsertCommand="INSERT INTO [ProgramSpec] ([ProgramSpec_Name]) VALUES (@ProgramSpec_Name)" SelectCommand="SELECT * FROM [ProgramSpec]" UpdateCommand="UPDATE [ProgramSpec] SET [ProgramSpec_Name] = @ProgramSpec_Name WHERE [ProgramSpec_ID] = @ProgramSpec_ID">
        <DeleteParameters>
            <asp:Parameter Name="ProgramSpec_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProgramSpec_Name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProgramSpec_Name" Type="String" />
            <asp:Parameter Name="ProgramSpec_ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [ProgramDifficulty] WHERE [ProgramDiff_ID] = @ProgramDiff_ID" InsertCommand="INSERT INTO [ProgramDifficulty] ([ProgramDiff_Name]) VALUES (@ProgramDiff_Name)" SelectCommand="SELECT * FROM [ProgramDifficulty]" UpdateCommand="UPDATE [ProgramDifficulty] SET [ProgramDiff_Name] = @ProgramDiff_Name WHERE [ProgramDiff_ID] = @ProgramDiff_ID">
        <DeleteParameters>
            <asp:Parameter Name="ProgramDiff_ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ProgramDiff_Name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProgramDiff_Name" Type="String" />
            <asp:Parameter Name="ProgramDiff_ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>






   

                        
                   




</asp:Content>
