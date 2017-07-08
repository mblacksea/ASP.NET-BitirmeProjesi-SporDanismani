<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AdminDefaultPage.aspx.cs" Inherits="BitirmeProjesi.Deneme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content"
   <div class="container-fluid">
                <div class="row">
                  <div class="col-lg-3 col-sm-6">
                        <div class="card">
                            <div class="content">
                                <div class="row">
                                    <div class="col-xs-5">
                                        <div class="icon-big icon-warning text-center">
                                            <i class="ti-star"></i>
                                        </div>
                                    </div>
                                    <div class="col-xs-7">
                                        <div class="numbers">
                                            <p>Total Users</p>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> 
                                        </div>
                                    </div>
                                    <div class="footer">
                                        <hr>
                                        <div class="stats">
                                      <a href="AdminDisplayUsers.aspx" class="ti-angle-double-right">Show Details</a>
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
                                            <i class="ti-user"></i>
                                        </div>
                                    </div>
                                    <div class="col-xs-7">
                                        <div class="numbers">
                                            <p>Total Trainer</p>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> 
                                        </div>
                                    </div>
                                      <div class="footer">
                                        <hr>
                                        <div class="stats">
                               <a href="AdminDisplayTrainer.aspx" class="ti-angle-double-right">Show Details</a>
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
                                        <div class="icon-big icon-danger text-center">
                                            <i class="ti-shopping-cart"></i>
                                        </div>
                                    </div>
                                    <div class="col-xs-7">
                                        <div class="numbers">
                                            <p>Total Sales</p>
                                       <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label> 
                                        </div>
                                    </div>
                                      <div class="footer">
                                        <hr>
                                        <div class="stats">
                                   <a href="AdminDisplayGeneralDetails.aspx" class="ti-angle-double-right">Show Details</a>
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
                                        <div class="icon-big icon-info text-center">
                                            <i class="ti-money"></i>
                                        </div>
                                    </div>
                                    <div class="col-xs-7">
                                        <div class="numbers">
                                            <p>Total Income</p>
                                   <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> 
                                        </div>
                                    </div>
                                      <div class="footer">
                                        <hr>
                                        <div class="stats">
                    
                                            <a href="AdminDisplayGeneralDetails.aspx" class="ti-angle-double-right">Show Details</a>
                                        </div>
                                    </div>
                                </div>
                             
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">

                 
                </div>
                <div class="row">
                    <div class="col-md-6">
                  
                    </div>
                    <div class="col-md-6">
                      
                    </div>
                </div>
            </div>
   </div>
</asp:Content>
