<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="Controls_SearchFriend" Codebehind="SearchFriend.ascx.cs" %>
<asp:UpdatePanel ID="upFriends" runat="server">
    <ContentTemplate>
        <div style="width: 640px;">
            <p>
                <asp:Label ID="lblTitleFriend" runat="server"></asp:Label></p>
            <asp:DataList ID="dlFriends" runat="server" RepeatColumns="1" Width="100%" CellPadding="0">
                <ItemTemplate>
                    <div class="friends">
                        <div class="imagesfriends">
                            <asp:Image ID="Image1" ImageUrl='<%# Session["HomePath"] + "StoreData/FriendLogo/" + Eval("Logo") %>'
                                runat="server" AlternateText="" />
                        </div>
                        <div class="overflowfriendsDiv">
                            <asp:HyperLink ID="hypURL" CssClass="friendsLink" Target="_blank" NavigateUrl='<%# "http://" + Eval("RefLink") %>'
                                Text='<%#Eval("RefLink") %>' runat="server"></asp:HyperLink>
                            <br />
                            <asp:Label CssClass="description" ID="lblDesc" Text='<%#Eval("Description") %>' runat="server"></asp:Label>
                        </div>
                    <li>
                        <asp:LinkButton ID="lnkFriendPrev" runat="server"></asp:LinkButton> </div>
                </ItemTemplate>
            </asp:DataList>
            <div class="prevNext" id="divprevNext" runat="server">
                <ul>
                        <li><asp:LinkButton runat="server" Text="Previous" ID="prevFriendlink" OnClick="prevFriendlink_Click"
                            CssClass="prevlink" ToolTip="Previous"></asp:LinkButton></li>
                    <li>
                        <asp:Label ID="lblFriendLine" runat="server" Text="|"></asp:Label>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnkFriendNext" runat="server" Text="Next" OnClick="lnkFriendNext_Click"
                            ToolTip="Next" CssClass="prevlink"></asp:LinkButton></li>
                </ul>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
            