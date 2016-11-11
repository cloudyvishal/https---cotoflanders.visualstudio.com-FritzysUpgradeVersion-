<%@ Control Language="C#" AutoEventWireup="true" Inherits="Controls_Footer" CodeBehind="Footer.ascx.cs" %>
<%--Footer control call from master page footer--%>
<div class="footer">
    <div class="validator">
        &nbsp;
    </div>
    <div class="footerLinks">
        <a href="index.aspx" title="Fritzy's pet care pros : Home">Home</a> l <a href="Aboutus.aspx"
            title="Fritzy's pet care pros : About us">About Us</a> l <a href="Contactus.aspx"
                title="Fritzy's pet care pros : Careers">Careers</a>

        l <a href="Services.aspx" title="Fritzy's pet care pros : Services">Services</a>
        l <a href="Products.aspx" title="Fritzy's pet care pros : Products">Products</a>
        l <a href="FleaTick.aspx" title="Fritzy's pet care pros : Flea tick &amp; hot spot">Flea Tick & Hot Spot</a>
        l <a href="FritzyFriends.aspx" title="Fritzy's pet care pros : Fritzy's friends">Fritzy’s Friends</a>
        l <a href="SiteMap.aspx" title="Fritzy's pet care pros : Site map">Site Map</a>
        l <a href="Contactus.aspx" title="Fritzy's pet care pros : Contact us">Contact Us</a><br />
    </div>
  
    <img src="images/spacer.gif" width="1" height="6" alt="" class="spacer" />
    <span class="above_copyrights">
        <asp:Literal ID="litContent" runat="server"></asp:Literal>
    </span>
    <div class="above_copyrights">
        <span class="footercopyright">&copy; Copyright 2009. Fritzy’s Pet Care Pros. All Rights Reserved.</span>
        <div class="clear">
        </div>
    </div>
</div>
