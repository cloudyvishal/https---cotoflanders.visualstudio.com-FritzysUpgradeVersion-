<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false"  AutoEventWireup="true" Inherits="Admin_News_EditNews" Title="Admin - Edit News" Codebehind="EditNews.aspx.cs" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">

<div class="pageTitle">
                    <h2>Edit News</h2>
                </div>
                <div class="previewLinkDiv">
                    <asp:LinkButton id="btnPreview" runat="server"  Text="Preview" ToolTip="Preview" OnClick="btnPreview_Click"></asp:LinkButton>
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

<%--Region to add news form start --%>
<table class="adduserTable" cellpadding="6" cellspacing="0">
    <tr>
        <td style="width:20%;"> <span class="star">*</span>News Title </td>
        <td> <asp:TextBox ID="txtTitle" runat="server" MaxLength="45" width="300px" CssClass="textBox" ></asp:TextBox>(45 Characters)
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtTitle" Display="None"  SetFocusOnError="true"
            ErrorMessage="<b>Required Field Missing</b><br />Title name is required.">  
             </asp:RequiredFieldValidator>
             
              <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator1"
                                    HighlightCssClass="validatorCalloutHighlight" />
        </td>
    </tr>
    <tr>
        <td> <span class="star">*</span> Short Description </td>
        <td> <asp:TextBox ID="txtShortDesc" runat="server" MaxLength="80" width="400px" CssClass="textBox"></asp:TextBox>(80 Characters)  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ControlToValidate="txtShortDesc" Display="None"  SetFocusOnError="true"
            ErrorMessage="<b>Required Field Missing</b><br />Short description is required.">  
             </asp:RequiredFieldValidator>
             
              <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator2"
                                    HighlightCssClass="validatorCalloutHighlight" />
        </td>
    </tr>
    <tr>
        <td valign="top">  Description </td>
        <td>  
        <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
             </FCKeditorV2:FCKeditor>
        </td>
    </tr>
    
    
    </table>
    
<%--Region to add news form start --%>
    <asp:Button ID="btnUpdate" runat="server" Text="Update News" ToolTip="Update News" CssClass="btnBg" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg" CausesValidation="false" PostBackUrl="~/Admin/News/ManageNews.aspx?SearchFor=0&SearchText=" />
      
    </div>
</asp:Content>

