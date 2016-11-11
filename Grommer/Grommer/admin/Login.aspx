<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_Login" Codebehind="Login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fritzy's Intranet :: Admin Login</title>
    <link href="admin.css" rel="Stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="maincontainer">
            <div class="containwrapper">
                <div class="header">
                </div>
                <div class="logindiv">
                    <div class="t"><div class="b"><div class="r"><div class="l">
                        <div class="bl"><div class="br"><div class="tl"><div class="tr">
                            <div class="content">
                                <div class="innercontent">
                                    <div><img src="images/login_title.jpg" alt="" /></div>
                                    <br />
                                        <div class="loginrow" style="padding-top:10px;">
                                            <div class="error">
                                                <asp:Label ID="lblerror" runat="server" Text="Incorrect Username and password."></asp:Label>
                                            </div>
                                        </div>
                                        <div class="loginrow" style="padding-top:10px;">
                                            <div class="loginleft"><asp:Label ID="lblUsername" runat="server">Username :</asp:Label></div>
                                            <div class="loginright"><asp:TextBox ID="txtUsername" runat="server" CssClass="txt"></asp:TextBox></div>
                                        </div>
                                        <div class="loginrow">
                                            <div class="loginleft"><asp:Label ID="lblPassword" runat="server">Password :</asp:Label></div>
                                            <div class="loginright"><asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="txt"></asp:TextBox></div>
                                        </div>
                                        <div class="loginrow">
                                            <div class="loginleft">&nbsp;</div>
                                            <div class="loginright"><asp:Button ID="btnLogin" runat="server" Text="Login" ToolTip="Login" CssClass="btn"/></div>
                                        </div>
                                        <div class="loginrow">
                                            <div class="loginleft">&nbsp;</div>
                                            <div class="loginright"><a href="forgotpassword.aspx" title="Forgot Password?">Forgot Password?</a></div>
                                        </div>
                                </div>
                            </div>
                        </div></div></div></div> 
                    </div></div></div></div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
