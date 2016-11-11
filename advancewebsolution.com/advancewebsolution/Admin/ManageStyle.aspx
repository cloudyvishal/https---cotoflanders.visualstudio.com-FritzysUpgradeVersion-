<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Style_ManageStyle" Title="Admin - Manage Styles" Codebehind="ManageStyle.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript" >
function showAddStyle()
{
    document.getElementById('<%=divAddStyle.ClientID %>').style.display = "block" ;
    document.getElementById('<%=DivlnkShowStyle.ClientID %>').style.display = "none" ;
    return false;
}
function HideAddStyle()
{
    document.getElementById('<%=divAddStyle.ClientID %>').style.display = "none" ;
    document.getElementById('<%=DivlnkShowStyle.ClientID %>').style.display = "block" ;
    document.getElementById('<%=txtStyleName.ClientID %>').value = "";
    return false;
}

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
            <h2>
                Manage Styles</h2>
        </div>
        <%--Region div error/Successmessage start --%>
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
                <%--Region div error/Successmessage end --%>
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
                                    <asp:ListItem Value="1" Text="Style Name"></asp:ListItem>
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
        <%--Region Grid start --%>
    <asp:GridView ID="gdvStyle" runat="server" AutoGenerateColumns="False" CellPadding="0" 
        AllowSorting="true" AllowPaging="True" DataKeyNames="StyleID" GridLines="Vertical"
        Width="100%" OnPageIndexChanging="gdvStyle_PageIndexChanging" HeaderStyle-CssClass="headerStyle"
        CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowCancelingEdit="gdvStyle_RowCancelingEdit"
        OnRowEditing="gdvStyle_RowEditing" OnRowUpdating="gdvStyle_RowUpdating" OnSorting="gdvStyle_Sorting" OnDataBound="gdvStyle_DataBound" OnRowCreated="gdvStyle_RowCreated">
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
            <asp:TemplateField HeaderText="Style Name" SortExpression="StyleName">
                <ItemStyle CssClass="itemstyle" />
                <HeaderStyle CssClass="headerStyle" />
                <EditItemTemplate>
                    <asp:TextBox ID="txtStyleName" runat="server" Text='<%# Bind("StyleName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStyleName" runat="server" Text='<%# Bind("StyleName") %>'></asp:Label>
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
                <ItemStyle CssClass="itemstyle" Width="15%" />
                <HeaderStyle CssClass="headerStyle" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
        
        <%--Region Grid end --%>
       
        
        
        <%--region button starts --%>
    <div id="DivlnkShowStyle" runat="server" style="display: block">
        <asp:Button ID="btnNew" runat="server" Text="Add" ToolTip="Add" CssClass="btnBg" OnClientClick="return showAddStyle();" OnClick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg"
            OnClick="btnDelete_Click" />
        <asp:Button ID="btnStatus" runat="server" Text="Active/Inactive" ToolTip="Active/Inactive"
            CssClass="btnBg" OnClick="btnStatus_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export" ToolTip="Export" CssClass="btnBg"
            OnClick="btnExport_Click" />
        <asp:Button ID="btnImport" runat="server" Text="Import" CssClass="btnBg" OnClientClick="return ShowDiv();" ToolTip="Import" />
    </div> 
        <%--region button end --%>
        
        <%--Region Add style start--%>
   
    <div id="divAddStyle" runat="server" style="display: none" class="itemstyle">
        <span class="star" style="color: #f00;">*</span>Add Style Name
        <asp:TextBox ID="txtStyleName" ValidationGroup="valStyle" runat="server" CssClass="textBox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStyleName"
            ValidationGroup="valStyle" Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Style Name is required.">  
        </asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
            TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight"
            Enabled="true" />
        <asp:Button ID="ImgSubmitService" runat="server" ValidationGroup="valStyle" CssClass="btnBg"
            Text="Add" ToolTip="Add" CausesValidation="true" OnClick="ImgSubmitService_Click1" />&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
            ToolTip="Cancel" OnClientClick="return HideAddStyle();" CssClass="btnBg" />
    </div> 
    
        <%--Region Add style start--%>
    
    

<div id="divShow" runat="server" style="display: none; margin:10px 0 0 0;" class="itemstyle">
        <table>
            <tr>
                <td>
                    <span class="star" style="color:#f00;">*</span>Upload file
                </td>
                <td>
                    <input id="flUpload" runat="server" type="file" onkeypress="return false;"  CssClass="textBox" />
                </td>
                <td>
                    <asp:Button ID="btnUpload" Text="Upload" runat="server" CssClass="servbtnBg" border="0" OnClick="btnUpload_Click" />
                    <asp:Button ID="btnHide" Text="Cancel" runat="server" CssClass="servbtnBg" border="0" OnClientClick="return HideDiv();"/>
                </td>
            </tr>
        </table>
    </div>
     <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
    </div>
    
</asp:Content>

