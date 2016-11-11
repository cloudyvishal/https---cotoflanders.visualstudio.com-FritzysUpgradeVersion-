<%@ Page Language="C#" AutoEventWireup="true" Inherits="Admin_Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin - Login</title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    
    <link href="CSS/Admin.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
     function FormPanel_FireDefaultButton(event, target) 
     {
//        if ((event.keyCode == 13 || event.which == 13) && !(event.srcElement && (event.srcElement.tagName.toLowerCase() == 'textarea'))) 
//        {
//        var defaultButton = document.getElementById(target);
//        if (defaultButton == 'undefined') defaultButton = document.all[target]; 
//        if (defaultButton && typeof(defaultButton.click) != 'undefined') 
//        {
//            defaultButton.click();
//            event.cancelBubble = true;
//            if (event.stopPropagation) event.stopPropagation();
//            return false;
//        }
//    }
    return true;
}
    </script>
</head>
<body class="loginBg">
    <form id="form1" runat="server">
     <%--Region Error/Success message start--%>


      <div class="loginDiv">
        <div style="width: 95%;" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
       <%--Region Error/Success message end--%>
       
      <%-- Login Page conntain form for user login Username Password forgot password as well remember me on this pc --%>
       <div   onkeypress="javascript:return FormPanel_FireDefaultButton(event,'btnLogin')">
        <table cellspacing="0" cellpadding="3" width="100%" border="0" class="loginTable">
            <tbody>
                <tr>
                    <td>
                        <h3>Username</h3></td>
                    
                    <td>
                        <asp:TextBox ID="txtUserId" runat="server" CssClass="loginText"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <h3>Password</h3></td>
                   
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="loginText"> </asp:TextBox></td>
                </tr>
               <%-- <tr>
                    <td>
                        &nbsp;</td>
                   
                    <td>
                        <asp:Label ID="lblip1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>--%>
                <tr>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="chkRemember" runat="server" Text="Remember me on this computer." /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="LOGIN" ToolTip="LOGIN" UseSubmitBehavior="true" CssClass="loginbtnBg" OnClick="btnLogin_Click"  ></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td >
                       <asp:HyperLink ID="ForgotPassword" CssClass="forgotLink" runat="server" NavigateUrl="~/Admin/forgotPassword.aspx"> I forgot my username or password</asp:HyperLink>
                    </td>
                </tr>
                
            </tbody>
        </table>
      </div>  
      </div>
    </form>
</body>
</html>
