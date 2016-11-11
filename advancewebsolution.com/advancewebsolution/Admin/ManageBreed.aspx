<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Breed_ManageBreed" Title="Admin - Manage Breed" Codebehind="ManageBreed.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript" >
function showAddBreed()
{
    document.getElementById('<%=divAddBreed.ClientID %>').style.display = "block" ;
    document.getElementById('<%=DivlnkShowBreed.ClientID %>').style.display = "none" ;
    return false;
}
function HideAddBreed()
{
    document.getElementById('<%=divAddBreed.ClientID %>').style.display = "none" ;
    document.getElementById('<%=DivlnkShowBreed.ClientID %>').style.display = "block" ;
    document.getElementById('<%=txtBreedName.ClientID %>').value = "";
    
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
                Manage Breeds</h2>
        </div>
    <table>
        <tr>
            <td>
                <div class="errorDivlarge" id="divError" runat="server" visible="false">
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
                            <asp:ListItem Value="1" Text="Breed Name"></asp:ListItem>
                                                                                     
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
            </td>
        </tr>
    </table>
    
    <div style="margin: 10px 0 0 0; border: 0px solid;" id="divSelectPet" runat="server">
                    <table border="0" class="setservPage">
                        <tr>
                            <td style="width: 15%;">
                                Select Pet:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPetList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPetList_OnSelectedIndexChanged">
                                    <asp:ListItem Value="2">Both Cat & Dog</asp:ListItem>
                                    <asp:ListItem Value="0">Cat</asp:ListItem>
                                    <asp:ListItem Value="1">Dog</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
        
    <asp:GridView ID="gdvBreed" runat="server" AutoGenerateColumns="False" CellPadding="0" 
        AllowSorting="true" OnRowDataBound="gdvBreed_OnRowDataBound" AllowPaging="True"
        DataKeyNames="BreedID" GridLines="Vertical" Width="100%" OnPageIndexChanging="gdvBreed_PageIndexChanging"
        HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle"
        OnRowCancelingEdit="gdvBreed_RowCancelingEdit" OnRowEditing="gdvBreed_RowEditing"
        OnRowUpdating="gdvBreed_RowUpdating" OnSorting="gdvBreed_Sorting" OnDataBound="gdvBreed_DataBound" OnRowCreated="gdvBreed_RowCreated">
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
            <asp:TemplateField HeaderText="Breed Name" SortExpression="BreedName" >
                <ItemStyle CssClass="itemstyle" />
                <HeaderStyle CssClass="headerStyle" />
                <EditItemTemplate>
                    <asp:TextBox ID="txtBreedName" runat="server" Text='<%# Bind("BreedName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblBreedName" runat="server" Text='<%# Bind("BreedName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pet Type" SortExpression="PetTypeID">
                <ItemStyle CssClass="itemstyle" Width="10%" />
                <HeaderStyle CssClass="headerStyle" />
                <ItemTemplate>
                    <asp:Label ID="lblPetTypeID" runat="server" Text='<%# Bind("PetTypeID") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lblPetName" runat="server"></asp:Label>
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
    
    <div id="DivlnkShowBreed" runat="server" style="display: block">
        <asp:Button ID="btnNew" runat="server" Text="Add" ToolTip="Add" CssClass="btnBg" OnClientClick="return showAddBreed();" OnClick="btnNew_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg" OnClick="btnDelete_Click" />
        <asp:Button ID="btnStatus" runat="server" Text="Active/Inactive" ToolTip="Active/Inactive" CssClass="btnBg" OnClick="btnStatus_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export" ToolTip="Export" CssClass="btnBg" OnClick="btnExport_Click" />
        <asp:Button ID="btnImport" runat="server" Text="Import" CssClass="btnBg" OnClientClick="return ShowDiv();" ToolTip="Import" />
    </div> 
   

    <div id="divAddBreed" runat="server" style="display: none" class="itemstyle">
          Pet Type:<asp:DropDownList ID="ddlPetType" runat="server">
                <asp:ListItem Value="0">Cat</asp:ListItem>
                <asp:ListItem Value="1">Dog</asp:ListItem>
            </asp:DropDownList>
        <span class="star" style="color:#f00;">*</span>Add Breed Name
        <asp:TextBox ID="txtBreedName"  ValidationGroup="valBreed"  runat="server" CssClass="textBox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBreedName"  ValidationGroup="valBreed" 
            Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Breed Name is required.">  
        </asp:RequiredFieldValidator>
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
            TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight"
            Enabled="true" />
        <asp:Button ID="ImgSubmitService" runat="server" ValidationGroup="valBreed" CssClass="btnBg" Text="Add" ToolTip="Add"
            CausesValidation="true" OnClick="ImgSubmitService_Click" />&nbsp;&nbsp;
            
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" ToolTip="Cancel" OnClientClick="return HideAddBreed();" CssClass="btnBg" />
    </div>
    
    
    <div id="divShow" runat="server" style="display: none; margin:10px 0 0 0;" class="itemstyle">
        <table border="0" style="margin:10px 0 0 0;">
            <tr>
                <td>
                    <span class="star" style="color:#f00;">*</span>Upload file
                </td>
                <td>
                    <input id="flUpload" runat="server" type="file" onkeypress="return false;" CssClass="textBox" />
                </td>
                <td >
                    <asp:Button ID="btnUpload" Text="Upload" runat="server" CssClass="servbtnBg" border="0" OnClick="btnUpload_Click" />
                    <asp:Button ID="btnHide" Text="Cancel" runat="server" CssClass="servbtnBg" border="0" OnClientClick="return HideDiv();"/>
                </td>
            </tr>
        </table>
    </div>
     <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
    
     </div>
</asp:Content>

