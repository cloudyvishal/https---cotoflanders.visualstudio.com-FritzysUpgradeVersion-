<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_Header_Login" Codebehind="Copy of Header_Login.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript" language="javascript">
    function showForgot() {
        document.getElementById('<%=divForgot.ClientID %>').style.display = "block";
        document.getElementById('<%=DivlnkForgot.ClientID %>').style.display = "none";
        return false;
    }
    function HideForgot() {
        document.getElementById('<%=divForgot.ClientID %>').style.display = "none";
        document.getElementById('<%=DivlnkForgot.ClientID %>').style.display = "block";
    }
    function SetLogintomailn() {
        document.getElementById('<%=divlblForgotmessage.ClientID %>').style.display = "none";
        document.getElementById('<%=DivlnkForgot.ClientID %>').style.display = "block";
        document.getElementById('<%=divForgot.ClientID %>').style.display = "none";
        return true;
    }
</script>

<!-- Some rules to make IE/Win display the boxes with variable height. -->
<div id="mainHeader">
    <!-- main header start here -->
    <div id="mainHeaderContent">
        <!-- main header content start here -->
        <div id="headerLogo">
            <!-- header logo start here -->
            <a href="../Index.aspx" title="Fritzy's pet care pros">
                <asp:Image ID="mainLogo" ImageUrl="~/Images/mainLogo.jpg" runat="server" AlternateText="Fritzy's pet care pros" /></a>
        </div>
        <!-- header logo end here -->
        <div id="hederRightNav">
            <!-- header right nav start here -->
            <div id="toplinks">
                <a href="../Aboutus.aspx" id="linkAboutus" title="Fritzy's pet care pros : About Us"
                    runat="server">About Us</a> l <a href="../ComingSoon.aspx" id="linkCareers" title="Fritzy's pet care pros : Careers"
                        runat="server">Careers</a> l <a href="../ComingSoon.aspx" id="linkSitemap" title="Fritzy's pet care pros : Site Map"
                            runat="server">Site Map</a> l <a href="../Registration_Basic.aspx" id="lnkRegistration"
                                runat="server" title="Fritzy's pet care pros : Registration">Registration</a>
                l <a href="../ComingSoon.aspx" onclick="javascript:$find('SuggestionBox').show();return false;" id="linkBlog" title="Fritzy's pet care pros : Blog"
                    runat="server">Blog</a>
            </div>
            <div id="callToday">
                <asp:Image ID="mobilegrooming" ImageUrl="~/Images/call_today1.jpg" runat="server"
                    AlternateText=" " />
            </div>
            <div class="cart">
                <!-- cart start here -->
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div class="search">
                                <label class="searchlbl">
                                    Search</label>
                            </div>
                        </td>
                        <td>
                            <div class="textbox">
                                <asp:TextBox ID="TextBox1" class="textfield" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="go">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/btn_go.gif"
                                    alt="Go" OnClientClick="return false;" />
                            </div>
                        </td>
                        <td valign="bottom">
                            <div class="cartPrice">
                                <span class="bold">
                                    <label class="searchlbl">
                                        cart:</label>
                                </span>0 Items&nbsp;&nbsp;$0.00
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- cart end here -->
        </div>
        <!-- header right nav end here -->
        <div id="topnavigation">
            <!-- top navigation start here -->
            <div id="topnav">
                <ul id="nav1">
                    <li><a href="Index.aspx" id="home" title="Fritzy's pet care pros"></a></li>
                    <li><a href="Services.aspx" id="services" title="Fritzy's pet care pros : SERVICES">
                    </a></li>
                    <li><a href="Products.aspx" id="products" title="Fritzy's pet care pros : PRODUCTS">
                    </a></li>
                    <li><a href="FleaTick.aspx" id="flea" title="Fritzy's pet care pros : FLEA, TICK &amp; HOT SPOT">
                    </a></li>
                    <li><a href="FritzyFriends.aspx" id="fritzyfriends" title="Fritzy's pet care pros : FRITZY'S FRIENDS">
                    </a></li>
                    <li><a href="Contactus.aspx" id="contactus" title="Fritzy's pet care pros : CONTACT US">
                    </a></li>
                    <li>
                        <asp:ImageButton ID="Login" runat="server" ImageUrl="~/Images/login_off_new.jpg"
                            ToolTip="LOGIN" CssClass="loginBtn" /></li>
                </ul>
            </div>
        </div>
        <!-- top nav ends here -->
    </div>
    <!-- main header content end here -->
