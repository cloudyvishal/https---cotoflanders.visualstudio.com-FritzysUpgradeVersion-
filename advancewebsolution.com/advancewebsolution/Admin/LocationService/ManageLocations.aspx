<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_LocationService_ManageLocations" Title="Admin - Manage Locations Serviced" Codebehind="ManageLocations.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript" language="javascript" >
function ShowDiv()
{
    document.getElementById('<%=divShow.ClientID %>').style.display = "Block";
    return false;
}

function HideDiv()
{
    document.getElementById('<%=divShow.ClientID %>').style.display = "none";
    return false;
}
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
                    <h2>Manage Locations Serviced</h2>
                </div>
            <asp:Label ID="lblErromessage" runat="server" Visible="false" ></asp:Label>
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
                                    <asp:ListItem Value="1" Text="Service ZipCode"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="ZipType"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="City"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="State"></asp:ListItem>
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
            </td>
        </tr>
    </table>
        <%--Region Error/Success message end--%>
        
        <%-- Region  grid start--%>
    <asp:GridView ID="GrdLocationService" runat="server" DataKeyNames="ZipCodeID" AutoGenerateColumns="False"
        AllowSorting="true" AllowPaging="true" PageSize="50" OnPageIndexChanging="GrdLocationService_PageIndexChanging"
        CellPadding="0" CellSpacing="0" GridLines="Vertical" Width="100%" OnDataBound="GrdLocationService_DataBound" OnRowCreated="GrdLocationService_RowCreated" OnSorting="GrdLocationService_Sorting"
        HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle">
         <PagerTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
                <asp:Label ID="pmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Page" CommandArgument="Prev">Prev</asp:LinkButton>
                <asp:LinkButton ID="p0" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p1" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p2" runat="server" >LinkButton</asp:LinkButton>
                <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="p4" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p5" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p6" runat="server" >LinkButton</asp:LinkButton>
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
            <asp:TemplateField HeaderText="Service Zipcode" SortExpression="ZipCode">
                <HeaderStyle CssClass="headerStyle" />
                <ItemStyle CssClass="itemstyle" />
                <ItemTemplate>
                    <asp:Label ID="lblZipCode" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Zip Type" SortExpression="ZipType">
                <ItemStyle CssClass="itemstyle" Width="15%" />
                <HeaderStyle CssClass="headerStyle" />
                <ItemTemplate>
                    <asp:Label ID="lblZip" runat="server" Text='<%# Bind("ZipType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City" SortExpression="City">
                <ItemStyle CssClass="itemstyle" Width="15%" />
                <HeaderStyle CssClass="headerStyle" />
                <ItemTemplate>
                    <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="State" SortExpression="State">
                <ItemStyle CssClass="itemstyle" Width="10%" />
                <HeaderStyle CssClass="headerStyle" />
                <ItemTemplate>
                    <asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Available" SortExpression="Available">
                <ItemStyle CssClass="itemstyle" Width="12%" />
                <HeaderStyle CssClass="headerStyle" />
                <ItemTemplate>
                    <asp:Label ID="lblAvailable" runat="server" Text='<%# Bind("Available") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
                    
                  
                </asp:GridView>
           <%-- Region  grid end --%>  
           
           <%--region button starts --%>
    <asp:Button ID="btnAdd" runat="server" Text="Add Service Location" CssClass="btnBg"
        ToolTip="Add Service Location" PostBackUrl="~/Admin/LocationService/AddServiceLocation.aspx" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnBg" ToolTip="Delete"
        OnClick="btnDelete_Click" />
    <asp:Button ID="btnAvailable" runat="server" Text="Available/UnAvailable" CssClass="btnBg"
        ToolTip="Available/UnAvailable" OnClick="btnAvailable_Click" />
        
         <asp:Button ID="btnExport" runat="server" Text="Export" CssClass="btnBg"
        ToolTip="Export" OnClick="btnExport_Click" />
        
          <asp:Button ID="btnImport" runat="server" Text="Import" CssClass="btnBg" OnClientClick="return ShowDiv();" ToolTip="Import" />
        
       <%--region button end --%>
       
    <div id="divShow" runat="server" style="display: none; margin:10px 0 0 0;" class="itemstyle">
        <table>
            <tr>
                <td>
                    <span class="star" style="color:#f00;">*</span>Upload file
                </td>
                <td>
                    <input id="flUpload" runat="server" type="file" onkeypress="return false;" />
                </td>
                <td >
                    <asp:Button ID="btnUpload" Text="Upload" runat="server" CssClass="servbtnBg" border="0" OnClick="btnUpload_Click" />
                    <asp:Button ID="btnHide" Text="Cancel" runat="server" CssClass="servbtnBg" border="0" OnClientClick="return HideDiv();"/>
                </td>
            </tr>
        </table>
    </div>
    
    
    <asp:Button ID="lnkNorec" runat="server" CssClass="btnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
   
</div>
</asp:Content>

