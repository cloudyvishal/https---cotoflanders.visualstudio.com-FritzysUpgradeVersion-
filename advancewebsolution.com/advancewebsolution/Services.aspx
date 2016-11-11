<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"   Inherits="Services" Title="Fritzy's pet care pros : Services" Codebehind="Services.aspx.cs" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--[if IE]>
	
	    <link href="ie.css" rel="stylesheet" type="text/css" />
   
    <![endif]-->
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
                            <%-- <img src="images/flash_banner.jpg" alt="flash banner" />--%>
                            <BN:Banner ID="Banner" runat="server" />
                        </div>
                        <asp:PlaceHolder ID="plcServices" runat="server"></asp:PlaceHolder>
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">
                            <div id="divUserName" runat="server">
                                <asp:Label ID="lblWelcome" runat="server" CssClass="lblWelcome" Text=""></asp:Label>
                            </div>
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server"/>
                              <div>
                                <asp:ImageButton ID="imgbtnMakePayment" runat="server"  ImageUrl="~/Images/makepayment.gif"
                                    Width="236px" Height="100px" OnClick="imgbtnMakePayment_Click" Visible="false" style="margin-left: 7px" />
                            </div>
                            <Jo:Join ID="asd" runat="server" />
                            <AP:Appointment ID="Appointment2" runat="server" />
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
