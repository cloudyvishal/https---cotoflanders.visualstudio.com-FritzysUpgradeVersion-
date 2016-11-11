<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"    Inherits="Search" Title="Fritzy's pet care pros - Search" Codebehind="Search.aspx.cs" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/SearchFriend.ascx" TagName="Friend" TagPrefix="FR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


 <style type="text/css">
    .prevlink{ color:#503414; font-size:12px; text-decoration:underline;}
    .prevlink:hover{ text-decoration:none;}
    .inactivelink{ color:#ccc; text-decoration:none;}
 </style>
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
                        <div class="tabsforIE">
                        <cc1:TabContainer ID="TC" runat="server"  >
                            <%--Tab 1 Service end here --%>
                            <cc1:TabPanel ID="Tp1" HeaderText="Services" runat="server">
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="up12" runat="server">
                                        <ContentTemplate>
                                            <div style="width: 640px;">
                                                <p>
                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label></p>
                                                <asp:DataList ID="dlService" runat="server" RepeatColumns="1" Width="100%" CellPadding="0">
                                                    <ItemTemplate>
                                                        <div class="news">
                                                            <div class="servicesImages">
                                                                <asp:Image ID="Image1" ImageUrl="~/Images/catPaw.jpg" runat="server" AlternateText=" " /></div>
                                                            <div class="ServicesCatsoverflowDiv">
                                                                <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%# Session["HomePath"] + "ServiceDetails.aspx?ID=" + Eval("ServiceID") + "&Page=" + Eval("Page")  %>'
                                                                    Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                                                                <div style="margin: 4px 0;">
                                                                </div>
                                                                <asp:Label ID="lblDesc" CssClass="description" Text='<%#Eval("ServiceDescription") %>'
                                                                    runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <div class="prevNext" id="divprevNext" runat="server">
                                                    <ul>
                                                        <li>
                                                            <asp:LinkButton ID="lnkPrev" runat="server" Text="Previous" OnClick="lnkPrev_Click"
                                                                CssClass="prevlink" ToolTip="Previous"></asp:LinkButton></li>
                                                        <li>
                                                            <asp:Label ID="lblLine" runat="server" Text="|"></asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lnkNext" runat="server" Text="Next" OnClick="lnkNext_Click" ToolTip="Next"
                                                                CssClass="prevlink"></asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                                <asp:Label ID="lblServices" runat="server"></asp:Label>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>
                            <%--Tab 1 Service end here --%>
                            <%--Tab 2 Product Start here --%>
                            <cc1:TabPanel ID="Tp2" HeaderText="Products" runat="server">
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="UpProd" runat="server">
                                        <ContentTemplate>
                                            <div style="width: 640px;">
                                                <p>
                                                    <asp:Label ID="lblProdTitle" runat="server"></asp:Label></p>
                                                <asp:DataList ID="dlProducts" runat="server" RepeatColumns="1" Width="100%" CellPadding="0">
                                                    <ItemTemplate>
                                                        <div class="news">
                                                            <div class="servicesImages">
                                                                <asp:Image ID="Image1" ImageUrl="~/Images/catPaw.jpg" runat="server" AlternateText=" " /></div>
                                                            <div class="ServicesCatsoverflowDiv">
                                                                <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%# Session["HomePath"] + "Products.aspx"%>'
                                                                    Text='<%#Eval("ProductName") %>'></asp:HyperLink>
                                                                <div style="margin: 4px 0;">
                                                                </div>
                                                                <asp:Label ID="lblProdDesc" CssClass="description" Text='<%#Eval("ProductDescription") %>'
                                                                    runat="server"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                    <%--Div Pagging --%>
                                                <div class="prevNext" id="div1" runat="server">
                                                    <ul>
                                                        <li>
                                                            <asp:LinkButton ID="lnkProdPrev" runat="server" Text="Previous" CssClass="prevlink"
                                                                ToolTip="Previous" OnClick="lnkProdPrev_Click"></asp:LinkButton></li>
                                                        <li>
                                                            <asp:Label ID="lblProdLine" runat="server" Text="|"></asp:Label>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lnkProdNext" runat="server" Text="Next" ToolTip="Next" CssClass="prevlink"
                                                                OnClick="lnkProdNext_Click"></asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>
                             <%--Tab 2 Product end here --%>
                            <cc1:TabPanel ID="Tp3" HeaderText="Friends" runat="server" >
                                <ContentTemplate>
                                    <FR:Friend Id="frd" runat="server" />
                                </ContentTemplate>
                            </cc1:TabPanel>
                        </cc1:TabContainer>
                        </div>
                    </div>
                    <div id="innerRightPannel" class="ieRight">
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
                <div style="clear: both;">
                </div>
                <div id="mainBottomImg">
                </div>
            </div>
        </div>
    </div>
    
    
    
    
</asp:Content>
