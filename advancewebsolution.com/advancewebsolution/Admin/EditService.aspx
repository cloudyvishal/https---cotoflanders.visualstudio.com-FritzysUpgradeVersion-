<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_EditService" Title="Admin - Edit Homepage Service" Codebehind="EditService.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script type="text/javascript" language="javascript" >

       function checkTextAreaMaxLength(textBox,e, length)
        {
                var mLen = textBox["MaxLength"];
                if(null==mLen)
                    mLen=length;
                var maxLength = parseInt(mLen);
                if(!checkSpecialKeys(e))
                {
                 if(textBox.value.length > maxLength-1)
                 {
                    if(window.event)//IE
                      e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                 }
            }   
        }
</script>
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Edit Home page Service </h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <table class="adduserTable" cellpadding="6" cellspacing="0">
         <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblServiceTitle" runat="server" Text="Service Title :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtServiceTitle" runat="server" MaxLength="50" Width="300px" CssClass="textBox"> 
                    </asp:TextBox>(50 Characters)
                    <asp:RequiredFieldValidator ID="reqContactFName" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtServiceTitle" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Service title is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactFname" Enabled="true"
                        TargetControlID="reqContactFName" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblServiceDescription" runat="server" Text="Service Description :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtServiceDescription" runat="server" MaxLength="150"  Rows="5" Columns="20" TextMode="MultiLine" Width="300px" onkeyDown="checkTextAreaMaxLength(this,event,'150');" > 
                    </asp:TextBox>(150 Characters)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtServiceDescription" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Service description is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" Enabled="true"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblImage" runat="server" Text="Upload Image :"></asp:Label></td>
                <td>
                    <asp:Image ID="ImgProduct" runat="server" ImageUrl="" />
                    <asp:FileUpload ID="flUploadDetail" onkeypress="return false;" runat="server"></asp:FileUpload>&nbsp;
                    <asp:Button ID="btnUpload" runat="server" CssClass="btnBg" CausesValidation="false"
                        Text="Upload" ToolTip="Upload" OnClick="btnUpload_Click1" /><br /><br />
                    You can upload .JPEG, .GIF, .BMP, .PNG files  with maximum size of 87 x 132.
                     
                </td>
            </tr>
         </table>
         <asp:Button ID="btnSave" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg"
              ValidationGroup="valContactus" onclick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            ToolTip="Cancel" CssClass="btnBg"  PostBackUrl="~/Admin/ManageHomePageService.aspx" />
    </div>
</asp:Content>
