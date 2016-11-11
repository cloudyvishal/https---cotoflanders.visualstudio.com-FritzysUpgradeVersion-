<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false"
    AutoEventWireup="true" Inherits="Admin_Services_AddService"
    Title="Admin - Add Service" Codebehind="AddService.aspx.cs" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
       function ValidateCharZip(source, args)
      {
          var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";
          var str = args.Value;
          for (var i = 0; i <  str.length; i++) 
          {   
            if(iChars.indexOf(str.charAt(i)) != -1)
              { 
  	               args.IsValid = false;
              }
          }
          
      }
      
       
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Add Service</h2>
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
        <%--Region is use to get all service detail form with Images and Fckeditor --%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 20%;">
                    <span class="star">*</span>
                    <asp:Label ID="lblServiceType" runat="server" Text="Service Type :"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlServiceType" runat="server">
                        <asp:ListItem Value="1" Text="Dog"></asp:ListItem>
                        <asp:ListItem Value="0" Text="Cat"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Service Type is required"
                        Display="None" ControlToValidate="ddlServiceType"></asp:RequiredFieldValidator></td>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                    TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                    Enabled="true" />
            </tr>
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblServiceTitle" runat="server" Text="Service Title :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtServiceTitle" runat="server" MaxLength="40" Width="300px" CssClass="textBox"> 
                    </asp:TextBox>(40 Characters)
                    <asp:RequiredFieldValidator ID="reqContactFName" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtServiceTitle" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Service Title is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactFname" Enabled="true"
                        TargetControlID="reqContactFName" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblServiceDesc" runat="server" Text="Service Description :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtServiceDesc" runat="server" MaxLength="200" Width="400px" CssClass="textBox">
                    </asp:TextBox>(200 Characters)
                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator3" runat="server"
                        ValidationGroup="valContactus" ErrorMessage="<b>Required Field Missing</b><br />Service Description is required"
                        Display="None" ControlToValidate="txtServiceDesc"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td style="height: 30px">
                    <span class="star">*</span><asp:Label ID="lblPageName" runat="server" Text="Enter File Name without Extension :"></asp:Label>
                </td>
                <td style="height: 30px">
                    <asp:TextBox ID="txtPageName" runat="server" MaxLength="50" CssClass="textBox">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator4" runat="server"
                        ValidationGroup="valContactus" ErrorMessage="<b>Required Field Missing</b><br />File Name is required"
                        Display="None" ControlToValidate="txtPageName"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                    <asp:CustomValidator runat="server" ID="custSpChar" ValidationGroup="valContactus"
                        ControlToValidate="txtPageName" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateCharZip"
                        ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                </td>
            </tr>
            <tr>
                <td style="height: 28px">
                    <span class="star">*</span><asp:Label ID="lblStatus" runat="server" Text="Service Status :"></asp:Label></td>
                <td style="height: 28px">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                        <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="valContactus"
                        ErrorMessage="<b>Required Field Missing</b><br />Service Status is required"
                        Display="None" ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                        TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblImage" runat="server" Text="Upload Image :"></asp:Label></td>
                <td>
                    <asp:Image ID="ImgService" runat="server" ImageUrl="" />
                    <asp:FileUpload ID="flUploadDetail" onkeypress="return false;" runat="server"></asp:FileUpload>&nbsp;
                    <asp:Button ID="btnUpload" runat="server" CssClass="btnBg" CausesValidation="false"
                        Text="Upload" ToolTip="Upload" OnClick="btnUpload_Click1" /><br /><br />
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
        <%--    End region of service form  --%>
        <%--region is use to set button event --%>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg"
            OnClick="btnSave_Click" ValidationGroup="valContactus" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            ToolTip="Cancel" CssClass="btnBg" OnClick="btnCancel_Click" />
        <%--region is use to set button event end --%>
    </div>
</asp:Content>
