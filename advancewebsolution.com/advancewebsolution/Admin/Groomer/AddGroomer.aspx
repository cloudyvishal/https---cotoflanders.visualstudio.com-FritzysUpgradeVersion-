<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_AddGroomer" Title="Admin - Add Groomer" CodeBehind="AddGroomer.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../../Scripts/phone_validation.js"></script>

    <script type="text/javascript" language="javascript" src="../../Scripts/Validation.js"></script>

    <script type="text/jscript" language="javascript">

        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57) //if not a number
                    return false //disable key press
            }
        }

        function CheckConfirmPassword(source, arguments) {
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
            <h2>Add Groomer</h2>
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
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblEmailID" runat="server" Text="Email ID :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmailID" runat="server" MaxLength="40" Width="230px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqContactEmailID" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtEmailID" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Email ID is required">  
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REEmailId" runat="server" ValidationGroup="valContactus"
                        ErrorMessage="<b>Required Field Missing</b><br />Invalid Email ID" ControlToValidate="txtEmailID"
                        SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="None">
                    </asp:RegularExpressionValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valContactEmailID" Enabled="true"
                        TargetControlID="reqContactEmailID" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="EmailId" Enabled="true"
                        TargetControlID="REEmailId" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="15" Rows="5" Columns="20"
                        Width="130px" TextMode="Password" CssClass="textBox"> </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtPassword" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Password is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="15" Width="130px"
                        CssClass="textBox" TextMode="Password"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtConfirmPassword" ErrorMessage="<b>Required Field Missing</b><br />Confirm Password is required"
                        Display="None">  
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cmp1" runat="server" ErrorMessage="Confirm Password Not Match"
                        ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" Operator="Equal"
                        ValidationGroup="valContactus" SetFocusOnError="true" Display="None"> </asp:CompareValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender9"
                        Enabled="true" TargetControlID="cmp1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="130px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtName" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Name is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        Enabled="true" TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="40" CssClass="txt_address"
                        TextMode="MultiLine" Rows="7"> 
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label2" runat="server" Text="Base City :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBaseCity" runat="server" MaxLength="30" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtBaseCity" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Base City is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender10"
                        Enabled="true" TargetControlID="RequiredFieldValidator9" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label3" runat="server" Text="State :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" MaxLength="30" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtState" Display="None" ErrorMessage="<b>Required Field Missing</b><br />State is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6"
                        Enabled="true" TargetControlID="RequiredFieldValidator6" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblZipCode" runat="server" Text="Zip code :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtZipCode" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="5" Width="130px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtZipCode" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Zip Code is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender8"
                        Enabled="true" TargetControlID="RequiredFieldValidator8" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="lblHomePhone" runat="server" Text="Phone 1 :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHomePhone" runat="server" Width="130px" CssClass="textBox" onkeydown="javascript:backspacerDOWN(this,event);"
                        onkeyup="javascript:backspacerUP(this,event);"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtHomePhone" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Phone 1 is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender5"
                        Enabled="true" TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPersonalCell" runat="server" Text="Phone 2 :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPersonalCell" runat="server" Width="130px" CssClass="textBox"
                        onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"> 
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label1" runat="server" Text="Sheet Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSheetName" runat="server" MaxLength="50" Width="130px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtSheetName" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Sheet Name is required">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                        Enabled="true" TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <span class="star">*</span><asp:Label ID="Label4" runat="server" Text="Time Zone :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTimeZone" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Atlantic Standard Time</asp:ListItem>
                        <asp:ListItem>Central Standard Time</asp:ListItem>
                        <asp:ListItem>Eastern Standard Time</asp:ListItem>
                        <asp:ListItem>Mountain Standard Time</asp:ListItem>
                        <asp:ListItem>Pacific Standard Time</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlTimeZone" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="ddlTimeZone" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Time Zone is required"
                        InitialValue="Select">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7"
                        Enabled="true" TargetControlID="rfvddlTimeZone" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
        </table>
        <%--region is use to set button event --%>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg"
            ValidationGroup="valContactus" OnClick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            PostBackUrl="~/Admin/Groomer/ManageGroomer.aspx?SearchFor=0&SearchText=" ToolTip="Cancel"
            CssClass="btnBg" />
        <%--region is use to set button event end --%>
    </div>
</asp:Content>
