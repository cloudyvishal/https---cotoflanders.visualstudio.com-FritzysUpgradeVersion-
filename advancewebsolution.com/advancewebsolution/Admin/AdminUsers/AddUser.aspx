<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    EnableEventValidation="true" Inherits="Admin_Users_AddUser"
    Title="Admin - Add Users" Codebehind="AddUser.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../Scripts/phone_validation.js"></script>

    <script type="text/javascript" language="javascript">
function CheckPassword(source ,args)
    {
       if(document.getElementById('<%= txtPassword.ClientID %>').value == "")
        {
            args.IsValid = false;
        }
        else if(document.getElementById('<%= txtPassword.ClientID %>').value.length < 6 )
        {
            args.IsValid = false;
        }
    } 
function CheckConfirmPassword(source ,args)
{
    if(document.getElementById('<%= txtPassword.ClientID %>').value == document.getElementById('<%= txtConfirmPassword.ClientID %>').value )
        {
            args.IsValid = true;
        }
        else  
        {
            args.IsValid = false;
        }
}
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Add Admin</h2>
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
        <%--Region table to user information form start--%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 20%;">
                    <span class="star">*</span> First Name :
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />First Name is required."> </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender0"
                        TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Last Name :
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Last Name is required."> </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Username :
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" CssClass="textBox" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserName"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Username is required."> </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Password :
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" CssClass="textBox" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Password is required."> </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="Cust1" runat="server" Display="None" ControlToValidate="txtPassword"
                        ValidationGroup="val1" SetFocusOnError="true" ClientValidationFunction="CheckPassword"
                        ErrorMessage="<b>Required Field Missing</b><br />Password length should not be less than 6 characters"> </asp:CustomValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                        TargetControlID="Cust1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Confirm Password :
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="textBox" runat="server" MaxLength="15"
                        TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtConfirmPassword"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Confirm Password is required."> </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Display="None" ControlToValidate="txtConfirmPassword"
                        SetFocusOnError="true" ClientValidationFunction="CheckConfirmPassword" ErrorMessage="<b>Required Field Missing</b><br />Password and confirm password should be same"> </asp:CustomValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5"
                        TargetControlID="RequiredFieldValidator6" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6"
                        TargetControlID="CustomValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Email :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                        Display="None" SetFocusOnError="true" ErrorMessage="<b>Required Field Missing</b><br />Email is required."> </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                        SetFocusOnError="true" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7"
                        TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender8"
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
                    <asp:TextBox ID="txtAddress1" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address2 :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress2" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
           
        </table>
        <%--Region table to user information form start--%>
        
        
<%--region button starts --%> 
        <asp:Button ID="AddUser" runat="server" Text="Add User" ToolTip="Add User" CssClass="btnBg"
            OnClick="AddUser_Click" />
        <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg"
            CausesValidation="false" PostBackUrl="~/Admin/AdminUsers/ManageUser.aspx?SearchFor=0&SearchText=" />
            
<%--region button end --%> 
    </div>
</asp:Content>
