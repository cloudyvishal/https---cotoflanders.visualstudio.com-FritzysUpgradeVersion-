<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" CodeBehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fritzy's :: Groomer Login</title>
    <%-- SCREEN STYLE --%>
    <link href="themes/screen.css" rel="stylesheet" media="all" type="text/css" id="stylesheet" />
    <%-- MOBILE STYLE --%>
    <%--<link href="themes/Style.css" rel="stylesheet"  media="all"  type="text/css" id="stylesheet" /> --%>
</head>
<body>
    <div class="maindiv">
        <form id="form1" runat="server">
            <!-- LOGO IMAGE DIV STATRS -->
            <div class="maincontainer">
            </div>
            <!-- LOGO IMAGE DIV ENDS-->
            <div class="logincontainer">
                <div class="containwrapper">
                    <!-- HEADER STARTS -->
                    <div class="header">
                        <div class="top_t">
                            <div class="top_tl">
                                <div class="top_tr">
                                    <div class="top_content">
                                        <h1>Groomer Login</h1>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- HEADER ENDS -->
                    <!-- CONTENT STATRS -->
                    <div class="content">
                        <div class="t">
                            <div class="b">
                                <div class="r">
                                    <div class="l">
                                        <div class="bl">
                                            <div class="br">
                                                <div class="tl">
                                                    <div class="tr">
                                                        <div class="contentbg">
                                                            <div class="logindiv">
                                                                <%--Region Error/Success message start--%>
                                                                <div style="width: 95%;" id="divError" runat="server" visible="false">
                                                                    <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                                                                </div>
                                                                <%--Region Error/Success message end--%>
                                                                <div class="divrow">
                                                                    <div class="divcell_left">
                                                                        <asp:Label ID="lblUsername" runat="server" CssClass="lbl">Email:</asp:Label>
                                                                    </div>
                                                                    <div class="divcell_right">
                                                                        <asp:TextBox ID="txtUsername" runat="server" CssClass="txt150" autocomplete="off" MaxLength="50"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="divrow">
                                                                    <div class="divcell_left">
                                                                        <asp:Label ID="lblPassword" runat="server" CssClass="lbl">Password:</asp:Label>
                                                                    </div>
                                                                    <div class="divcell_right">
                                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="txt150" MaxLength="20" TextMode="Password"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="divrow">
                                                                    <div class="divcell_left">&nbsp; </div>
                                                                    <div class="divcell_right">
                                                                        <asp:Button ID="btnSignin" runat="server" Text="Sign in" ToolTip="Sign in" AccessKey="1"  CssClass="btn" OnClick="btnSignin_Click" />
                                                                        <a href="forgotpassword.aspx" title="forgot password?" accesskey="2" class="link">Forgot Password?</a>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- CONTENT ENDS -->
                </div>
            </div>
        </form>
    </div>
</body>
</html>
