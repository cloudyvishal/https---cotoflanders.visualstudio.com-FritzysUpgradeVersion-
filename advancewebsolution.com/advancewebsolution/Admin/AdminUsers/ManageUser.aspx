<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Users_ManageUser" Title="Admin - Manage Users" Codebehind="ManageUser.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById('<%=ddlSearch.ClientID %>').value == "0") {
                alert("Please select search criteria");
                return false;
            }
            if (document.getElementById('<%=txtSearch.ClientID %>').value == "") {
                alert("Please enter search text");
                return false;
            }
        }
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Admin Users</h2>
        </div>
        <%--Region Error/Success message start--%>
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
        <%--Region Error/Success message end--%>
        <div id="divsearch" runat="server" class="searchtopDiv">
            <table border="0" class="searchTable">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSearch" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="User Name"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Email"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="servbtnBg" OnClientClick="return validate();"
                            OnClick="btnSearch_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="VIEW ALL" CssClass="servbtnBg"
                            OnClick="btnViewall_Click" />
                    </td>
                </tr>
            </table>
            <br style="clear: both;" />
        </div>
        <%-- Region  grid start--%>
        <asp:GridView ID="GrdUser" runat="server" DataKeyNames="UserID" AutoGenerateColumns="False"
            AllowSorting="true" AllowPaging="true" PageSize="10" OnPageIndexChanging="GrdUser_PageIndexChanging"
            CellPadding="0" CellSpacing="0" GridLines="Vertical" Width="100%" OnSorting="GrdUser_Sorting"
            HeaderStyle-CssClass="headerStyle" OnDataBound="GrdUser_DataBound" OnRowCreated="GrdUser_RowCreated"
            CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle">
            <PagerTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
                <asp:Label ID="pmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Page" CommandArgument="Prev">Prev</asp:LinkButton>
                <asp:LinkButton ID="p0" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p1" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p2" runat="server">LinkButton</asp:LinkButton>
                <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="p4" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p5" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p6" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Page" CommandArgument="Next">Next</asp:LinkButton>
                <asp:Label ID="nmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Page" CommandArgument="Last">Last</asp:LinkButton>
            </PagerTemplate>
            <HeaderStyle CssClass="headerStyle"></HeaderStyle>
            <AlternatingRowStyle CssClass="altGridStyle" />
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
                <asp:HyperLinkField SortExpression="Username" ItemStyle-CssClass="itemstyle manageuser"
                    HeaderStyle-CssClass="headerStyle" DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="EditAdminUser.aspx?UserId={0}"
                    DataTextField="Username" HeaderText="Username">
                    <HeaderStyle CssClass="headerStyle"></HeaderStyle>
                    <ItemStyle CssClass="itemstyle manageuser"></ItemStyle>
                </asp:HyperLinkField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemStyle CssClass="itemstyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Added On" SortExpression="AddedOn">
                    <ItemStyle CssClass="itemstyle" Width="18%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("AddedOn") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Type">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblUserType" runat="server" Text='<%# Bind("UserType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="gridPager" />
        </asp:GridView>
        <%-- Region  grid end --%>
        <%--region button starts --%>
        <asp:Button ID="btnAdd" runat="server" Text="Add User" CssClass="btnBg" ToolTip="Add User"
            PostBackUrl="~/Admin/AdminUsers/AddUser.aspx" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnBg" ToolTip="Detlete"
            OnClick="btnDelete_Click" />
        <asp:Button ID="btnStatus" runat="server" Text="Active/Inactive" CssClass="btnBg"
            ToolTip="Active/Inactive" OnClick="btnStatus_Click" />
        <%--region button end  --%>
        <asp:Button ID="lnkNorec" runat="server" style="padding:5px;" CssClass="servbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
    </div>
</asp:Content>
