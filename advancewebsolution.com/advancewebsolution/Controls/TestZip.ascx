<%@ Control Language="C#" AutoEventWireup="true" Inherits="Controls_TestZip" Codebehind="TestZip.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript" >
    function ValidateCharZip(source, args) {
        var iChars = "#()[]{}<>";
        var str = args.Value;
        for (var i = 0; i < str.length; i++) {
            if (iChars.indexOf(str.charAt(i)) != -1) {
                args.IsValid = false;
            }
        }

    }

    function FormPanel_FireDefaultButtonZip(event, target) {
        if ((event.keyCode == 13 || event.which == 13) && !(event.srcElement && (event.srcElement.tagName.toLowerCase() == 'textarea'))) {

            var defaultButton = document.getElementById(target);

            if (defaultButton == 'undefined') defaultButton = document.all[target];

            if (defaultButton && typeof (defaultButton.click) != 'undefined') {

                defaultButton.click();
                event.cancelBubble = true;
                if (event.stopPropagation) event.stopPropagation();
                return false;
            }
        }
        return true;
    }
    function ClearZip() {
        document.getElementById('<%=txtZip.ClientID %>').value = "Zip code";
        return false;
    }
    function SetZipText() {
        if (document.getElementById('<%=txtZip.ClientID %>').value == "Zip code") {
            document.getElementById('<%=txtZip.ClientID %>').value = "";
        }
    }
</script>


<div class="locationServiced" onkeypress="javascript:return FormPanel_FireDefaultButtonZip(event,'ctl00_ContentPlaceHolder1_ctlZipcode_imgZipcode')">
    <div class="zipcode">
        <asp:TextBox ID="txtZip" runat="server" CssClass="textfieldZip" Height="15px" OnClick="return SetZipText();"
            OnFocus="return SetZipText();" MaxLength="5"></asp:TextBox>
        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtZip"
            WatermarkText="    Zip Code" WatermarkCssClass="watermarked" />
        <asp:RequiredFieldValidator ID="reqContactZip" runat="server" ValidationGroup="valZip"
            SetFocusOnError="true" ControlToValidate="txtZip" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Zipcode is required.">  
        </asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender runat="Server" ID="valContactFname" Enabled="true"
            TargetControlID="reqContactZip" HighlightCssClass="validatorCalloutHighlight" />
        <asp:CustomValidator runat="server" ID="custSpChar" ValidationGroup="valZip" ControlToValidate="txtZip"
            Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateCharZip"
            ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
        <cc1:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
        <asp:RegularExpressionValidator ID="RegValZip" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct zipcode ."
            ValidationGroup="valZip" SetFocusOnError="true" ControlToValidate="txtZip" ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender49" TargetControlID="RegValZip"
            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
    </div>
    <div>
        <asp:ImageButton ID="imgZipcode" runat="server" CssClass="gobtn" ImageUrl="~/images/btn_go.gif"  ValidationGroup="valZip" AlternateText="Go" ToolTip="Go" OnClick="imgZipcode_Click" />
    </div>
    <div style="display: none">
        <asp:Button ID="btnTest" runat="server" Text="tset" />
    </div>
</div>
<cc1:ModalPopupExtender ID="ModelZip" runat="server" TargetControlID="btnTest" PopupControlID="PanelFiveImg"  BackgroundCssClass="modalBackground" CancelControlID="imgClose" OnCancelScript="ClearZip()">
</cc1:ModalPopupExtender>
<asp:Panel Style="display: none" ID="PanelFiveImg" runat="server" CssClass="zipPopupDiv">
    <table class="zipmodalPopup" border="0">
        <tbody>
            <tr>
                <td align="right">
                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="~/Images/closeImgButton.jpg" />
                </td>
            </tr>
            <tr>
                <td style="height: 38px" align="right">
                    <div id="div3" class="zippopupInnerDiv">
                        <table width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <h5> <asp:Label ID="lblZipcode" runat="server"></asp:Label></h5>
                                        <asp:Label ID="lblShow" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSumbmit" Text="OK" ToolTip="OK" CssClass="btnBg" runat="server"  OnClick="btnSumbmit_Click" />
                                        <asp:Button Visible="false" ID="cancelflUploadThumb" CssClass="btnBg" runat="server"  CausesValidation="false" Text="Cancel" ToolTip="Cancel"></asp:Button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Panel>
