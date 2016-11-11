<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="ManageGroomer" Title="Admin - Manage Groomers" Codebehind="ManageGroomer.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">


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
                Manage Groomers</h2>
        </div>
        <%--Region Error/Success message start--%>
        <table>
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server" visible="false">
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
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divsearch" runat="server" class="searchtopDiv">
                        <table border="0" class="searchTable">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSearch" runat="server">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Email"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Name"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="return validate();"
                                        ToolTip="SEARCH" OnClick="btnSearch_Click" CssClass="servbtnBg" />
                                </td>
                                <td>
                                    <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="VIEW ALL" CssClass="servbtnBg"
                                        OnClick="btnViewall_Click" />
                                </td>
                            </tr>
                        </table>
                        <div style="clear: both;">
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <br style="clear: both;" />
        <%--Region Error/Success message end--%>
        <%-- Region  grid start--%>
        <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="GID" AutoGenerateColumns="False"
            AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GrdUsers_PageIndexChanging"
            OnSorting="GrdUsers_Sorting" OnDataBound="GrdUsers_DataBound" OnRowCreated="GrdUsers_RowCreated"
            PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
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
            <AlternatingRowStyle CssClass="altGridStyle" />
            <PagerStyle CssClass="gridPager" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" Wrap="False" />
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
                <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                    DataNavigateUrlFields="GID" DataNavigateUrlFormatString="EditGroomer.aspx?GID={0}&p=1"
                    DataTextField="Name" HeaderText="Name" SortExpression="Name" HeaderStyle-Wrap="False" ItemStyle-Wrap="false"></asp:HyperLinkField>
                <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                    DataNavigateUrlFields="GID" DataNavigateUrlFormatString="EditGroomer.aspx?GID={0}&p=1"
                    DataTextField="UserName" HeaderText="Email" SortExpression="UserName" HeaderStyle-Wrap="False" ItemStyle-Wrap="false"></asp:HyperLinkField>
                <asp:TemplateField HeaderText="Base City" SortExpression="BaseCity">
                    <ItemStyle CssClass="itemstyle" Width="30%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("BaseCity")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone 1">
                    <ItemStyle CssClass="itemstyle" Width="20%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Bind("HomePhone")%>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone 2">
                    <ItemStyle CssClass="itemstyle" Width="20%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPersonalCellPhone" runat="server" Text='<%# Bind("PersonalCellPhone")%>'>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Time Zone">
                    <ItemStyle CssClass="itemstyle" Width="20%"  Wrap="False" />
                    <HeaderStyle CssClass="headerStyle"  Wrap="False" />
                    <ItemTemplate >
                        <asp:Label ID="lblTimeZones" runat="server" Text='<%# Bind("GTimeZone")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Added On" SortExpression="AddedOn" Visible="false">
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblGroomeraddedon" runat="server" Text='<%# Bind("AddedOn" , "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%-- Region  grid end --%>
        <%--region button start--%>
        <div id="divBtn" runat="server" style="display: block;">
            <asp:Button ID="btnAdd" runat="server" Text="Add" ToolTip="Add Groomers" CssClass="btnBg"  PostBackUrl="~/Admin/Groomer/AddGroomer.aspx" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg"  OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="lnkNorec" runat="server" CssClass="btnBg" Text="Go Back" Visible="false"   OnClick="lnkNorec_Click" />
            <%--region button end --%>
        </div>
    </div>
</asp:Content>
