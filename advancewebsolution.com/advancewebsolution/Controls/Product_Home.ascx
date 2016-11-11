<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_Product_Home" Codebehind="Product_Home.ascx.cs" %>
<div class="ServicesInnerDatalistDiv">
    <%--  Data list is use to bind all services of cat Start --%>
    <asp:DataList ID="dlProducts" runat="server" RepeatColumns="2" Width="100%" CellPadding="0"
        RepeatDirection="Vertical" CellSpacing="0" OnItemDataBound="dlProducts_ItemDataBound">
        <ItemTemplate>
            <div class="innerPannelLeft">
                <div class="left1">
                    <img alt="Image Product yes" src="#" runat="server" id="ImgProduct" />
                    <asp:Label ID="lblImage" Text='<%#Eval("ImageName") %>' Visible="false" runat="server"></asp:Label>
                </div>
                <div class="right">
                    <span>
                        <asp:Label ID="lblProductName" Text='<%#Eval("ProductName") %>' runat="server"></asp:Label></span>
                    <div id="divProducts" runat="server" class="innerParaDiv">
                        <br />
                        <p>
                            <asp:Label ID="lblProductDescription" Text='<%#Eval("ProductDescription") %>' runat="server"></asp:Label>
                        </p>
                    </div>
                    <img src="images/spacer.gif" width="1" height="6" alt="" class="spacer" />
                    <span class="bluebold">Our Price: $
                        <asp:Label ID="Label1" Text='<%# String.Format("{0:F}", Eval("Price")) %>' runat="server"></asp:Label></span>
                    <br />
                    <br />
                    <a href="Contactus.aspx" title="Buy"><img src="Images/btn_buy.gif" width="53" height="20"
                            alt="Buy" />
                    </a>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <%--  Data list is use to bind all services of cat End --%>
</div>
