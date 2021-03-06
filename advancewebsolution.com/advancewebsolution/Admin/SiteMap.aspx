﻿<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="AdminSiteMap" Title="Fritzy's pet care pros : SiteMap " Codebehind="~/Admin/SiteMap.aspx.cs" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



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
                        <div class="title">
                            <asp:Image ID="aboutustitle" ImageUrl="~/Images/sitemapTitle.jpg" runat="server"
                                AlternateText="" />
                        </div>
                    <div class="leftInner">
                       <div class="sitemapDiv">
                        <ul class="sitemap">
                            <li><a href="Index.aspx" title="Home">Home</a></li>
                            <li><a href="Services.aspx" title="Services">Services</a>
                                <ul>
                                    <li><a href="Services.aspx" title="For your Cat">For Your Dog</a></li>
                                    <li><a href="Services.aspx" title="For Your Dog">For Your Dog </a></li>
                                </ul>
                            </li>
                            
                            <li><a href="Contactus.aspx" title="Products">Products</a></li>
                            <li><a href="Contactus.aspx" title="Fles Tick & Hot Spot">Fles Tick & Hot Spot</a></li>
                            <li><a href="FritzyFriends.aspx" title="Fritzy Friend">Fritzy Friend</a></li>
                           
                            <li><a href="Visitourvan.aspx" title="Visit Our Van">Visit Our Van </a></li>
                            <li><a href="Registration_Basic.aspx" title="oin Fritzy’s Club">Join Fritzy’s Club</a></li>
                            <li><a href="Aboutus.aspx" title="About Us">About Us </a></li>
                            <li><a href="Contactus.aspx" title="Contact us">Contact us</a></li>
                            <li><a href="Registration_Basic.aspx" title="Registration Basic">Registration Basic</a></li>
                            <li><a href="Contactus.aspx" title="Careers">Careers</a></li>
                         
                        </ul>
                        </div>
                        </div>
                    </div>
                    
                    <div id="innerRightPannel">
                    <!-- innere right pannel start here -->
                    <div class="img">
                        <Z1:Zipcode1 ID="ctlZipcode" runat="server" />
                        <Jo:Join ID="asd" runat="server" />
                        <AP:Appointment ID="Appointment1" runat="server" />
                        <GF:Gift ID="GF" runat="server" />
                        <div class="img">
                            <a href="#"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="GROOMERS BLOG"  >
                                <img src="images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                        </div>
                        <div class="img">
                            <a href="#"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="PET LOVERS BLOG"  >
                                <img src="images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="Pet Lovers Blog" /></a>
                        </div>
                        <Sg:Suggestion ID="ctlSuggestion" runat="server" />
                    </div>
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

