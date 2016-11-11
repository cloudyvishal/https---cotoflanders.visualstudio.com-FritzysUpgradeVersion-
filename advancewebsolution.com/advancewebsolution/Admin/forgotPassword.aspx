<%@ Page Language="C#" AutoEventWireup="true" Inherits="Admin_ForgotPassword"
    EnableEventValidation="false" Codebehind="ForgotPassword.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin - Forgot Password</title>
    <link href="CSS/Admin.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript">
        function ValidateChar(source, arguments) {

            var iChars = "!@#$%^&*()+=-[]\\\';,/{}|\":<>?";
            var str = arguments.Value;
            for (var i = 0; i < str.length; i++) {
                if (iChars.indexOf(str.charAt(i)) != -1) {
                    arguments.IsValid = false;
                }
            }
        }
    </script>

</head>
<body class="logoutBg">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager3" runat="server" />
    <div class="loginDiv">
        <div style="width: 95%" id="divError" runat="server">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table cellspacing="0" cellpadding="3" width="100%" border="0" class="loginTable">
            <tbody>
                <tr>
                    <td colspan="2">
                        Enter your username below, and we'll email your password to the email address we
                        have on file.
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>
                            Enter your username</h3>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserId" runat="server" CssClass="loginText"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                            ControlToValidate="txtUserId" Display="None" ValidationGroup="valSuggest1" ErrorMessage="<b>Required Field Missing</b><br />Username is required.">  
                        </asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                            TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                            Enabled="true" />
                        <asp:CustomValidator runat="server" ID="custSpChar" ValidationGroup="valSuggest1"
                            ControlToValidate="txtUserId" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateChar"
                            ErrorMessage="<b> Special characters not allowed</b> ."></asp:CustomValidator>
                        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custSpChar"
                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Send me my password"
                            CssClass="btnBg" UseSubmitBehavior="True" ValidationGroup="valSuggest1" OnClick="btnSubmit_Click">
                        </asp:Button>
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btnBg" PostBackUrl="~/Admin/Default.aspx" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
