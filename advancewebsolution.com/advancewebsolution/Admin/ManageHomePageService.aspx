<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ManageHomePageService"
    Title="Admin - Home Page Services" Codebehind="ManageHomePageService.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Home Page Services</h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table class="setservPage">
            <tr>
                <td>
                    User Type :
                </td>
                <td>
                    <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" 
                        OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="Registerd User - Cat"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Registerd User - Dog"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Registerd User - Cat & Dog"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Unregistered"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GrdServiceHome" runat="server" DataKeyNames="ServiceID" AutoGenerateColumns="False"
            PageSize="5" CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
            CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowDataBound="GrdServiceHome_RowDataBound">
            <AlternatingRowStyle CssClass="altGridStyle" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                    DataNavigateUrlFields="ServiceID" DataNavigateUrlFormatString="EditService.aspx?ServiceID={0}"
                    DataTextField="Title" HeaderText="Service Title" SortExpression="Title"></asp:HyperLinkField>
                <asp:TemplateField HeaderText="Service Description">
                    <ItemStyle CssClass="itemstyle" Width="40%" />
                    <HeaderStyle CssClass="headerStyle" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblServiceFor" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Service For">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPetType" runat="server" Text='<%# Bind("PetType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Service For" Visible="false">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblImageName" runat="server" Text='<%# Bind("ImageName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <ItemStyle CssClass="itemstyle"/>
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <img id="ImageCoupon" alt="ImageService"  src="#" runat="server" width="80" height="80" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
