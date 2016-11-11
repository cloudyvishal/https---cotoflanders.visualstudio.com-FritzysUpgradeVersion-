<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="ManageBaners" Title="Admin - Manage Banners" Codebehind="ManageBaners.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Banners</h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br style="clear: both;" />
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 15%;">
                    Select Page :
                </td>
                <td>
                    <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                       
                        <asp:ListItem Value="0" Text="Home"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Services"></asp:ListItem>
                        <asp:ListItem Value="2" Text="ServiceDetail"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Product"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Flea"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Fritzy Friend"></asp:ListItem>
                        <asp:ListItem Value="6" Text="About Us"></asp:ListItem>
                        <asp:ListItem Value="7" Text="Contact Us"></asp:ListItem>
                        <asp:ListItem Value="8" Text="Registration"></asp:ListItem>
                        <asp:ListItem Value="9" Text="News Detail"></asp:ListItem>
                        <asp:ListItem Value="10" Text="Default"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    User Type :
                </td>
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="Unregistered User"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Registered User - Cat"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Registered User - Dog"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Registered User - Cat & Dog"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        
       
       
        <h3>
            Banners Sequence</h3>
        <br />
        <asp:DataList ID="dtlOrder" runat="server" RepeatColumns="10" RepeatDirection="Horizontal"
            OnItemDataBound="dtlOrder_ItemDataBound">
            <ItemTemplate>
                <table cellpadding="4" cellspacing="1" class="mngbnrTable">
                    <tr>
                        <td>
                            <asp:Label Width="40px" ID="lblSrNo" runat="server"></asp:Label>
                            <asp:TextBox Width="60px" ID="txtId" MaxLength="6" Text='<%# Bind("BannerId") %>'
                                runat="server" CssClass="usertextBox"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="ftbBannerId" runat="server" TargetControlID="txtId"
                                FilterType="Numbers" />
                            <asp:CheckBox Width="40px" ID="chkIsCOupon" runat="server" />
                            <asp:Label Width="40px" ID="lblPageName" Visible="false" Text='<%# Bind("pageName") %>'
                                runat="server"></asp:Label>
                            <asp:Label Width="40px" ID="lblIsCoupon" Visible="false" Text='<%# Bind("IsCoupon") %>'
                                runat="server"></asp:Label>
                            <asp:Label Width="40px" ID="lblId" Visible="false" Text='<%# Bind("Id") %>' runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Set Banners" OnClick="btnSave_Click"
            CssClass="servbtnBg" />
        <br />
        <img src="../images/seperator.jpg" alt="" />
        <br />
        <h3>
            Banner List</h3><br />
           
        <asp:Panel ID="PnlImport" runat="server" CssClass="bannerlist_panel">
            <asp:DataList ID="dtBannerlIst" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" CssClass="BanerList">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="BanerList" border="0">
                        <tr>
                            <td>
                                <asp:Label Width="40px" ID="lblSrNo" runat="server" Visible="false"></asp:Label>
                                <img alt="Image" width="138" height="60" src='<%#Bind("BannerPath") %>' runat="server"
                                    id="imgThumb" /><br />
                                <asp:Label ID="Label1" CssClass="lblBannernumber" runat="server" Text='<%#Bind("BId") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
    </div>
</asp:Content>
