<%@ Control Language="C#" AutoEventWireup="true" Inherits="Controls_Login" CodeBehind="Login.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript" language="javascript">
    function showForgot() {
        alert("Show forgot");
        document.getElementById('<%=divForgot.ClientID %>').style.display = "block";
        document.getElementById('<%=DivlnkForgot.ClientID %>').style.display = "none";
        return false;
    }
    function HideForgot() {
        alert("hide forgot");
        document.getElementById('<%=divForgot.ClientID %>').style.display = "none";
        document.getElementById('<%=DivlnkForgot.ClientID %>').style.display = "block";
    }
    function SetLogintomailn() {
        alert("SetLogintomailn");
        document.getElementById('<%=divlblForgotmessage.ClientID %>').style.display = "none";
        document.getElementById('<%=DivlnkForgot.ClientID %>').style.display = "block";
        document.getElementById('<%=divForgot.ClientID %>').style.display = "none";
        return true;
    }
</script>

<div>
    <asp:ImageButton ID="ImgAppointment" runat="server" ImageUrl="~/Images/make_appointment_now.jpg" ToolTip="MAKE AN APPOINTMENT NOW" />
</div>

<cc1:ModalPopupExtender ID="ModalLogin" runat="server" TargetControlID="ImgAppointment"
    PopupControlID="PanelFiveImg" BackgroundCssClass="modalBackground" CancelControlID="closeLoginWindow"
    OnCancelScript="return SetLogintomailn();">
</cc1:ModalPopupExtender>

<asp:Panel Style="display: none" ID="PanelFiveImg" runat="server">

    <div id="loginOuter">
        <div id="loginMain">
            <div id="loginHeader">
                <div id="loginLogo">
                    <asp:Image ID="Image1" ImageUrl="~/Images/loginLogo.jpg" runat="server" AlternateText="" />
                </div>
                <div id="loginTitle">
                    <div class="closeLoginWindow">
                        <asp:Image ID="closeLoginWindow" ImageUrl="~/Images/closeImg.jpg" runat="server"
                            AlternateText="" />
                    </div>
                    <div class="loginTitle">
                        <asp:Image ID="Image2" ImageUrl="~/Images/loginTitle.gif" runat="server" AlternateText="" />
                    </div>
                </div>
            </div>
            <div class="loginLeft">
                <asp:Image ID="loginleftimage" ImageUrl="~/Images/loginLeftImg.jpg" runat="server"
                    AlternateText="" />
            </div>
            <div class="loginRight" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ctl04_btnLogin')">
                <table width="100%" border="0" cellpadding="3">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblLoginerror" runat="server" Text="* Invalid UserEmail or Password"
                                    CssClass="errormsg"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Username:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" autocomplete="off" CssClass="logintextField" ValidationGroup="valLoginAppointment"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                    Display="None" SetFocusOnError="true" ValidationGroup="valLoginAppointment" ErrorMessage="<b>Required Field Missing</b><br />User name is required.">  
                                </asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Username."
                                    ValidationGroup="valLoginAppointment" SetFocusOnError="true" ControlToValidate="txtUsername"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                </asp:RegularExpressionValidator>
                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="revEmail"
                                    HighlightCssClass="validatorCalloutHighlight" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Password:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="logintextField" TextMode="Password" ValidationGroup="valLoginAppointment"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valLoginAppointment"
                                    ControlToValidate="txtPassword" Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Password is required.">  
                                </asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator2"
                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="chkRemember" runat="server" />Remember me on this computer
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ImageButton ID="btnLogin" runat="server" ValidationGroup="valLoginAppointment"
                                    ImageUrl="~/Images/loginbtn.jpg" OnClick="btnLogin_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="loginRight" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ctl04_ImgSubmitForgot')">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <div id="divlblForgotmessage" runat="server" style="display: none;">
                                    <asp:Label ID="lblForgotmessage" runat="server" Text=""></asp:Label>
                                </div>
                                <div id="DivlnkForgot" runat="server" style="display: block">
                                    <asp:LinkButton ID="lnkFoggot" runat="server" Text="Forgot Password?" CssClass="forgotpwdlink" OnClientClick="return showForgot();"></asp:LinkButton>
                                </div>
                                <div id="divForgot" runat="server" style="display: none; border: 1px solid #baa080; margin: 0 0 10px 0;">
                                    <table border="0" width="100%">
                                        <tr>
                                            <td>
                                                <label>
                                                    Username:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtforgotUsername" runat="server" autocomplete="off" CssClass="logintextField" ValidationGroup="valForgot"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="valForgot"
                                                    ControlToValidate="txtforgotUsername" Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Username is required.">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4" TargetControlID="RequiredFieldValidator3"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Please enter correct username."
                                                    ValidationGroup="valForgot" SetFocusOnError="true" ControlToValidate="txtforgotUsername"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>
                                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5" TargetControlID="RegularExpressionValidator1"
                                                    HighlightCssClass="validatorCalloutHighlight" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:ImageButton ID="ImgSubmitForgot" runat="server" ImageUrl="~/Images/submitbutton.jpg"
                                                    ValidationGroup="valForgot" OnClick="ImgSubmitForgot_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="notreg">Not a Member?&nbsp;&nbsp;
                                <asp:ImageButton ID="RegisterNow" runat="server" ImageUrl="~/Images/regesterImg.jpg"
                                    PostBackUrl="~/Registration_Full.aspx" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Panel>
