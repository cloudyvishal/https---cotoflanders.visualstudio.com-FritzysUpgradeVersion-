<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Friends_EditFriends" Title="Admin - Edit Friends" Codebehind="EditFriends.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
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
        function checkSpecialKeys(e)
        {
            if(e.keyCode !=8 && e.keyCode!=46 && e.keyCode!=37 && e.keyCode!=38 && e.keyCode!=39 && e.keyCode!=40)
                return false;
            else
                return true;
        }
    </script>

    <script type="text/javascript" language="javascript">
       function ValidateURL(source, args)
      {
            
         var regexp = /www.[a-zA-Z0-9-\.]+\.(com|org|net|mil|edu|ca|co.uk|co.in|com.au|ac.in|gov|gov.in)(\/[A-Za-z0-9\.-])?/;
 	       if(!regexp.test(args.Value))
 	            args.IsValid = false;
          
      }
      
       
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Edit Fritzy's Friends</h2>
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
        <%--Region Edit friend start --%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td width="13%">
                    <span class="star">*</span>Friend Title :
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" CssClass="textBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" SetFocusOnError="true" 
                        Display="None" ValidationGroup="ValFriend" ErrorMessage="<b>Required Field Missing</b><br />Friend title is required.">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span>Referral Link :
                </td>
                <td>
                    <asp:TextBox ID="txtReferallink" runat="server" MaxLength="100" CssClass="textBox"></asp:TextBox>
                    e.g. :- www.Fritzy.com
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReferallink"
                        Display="None" ValidationGroup="ValFriend" ErrorMessage="<b>Required Field Missing</b><br />Referal link is required.">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                    <asp:CustomValidator runat="server" ID="custSpChar" ControlToValidate="txtReferallink"
                        Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateURL" ValidationGroup="ValFriend"
                        ErrorMessage="<b> Please enter correct URL</b> ."></asp:CustomValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span>Description :
                </td>
                <td>
                    <asp:TextBox Rows="5" Columns="35" TextMode="MultiLine" ID="txtDescription" runat="server"
                        CssClass="MultilinetextBox" MaxLength="300" onkeyDown="checkTextAreaMaxLength(this,event,'300');"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription"
                        Display="None" ValidationGroup="ValFriend" ErrorMessage="<b>Required Field Missing</b><br />Description is required.">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    Logo :
                </td>
                <td>
                    <asp:Image ID="imgLogo" runat="server" />
                    <asp:FileUpload ID="flUploadDetail" onkeypress="return false;" runat="server"></asp:FileUpload>&nbsp;
                    <%-- <asp:Button ID="btnUpload" runat="server" CausesValidation="false" Text="Upload"   />--%>
                </td>
            </tr>
        </table>
        <%--Region Edit friend end --%>
        
        <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg" ValidationGroup="ValFriend"
            OnClick="btnUpdate_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg"
            CausesValidation="false" PostBackUrl="~/Admin/Friends/ManageFriends.aspx?SearchFor=0&SearchText=" />
    </div>
</asp:Content>
