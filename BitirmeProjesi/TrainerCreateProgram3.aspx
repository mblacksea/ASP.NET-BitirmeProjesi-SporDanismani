﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TrainerPanel.Master" AutoEventWireup="true" CodeBehind="TrainerCreateProgram3.aspx.cs" Inherits="BitirmeProjesi.TrainerCreateProgram3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Create Program</h3>

        </div>
        <!-- /.box-header -->
        <div class="box-body">
            <div class="row">
                <div class="col-md-6">
       
                       <div class="form-group" id="setnumberGroup" runat="server">
                        <label>Set Number</label>
                        <asp:TextBox ID="setNumber" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                      <br />
                        <asp:Button ID="Button2" OnClick="CreateSets" CssClass="btn btn-warning" runat="server" Text="Create Sets" />
                   
                         <asp:RequiredFieldValidator ID="reqsetNumber"
                            runat="server"
                            ControlToValidate="setNumber"
                            ErrorMessage="Set Number is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                         <asp:RangeValidator ID="RangeValidator1" SetFocusOnError="True" ForeColor="Red" ControlToValidate="setNumber" minimumvalue="1" maximumvalue="10" runat="server" ErrorMessage="Please enter value between 1-10" Type="Integer"></asp:RangeValidator>

                    </div>
                    <asp:Panel ID="Panel1" CssClass="form-group" runat="server">
                          <label>Repetition</label>
                         <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server"
                            ControlToValidate="TextBox1"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server"
                            ControlToValidate="TextBox2"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                            runat="server"
                            ControlToValidate="TextBox3"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                            runat="server"
                            ControlToValidate="TextBox4"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                            runat="server"
                            ControlToValidate="TextBox5"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                            runat="server"
                            ControlToValidate="TextBox6"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                            runat="server"
                            ControlToValidate="TextBox7"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                            runat="server"
                            ControlToValidate="TextBox8"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                            runat="server"
                            ControlToValidate="TextBox9"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                            runat="server"
                            ControlToValidate="TextBox10"
                            ErrorMessage="Repetetion is required!"
                            SetFocusOnError="True" ForeColor="Red" />

                    </asp:Panel>
                   <!-- <div class="form-group" id="repetitionGroup" runat="server">-->
                      
                   

                    <!--</div>-->
                       <asp:Panel ID="Panel2" CssClass="form-group" runat="server">
                          <label>Weight (kg)</label>
                         <asp:TextBox ID="TextBoxx1" CssClass="form-control" Text="0" runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx2" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx3" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx4" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx5" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx6" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx7" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx8" CssClass="form-control" Text="0" runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx9" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>
                              <br />
                         <asp:TextBox ID="TextBoxx10" CssClass="form-control" Text="0"  runat="server" TextMode="Number" ></asp:TextBox>

                    </asp:Panel>

                
                    <div class="form-group" id="timeGroup" runat="server">
                        <label>Time (minutes)</label>
                        <asp:TextBox ID="timeEx" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server"
                            ControlToValidate="timeEx"
                            ErrorMessage="Rest Time is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                        <asp:RangeValidator ID="RangeValidator4" SetFocusOnError="True" ForeColor="Red" ControlToValidate="timeEx" MinimumValue="0" MaximumValue="300" runat="server" ErrorMessage="Please enter value between 1-300" Type="Integer"></asp:RangeValidator>

                    </div>

                     <asp:Panel ID="Panel3" CssClass="form-group" runat="server">
                          <label>Rest (second)</label>
                         <asp:TextBox ID="TextBoxxx1" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server"
                            ControlToValidate="TextBoxxx1"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx2" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                            runat="server"
                            ControlToValidate="TextBoxxx2"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx3" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator14"
                            runat="server"
                            ControlToValidate="TextBoxxx3"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx4" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                            runat="server"
                            ControlToValidate="TextBoxxx4"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx5" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator16"
                            runat="server"
                            ControlToValidate="TextBoxxx5"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx6" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator17"
                            runat="server"
                            ControlToValidate="TextBoxxx6"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx7" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator18"
                            runat="server"
                            ControlToValidate="TextBoxxx7"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx8" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator19"
                            runat="server"
                            ControlToValidate="TextBoxxx8"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx9" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator20"
                            runat="server"
                            ControlToValidate="TextBoxxx9"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />
                              <br />
                         <asp:TextBox ID="TextBoxxx10" CssClass="form-control" runat="server" TextMode="Number" ></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator21"
                            runat="server"
                            ControlToValidate="TextBoxxx10"
                            ErrorMessage="Rest is required!"
                            SetFocusOnError="True" ForeColor="Red" />

                    </asp:Panel>


                 
                    
                      <div class="form-group">
                        <button type="button" runat="server" onserverclick="Add" class="btn btn-block btn-success">Add</button>
                     </div>

                    <div class="form-group">
                        <asp:Button ID="Button1" CssClass="btn btn-block btn-warning" OnClick="Publish" OnClientClick="return confirm('Are you sure you want to publish?');" runat="server" Text="Publish" />
                    </div>
               
                   
                   
                </div>
            </div>
        </div>
        </div>

</asp:Content>