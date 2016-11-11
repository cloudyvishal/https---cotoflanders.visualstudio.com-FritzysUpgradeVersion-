<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ReferalSource_ManageReferalSource" Title="Admin - Manage Referral Source" Codebehind="ManageReferalSource.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript" >
function showAddReferalSource()
{
    document.getElementById('<%=divAddReferalSource.ClientID %>').style.display = "block" ;
    document.getElementById('<%=DivlnkShowReferalSource.ClientID %>').style.display = "none" ;
    return false;
}
function HideAddReferalSource()
{
    document.getElementById('<%=divAddReferalSource.ClientID %>').style.display = "none" ;
    document.getElementById('<%=DivlnkShowReferalSource.ClientID %>').style.display = "block" ;
    document.getElementById('<%=txtReferalName.ClientID %>').value = "";
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
            <h2>
               Manage Referral Source</h2>
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
                            <asp:ListItem Value="1" Text="Referal Name"></asp:ListItem>
                                                                                     
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
<%-- Region  grid start--%>        
    <asp:GridView ID="gdvReferalSource" runat="server" AutoGenerateColumns="False" CellPadding="0" 
        AllowSorting="true" AllowPaging="True" DataKeyNames="ReferalID" GridLines="Vertical"
        Width="100%" OnPageIndexChanging="gdvReferalSource_PageIndexChanging" HeaderStyle-CssClass="headerStyle"
        CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowCancelingEdit="gdvReferalSource_RowCancelingEdit"
        OnRowEditing="gdvReferalSource_RowEditing" OnDataBound="gdvReferalSource_DataBound" OnRowCreated="gdvReferalSource_RowCreated" OnRowUpdating="gdvReferalSource_RowUpdating" OnSorting="gdvReferalSource_Sorting">
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
            <asp:TemplateField HeaderText="Referral Name" SortExpression="ReferalName">
                <ItemStyle CssClass="itemstyle" />
                <HeaderStyle CssClass="headerStyle" />
                <EditItemTemplate>
                    <asp:TextBox ID="txtReferalName" runat="server" Text='<%# Bind("ReferalName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblReferalName" runat="server" Text='<%# Bind("ReferalName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                <ItemStyle CssClass="itemstyle" Width="10%" />
                <HeaderStyle CssClass="headerStyle" />
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Edit" ShowEditButton="True" CausesValidation="False">
                <ItemStyle CssClass="itemstyle" Width="15%" HorizontalAlign="left" />
                <HeaderStyle CssClass="headerStyle" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
        
       <%-- Region  grid end --%> 
        
        <%--Region Button start--%>
         <div id="DivlnkShowReferalSource" runat="server" style="display:block">
        <asp:Button ID="btnNew" runat="server" Text="Add" ToolTip="Add" CssClass="btnBg" OnClientClick="return showAddReferalSource();" OnClick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg" OnClick="btnDelete_Click" />
        <asp:Button ID="btnStatus" runat="server" Text="Active/Inactive" ToolTip="Active/Inactive" CssClass="btnBg" OnClick="btnStatus_Click" />
        </div> 
        <%--Region Button end--%>
    
<%--Region to add referral  start--%>
    <div id="divAddReferalSource" runat="server" style="display: none"  class="itemstyle">
        <span class="star" style="color:#f00;">*</span>Add Referral Name
        <asp:TextBox ID="txtReferalName"  ValidationGroup="valReferal"  runat="server"  CssClass="textBox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReferalName"  ValidationGroup="valReferal" 
            Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Referral Name is required.">  
        </asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
            TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight"
            Enabled="true" />
        <asp:Button ID="ImgSubmitService" runat="server" ValidationGroup="valReferral" CssClass="btnBg" Text="Add" ToolTip="Add"
            CausesValidation="true" OnClick="ImgSubmitService_Click" />
        
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" ToolTip="Cancel" OnClientClick="return HideAddReferalSource();" CssClass="btnBg" />
        
    </div>
<%--Region to add referral end --%>
 <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
    
    </div>
</asp:Content>