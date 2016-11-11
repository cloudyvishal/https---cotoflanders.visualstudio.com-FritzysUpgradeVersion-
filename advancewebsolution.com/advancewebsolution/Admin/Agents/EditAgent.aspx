<%@ Page Title="Admin - Edit Agents" Language="C#" MasterPageFile="~/Admin/AdminMaster.master"
    AutoEventWireup="true" Inherits="Admin_Agents_EditAgent" Codebehind="EditAgent.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function CheckPassword(source, args) {
            if (document.getElementById('<%= txtPassword.ClientID %>').value == "") {
                args.IsValid = false;
            }
            else if (document.getElementById('<%= txtPassword.ClientID %>').value.length < 6) {
                args.IsValid = false;
            }
        }
        function CheckConfirmPassword(source, args) {
            if (document.getElementById('<%= txtPassword.ClientID %>').value == document.getElementById('<%= txtConfirmPassword.ClientID %>').value) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Edit Agent</h2>
        </div>
        <%--<asp:ValidationSummary ID="ValidationSummary1" runat=server CssClass="errorStyle"/>--%>
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
        <%--Region table to display all user information start--%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 20%;">
                    <span class="star">*</span> First Name :
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />First Name is required.">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Last Name :
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Last Name is required.">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Username :
                </td>
                <td>
                    <asp:Label ID="lblUserName" runat="server"></asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textBox" MaxLength="15" Visible="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Username is required.">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <span class="star">*</span> Password :
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textBox" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Password is required.">  
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="Cust1" runat="server" Display="None" ControlToValidate="txtPassword"
                        SetFocusOnError="true" ClientValidationFunction="CheckPassword" ErrorMessage="<b>Required Field Missing</b><br />Password length should not be less than 6 characters">
                    </asp:CustomValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender8"
                        TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        TargetControlID="Cust1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <span class="star">*</span> Confirm Password :
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="textBox" MaxLength="15"
                        TextMode="Password"></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Email :
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox" MaxLength="45" Visible="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true"
                        ControlToValidate="txtEmail" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Email is required.">  
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                        SetFocusOnError="true" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6"
                        TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5"
                        TargetControlID="revEmail" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    Mobile :
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="textBox" MaxLength="15" onkeydown="javascript:backspacerDOWN(this,event);"
                        onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address1 :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="textBox" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address2 :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="textBox" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
           
        </table>
        <%--Region table to display all user information end --%>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg"
            OnClick="btnUpdate_Click" />
        <asp:Button ID="btnBack" runat="server" CssClass="btnBg" Text="Cancel" ToolTip="Cancel"
            CausesValidation="false" PostBackUrl="~/Admin/Agents/ManageAgents.aspx?SearchFor=0&SearchText=" />
    </div>
</asp:Content>
