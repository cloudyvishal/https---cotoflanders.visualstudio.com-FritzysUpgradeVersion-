<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master"  validateRequest="false" AutoEventWireup="true" Inherits="Admin_VisitVan" Title="Admin - Manage Our Vans" Codebehind="VisitVan.aspx.cs" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript" language="javascript" >
function Validate()
{
    
    return false;
}
</script>
<div class="innerContent">

<div class="pageTitle">
                    <h2>Manage visit our van images</h2>
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
      <%--Region Error/Success message end--%>  
      
<table class="adduserTable" cellpadding="6" cellspacing="0">
        <%--region to upload visit van image start --%>
        <tr>
        <td> Upload image to Visit our van : 
            <asp:FileUpload ID="fuFile" runat="server" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="fuFile" Display="None"
            ErrorMessage="File size should not be greater than 100 X 100." OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <asp:Button ID="btnUp" runat="server" Text="Upload" ToolTip="Upload" CssClass="servbtnBg" OnClick="btnUp_Click"  /><br /><br />
            
            
            You can upload .JPEG, .GIF, .BMP, .PNG files for Vans with maximum size of 666 X 378. 
        </td>
        </tr>
        <%--region to upload visit van image end --%>
        
        </table>
     <%--   region to show image info start--%>
                <asp:GridView ID="GrdVan" runat="server"  AutoGenerateColumns="False"
                    AllowSorting="true" AllowPaging="true" PageSize="10"  
                     CellPadding="0" GridLines="Vertical" Width="100%" 
                    OnPageIndexChanging="GrdVan_PageIndexChanging" OnDataBound="GrdVan_DataBound" OnRowCreated="GrdVan_RowCreated" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowDataBound="GrdVan_RowDataBound" >
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
                        
                        <asp:TemplateField HeaderText="Image Name" >
                        <ItemStyle CssClass="itemstyle" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thumbnail view">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <img alt="Image" width="170" height="80" src="#" runat="server" id="imgThumb"    />
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                   
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            
                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg" OnClick="btnDelete_Click"  />
     <%--   region to show image info end--%>
                
          
          
          
          <div class="pageTitle">
                    <h2>Visit our van content</h2>
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
            <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td colspan="2">
                  
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg"
            OnClick="btnSave_Click" />&nbsp;
            
          
          
          
 </div>
</asp:Content>

