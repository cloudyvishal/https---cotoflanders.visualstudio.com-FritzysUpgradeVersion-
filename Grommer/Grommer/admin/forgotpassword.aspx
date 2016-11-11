<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_forgotpassword" Codebehind="forgotpassword.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Fritzy's Intranet :: Admin Forgot Password</title>
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
                                                <asp:Label ID="lblerror" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="loginrow" style="padding-top:30px;">
                                            <div class="loginleft"><asp:Label ID="lblEmail" runat="server">Email :</asp:Label></div>
                                            <div class="loginright"><asp:TextBox ID="txtEmail" runat="server" CssClass="txt txt180"></asp:TextBox></div>
                                        </div>
                                      
                                        <div class="loginrow">
                                            <div class="loginleft">&nbsp;</div>
                                            <div class="loginright"><asp:Button ID="btnSend" runat="server" Text="Send" ToolTip="Send" CssClass="btn"/></div>
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
