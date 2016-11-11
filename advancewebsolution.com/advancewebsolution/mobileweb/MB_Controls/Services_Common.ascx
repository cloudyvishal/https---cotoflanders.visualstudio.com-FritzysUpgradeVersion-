<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_Services_Common" Codebehind="Services_Common.ascx.cs" %>

<div class="contentinnersection">
    <div class="innerpageheading">
        <h1>
            Mobile Grooming Services<br />
            For Your Dogs</h1>
    </div>
    <div class="innercontent">
        <div class="productlistdiv">
            <div class="productimg">
                <asp:Image ID="ImgDog" runat="server" Height="62" Width="73" AlternateText=" " />
            </div>
            <div class="product_shortdesc" id="divDogService" runat="server">
                <p>
                    Keep your pet looking great between regular appointments with our brush-out service.
                </p>
            </div>
            <div style="clear: both;">
            </div>
            <asp:DataList ID="dlDog" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
                CellSpacing="0">
                <ItemTemplate>
                    <div class="news">
                        <div class="servicesImages">
                            <asp:Image ID="Image1" ImageUrl="~/Images/dogPaw.jpg" runat="server" AlternateText=" " /></div>
                        <div class="overflowDiv">
                            <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server"
                                   NavigateUrl='<%# "~/mobileweb/"+ Eval("ServicePageNames") %>' 
                                 
                                Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                            <div style="margin: 4px 0;">
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="innerpageheading">
        <h1>
            For Your Cats</h1>
    </div>
    <div class="innercontent">
        <div class="productlistdiv">
            <div class="productimg">
                <asp:Image ID="imgCatservice" Height="62" Width="73" runat="server" AlternateText=" " />
            </div>
            <div class="product_shortdesc" id="divCatService" runat="server">
                <p>
                    Keep your pet looking great between regular appointments with our brush-out service.
                </p>
            </div>
            <div style="clear: both;">
            </div>
            <asp:DataList ID="dlCat" runat="server" RepeatColumns="1" Width="100%" CellPadding="0"
                CellSpacing="0">
                <ItemTemplate>
                    <div class="news">
                        <div class="servicesImages">
                            <asp:Image ID="Image1" ImageUrl="~/Images/catPaw.jpg" runat="server" AlternateText=" " /></div>
                        <div class="overflowDiv">
                            <asp:HyperLink ID="hypService" CssClass="newstitle" runat="server"
                                  NavigateUrl='<%# "~/mobileweb/"+ Eval("ServicePageNames") %>' 
                              
                                Text='<%#Eval("ServiceTitle") %>'></asp:HyperLink>
                            <div style="margin: 4px 0;">
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</div>
