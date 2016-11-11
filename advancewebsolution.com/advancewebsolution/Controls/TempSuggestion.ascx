<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_TempSuggestion" Codebehind="TempSuggestion.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<script type="text/javascript" src="../Scripts/phone_validation.js"></script>

<script type="text/javascript" src="../Scripts/Validation.js"></script>

<script type="text/javascript" language="javascript">
    function checkTextAreaMaxLength(textBox, e, length) {
        var mLen = textBox["MaxLength"];
        if (null == mLen)
            mLen = length;
        var maxLength = parseInt(mLen);
        if (!checkSpecialKeys(e)) {
            if (textBox.value.length > maxLength - 1) {
                if (window.event)//IE
                    e.returnValue = false;
                else//Firefox
                    e.preventDefault();
            }
        }
    }
    function checkSpecialKeys(e) {
        if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
            return false;
        else
            return true;
    }
    function Specialchar() {
        var iChars = "#{}<>()";

        for (var i = 0; i < document.formname.fieldname.value.length; i++) {
            if (iChars.indexOf(document.formname.fieldname.value.charAt(i)) != -1) {
                alert("Your username has special characters. \nThese are not allowed.\n Please remove them and try again.");
                return false;
            }
        }
    }


    function ValidateSpecialChar(Str) {
        var iChars = "#{}<>()";
        for (var i = 0; i < Str.length; i++) {
            if (iChars.indexOf(Str.charAt(i)) != -1) {
                return false;
            }
        }
    }
    function ValidateChar(source, arguments) {
        var iChars = "#{}<>()";
        var str = arguments.Value;
        for (var i = 0; i < str.length; i++) {
            if (iChars.indexOf(str.charAt(i)) != -1) {
                arguments.IsValid = false;
            }
        }
    }

    function ValidateChar1(source, arguments) {

        var iChars = "#{}<>()";
        var str = arguments.Value;
        for (var i = 0; i < str.length; i++) {
            if (iChars.indexOf(str.charAt(i)) != -1) {
                arguments.IsValid = false;
            }
        }
    }
    function CleareText() {

        //document.getElementById('<%=PanelFiveImg.ClientID %>').style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_ctlSuggestion_txtName").value = "*Name";
        document.getElementById('<%=txtEmail.ClientID %>').value = "*Email";
        document.getElementById('<%=txtPhone.ClientID %>').value = "Phone";
        document.getElementById('<%=txtComment.ClientID %>').value = "*Comment";
        document.getElementById('<%=PanelFiveImg.ClientID %>').style.display = "none";
        return false;
    }
    function SetName() {
        if (document.getElementById("ctl00_ContentPlaceHolder1_ctlSuggestion_txtName").value == "*Name") {
            document.getElementById("ctl00_ContentPlaceHolder1_ctlSuggestion_txtName").value = "";
        }
    }
    function SetEmail() {
        if (document.getElementById('<%=txtEmail.ClientID %>').value == "*Email") {
            document.getElementById('<%=txtEmail.ClientID %>').value = "";
        }
    }
    function SetPhone() {
        if (document.getElementById('<%=txtPhone.ClientID %>').value == "Phone") {
            document.getElementById('<%=txtPhone.ClientID %>').value = "";
        }
    }
    function SetComment() {
        if (document.getElementById('<%=txtComment.ClientID %>').value == "*Comment") {
            document.getElementById('<%=txtComment.ClientID %>').value = "";
        }
    }
</script>

<style type="text/css">
    .modalBackground
    {
        background-color: Gray;
        filter: alpha(opacity=70);
        opacity: 0.7;
    }
    .modalPopup
    {
        background-color: #f5f5f5;
        border-width: 3px;
        border-style: solid;
        border-color: #827B60;
        padding: 3px;
        height: 0 auto;
        font-family: Thomba;
        font-size: 10pt;
    }
</style>
<%--This control will countain Suggestion image button
and text box for zip code 
on clicking on suggestion button it will validation text box 
1. Numerice value 
2. empty text box 
on clicking it will open a Ajax model popup.
and show whether we are working in this area or not --%>
<%--Region suggestion  start--%>
<%--<div class="img">
    <div class="sugesstionBox">
        <div class="sugesstionBox">
            <asp:ImageButton ID="btnSuggestion" runat="server"  CausesValidation="false" ToolTip="SUGGESTION BOX"  />
        </div>
    </div>
