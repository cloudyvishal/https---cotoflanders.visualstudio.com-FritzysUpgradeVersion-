<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false"
    AutoEventWireup="true" Inherits="Admin_Services_EditService"
    Title="Admin - Edit Service" Codebehind="EditService.aspx.cs" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Edit Service</h2>
        </div>
        <div class="previewLinkDiv">
        <asp:LinkButton id="btnPreview"  runat="server"  Text="Preview" ToolTip="Preview" OnClick="btnPreview_Click1"></asp:LinkButton>
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
        <%--Region is use Edit Service detail start --%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
          
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblServiceTitle" runat="server" Text="Service Title :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtServiceTitle" runat="server" MaxLength="40" Width="300px" CssClass="textBox">
                    </asp:TextBox>(40 Characters)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                        ErrorMessage="<b>Required Field Missing</b><br />Service title is required" Display="None"
                        ControlToValidate="txtServiceTitle"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                        TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblServiceDesc" runat="server" Text="Service Description :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtServiceDesc" runat="server" MaxLength="200" Width="400px" CssClass="textBox">
                    </asp:TextBox>(200 Characters)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server"
                        ErrorMessage="<b>Required Field Missing</b><br />Service description is required"
                        Display="None" ControlToValidate="txtServiceDesc"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                     <asp:Label ID="lblPageName" runat="server" Text="File Name :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblFileName" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="txtPageName" runat="server" ReadOnly="true" style="display:none;" MaxLength="50" CssClass="textBox">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                        ErrorMessage="<b>Required Field Missing</b><br />File Name is required" Display="None"
                        ControlToValidate="txtPageName"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblStatus" runat="server" Text="Service Status :"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="0" Text="Inactive"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true"
                        ErrorMessage="<b>Required Field Missing</b><br />Service Type is required" Display="None"
                        ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <span class="star">*</span><asp:Label ID="lblImage" runat="server" Text="Upload Image :"></asp:Label>
                    <br />
                </td>
                <td>
                    <asp:Image ID="ImgService" runat="server" />
                    <asp:FileUpload ID="flUploadDetail" onkeypress="return false;" runat="server"></asp:FileUpload>&nbsp;
                    <asp:Button ID="btnUpload" runat="server" CausesValidation="false" Text="Upload"
                        ToolTip="Upload" CssClass="btnBg" OnClick="btnUpload_Click" />&nbsp; <br />
                        You can upload .JPEG, .GIF, .BMP, .PNG files  with maximum size of 90 X 145.
                  
                </td>
            </tr>
            <tr>
                <td colspan="2">
                  
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </table>
        <%--Region is use Edit Service detail end --%>
        
        <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg"
            OnClick="btnUpdate_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btnBg"
            Text="Cancel" ToolTip="Cancel" OnClick="btnCancel_Click" />
             
    </div>
</asp:Content>
