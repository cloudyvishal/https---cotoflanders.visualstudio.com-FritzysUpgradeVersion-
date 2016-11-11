<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master"  validateRequest="false"  AutoEventWireup="true" Inherits="Admin_Friends_ManageFriends" Title="Admin - Manage Fritzy's Friends Content" Codebehind="ManageFriends.aspx.cs" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
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
        Manage Fritzy's Friends Content</h2>
    </div>
     <div class="previewLinkDiv">
                 <asp:LinkButton id="btnPreview" runat="server"  ToolTip="Preview" Text="Preview" OnClick="btnPreview_Click1"></asp:LinkButton>
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
    <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td colspan="2">
                   <%-- <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>--%>
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </table>
        
  <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="servbtnBg"
            OnClick="btnSave_Click" />
        
<br style="clear:both;" />

<div class="pageTitle" style="margin:20px 0 0 0;">
                    <h2>Manage Fritzy's Friends</h2>
                </div>

                <%--Region Error/Success message start--%>

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
         
        <%--Region Error/Success message end--%>
        <div id="divsearch" runat="server"  class="searchtopDiv">
            <table border="0" class="searchTable">
                <tr>
                    
                    <td>
                        <asp:DropDownList ID="ddlSearch" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Friends Title"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Ref Link"></asp:ListItem>
                                                         
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
            </table><br style="clear: both;" />
        </div>
<%-- Region  grid start--%>
                <asp:GridView ID="GrdFriends" runat="server" DataKeyNames="FriendID" AutoGenerateColumns="False"
                    AllowSorting="true" AllowPaging="true" PageSize="5" OnPageIndexChanging="GrdFriends_PageIndexChanging"
                     CellPadding="0" GridLines="Vertical" Width="100%" OnSorting="GrdFriends_Sorting" OnDataBound="GrdFriends_DataBound" 
                     OnRowCreated="GrdFriends_RowCreated" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" 
                     AlternatingRowStyle-CssClass="altGridStyle" onrowdatabound="GrdProducts_RowDataBound" >
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
                        
                        <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle" DataNavigateUrlFields="FriendID" DataNavigateUrlFormatString="EditFriends.aspx?FriendID={0}"
                            DataTextField="Title" HeaderText="Friends Title" SortExpression="Title">
                           
                        </asp:HyperLinkField>
                        
                        <asp:TemplateField HeaderText="Ref Link"  >
                          <ItemStyle CssClass="itemstyle"  />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblRefLink" runat="server" Text='<%# Bind("RefLink") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                             <ItemStyle CssClass="itemstyle"  Width="10%"/>
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
                        <asp:Label ID="lblID" runat="server"  Text='<%# Bind("FriendID") %>'></asp:Label>
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
            <%-- Region  grid end --%>  
            <%--region button starts --%> 


                <asp:Button ID="btnAdd" runat="server" Text="Add Friend" ToolTip="Add Friend" CssClass="btnBg" PostBackUrl="~/Admin/Friends/AddFriends.aspx" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg" OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnStatus" runat="server" Text="Active/Inactive" ToolTip="Active/Inactive" CssClass="btnBg" OnClick="btnStatus_Click" />
                <%--region button end --%>
                 <asp:Button ID="lnkNorec" runat="server" CssClass="servbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
            </div>
</asp:Content>

