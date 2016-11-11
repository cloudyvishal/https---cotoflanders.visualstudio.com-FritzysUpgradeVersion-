<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" Inherits="Aboutus" Title="Fritzy's pet care pros : About us" CodeBehind="Aboutus.aspx.cs" %>

<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    mo<!--[if IE]><link href="ie.css" rel="stylesheet" type="text/css" /><![endif]--><div id="mainPlaceholder">
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
                        <div class="title">
                            <asp:Image ID="aboutustitle" ImageUrl="~/Images/aboutusTitle.jpg" runat="server" AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div class="aboutinnerleft">
                                <asp:Image ID="leftimage" ImageUrl="~/Images/aboutusImg1.jpg" runat="server" AlternateText="" />
                            </div>
                            <div class="aboutinnerright">
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="title">
                            <asp:Image ID="patecarepro" ImageUrl="~/Images/petcareprosTitle.jpg" runat="server" AlternateText="" />
                        </div>
                        <div class="leftInner">
                            <div class="petcareBg">
                                <asp:DataList ID="dtlNews" DataKeyField="NewsID" runat="server" RepeatColumns="2" Width="100%" OnItemDataBound="dtlNews_ItemDataBound" CellPadding="0" CellSpacing="0">
                                    <ItemTemplate>
                                        <div class="news">
                                            <div class="images">
                                                <asp:Image ID="Image1" ImageUrl="~/Images/patecareListImg.gif" runat="server" AlternateText="" /></div>
                                            <div class="overflowDiv">
                                                <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%# Session["HomePath"] + "NewsDetails.aspx?ID=" + Eval("NewsID") %>' Text='<%#Eval("NewsTitle") %>'></asp:HyperLink>
                                                <div style="margin: 4px 0;"></div>
                                                <asp:Label ID="lblDesc" CssClass="description" Text='<%# Bind("ShortDescription") %>' runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                        <div class="titleBar">
                            <asp:Image ID="pagetitle" ImageUrl="~/Images/pageTitle.jpg" runat="server" AlternateText="" />
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
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" />
                            <div>
                                <asp:ImageButton ID="imgbtnMakePayment" runat="server" ImageUrl="~/Images/makepayment.gif" Width="236px" Height="100px" OnClick="imgbtnMakePayment_Click" Visible="false" Style="margin-left: 7px" />
                            </div>
                            <Jo:Join ID="asd" runat="server" />
                            <AP:Appointment ID="Appointment1" runat="server" />
                            <GF:Gift ID="GF" runat="server" />
                            <div class="img">
                                <a href="ComingSoon.aspx"   onclick="javascript:$find('SuggestionBox').show();return false;"  title="GROOMERS BLOG"  >
                                    <img src="images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="ComingSoon.aspx"   onclick="javascript:$find('SuggestionBox').show();return false;"  title="PET LOVERS BLOG"  >
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
