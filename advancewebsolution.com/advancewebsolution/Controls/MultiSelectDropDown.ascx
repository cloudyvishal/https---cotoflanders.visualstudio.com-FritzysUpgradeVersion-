<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_MultiSelectDropDown" Codebehind="MultiSelectDropDown.ascx.cs" %>
<head>
    <title>MultiselectionDropdown</title>
</head>
<meta content="False" name="vs_snapToGrid">
<meta content="True" name="vs_showGrid">
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
<meta content="C#" name="CODE_LANGUAGE">
<meta content="JavaScript" name="vs_defaultClientScript">
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

<script language="javascript">
    function SelectedIndexChanged(ctlId) {
        var control = document.getElementById(ctlId + 'DDList');
        var strSelText = '';
        for (var i = 0; i < control.length; i++) {
            if (control.options[i].selected) {
                strSelText += control.options[i].text + ',';
            }
        }
        if (strSelText.length > 0)
            strSelText = strSelText.substring(0, strSelText.length - 1);
        var ddLabel = document.getElementById(ctlId + "DDLabel");
        ddLabel.innerHTML = strSelText;
        ddLabel.innerText = strSelText;
        ddLabel.title = strSelText;
    }

    function OpenListBox(ctlId) {
        var lstBox = document.getElementById(ctlId + "DDList");
        if (lstBox.style.visibility == "visible")
        { CloseListBox(ctlId); }
        else {
            lstBox.style.visibility = "visible";
            lstBox.style.height = "100px";
        }
    }

    function CloseListBox(ctlId) {
        var panel = document.getElementById(ctlId + "Panel2");
        var tabl = document.getElementById(ctlId + "Table2");
        var lstBox = document.getElementById(ctlId + "DDList");
        lstBox.style.visibility = "hidden";
        lstBox.style.height = "0px";
        panel.style.height = tabl.style.height;
    }
</script>

<asp:Panel ID="Panel2" Height="1px" runat="server" Width="160px" BackColor="White">
    <table id="Table2" style="table-layout: fixed; height: 24px" cellspacing="0" bordercolordark="#cccccc"
        cellpadding="0" width="100%" bordercolorlight="#7eb3e3" border="1" runat="server">
        <tr id="rowDD" style="height: 15px" runat="server">
            <td nowrap>
                <asp:Label ID="DDLabel" Style="cursor: default" runat="server" Width="134px" ToolTip=""
                    Font-Size="Smaller" Font-Names="Arial" BorderColor="Transparent" BorderStyle="None"
                    Height="15px"></asp:Label>
            </td>
            <td id="colDDImage" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
                padding-top: 0px; background-color: #7eb3e3" width="20" background="../Images/DDImage.bmp"
                runat="server">
            </td>
        </tr>
    </table>
    <div style="z-index: 9999; position: absolute">
        <asp:ListBox ID="DDList" Height="72px" runat="server" Width="100%" SelectionMode="Multiple">
        </asp:ListBox>
    </div>
</asp:Panel>
