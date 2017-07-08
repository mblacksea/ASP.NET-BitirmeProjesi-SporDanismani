<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerGraphicsDetails.aspx.cs" Inherits="BitirmeProjesi.TrainerGraphicsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="/js/notifyit/notifIt.css" />
    <script src="/js/jquery-2.0.3.min.js"></script>
    <script src="/js/notifyit/notifIt.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div runat="server" class="header">
            <h4 runat="server" id="detailProgramDesc" class="title"><asp:Label ID="Label100" runat="server" Text="All Programs Graphics"></asp:Label> </h4>

        </div>
               <div class="row">
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow">
            <div class="inner">
              <h3> <asp:Label ID="Label1" Text="" runat="server"></asp:Label> </h3>

              <p>Total Program Sales</p>
            </div>
            <div class="icon">
              <i class="ion ion-pie-graph"></i>
            </div>
      
          </div>
        </div>
        <!-- ./col -->
           <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red">
            <div class="inner">
             <h3><asp:Label ID="Label2" Text="" runat="server"></asp:Label> </h3>

              <p>Total Income</p>
            </div>
            <div class="icon">
              <i class="ion ion-bag"></i>
            </div>
      
          </div>
        </div>
        <!-- ./col -->
 
        <!-- ./col -->
      </div>
        <div class="row">
             <div class="col-lg-5 col-sm-6">
                       
                         
                                <div class="row">
                                    <div class="form-group">
                                       <label>Start</label>
                                        <asp:TextBox ID="DateStart" TextMode="Date" runat="server"></asp:TextBox>
                                  <label> End  </label>
                                        <asp:TextBox ID="DateEnd" TextMode="Date" runat="server"></asp:TextBox>
                              
                                        <asp:Button ID="search"  OnClick="search_Click" Text="Search" CssClass="btn btn-primary" CausesValidation="false" runat="server" />

                                    </div>
                                    
                                </div>
                            
                
                        
                    </div>
        </div>
                <div runat="server" id="chartRow" class="row">
                    <div class="col-md-3">
               
                        <asp:Chart ID="Chart1" DataSourceID="SqlDataSource1"  runat="server">
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
                                <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select sum(pr.ProgramPrice*cnt) as totalPrice,replace(convert(NVARCHAR, x.BuyDate, 104), ' ', '/') as buydate ,cast(x.BuyDate as date) as buydate2 from Program pr,(select COUNT(*) as cnt,up.BuyDate,up.Program_ID from UserProgram up where up.Program_ID in(select p.Program_ID from Program p where p.Trainer_ID=@Trainer_ID) group by up.BuyDate,up.Program_ID) x where pr.Program_ID=x.Program_ID group by x.BuyDate">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="Trainer_ID" SessionField="trainerID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>

                    </div>

                    <div class="col-md-3">
                        <asp:Chart ID="Chart2" DataSourceID="SqlDataSource2"  runat="server">
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

                    

                    </div>
                   
                    </div>
    
   

                </div>
         



</asp:Content>