</div>
<cc1:ModalPopupExtender ID="ModalLogin" runat="server" TargetControlID="login" PopupControlID="PanelFiveImg"
    BackgroundCssClass="modalBackground" CancelControlID="closeLoginWindow" OnCancelScript="return SetLogintomailn();">
</cc1:ModalPopupExtender>
<asp:Panel Style="display: none" ID="PanelFiveImg" runat="server">
    <div id="loginOuter">
        <div id="loginMain">
            <div id="loginHeader">
                <div id="loginLogo">
                    <asp:Image ID="Image1" ImageUrl="~/Images/loginLogo.jpg" runat="server" AlternateText=" " /></div>
                <div id="loginTitle">
                    <div class="closeLoginWindow">
                        <asp:Image ID="closeLoginWindow" ImageUrl="~/Images/closeImg.jpg" runat="server"
                            AlternateText=" " /></div>
                    <div class="loginTitle">
                        <asp:Image ID="Image2" ImageUrl="~/Images/loginTitle.gif" runat="server" AlternateText=" " /></div>
                </div>
            </div>
            <div class="loginLeft">
                <asp:Image ID="loginleftimage" ImageUrl="~/Images/loginLeftImg.jpg" runat="server"
                    AlternateText=" " /></div>
            <div class="loginRight">
                <table width="100%" border="0" cellpadding="3">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblLoginerror" runat="server" Text="* Invalid Username or Password"
                                    CssClass="errormsg"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Username:
                                </label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="logintextField" ValidationGroup="valLogin"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                    Display="None" SetFocusOnError="true" ValidationGroup="valLogin" ErrorMessage="<b>Required Field Missing</b><br />User name is required.">  
                                </asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Username."
                                    ValidationGroup="valLogin" SetFocusOnError="true" ControlToValidate="txtUsername"
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
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="logintextField" TextMode="Password"
                                    ValidationGroup="valLogin"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valLogin"
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
                                <asp:ImageButton ID="btnLogin" runat="server" CausesValidation="true" ImageUrl="~/Images/loginbtn.jpg"
                                    ValidationGroup="valLogin" OnClick="btnLogin_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="divlblForgotmessage" runat="server" style="display: none;">
                                    <asp:Label ID="lblForgotmessage" runat="server" Text=""></asp:Label>
                                </div>
                                <div id="DivlnkForgot" runat="server" style="display: block">
                                    <asp:LinkButton ID="lnkFoggot" runat="server" Text="Forgot Password?" CssClass="forgotpwdlink"
                                        OnClientClick="return showForgot();"></asp:LinkButton>
                                </div>
                                <div id="divForgot" runat="server" style="display: none; border: 1px solid #baa080;
                                    margin: 0 0 10px 0;">
                                    <table border="0" width="100%">
                                        <tr>
                                            <td>
                                                <label>
                                                    Username:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtforgotUsername" runat="server" CssClass="logintextField" ValidationGroup="valForgot"></asp:TextBox>
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
                                                    ValidationGroup="valForgot" CausesValidation="true" OnClick="ImgSubmitForgot_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="notreg">
                                Not a Member?&nbsp;&nbsp;
                                <asp:ImageButton ID="RegisterNow" Text="Register Now" runat="server" ImageUrl="~/Images/regesterImg.jpg"
                                    PostBackUrl="~/Registration_Basice.aspx" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
  
</asp:Panel>
