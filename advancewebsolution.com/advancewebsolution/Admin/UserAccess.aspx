<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_UserAccess" Title="Admin - User Access" Codebehind="UserAccess.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function showAddBreed() {
            document.getElementById('<%=divAddBreed.ClientID %>').style.display = "block";
            document.getElementById('<%=DivlnkShowBreed.ClientID %>').style.display = "none";
            return false;
        }
        function HideAddBreed() {
            document.getElementById('<%=divAddBreed.ClientID %>').style.display = "none";
            document.getElementById('<%=DivlnkShowBreed.ClientID %>').style.display = "block";
            return false;
        }
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Admin User Access</h2>
        </div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
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
        <asp:GridView ID="grdAccess" runat="server" AutoGenerateColumns="False" CellPadding="0"
            AllowSorting="true" AllowPaging="True" DataKeyNames="AccessID" GridLines="Vertical"
            Width="100%" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle"
            OnPageIndexChanging="grdAccess_PageIndexChanging">
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
                <asp:TemplateField HeaderText="User Type">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="UserType" runat="server" Text='<%# Bind("UserType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Module">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="Module" runat="server" Text='<%# Bind("Module") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Page Name">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="PageName" runat="server" Text='<%# Bind("PageName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Allow">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="Status" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div id="DivlnkShowBreed" runat="server" style="display: block">
            <asp:Button ID="btnNew" runat="server" Text="Add" ToolTip="Add" CssClass="btnBg"
                OnClientClick="return showAddBreed();" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg"
                OnClick="btnDelete_Click" />
            <asp:Button ID="btnStatus" runat="server" Text="Allow" ToolTip="Allow" CssClass="btnBg"
                OnClick="btnStatus_Click" />
        </div>
        <div id="divAddBreed" runat="server" style="display: none" class="itemstyle">
            User Type :
            <asp:DropDownList ID="ddlUserType" runat="server" CssClass="regddlField">
                <asp:ListItem Value="0">Admin</asp:ListItem>
                <asp:ListItem Value="1">SubAdmin</asp:ListItem>
            </asp:DropDownList>
            Module :
            <asp:DropDownList ID="ddlModule" runat="server" CssClass="regddlField">
                <asp:ListItem Value="ManageUser.aspx" Text="Manage Admin User"> </asp:ListItem>
                <asp:ListItem Value="Users.aspx" Text="Users"></asp:ListItem>
                <asp:ListItem Value="UserAccess.aspx" Text="Admin User Access"></asp:ListItem>
                <asp:ListItem Value="ManageServices.aspx" Text="Services"></asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="ImgSubmitService" runat="server" ValidationGroup="valBreed" CssClass="btnBg"
                Text="Add" ToolTip="Add" CausesValidation="true" OnClick="ImgSubmitService_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                ToolTip="Cancel" OnClientClick="return HideAddBreed();" CssClass="btnBg" />
        </div>
    </div>
</asp:Content>
