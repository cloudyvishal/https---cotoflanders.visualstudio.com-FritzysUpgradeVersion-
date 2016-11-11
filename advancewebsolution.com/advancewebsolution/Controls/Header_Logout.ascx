<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_Header_Logout" Codebehind="Header_Logout.ascx.cs" %>
<%@ Register Src="~/Controls/TempSuggestion.ascx" TagName="Temp" TagPrefix="TS" %>
<%--

This page will countain logout button on header of each page and myaccount link in header will redirect to the manage account 
on logout it will remove all sessions and will redirect ot home page 

--%>

<script type="text/ecmascript">
    function CheckSearch1() {
        if (document.getElementById('<%=txtSearchLogout.ClientID %>').value == "") {
            return false;
        }
    }
</script>

<div id="mainHeader">
    <!-- main header start here -->
    <div id="mainHeaderContent">
        <!-- main header content start here -->
        <div id="headerLogo">
            <!-- header logo start here -->
            <a id="lnkLogo" runat="server" title="Fritzy's pet care pros">
                <asp:Image ID="mainLogo" ImageUrl="~/Images/mainLogo.jpg" runat="server" AlternateText="Fritzy's pet care pros" /></a>
        </div>
        <!-- header logo end here -->
        <div id="hederRightNav">
            <!-- header right nav start here -->
            <div id="toplinks">
                <a href="../Aboutus.aspx" id="linkAboutus" title="Fritzy's pet care pros : About Us"
                    runat="server">About Us</a> l <a href="../Contactus.aspx" id="linkCareers" title="Fritzy's pet care pros : Careers"
                        runat="server">Careers</a> l <a href="../SiteMap.aspx" id="linkSitemap" title="Fritzy's pet care pros : Site Map"
                            runat="server">Site Map</a> l <a href="../MyAccount.aspx" id="lnkMyAccount" runat="server"
                                title="Fritzy's pet care pros : My Account">My Account</a> l
                <TS:Temp ID="ctlTempSug" runat="server" />
            </div>
            <div id="callToday">
            </div>
            <div class="cart">
                <!-- cart start here -->
                <table border="0">
                    <tr>
                        <td>
                            <div class="search">
                                <label class="searchlbl">
                                    Search</label>
                            </div>
                        </td>
                        <td>
                            <div class="textbox">
                                <asp:TextBox ID="txtSearchLogout" class="textfield" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="go">
                                <asp:ImageButton ID="btnSearchLogin" runat="server" ImageUrl="~/Images/btn_go.gif"
                                    alt="Go" OnClientClick="return CheckSearch1();" OnClick="btnSearchLogin_Click" />
                            </div>
                        </td>
                        <td align="bottom">
                         
                        </td>
                    </tr>
                </table>
            </div>
            <!-- cart end here -->
        </div>
        <!-- header right nav end here -->
        <div id="topnavigation">
            <!-- top navigation start here -->
            <div id="topnav">
                <ul id="nav1">
                    <li><a href="Index.aspx" id="home" title="Fritzy's pet care pros "></a></li>
                    <li><a href="Services.aspx" id="services" title="Fritzy's pet care pros : SERVICES">
                    </a></li>
                    <li><a href="Products.aspx" id="products" title="Fritzy's pet care pros : PRODUCTS">
                    </a></li>
                    <li><a href="FleaTick.aspx" id="flea" title="Fritzy's pet care pros : FLEA, TICK &amp; HOT SPOT">
                    </a></li>
                    <li><a href="FritzyFriends.aspx" id="fritzyfriends" title="Fritzy's pet care pros : FRITZY'S FRIENDS">
                    </a></li>
                    <li><a href="Contactus.aspx" id="contactus" title="Fritzy's pet care pros : CONTACT US">
                    </a></li>
                    <li><a href="logout.aspx"  id="logout" title="LOGOUT"></a></li>
                </ul>
            </div>
        </div>
        <!-- top nav ends here -->
    </div>
    <!-- main header content end here -->
</div>

