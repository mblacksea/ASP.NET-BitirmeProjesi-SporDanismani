<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminDisplayAllDetails.aspx.cs" Inherits="BitirmeProjesi.AdminDisplayAllDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div runat="server" class="header">
            <h4 runat="server" id="detailProgramDesc" class="title"><asp:Label ID="Label100" runat="server" Text="Trainer General Details -> "></asp:Label> </h4>

        </div>
                <div class="row">
                    <div class="col-lg-3 col-sm-6">
                    
                    </div>
                    <div class="col-lg-3 col-sm-6">
                       
                    </div>
                      <div class="col-lg-3 col-sm-6">
                      
                            <div class="content">
                                <div class="row">
                                    

                                  

                                
                                    
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
                <div class="row">
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

                        
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select count(*) as Count,replace(convert(NVARCHAR, up.BuyDate, 104), ' ', '/') as buydate,cast(up.BuyDate as date) as buydate2 from UserProgram up where up.Program_ID in (select p.Program_ID from Program p where p.Trainer_ID=@Trainer_ID) group by up.BuyDate">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerDisplayID" Type="Int32" />
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

                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select sum(pr.ProgramPrice*cnt) as totalPrice,replace(convert(NVARCHAR, x.BuyDate, 104), ' ', '/') as buydate ,cast(x.BuyDate as date) as buydate2 from Program pr,(select COUNT(*) as cnt,up.BuyDate,up.Program_ID from UserProgram up where up.Program_ID in(select p.Program_ID from Program p where p.Trainer_ID=@Trainer_ID) group by up.BuyDate,up.Program_ID) x where pr.Program_ID=x.Program_ID group by x.BuyDate">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerDisplayID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                    </div>
                   
                    </div>
    
        <div class="row">
          
                    
        </div>

                </div>


</asp:Content>
