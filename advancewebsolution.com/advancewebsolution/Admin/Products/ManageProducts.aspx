<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Products_ManageProducts" Title="Admin - Product" Codebehind="ManageProducts.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script type="text/javascript" language="javascript" >
function validate()
{
    if(document.getElementById('<%=ddlSearch.ClientID %>').value == "0")
    {
        alert("Please select search criteria");
        return false;
    }
     if(document.getElementById('<%=txtSearch.ClientID %>').value == "")
    {
        alert("Please enter search text");
        return false;
    }
}
</script>
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Products</h2>
        </div>
        <div class="previewLinkDiv">
        <asp:LinkButton id="btnPreview" runat="server"  Text="Preview" ToolTip="Preview" OnClick="btnPreview_Click1"></asp:LinkButton>
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
        
        <div id="divsearch" runat="server" class="searchtopDiv">
                <table border="0" class="searchTable">
                <tr>
                    
                    <td>
                        <asp:DropDownList ID="ddlSearch" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Product Name"></asp:ListItem>
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
            </table><br style="clear:both;" />
        </div>
        <%--Region Error/Success message end--%>
        <asp:GridView ID="GrdProducts" runat="server" AutoGenerateColumns="False" 
            CellPadding="0" PageSize="10" 
            AllowSorting="true" AllowPaging="True" DataKeyNames="ProductID" GridLines="Vertical"
            Width="100%" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" 
            AlternatingRowStyle-CssClass="altGridStyle"  
            PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" 
            PagerSettings-NextPageText="next"  PagerSettings-PreviousPageText="prev" 
            onpageindexchanging="GrdProducts_PageIndexChanging"  PagerSettings-Mode="NumericFirstLast"
            onsorting="GrdProducts_Sorting" onrowdatabound="GrdProducts_RowDataBound">
           
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
                <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                    DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="EditProducts.aspx?ProductID={0}"
                    DataTextField="ProductName" HeaderText="Product Name" SortExpression="ProductName"></asp:HyperLinkField>
                <asp:TemplateField HeaderText="Description" SortExpression="ProductDescription" Visible="false">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblProductDescription" runat="server" Text='<%# Bind("ProductDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Added On" SortExpression="AddedOn" >
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddedon" runat="server" Text='<%# Bind("AddedOn", "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Home Product" SortExpression="IsHome">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblHome" runat="server" Text='<%# Bind("IsHome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Flea Product" SortExpression="IsFlea">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblFlea" runat="server" Text='<%# Bind("IsFlea") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Order" >
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                            <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlList" runat="server" AutoPostBack="true" onselectedindexchanged="ddlList_SelectedIndexChanged" ></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Order" Visible="false" >
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                            <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server"  Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
               <asp:TemplateField HeaderText="Order" Visible="false" >
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                            <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPosition" runat="server"  Text='<%# Bind("Position") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
            </Columns>
        </asp:GridView>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnNew" runat="server" Text="Add" ToolTip="Add" CssClass="btnBg"
                        OnClick="btnNew_Click" />
                </td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg"
                        OnClick="btnDelete_Click" />
                </td>
                <td>
                    <asp:Button ID="btnStatus" runat="server" Text="Active/Inactive" ToolTip="Active/Inactive"
                        CssClass="btnBg" OnClick="btnStatus_Click" />
                </td>
                
                <td>
                    <asp:Button ID="btnHome" runat="server" Text="Set Home Product" ToolTip="Set Home Product"
                        CssClass="btnBg" OnClick="btnHome_Click" />
                </td>
                
                <td>
                    <asp:Button ID="btnFlea" runat="server" Text="Set Flea Product" ToolTip="Set Flea Product"
                        CssClass="btnBg" OnClick="btnFlea_Click" />
                </td>
                
                 
            </tr>
        </table>
         <asp:Button ID="lnkNorec" runat="server" CssClass="btnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
</asp:Content>
