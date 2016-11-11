<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" Inherits="Cat_Teeth_Brushing" Codebehind="Cat_Teeth_Brushing.aspx.cs" %>

<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%--<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            <%-- <BN:Banner ID="Banner" runat="server" />--%>
                            <asp:LinkButton ToolTip="Click for Coupon." runat="server" ID="lnkHoverBanner">
                                <asp:PlaceHolder ID="plh" runat="server"></asp:PlaceHolder>
                            </asp:LinkButton>
                            <%--<div id="bigFlash" runat="server"  style="margin-left:2px;">Get the Flash player!</div>
          <script type="text/javascript">
                // <![CDATA[
                var so = new SWFObject("XML_Banner.swf", "LMtimeline_vazt4", "668", "256", "9", "");
                so.write("ctl00_ContentPlaceHolder1_Banner_bigFlash");
				so.addParam("wmode","transparent");
                // ]]>
             </script>--%>

                        </div>
                        <!-- -------------------Middle body content here---------------------- -->
                        <div class="ServicesDatalistDiv">
                            <div class="serviceTitle">
                                <h1>
                                    <asp:Label ID="lblServiceTitle" runat="server"></asp:Label></h1>
                            </div>
                            <div class="title">
                                <%--<asp:Image ID="blanktitle" ImageUrl="~/Images/pageTitle.jpg" runat="server" AlternateText=""/>--%>
                            </div>
                            <div class="backlinkDiv">
                                <a class="servbacklink" href="javascript: window.history.back()">Go Back</a>
                                <%-- <asp:HyperLink ID="hypBack" runat="server" Text="Back to Services" CssClass="servbacklink" OnClick=""
                                <asp:LinkButton ID="lnkBack" runat="server" Text="Back to Services" CssClass="servbacklink" OnClientClick="history.back();" ></asp:LinkButton>--%>
                            </div>
                            <%-- <div class="left1">
                            <%--<asp:Image ID="imgDogservice" runat="server"  />
                            
                        </div>--%>
                            <%--  Lable show service description --%>
                            <div class="ServicesMidDiv">
                                <asp:Image ID="ImgService" runat="server" AlternateText="" CssClass="imgfloatleft" />
                                <div id="divDogService" runat="server">
                                    <asp:Label ID="lblServiceDesc" CssClass="shortDesc" runat="server"></asp:Label>
                                </div>
                                <%--Literal control will show content of services--%>
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <!-- ----------------------------------------------------------------- -->
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" />
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

