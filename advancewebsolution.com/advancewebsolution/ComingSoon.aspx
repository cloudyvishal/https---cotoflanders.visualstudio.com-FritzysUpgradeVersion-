<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"    Inherits="DCommingSoon" Title="Coming Soon" Codebehind="ComingSoon.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%--<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <div id="mainPlaceholder">
        <%--main place holder start here --%>
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="innerLeftPannel">
                        <%--<div class="flashImg">
                       <BN:Banner ID="Banner" runat="server" />
                    </div>--%>
                        <div style="clear: both;">
                        </div>
                        <table>
                            <tr>
                                <td align="center" valign="top" style="height: 300px; font-size: 50px;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Coming Soon ......
                                </td>
                            </tr>
                        </table>
                        <div class="leftInner">
                            <div class="visitOurVan">
                                <a href="visitourvan.aspx" title="Visit our van">
                                    <img src="images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                            </div>
                        </div>
                    </div>
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img">
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
                                <a href="comingsoon.aspx"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="GROOMERS BLOG"  >
                                    <img src="images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="comingsoon.aspx"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="PET LOVERS BLOG"  >
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
