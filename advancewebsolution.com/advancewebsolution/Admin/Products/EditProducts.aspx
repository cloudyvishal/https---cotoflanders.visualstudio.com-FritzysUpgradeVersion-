<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"  EnableEventValidation="true" Inherits="Admin_Products_EditProducts" Title="Admin - Product Edit" Codebehind="EditProducts.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript">
       function ValidateDecimal(source, args)
      {
           var reg=/^-?\d+(\.\d+)?$/;
            var val = args.Value;
              
            if(reg.test(val))
                args.IsValid = true ;
            else
               args.IsValid = false;
      }
      
       
    </script>
 <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Edit Product</h2>
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
         
         <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblProductName" runat="server" Text="Product Name :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtProductName" runat="server" MaxLength="40" Width="300px" CssClass="textBox"> 
                    </asp:TextBox>(40 Characters)
                    <asp:RequiredFieldValidator ID="reqContactFName" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtProductName" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Product name is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactFname" Enabled="true"
                        TargetControlID="reqContactFName" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            
            
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblProductDescription" runat="server" Text="Product Description :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtProductDescription" runat="server" MaxLength="150"  Rows="5" Columns="20" TextMode="MultiLine" Width="300px"  > 
                    </asp:TextBox>(150 Characters)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtProductDescription" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Product description is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" Enabled="true"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span><asp:Label ID="lblProductPrice" runat="server" Text="Product Price :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" MaxLength="7" Width="50px" CssClass="textBox"> 
                    </asp:TextBox>(7 Characters)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtPrice" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Product price is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" Enabled="true"
                        TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                        
                    <asp:CustomValidator runat="server" ID="custSpChar" ValidationGroup="valContactus"
                        ControlToValidate="txtPrice" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateDecimal"
                        ErrorMessage="<b>Required Field Missing</b><br />Please enter correct product price "></asp:CustomValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                        
                </td>
            </tr>
            
          
             <tr>
                <td style="height: 28px">
                   <asp:Label ID="lblStatus" runat="server" Text="Service Status :"></asp:Label></td>
                <td style="height: 28px">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                        <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                        <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="valContactus"
                        ErrorMessage="<b>Required Field Missing</b><br />Product Status is required"
                        Display="None" ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                        TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblImage" runat="server" Text="Upload Image :"></asp:Label></td>
                <td>
                    <asp:Image ID="ImgProduct" runat="server" ImageUrl="" />
                    <asp:FileUpload ID="flUploadDetail" onkeypress="return false;" runat="server"></asp:FileUpload>&nbsp;
                    <asp:Button ID="btnUpload" runat="server" CssClass="btnBg" CausesValidation="false"
                        Text="Upload" ToolTip="Upload" OnClick="btnUpload_Click1" /><br />
                    You can upload .JPEG, .GIF, .BMP, .PNG files with maximum size of 90 X 145
                   
                </td>
            </tr>
         </table>
         
         
         <%--region is use to set button event --%>
        <asp:Button ID="btnSave" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg"
              ValidationGroup="valContactus" onclick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            ToolTip="Cancel" CssClass="btnBg"  
           
            onclick="btnCancel_Click"   />
        <%--region is use to set button event end --%>
        </div>
</asp:Content>

