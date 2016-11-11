<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" Inherits="MB_login" Title="Mobile Grooming Services" CodeBehind="MB_login.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function validate() {
            if (document.getElementById('<%=txtUserName.ClientID %>').value == "") {

                alert("Please Enter User Name.");
                document.getElementById('<%=txtUserName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtpassword.ClientID %>').value == "") {

                alert("Please Enter Password.");
                document.getElementById('<%=txtpassword.ClientID %>').focus();
                return false;
            }
        }
        function disableautocompletion(id) {
            var passwordControl = document.getElementById(id);
            passwordControl.setAttribute("autocomplete", "off");
        }
    </script>

    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Login</h1>
        </div>
        <div class="innercontent">
            <div class="forform">
                <div>
                    <asp:Label runat="server" ID="lblLoginerror" CssClass="label" ForeColor="Red" Text="* Invalid UserEmail or Password" Visible="false"></asp:Label><br />
                    <asp:Label runat="server" ID="username" CssClass="label">Email-Id</asp:Label><br />
                    <asp:TextBox CssClass="txtbox" ID="txtUserName" runat="server" EnableViewState="false" autocomplete="off"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                        Display="None" SetFocusOnError="true" ValidationGroup="valLoginAppointment" ErrorMessage="<b>Required Field Missing</b><br />User name is required.">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Email Not Valid</b><br />Please enter correct User Email."
                        ValidationGroup="valLoginAppointment" SetFocusOnError="true" ControlToValidate="txtUsername"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="revEmail"
                        HighlightCssClass="validatorCalloutHighlight" />
                    <asp:Label runat="server" ID="passwordlbl" CssClass="label">Password</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtpassword" CssClass="txtbox" TextMode="password"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valLoginAppointment"
                        ControlToValidate="txtPassword" Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Password is required.">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator2"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="valLoginAppointment"
                        ControlToValidate="txtPassword" Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Password is required.">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4" TargetControlID="RequiredFieldValidator2"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    <asp:Button runat="server" CssClass="button" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" ValidationGroup="valLoginAppointment" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
