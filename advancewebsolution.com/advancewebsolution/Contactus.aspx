<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    Inherits="Contactus" Title="Fritzy's pet care pros : Contact Us" Codebehind="Contactus.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->
   
    <script type="text/javascript" language="javascript" src="Scripts/phone_validation.js"></script>

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
        function ValidateSpecialChar(Str) {

            var iChars = "!@#$%^&*()+=-[]\\\;/{}|\":<>?";
            for (var i = 0; i < Str.length; i++) {
                if (iChars.indexOf(Str.charAt(i)) != -1) {

                    return false;
                }
            }
            return true;
        }
        function ValidateChar123(source, args) {
            var iChars = "!@#$%^&*()+=-[]\\\;/{}|\":<>?";
            var str = args.Value;
            for (var i = 0; i < str.length; i++) {
                if (iChars.indexOf(str.charAt(i)) != -1) {
                    args.IsValid = false;
                }
            }

        }


    </script>

    <div id="mainPlaceholder">
        <%--main place holder start here --%>
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="innerLeftPannel">
                        <div class="flashImg">
                            <BN:Banner ID="Banner" runat="server" />
                        </div>
                        <div class="title">
                            <asp:Image ID="contactustitle" ImageUrl="~/Images/contactTitle.jpg" runat="server"
                                AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div id="contactmain">
                                <div id="contactLeftPannel" style="border: 0px solid; margin: 200px 0 0 0;">
                                    <asp:Image ID="contactleftimg" ImageUrl="~/Images/contactLeftDogImg.jpg" runat="server"
                                        AlternateText="" />
                                </div>
                                <div id="contactRightPannel">
                                    <div id="contactRightTop">
                                    </div>
                                    <div id="contactRightMid">
                                        <div id="contactForm" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ContentPlaceHolder1_btnSave')">
                                            <%-- ***************Form Starts here*********************--%>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <p>
                                                            <span>Fritzy's Pet Care Pros, Incorporated</span><br />
                                                            15510 Rockfield Blvd., Suite B110, Irvine, CA, 92618.
                                                            <br />
                                                            Email: <a href="mailto:customerservice@fritziespetcarepros.com">customerservice@fritziespetcarepros.com</a></p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="contactshadow" ImageUrl="~/Images/contactBgshadow.jpg" runat="server"
                                                            AlternateText="" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div id="divError" runat="server" visible="false">
                                                            <table width="100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="left" rowspan="2">
                                                                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="5">
                                                            <tr>
                                                                <td style="width: 106px;">
                                                                    <label>First Name<span class="star">*</span></label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFName" runat="server" CssClass="contacttextField" MaxLength="20"
                                                                        ValidationGroup="valContactus"></asp:TextBox>
                                                                </td>
                                                                <asp:RequiredFieldValidator ID="reqContactFName" runat="server" ValidationGroup="valContactus"
                                                                    SetFocusOnError="true" ControlToValidate="txtFName" Display="None" ErrorMessage="<b>Required Field Missing</b><br />First Name is required.">  
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactFname" Enabled="true"
                                                                    TargetControlID="reqContactFName" HighlightCssClass="validatorCalloutHighlight" />
                                                                <asp:CustomValidator runat="server" ID="custSpChar" ValidationGroup="valContactus"
                                                                    ControlToValidate="txtFName" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateChar123"
                                                                    ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
                                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>Last Name</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtLName" runat="server" CssClass="contacttextField" MaxLength="20"
                                                                        ValidationGroup="valContactus"></asp:TextBox>
                                                                    <asp:CustomValidator runat="server" ID="CustomValidator2" ValidationGroup="valContactus"
                                                                        ControlToValidate="txtLName" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateChar123"
                                                                        ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
                                                                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                                                        TargetControlID="CustomValidator2" HighlightCssClass="validatorCalloutHighlight"
                                                                        Enabled="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>Email<span class="star">*</span></label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtContactEmail" runat="server" CssClass="contacttextField" ValidationGroup="valContactus"
                                                                        MaxLength="200"></asp:TextBox>
                                                                </td>
                                                                <asp:RequiredFieldValidator ID="reqContactEmail" ValidationGroup="valContactus" runat="server"
                                                                    ControlToValidate="txtContactEmail" SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Email is required.">  
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactEmail1" Enabled="true"
                                                                    TargetControlID="reqContactEmail" HighlightCssClass="validatorCalloutHighlight" />
                                                                <asp:RegularExpressionValidator ID="revContactEmail" runat="server" Display="None"
                                                                    ValidationGroup="valContactus" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                                                                    SetFocusOnError="true" ControlToValidate="txtContactEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                                </asp:RegularExpressionValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactEmail11" TargetControlID="revContactEmail"
                                                                    HighlightCssClass="validatorCalloutHighlight" />
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>Phone</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="contacttextField" onkeydown="javascript:backspacerDOWN(this,event);"
                                                                        onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 24px">
                                                                    <label>Message<span class="star">*</span></label>
                                                                </td>
                                                                <td style="height: 24px">
                                                                    <asp:TextBox Height="60px" Rows="5" Columns="20" TextMode="MultiLine" ID="txtMessage"
                                                                        runat="server" CssClass="contacttextField" MaxLength="300" ValidationGroup="valContactus"
                                                                        onkeyDown="checkTextAreaMaxLength(this,event,'200');"></asp:TextBox>
                                                                </td>
                                                                <asp:RequiredFieldValidator ID="reqContactMessage" runat="server" SetFocusOnError="true"
                                                                    ControlToValidate="txtMessage" ValidationGroup="valContactus" Display="None"
                                                                    ErrorMessage="<b>Required Field Missing</b><br />Message is required.">  
                                                                </asp:RequiredFieldValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valMessage" Enabled="true"
                                                                    TargetControlID="reqContactMessage" HighlightCssClass="validatorCalloutHighlight" />
                                                                <asp:CustomValidator runat="server" ID="CustomValidator1" ValidationGroup="valContactus"
                                                                    ControlToValidate="txtMessage" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateChar123"
                                                                    ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
                                                                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                                                    TargetControlID="CustomValidator1" HighlightCssClass="validatorCalloutHighlight"
                                                                    Enabled="true" />
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="Images/contactSendButton.jpg"
                                                                        ValidationGroup="valContactus" OnClick="btnSave_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Note: Fields marked with <span class="star">*</span> required
                                                    </td>
                                                </tr>
                                            </table>
                                            <%--***************Form ends here************************--%>
                                        </div>
                                    </div>
                                    <div id="contactRightBottom">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="titleBar">
                            <asp:Image ID="pagetitle" ImageUrl="~/Images/pageTitle.jpg" runat="server" AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div class="visitOurVan">
                                <a href="visitourvan.aspx" title="Visit our van">
                                    <img src="images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                            </div>
                        </div>
                    </div>
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">
                            <div id="divUserName" runat="server">
                                <asp:Label ID="lblWelcome" runat="server" CssClass="lblWelcome" Text=""></asp:Label>
                            </div>
                            <%--<Zp:Zipcode ID="ctlZipcode" runat="server" />--%>
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" />
                            <div>
                                <asp:ImageButton ID="imgbtnMakePayment" runat="server" ImageUrl="~/Images/makepayment.gif"
                                    Width="236px" Height="100px" OnClick="imgbtnMakePayment_Click" Visible="false" Style="margin-left: 7px" />
                                <%--<asp:ImageButton ID="btnPaid" runat="server" ImageUrl="~/Images/paid.png" Visible="false" />--%>
                            </div>
                            <Jo:Join ID="asd" runat="server" />
                            <AP:Appointment ID="Appointment1" runat="server" />
                            <GF:Gift ID="GF" runat="server" />
                            <div class="img">
                                <a href="ComingSoon.aspx"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="GROOMERS BLOG"  >
                                    <img src="images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="ComingSoon.aspx"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="PET LOVERS BLOG"  >
                                    <img src="images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="Pet Lovers Blog" /></a>
                            </div>
                            <Sg:Suggestion ID="ctlSuggestion" runat="server" />
                        </div>
                        <!-- inner right pannel end here -->
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <div id="mainBottomImg">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
