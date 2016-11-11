<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" EnableViewStateMac="false" Inherits="Admin_Baner_ManageBanner"
    Title="Manage Banner" Codebehind="ManageBanner.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Banner</h2>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" BorderWidth="1px" BorderColor="red"
            ForeColor="red" runat="server" />
            <%--Div Error Start--%>
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
            <%--Div Error End--%>
        
            <%--Upload Banner and coupon Start--%>
        <table border="0" class="setservPage">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlPetType" runat="server" AutoPostBack="true" Visible="false"
                        OnSelectedIndexChanged="ddlPetType_SelectedIndexChanged">
                        <asp:ListItem Value="1" Text="Cat"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Dog"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Cat & Dog"></asp:ListItem>
                    </asp:DropDownList>
                    Select Banner :
                </td>
                <td>
                    <asp:FileUpload ID="flv" runat="server" onkeypress="return false" />
                </td>
            </tr>
            <tr>
                <td>
                    Select Coupon :
                </td>
                <td>
                    <asp:FileUpload ID="FlvCoupon" runat="server" onkeypress="return false" />
                    &nbsp; (Optional)
            </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnUp" runat="server" Text="Upload Banner" CssClass="servbtnBg" OnClick="btnUp_Click" />
                </td>
            </tr>
        </table>
            <%--Upload Banner and coupon End--%>
        
        <%--Gred Banner and coupon Start--%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
        </table>
        <asp:GridView ID="GrdBaner" runat="server" AutoGenerateColumns="False" AllowSorting="true"
            AllowPaging="true" PageSize="5" DataKeyNames="imagePath" CellPadding="0" GridLines="Vertical"
            Width="100%" OnPageIndexChanging="GrdBaner_PageIndexChanging" HeaderStyle-CssClass="headerStyle"
            CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowDataBound="GrdBaner_RowDataBound">
            <AlternatingRowStyle CssClass="altGridStyle" />
            <PagerStyle CssClass="gridPager" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Banner Name">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblImageName" runat="server" Text='<%# Bind("imagePath") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <%--Gred Banner and coupon End--%>
        <%--Button Banner and coupon Delete--%>
        <asp:Label ID="lblNorecNo" runat="server" Visible="false" Text="No record found"></asp:Label>
        <asp:Button ID="btnDelete" CssClass="servbtnBg" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <%--Button Banner and coupon Delete--%>
    </div>
</asp:Content>
