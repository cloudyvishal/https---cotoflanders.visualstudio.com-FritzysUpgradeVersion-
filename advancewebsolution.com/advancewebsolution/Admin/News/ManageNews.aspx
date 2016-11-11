<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false" AutoEventWireup="true" Inherits="Admin_News_ManageNews" Title="Admin - Manage About us Content" Codebehind="ManageNews.aspx.cs" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

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
            <h2>Manage About us Content</h2>
        </div>
        <div class="previewLinkDiv">
            <asp:LinkButton ID="btnPreview" runat="server" Text="Preview" ToolTip="Preview"  OnClick="btnPreview_Click"></asp:LinkButton>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td colspan="2">
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server"></FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg" OnClick="btnSave_Click" />&nbsp;
       <br />
        <br />
        <div class="pageTitle">
            <h2>Manage Pet Care Pros</h2>
        </div>

        <div class="errorDiv" id="divError1" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError1" runat="server" Visible="False"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div id="divsearch" runat="server" class="searchtopDiv">
            <table border="0" class="searchTable">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSearch" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="News Title"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="servbtnBg" OnClientClick="return validate();" OnClick="btnSearch_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="VIEW ALL" CssClass="servbtnBg" OnClick="btnViewall_Click" />
                    </td>
                </tr>
            </table>
            <br style="clear: both;" />
        </div>


        <div class="paddingDiv">
            <asp:GridView ID="GrdNews" runat="server" DataKeyNames="NewsID" AutoGenerateColumns="False"
                AllowSorting="true" AllowPaging="true" PageSize="10" CellPadding="0" 
                GridLines="Vertical" Width="100%" OnPageIndexChanging="GrdNews_PageIndexChanging" OnSorting="GrdNews_Sorting"
                OnDataBound="GrdNews_DataBound" OnRowCreated="GrdNews_RowCreated" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle"
                AlternatingRowStyle-CssClass="altGridStyle" OnRowDataBound="GrdProducts_RowDataBound">
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

                    <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle" DataNavigateUrlFields="NewsID" DataNavigateUrlFormatString="EditNews.aspx?NewsID={0}"
                        DataTextField="NewsTitle" HeaderText="News Title" SortExpression="NewsTitle"></asp:HyperLinkField>

                    <asp:TemplateField HeaderText="Added On" SortExpression="Addedon">
                        <ItemStyle CssClass="itemstyle" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblShortDescription" runat="server" Text='<%# Bind("Addedon", "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlList_SelectedIndexChanged"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("NewsID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Order" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblPosition" runat="server" Text='<%# Bind("Position") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>

        <%-- Region  grid end--%>
        <%-- Region Button starts --%>
        <%-- <div class="buttondiv">--%>
        <asp:Button ID="btnAdd" runat="server" CssClass="btnBg" Text="Add News" ToolTip="Add News" PostBackUrl="~/Admin/News/AddNews.aspx" />
        <asp:Button ID="btnDelete" runat="server" CssClass="btnBg" Text="Delete" ToolTip="Detlete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnStatus" runat="server" CssClass="btnBg" Text="Active/Inactive" ToolTip="Active/Inactive" OnClick="btnStatus_Click" />
        <%--  </div>--%>
        <%-- Region Button starts --%>
        <asp:Button ID="lnkNorec" runat="server" CssClass="servbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />

    </div> 

</asp:Content>