</div>--%>
<a id="linkBlog" title="Fritzy's pet care pros : Blog" runat="server" style="cursor: pointer;">
    Blog</a>
<%--Region suggestion  end--%>
<%-- Region Modelpopup Start--%>
<cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID="linkBlog"
    PopupControlID="PanelFiveImg" BackgroundCssClass="modalBackground" CancelControlID="closewindow"
    OnCancelScript="CleareText()">
</cc1:ModalPopupExtender>
<asp:Panel Style="display: none" ID="PanelFiveImg" runat="server">
    <div style="border: 2px solid #6d5c45;">
        <div id="suggestionpopup">
            <div class="popupleft">
                <asp:Image ID="popupimg" ImageUrl="~/Images/popupImg.jpg" runat="server" AlternateText=" " /></div>
            <div class="popupright">
                <table width="100%" border="0">
                    <tbody>
                        <tr>
                            <td align="left">
                                <div id="divsuggestn">
                                    <table width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td class="closewindow">
                                                    <asp:ImageButton ID="closewindow" ImageUrl="~/Images/closeImg.jpg" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="suggestionboxheader" ImageUrl="~/Images/suggestionBoxHeader.jpg" runat="server"
                                                        AlternateText=" " />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span>We appreciate your input</span>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtName" CssClass="textField" runat="server" Text="" MaxLength="30"
                                                        ValidationGroup="ValTempSuggestion" OnFocus="SetName();" OnClick="SetName();"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtName"
                                                        WatermarkText="Name*" WatermarkCssClass="textField" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="txtName" Display="None" ValidationGroup="ValTempSuggestion"
                                                        ErrorMessage="<b>Required Field Missing</b><br />Name is required.">  
                                                    </asp:RequiredFieldValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                                                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                                        Enabled="true" />
                                                    <asp:CustomValidator runat="server" ID="custSpChar" ValidationGroup="ValTempSuggestion"
                                                        ControlToValidate="txtName" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateChar"
                                                        ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
                                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textField" MaxLength="30" ValidationGroup="ValTempSuggestion"
                                                        OnFocus="return SetEmail();" OnClick="return SetEmail();"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtEmail"
                                                        WatermarkText="Email*" WatermarkCssClass="textField" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                                                        Display="None" ValidationGroup="ValTempSuggestion" ErrorMessage="<b>Required Field Missing</b><br />Email is required."
                                                        SetFocusOnError="true">  
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                                                        ValidationGroup="ValTempSuggestion" SetFocusOnError="true" ControlToValidate="txtEmail"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                    </asp:RegularExpressionValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                                        TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight"
                                                        Enabled="true" />
                                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                                        TargetControlID="revEmail" Enabled="true" HighlightCssClass="validatorCalloutHighlight" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="textField" MaxLength="15" onkeydown="javascript:backspacerDOWN(this,event);"
                                                        onkeyup="javascript:backspacerUP(this,event);" OnFocus="return SetPhone();" OnClick="return SetPhone();"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtPhone"
                                                        WatermarkText="Phone" WatermarkCssClass="textField" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox Rows="5" Columns="20" CssClass="textArea" ValidationGroup="ValTempSuggestion"
                                                        TextMode="MultiLine" ID="txtComment" runat="server" MaxLength="10" onkeyDown="checkTextAreaMaxLength(this,event,'200');"
                                                        OnFocus="return SetComment();" OnClick="return SetComment();"></asp:TextBox>
                                                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtComment"
                                                        WatermarkText="Comment*" WatermarkCssClass="textArea" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                                                        ControlToValidate="txtComment" Display="None" ValidationGroup="ValTempSuggestion"
                                                        ErrorMessage="<b>Required Field Missing</b><br />Comment is required.">  
                                                    </asp:RequiredFieldValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                                                        TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight"
                                                        Enabled="true" />
                                                    <asp:CustomValidator runat="server" ID="CustomValidator1" ValidationGroup="ValTempSuggestion"
                                                        ControlToValidate="txtComment" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateChar1"
                                                        ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                                                        TargetControlID="CustomValidator1" HighlightCssClass="validatorCalloutHighlight"
                                                        Enabled="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="btnSumbmit" runat="server" OnClick="btnSumbmit_Click" ImageUrl="~/Images/submitbutton.jpg"
                                                        ValidationGroup="ValTempSuggestion" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Panel>
<%-- Region Modelpopup Start--%>