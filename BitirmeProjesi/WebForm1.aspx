<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BitirmeProjesi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/themes/smoothness/jquery-ui.css" />
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.24/jquery-ui.min.js"></script>
<script type="text/javascript">
    jQuery(function () {
        jQuery("[id*=gvLocations]").sortable({
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
                jQuery(this).find("tbody").append(ui.item);
            }
        });
    });
</script>


</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
