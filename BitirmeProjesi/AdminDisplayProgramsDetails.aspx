<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminDisplayProgramsDetails.aspx.cs" Inherits="BitirmeProjesi.AdminDisplayProgramsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script src="Chart/Chart.js"></script>
     <link rel="stylesheet" href="/js/notifyit/notifIt.css" />
    <script src="/js/jquery-2.0.3.min.js"></script>
    <script src="/js/notifyit/notifIt.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div runat="server" class="header">
            <h4 runat="server" id="detailProgramDesc" class="title"><asp:Label ID="Label100" runat="server" Text=""></asp:Label> </h4>

        </div>
                <div class="row">
                    <div class="col-lg-3 col-sm-6">
                        <div class="card">
                            <div class="content">
                                <div class="row">
                                    <div class="col-xs-5">
                                        <div class="icon-big icon-warning text-center">
                                            <i class="ti-shopping-cart"></i>
                                        </div>
                                    </div>
                                    <div class="col-xs-7">
                                        <div class="numbers">
                                            <p>Total Sales</p>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 
                                        </div>
                                    </div>
                                </div>
                              
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-sm-6">
                        <div class="card">
                            <div class="content">
                                <div class="row">
                                    <div class="col-xs-5">
                                        <div class="icon-big icon-success text-center">
                                            <i class="ti-wallet"></i>
                                        </div>
                                    </div>
                                    <div class="col-xs-7">
                                        <div class="numbers">
                                            <p>Total Income</p>
                                          <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> 
                                        </div>
                                    </div>
                                </div>
                           
                            </div>
                        </div>
                    </div>
                      <div class="col-lg-3 col-sm-6">
                      
                            <div class="content">
                                <div class="row">
                                    <asp:Button ID="removeProgramBan" OnClick="RemoveProgramBan_ServerClick" OnClientClick="return confirm('Are you sure?'); " class="btn btn-danger btn-fill btn-wd" Text="Remove Program Ban" CausesValidation="false" runat="server" />

                                  

                                
                                    
                                </div>
                               
                            </div>
                        </div>
              
                   
                  
                </div>
        <div class="row">
             <div class="col-lg-5 col-sm-6">
                       
                            <div class="content">
                                <div class="row">
                                    <div class="form-group">
                                     &nbsp;&nbsp;&nbsp;   <label>Start</label>
                                        <asp:TextBox ID="DateStart" TextMode="Date" runat="server"></asp:TextBox>
                                  &nbsp;&nbsp;   &nbsp;   <label> End  </label>
                                        <asp:TextBox ID="DateEnd" TextMode="Date" runat="server"></asp:TextBox>
                                 &nbsp;&nbsp;  &nbsp;
                                        <asp:Button ID="search" OnClick="search_Click"  Text="Search" CssClass="btn btn-primary" CausesValidation="false" runat="server" />

                                    </div>
                                    
                                </div>
                            
                            </div>
                        
                    </div>
        </div>
                <div runat="server" id="chartRow" class="row">
                    <div class="col-md-3">
               
                        <asp:Chart ID="Chart1"  runat="server" DataSourceID="SqlDataSource1">
                            <Titles>
                                <asp:Title Text="Number of Sales"></asp:Title>
                            </Titles> 
                            <Series>
                            
                                <asp:Series Name="Series1" Color="#FF9933" XValueMember="buydate"  YValueMembers="Count" ChartType="StackedColumn" YValuesPerPoint="6" ShadowColor="#FFCC99" IsValueShownAsLabel="True" LabelForeColor="White" LabelBorderWidth="2" ShadowOffset="4"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea   Name="ChartArea1">
                                    <AxisY Title="Count">
                                    </AxisY>
                                    <AxisX Title="Date">
                                    </AxisX>
                                </asp:ChartArea>

                            </ChartAreas>
                         
                        </asp:Chart>

                        
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT  count([UserProgram].[BuyDate]) as Count,replace(convert(NVARCHAR, [UserProgram].[BuyDate], 104), ' ', '/') as buydate,cast([UserProgram].[BuyDate] as date) as buydate2 FROM [UserProgram] WHERE ([UserProgram].[Program_ID] = @Program_ID) group by [UserProgram].[BuyDate]">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="Program_ID" SessionField="displayProgramID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                    </div>

                    <div class="col-md-3">
                        <asp:Chart ID="Chart2" DataSourceID="SqlDataSource2" runat="server">
                              <Titles>
                                <asp:Title Text="Total Price"></asp:Title>
                            </Titles> 
                            <Series>
                                <asp:Series Name="Series1" Color="#FF9933" XValueMember="buydate"  YValueMembers="totalPrice" ChartType="StackedColumn" YValuesPerPoint="6" ShadowColor="#FFCC99" IsValueShownAsLabel="True" LabelForeColor="White" LabelBorderWidth="2" ShadowOffset="4"></asp:Series>
                            </Series>
                               <ChartAreas>
                                <asp:ChartArea   Name="ChartArea1">
                                    <AxisY Title="Total Price">
                                    </AxisY>
                                    <AxisX Title="Date">
                                    </AxisX>
                                </asp:ChartArea>

                            </ChartAreas>
                        </asp:Chart>

                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT  count([UserProgram].[BuyDate]) *(select p.ProgramPrice from Program p where p.Program_ID=[UserProgram].[Program_ID]) as totalPrice, replace(convert(NVARCHAR, [UserProgram].[BuyDate], 104), ' ', '/') as buydate,cast([UserProgram].[BuyDate] as date) as buydate2 FROM [UserProgram] WHERE ([UserProgram].[Program_ID] = @Program_ID) group by [UserProgram].[BuyDate],[UserProgram].[Program_ID] ">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="Program_ID" SessionField="displayProgramID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                    </div>
                   
                    </div>
    
        <div class="row">
            <br />
                   <div class="container-fluid">
                         <div runat="server" class="header">
            <h5 runat="server" id="H1" class="title"><asp:Label ID="Label5" runat="server" Text="Buyers"></asp:Label> </h5>

        </div>
                     <asp:GridView ID="GridView1" OnSelectedIndexChanged = "OnSelectedIndexChanged" CssClass= "table table-striped table-bordered table-condensed" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" Height="127px" AllowPaging="True" PageSize="3">
                         <Columns>
                                
                                 <asp:TemplateField ShowHeader="False">
                                     <ItemTemplate>
                                         <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label200" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="User_ID" SortExpression="User_ID" Visible="False">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("User_ID") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label2" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label3" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                               <asp:TemplateField HeaderText="Rating" SortExpression="Rating">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Rating") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label4" runat="server" Text='<%# Bind("Rating") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             <asp:TemplateField HeaderText="BuyDate" SortExpression="BuyDate">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("BuyDate","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="Label5" runat="server" Text='<%# Bind("BuyDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                   
                   </div>
                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select  u.Name+ ' ' +U.Surname  as UserName,u.User_ID ,r.Comment,r.Rating,up.BuyDate from Users u,UserProgram up left join Rating r on r.Program_ID=up.Program_ID and r.User_ID=up.User_ID where (up.Program_ID= @Program_ID) and u.User_ID = up.User_ID ">
                         <SelectParameters>
                             <asp:SessionParameter DefaultValue="0" Name="Program_ID" SessionField="displayProgramID" Type="Int32" />
                         </SelectParameters>
                     </asp:SqlDataSource>
        </div>

                </div>
         

</asp:Content>
