<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerDisplayUsersGraphics.aspx.cs" Inherits="BitirmeProjesi.TrainerDisplayUsersGraphics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div runat="server" class="header">
            <h4 runat="server" id="detailProgramDesc" class="title">
                <asp:Label ID="Label100" runat="server" Text="Buyers -> Graphics -> "></asp:Label>
            </h4>

        </div>

        
  
      <div class="row">
          <div class="col-lg-5 col-sm-6">


              <div class="row">
                  <div class="form-group">
                      <label>Start</label>
                      <asp:TextBox ID="DateStart" TextMode="Date" runat="server"></asp:TextBox>
                      <label>End  </label>
                      <asp:TextBox ID="DateEnd" TextMode="Date" runat="server"></asp:TextBox>

                      <asp:Button ID="search" OnClick="search_Click" Text="Search" CssClass="btn btn-primary" CausesValidation="false" runat="server" />

                  </div>

              </div>



          </div>
        </div>
        
         


              <div class="row">
                 
                  <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
                        <Series>
                          <asp:Series Name="Series0" IsValueShownAsLabel="True" Color="#CC0099" ShadowColor="#FFCC99"  XValueMember="UserBodyRateDate" YValueMembers="Tall" ChartType="Spline" BorderWidth="6"></asp:Series>
                      </Series>
                        <ChartAreas>
                                <asp:ChartArea   Name="ChartArea100">
                                    <AxisY Title="Tall">
                                    </AxisY>
                                    <AxisX Title="Date">
                                    </AxisX>
                                </asp:ChartArea>

                            </ChartAreas>
                 
                    
                  </asp:Chart>
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [User_ID], [Tall], [Weight], [MuscleRate], [FatRate], [WaterRate], [UserBodyRateDate] FROM [UsersData] WHERE ([User_ID] = @User_ID) ORDER BY [UserBodyRateDate]">
                      <SelectParameters>
                          <asp:SessionParameter DefaultValue="0" Name="User_ID" SessionField="userDisplayGraphicsID" Type="Int32" />
                      </SelectParameters>
                  </asp:SqlDataSource>

                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1">
                       
                      <Series>
                          <asp:Series Name="Series1" IsValueShownAsLabel="True" Color="#009933" ShadowColor="#FFCC99"  XValueMember="UserBodyRateDate" YValueMembers="Weight" ChartType="Spline" BorderWidth="6"></asp:Series>
                      </Series>
                           <ChartAreas>
                                <asp:ChartArea   Name="ChartArea100">
                                    <AxisY Title="Weight">
                                    </AxisY>
                                    <AxisX Title="Date">
                                    </AxisX>
                                </asp:ChartArea>

                            </ChartAreas>
                      
                  </asp:Chart>
              
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource1">
                      
                      <Series>
                          <asp:Series Name="Series2" IsValueShownAsLabel="True" XValueMember="UserBodyRateDate" YValueMembers="MuscleRate" BorderWidth="6" ChartType="Spline" Color="Blue"></asp:Series>
                      </Series>
                     <ChartAreas>
                                <asp:ChartArea   Name="ChartArea100">
                                    <AxisY Title="MuscleRate">
                                    </AxisY>
                                    <AxisX Title="Date">
                                    </AxisX>
                                </asp:ChartArea>

                            </ChartAreas>
                    
                  </asp:Chart>
             
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource1">
                 
                      <Series>
                          <asp:Series Name="Series3" IsValueShownAsLabel="True" XValueMember="UserBodyRateDate" YValueMembers="FatRate" BorderWidth="6" ChartType="Spline" Color="Red"></asp:Series>
                      </Series>
                       <ChartAreas>
                                <asp:ChartArea   Name="ChartArea100">
                                    <AxisY Title="FatRate">
                                    </AxisY>
                                    <AxisX Title="Date">
                                    </AxisX>
                                </asp:ChartArea>

                            </ChartAreas>
                  </asp:Chart>
     

                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       <asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource1">
                        <Series>
                          <asp:Series Name="Series0" IsValueShownAsLabel="True" Color="#FF6600" ShadowColor="#FFCC99"  XValueMember="UserBodyRateDate" YValueMembers="WaterRate" ChartType="Spline" BorderWidth="6"></asp:Series>
                      </Series>
                        <ChartAreas>
                                <asp:ChartArea   Name="ChartArea100">
                                    <AxisY Title="WaterRate">
                                    </AxisY>
                                    <AxisX Title="Date">
                                    </AxisX>
                                </asp:ChartArea>

                            </ChartAreas>
                 
                    
                  </asp:Chart>
             

              </div>

        <br />

           <div class="row">
               <asp:GridView ID="GridView1" runat="server" CssClass= "table table-striped table-bordered table-condensed" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                   <Columns>
                       <asp:BoundField DataField="User_ID" Visible="false" HeaderText="User_ID" SortExpression="User_ID" />
                       <asp:BoundField DataField="Tall" HeaderText="Tall" SortExpression="Tall" />
                       <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" />
                       <asp:BoundField DataField="MuscleRate" HeaderText="MuscleRate" SortExpression="MuscleRate" />
                       <asp:BoundField DataField="FatRate" HeaderText="FatRate" SortExpression="FatRate" />
                       <asp:BoundField DataField="WaterRate" HeaderText="WaterRate" SortExpression="WaterRate" />
                       <asp:TemplateField HeaderText="UserBodyRateDate" SortExpression="UserBodyRateDate">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserBodyRateDate","{0:dd/MM/yyyy}") %>'></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Bind("UserBodyRateDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
               </asp:GridView>
           </div>
     


    </div>

</asp:Content>
