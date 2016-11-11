<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="MB_aboutus" Title="Mobile Grooming Services" Codebehind="MB_aboutus.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>
                About Us</h1>
        </div>
        <div class="innercontent">
            <img src="images/about_us_image.jpg" height="71" width="73" alt="" />
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
            <div class="servicetitle">
                Pet Care Pros News:
            </div>
            <asp:DataList ID="dtlNews" DataKeyField="NewsID" runat="server" RepeatColumns="1"
                Width="100%" OnItemDataBound="dtlNews_ItemDataBound" CellPadding="0" CellSpacing="0">
                <ItemTemplate>
                    <div class="news">
                        <div class="servicesImages">
                            <asp:Image ID="Image1" ImageUrl="~/Images/catPaw.jpg" runat="server" AlternateText=" " /></div>
                        <div class="ServicesCatsoverflowDiv">
                            <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server" NavigateUrl='<%# "MB_newsdetail.aspx?ID=" + Eval("NewsID") %>'
                                Text='<%#Eval("NewsTitle") %>'></asp:HyperLink>
                          
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
