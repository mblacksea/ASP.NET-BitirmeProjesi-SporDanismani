<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerDefaultPage.aspx.cs" Inherits="BitirmeProjesi.TrainerPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
    <link href="js/notifyit/notifIt.css" rel="stylesheet" />
    <script src="js/notifyit/notifIt.js"></script>
    <script src="js/jquery-2.0.3.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
                <a href="TrainerGraphicsDetails.aspx" class="small-box-footer">Show Details <i class="fa fa-arrow-circle-right"></i></a>
      
          </div>
        </div>
        <!-- ./col -->
           <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red">
            <div class="inner">
             <h3> <asp:Label ID="Label2" Text="" runat="server"></asp:Label> </h3>

              <p>Total Income</p>
            </div>
            <div class="icon">
              <i class="ion ion-bag"></i>
            </div>
                <a href="TrainerGraphicsDetails.aspx" class="small-box-footer">Show Details <i class="fa fa-arrow-circle-right"></i></a>
      
          </div>
        </div>
        <!-- ./col -->
 
        <!-- ./col -->
      </div>
 
    
</asp:Content>
