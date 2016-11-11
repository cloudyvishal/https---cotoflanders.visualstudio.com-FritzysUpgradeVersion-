<%@ Control Language="C#" AutoEventWireup="true" Inherits="Admin_Controls_Header" Codebehind="Header.ascx.cs" %>
<table border="0" width="100%" cellpadding="0" cellspacing="0">
    <tr style="background-color: #997a52;">
        <td id="toplinks">
            <asp:Image ID="IMG1" runat="server" ImageUrl="~/Images/logo.gif" /></td>
        <td valign="bottom" align="right">
            <ul>
                <li>Welcome :
                    <asp:Label ID="lblUsername" runat="server"> </asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTDate" runat="server"> </asp:Label></li>
            </ul>
        </td>
    </tr>
    <tr style="height: 3px">
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" class="staticmenu" colspan="2">
            <asp:Menu ID="Menu_admin" Width="400px" Height="20px" runat="server" Orientation="Horizontal"
                OnMenuItemClick="Menu_admin_MenuItemClick" StaticEnableDefaultPopOutImage="false"
                BorderWidth="1px" ScrollDownText="asdf">
                <Items>
                    <asp:MenuItem NavigateUrl="~/Admin/Default.aspx" Text="Home" Value="Home"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Admin/Users/ManageUser.aspx" Text="Profile">
                        <asp:MenuItem NavigateUrl="~/Admin/Users/ManageUser.aspx" Text="User Manager" Value="ManageUser">
                        </asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Admin/Users/ManageUser.aspx" Text="Static Content" Value="static">
                        <asp:MenuItem NavigateUrl="~/Admin/AboutUs.aspx" Text="About Us" Value="About Us"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Admin/ContactUs.aspx" Text="About Us" Value="About Us"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Admin/Users/ManageUser.aspx" Text="Dog" Value="Dog"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Admin/Services/ManageServices.aspx" Text="Services"
                        Value="Services"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Admin/Friends/ManageFriends.aspx" Text="Friends" Value="Friends">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Admin/News/ManageNews.aspx" Text="News" Value="News"></asp:MenuItem>
                    <asp:MenuItem Text="VisitVan" Value="VisitVan" NavigateUrl="~/Admin/VisitVan.aspx" ></asp:MenuItem>
                    <asp:MenuItem Text="Logout" Value="Logout"></asp:MenuItem>
                </Items>
                <StaticSelectedStyle BackColor="#5D7B9D" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                <DynamicMenuStyle BackColor="#F7F6F3" />
                <DynamicSelectedStyle BackColor="#5D7B9D" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            </asp:Menu>
        </td>
    </tr>
</table>
