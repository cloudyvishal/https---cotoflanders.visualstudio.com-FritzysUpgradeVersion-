<%@ Control Language="C#" AutoEventWireup="true"  Inherits="Services_Common_cat" Codebehind="Services_Common_cat.ascx.cs" %>
<style type="text/css">
    .prevlink
    {
        color: #503414;
        font-size: 12px;
        text-decoration: underline;
    }
    .prevlink:hover
    {
        text-decoration: none;
    }
    .inactivelink
    {
        color: #ccc;
        text-decoration: none;
    }
</style>

<div class="ServicesDatalistDiv">
    <div class="serviceTitle">
        <div class="gradient">
            <h1>
                <span></span>Mobile Grooming Services</h1>
        </div>
    </div>
</div>
<div class="leftInner">
     <div class="ServicesinnerPannelLeft">
        <div class="innerTitle">
            <asp:Image ID="forcats" ImageUrl="~/images/for_your_cats_title.jpg" runat="server"
                AlternateText=" " />
        </div>
        <div class="topDatalistDiv">
            <div class="left">
                <asp:Image ID="imgCatservice" runat="server" AlternateText=" " />
            </div>
            <div class="servicesright1">
                <div id="divCatService" runat="server">
                    <p>
                    </p>
                </div>
            </div>
        </div>
        <div class="dataListDiv">
            <p>
                Fritzy's Pet Care Pros offer the following services for your cat:</p>
            <%--  Data list is use to bind all services of cat end--%>
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <asp:DataList ID="dlCat" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
                        CellSpacing="0">
                        <ItemTemplate>
                            <div class="news">
                                <div class="servicesImages">
                                    <asp:Image ID="Image1" ImageUrl="~/Images/catPaw.jpg" runat="server" AlternateText=" " /></div>
                                <div class="overflowDiv">
                                    <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%#(ConfigurationManager.AppSettings["HomePath"] .ToString() + Eval("ServicePageNames") ) %>'
                                        Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                                    <div style="margin: 4px 0;">
                                    </div>
                                    <asp:Label ID="lblDesc" CssClass="description" Text='<%#Eval("ServiceDescription") %>'
                                        runat="server"></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div class="prevNext" id="divprevNextCat" runat="server">
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnkPrev_Cat" runat="server" Text="Previous" ToolTip="Previous"
                                    OnClick="lnkPrev_Cat_Click" CssClass="prevlink"></asp:LinkButton></li>
                            <li>
                                <asp:Label ID="lblLink_Cat" runat="server" Text="|"></asp:Label>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnkNext_Cat" runat="server" Text="Next" ToolTip="Next" OnClick="lnkNext_Cat_Click"
                                    CssClass="prevlink"></asp:LinkButton></li>
                        </ul>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--  Data list is use to bind all services of cat end--%>
        </div>
    </div>
    <%--  Data list is use to bind all services of dog end--%>
    <div class="ServicesinnerMidPannel">
        <asp:Image ID="imgDivider" ImageUrl="~/images/midDivider.jpg" runat="server" AlternateText=" " />
    </div>
   <div class="ServicesinnerPannelRight">
        <div class="innerTitle">
            <img src="images/for_your_dogs_title.jpg" alt="Dog Grooming, Cat Grooming" />
        </div>
        <%--Region for Service header that is main service set from admin--%>
        <div class="topDatalistDiv">
            <div class="left1">
                <asp:Image ID="ImgDog" runat="server" AlternateText=" " />
            </div>
            <div class="servicesright1">
                <div id="divDogService" runat="server">
                    <p>
                    </p>
                </div>
            </div>
        </div>
        <div class="dataListDiv">
            <p>
                Fritzy's Pet Care Pros offer the following services for your dog:</p>
            <%--  Data list is use to bind all services of dog start--%>
            <asp:UpdatePanel ID="up2" runat="server">
                <ContentTemplate>
                    <asp:DataList ID="dlDog" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
                        CellSpacing="0">
                        <ItemTemplate>
                            <div class="news">
                                <div class="servicesImages">
                                    <asp:Image ID="Image1" ImageUrl="~/Images/dogPaw.jpg" runat="server" AlternateText=" " /></div>
                                <div class="overflowDiv">
                                    <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%#(ConfigurationManager.AppSettings["HomePath"] .ToString() + Eval("ServicePageNames") ) %>'
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
                                    ToolTip="Previous" CssClass="prevlink"></asp:LinkButton></li>
                            <li>
                                <asp:Label ID="lblDivider" runat="server" Text="|"></asp:Label>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnkNext" runat="server" Text="Next" OnClick="lnkNext_Click" ToolTip="Next"
                                    CssClass="prevlink"></asp:LinkButton></li>
                        </ul>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
