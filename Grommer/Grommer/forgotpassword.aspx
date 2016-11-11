<%@ Page Language="C#" AutoEventWireup="true" Inherits="forgotpassword" CodeBehind="forgotpassword.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fritzy's :: Groomer Forgot Password</title>
    <%-- SCREEN STYLE --%>
    <link href="themes/screen.css" rel="stylesheet" media="all" type="text/css" id="stylesheet" />
    <%-- MOBILE STYLE --%>
    <%--<link href="themes/Style.css" rel="stylesheet"  media="all"  type="text/css" id="stylesheet" /> --%>
</head>
<body>
    <div class="maindiv">
        <form id="form1" runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <!-- LOGO IMAGE DIV STATRS -->
            <div class="maincontainer">
            </div>
            <!-- LOGO IMAGE DIV ENDS-->
            <div class="contentainer" style="width: 30%;">
                <div class="containwrapper">
                    <!-- HEADER STARTS -->
                    <div class="header">
                        <div class="top_t">
                            <div class="top_tl">
                                <div class="top_tr">
                                    <div class="top_content">
                                        <h1>Groomer Forgot Password</h1>
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
                                                        <div class="contentbg" style="width: 260px;">
                                                            <div class="logindiv">
                                                                <%--Region Error/Success message start--%>
                                                                <div style="width:95%;" id="divError" runat="server">
                                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                                </div>
                                                                <%--Region Error/Success message end--%>
                                                                <div class="divrow">
                                                                    <div class="divcell_left">
                                                                        <asp:Label ID="lblEmail" runat="server" CssClass="lbl">Email:</asp:Label>
                                                                    </div>
                                                                    <div class="divcell_right">
                                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txt txt150"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                                                            Display="None" SetFocusOnError="true" ValidationGroup="valLoginAppointment" ErrorMessage="<b>Required Field Missing</b><br />User name is required.">  
                                                                        </asp:RequiredFieldValidator>
                                                                        <cc1:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender1" targetcontrolid="RequiredFieldValidator1"
                                                                            highlightcssclass="validatorCalloutHighlight" enabled="true" />
                                                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Email Not Valid</b><br />Please enter correct User Email."
                                                                            ValidationGroup="valLoginAppointment" SetFocusOnError="true" ControlToValidate="txtEmail"  ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                                        </asp:RegularExpressionValidator>
                                                                        <cc1:validatorcalloutextender runat="Server" id="ValidatorCalloutExtender3" targetcontrolid="revEmail" highlightcssclass="validatorCalloutHighlight" />

                                                                    </div>
                                                                </div>
                                                                <div class="divrow">
                                                                    <div class="divcell_left">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div class="divcell_right">
                                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" AccessKey="1" CssClass="btn"  ValidationGroup="valLoginAppointment" OnClick="btnSubmit_Click" />
                                                                        <asp:Button ID="btnBack" runat="server" Text="Back" ToolTip="Back" AccessKey="1" CssClass="btn" OnClick="btnBack_Click" CausesValidation="false" />
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
