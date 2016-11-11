<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"   Inherits="Index" Title="Fritzy's pet care pros" EnableEventValidation="false" Codebehind="Index.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<%@ Register Src="~/Controls/Product_Home.ascx" TagName="Product" TagPrefix="PR" %>
<%--<%@ Register Src="~/Controls/Payment.ascx" TagName="makepay" TagPrefix="MK" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">ii<!--[if IE]><link href="ie.css" rel="stylesheet" type="text/css" /><![endif]-->
    <script type="text/javascript" src="Scripts/phone_validation.js" ></script>

    <script type="text/javascript" language="javascript">
        // function Use to check maxlength of textbox 
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
    </script>
    <%-- lblError Div --%>
    <div style="width: 95%" id="divError" runat="server" visible="false">
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
    <div id="mainPlaceholder">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="innerLeftPannel">
                        <!-- inner left pannel start here -->
                        <div class="flashImg">
                            <BN:Banner ID="Banner" runat="server" />
                        </div>
                      
                        <div class="ServicesDatalistDiv">
                            <div class="serviceTitle">
                                <div class="gradient">
                                    <h1>
                                        <span></span>Mobile Grooming</h1>
                                </div>
                            </div>
                        </div>
                        <div class="HomeleftInner">
                            <div class="innerPannelLeft">
                                <div class="innerTitle">
                                    <img src="images/for_your_dogs_title.jpg" alt="Mobile Grooming, Grooming, Mobile Pet Grooming" />
                                </div>
                                <div class="left1">
                                    <asp:Image ID="imgDogservice" runat="server" AlternateText="" />
                                </div>
                                <div class="right1">
                                    <div id="divDogService" runat="server" class="innerParaDiv">
                                        <p></p>
                                    </div>
                                    <a href="Services.aspx" class="more" title="more">more</a>
                                </div>
                            </div>
                         
                            <div class="innerPannelRight">
                                <div class="innerTitle">
                                    <asp:Image ID="forcats" ImageUrl="~/images/for_your_cats_title.jpg" runat="server"
                                        AlternateText="" />
                                </div>
                                <div class="left">
                                    <asp:Image ID="imgCatservice" runat="server" AlternateText="Mobile Grooming, Grooming, Mobile Pet Grooming" />
                                </div>
                                <div class="right">
                                    <div id="divCatService" runat="server" class="innerParaDiv">
                                        <p></p>
                                    </div>
                                    <a href="Services.aspx" class="more" title="more">more</a>
                                </div>
                            </div>
                        </div>
                        <div class="title">
                            <asp:Image ID="productHeader" ImageUrl="~/images/products_title.jpg" runat="server"   AlternateText="" />
                        </div>
                        <div class="HomeleftInner">
                            <PR:Product ID="Pro" runat="server" />
                        </div>
                        <div class="titleBar">
                            <img src="images/content_shadow3.jpg" width="668" height="39" alt="" />
                        </div>
                        <div class="leftInner">
                            <div class="visitOurVan">
                                <a href="Visitourvan.aspx" title="Visit our van">
                                    <img src="images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                            </div>
                        </div>
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">
                            <div id="divUserName" runat="server">
                                <asp:Label ID="lblWelcome" runat="server" CssClass="lblWelcome" Text=""></asp:Label>
                            </div>
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" Visible="true" />
                            <div>
                              
                                <asp:ImageButton ID="imgbtnMakePayment" runat="server" ImageUrl="~/Images/makepayment.gif"  Width="236px" Height="100px" OnClick="imgbtnMakePayment_Click" Visible="false" Style="margin-left: 7px" />
                                
                            </div>
                            <%--<MK:makepay />--%>
                            <Jo:Join ID="asd" runat="server" />
                            <AP:Appointment ID="Appointment1" runat="server" />
                            <GF:Gift ID="GF" runat="server" />
                            <div class="img">
                                <a href="comingsoon.aspx"   onclick="javascript:$find('SuggestionBox').show();return false;"  title="GROOMERS BLOG"  >
                                    <img src="images/btn_groomers_blog.jpg" border="0" alt="GROOMERS BLOG" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="comingsoon.aspx"   onclick="javascript:$find('SuggestionBox').show();return false;"  title="PET LOVERS BLOG"  >
                                    <img src="images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="PET LOVERS BLOG" /></a>
                            </div>
                            <Sg:Suggestion ID="ctlSuggestion" runat="server" />
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
</asp:Content>
