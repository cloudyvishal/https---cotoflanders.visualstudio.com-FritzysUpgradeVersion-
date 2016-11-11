<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_StaticWebPages" Title="Admin - Manage Web Pages" Codebehind="StaticWebPages.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Static Web Pages</h2>
        </div>
        <asp:GridView ID="GrdFileManager" runat="server" Width="100%" GridLines="Horizontal"
            CellPadding="4" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle"
            AutoGenerateColumns="False">
            <AlternatingRowStyle CssClass="altGridStyle" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField HeaderText="Page Name" ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                    DataNavigateUrlFields="FilePath" DataNavigateUrlFormatString="ViewPage.aspx?File={0}"
                    DataTextField="PageName" NavigateUrl="ViewPage.aspx" />
                 
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
