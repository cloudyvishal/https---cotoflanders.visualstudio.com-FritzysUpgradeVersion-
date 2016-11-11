<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" Inherits="Login" Title="Fritzy's pet care pros : Login" CodeBehind="Login.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function SetEmpty() {
            document.getElementById('<%=txtEmail.ClientID %>').value = "";
            return false;
        }

    </script>

    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <div id="mainPlaceholder" style="z-index: 10;">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="innerLeftPannel">
                        <!-- inner left pannel start here -->
                        <div class="flashImg">
                            <asp:Image ID="aboutusbanner" ImageUrl="~/Images/aboutusBanner.jpg" runat="server"
                                AlternateText=" " />
                        </div>
                        <div class="title">
                            <asp:Image ID="BlankTitle" ImageUrl="~/Images/content_shadow3.jpg" runat="server"
                                AlternateText=" " />
                        </div>
                        <div class="leftInner">
                            <div id="loginMainpage">
                                <div id="contactRightTop">
                                </div>
                                <div id="contactRightMid">
                                    <div class="loginPage">
                                        <table width="80%" border="0" cellpadding="3" cellspacing="0">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2" style="height: 16px">
                                                        <asp:Label ID="lblLoginerror" runat="server" Text="* Invalid Username or Password"
                                                            Visible="false" CssClass="errormsg"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px">
                                                        <label>
                                                            Username:
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="logintextField"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                                                            Display="None" SetFocusOnError="true" ValidationGroup="valSuggest" ErrorMessage="<b>Required Field Missing</b><br />User name is required.">  
                                                        </asp:RequiredFieldValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                                            TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                                            Enabled="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 84px">
                                                        <label>
                                                            Password:
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="logintextField"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valSuggest"
                                                            ControlToValidate="txtPassword" Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Password is required.">  
                                                        </asp:RequiredFieldValidator>
                                                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                                            TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight"
                                                            Enabled="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="chkRemember" runat="server" />Remember me on this computer
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 17px">
                                                        <asp:ImageButton ID="btnLogin" runat="server" ToolTip="LOGIN" ImageUrl="~/Images/loginbtn.jpg"
                                                            ValidationGroup="valSuggest" OnClick="btnLogin_Click1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <p>
                                                            <asp:LinkButton ID="lnkForgotPassword" CausesValidation="false" runat="server" Text="Forgot Password?"
                                                                ToolTip="Forgot Password?" CssClass="friendsLink" />
                                                        </p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">Not a Member?&nbsp;&nbsp;<asp:ImageButton ID="RegisterNow" runat="server" ToolTip="REGISTER NOW" ImageUrl="~/Images/regesterImg.jpg" ValidationGroup="valSuggest" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div id="contactRightBottom">
                                </div>
                            </div>
                        </div>
                        <div class="titleBar">
                            <asp:Image ID="pagetitle" ImageUrl="~/Images/pageTitle.jpg" runat="server" AlternateText=" " />
                        </div>
                        <div class="leftInner">
                            <div class="visitOurVan">
                                <a href="#" title="Visit our van">
                                    <img src="images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                            </div>
                        </div>
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img">
                            <div class="locationServiced">
                                <div class="zipcode">
                                    <asp:TextBox ID="TextBox2" name="textfield" type="text" runat="server" class="textfield1"
                                        value="zip code"></asp:TextBox>
                                </div>
                                <div class="gobutton">
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/btn_go.gif"
                                        AlternateText="Go" />
                                </div>
                            </div>
                            <div class="img">
                                <a href="#" title="It's Free Join Fritzy's Club">
                                    <img src="images/join_fritzys_club.jpg" border="0" alt="It's Free Join Fritzy's Club" /></a>
                            </div>
                            <div class="img">
                                <a href="#" title="Make an appointment Now">
                                    <img src="images/make_appointment_now.jpg" border="0" alt="Make an appointment Now" /></a>
                            </div>
                            <div class="imgGiftcard">
                                <a href="#" title="Fritzy's giftcard">
                                    <img src="images/giftcard1.jpg" border="0" alt="Fritzy's GiftCard" /></a>
                            </div>
                            <div class="img">
                                <a href="#" onclick="javascript:$find('SuggestionBox').show();return false;" title="GROOMERS BLOG">
                                    <img src="images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="#" onclick="javascript:$find('SuggestionBox').show();return false;" title="PET LOVERS BLOG">
                                    <img src="images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="Pet Lovers Blog" /></a>
                            </div>
                            <div class="img">
                                <div class="sugesstionBox">
                                    <asp:ImageButton ID="btnSuggestion" runat="server" ImageUrl="~/Images/btn_suggestion_box_bg.jpg" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- inner right pannel end here -->
                </div>
                <!-- main content end here -->
                <div style="clear: both;">
                </div>
                <div id="mainBottomImg">
                </div>
            </div>
            <!-- wrapper end here -->
        </div>
    </div>
    <cc1:ModalPopupExtender ID="ModalPopupExtender5" runat="server" TargetControlID="lnkForgotPassword"
        PopupControlID="PanelFiveImg" BackgroundCssClass="modalBackground" OnCancelScript="return SetEmpty();"
        CancelControlID="closewindow">
    </cc1:ModalPopupExtender>
    <asp:Panel Style="display: none" ID="PanelFiveImg" runat="server">
        <table width="200px" border="1">
            <tbody>
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="closewindow" ImageUrl="~/Images/closeImg.jpg" runat="server"
                            CausesValidation="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Please Enter your Email</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtEmail" CssClass="textField" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"
                            Display="None" SetFocusOnError="true" ValidationGroup="valSubmit" ErrorMessage="<b>Required Field Missing</b><br />Name is required.">  
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                            SetFocusOnError="true" ValidationGroup="valSubmit" ControlToValidate="txtEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                            TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight"
                            Enabled="true" />
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender8"
                            TargetControlID="revEmail" HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="btnSumbmit" runat="server" ImageUrl="~/Images/submitbutton.jpg" ValidationGroup="valSubmit" />
                    </td>
                </tr>
            </tbody>
        </table>
    </asp:Panel>
</asp:Content>
