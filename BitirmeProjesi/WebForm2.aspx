<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="BitirmeProjesi.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script type="text/javascript">
    $(function ($) {
        $("[id*=gvLocations]").sortable({
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

    <div>
    
      
        <asp:GridView ID="gvLocations" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Siralama" ItemStyle-Width="30">
                    <ItemTemplate>
                        <%# Eval("Siralama") %>
                        <input type="hidden" name="Siralama" value='<%# Eval("Siralama") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Type_ID" HeaderText="Type_ID" ItemStyle-Width="150" />
                <asp:BoundField DataField="Type_Name" HeaderText="Type_Name" ItemStyle-Width="100" />
                  <asp:BoundField DataField="Siralama" HeaderText="Siralama" ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>
<br />
        <asp:Button Text="Update Preference" runat="server" OnClick="UpdatePreference" />




    </div>




</asp:Content>
