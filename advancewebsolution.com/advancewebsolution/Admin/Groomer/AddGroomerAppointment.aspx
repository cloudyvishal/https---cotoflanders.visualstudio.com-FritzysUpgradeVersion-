<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_AddGroomerAppointment" Title="Add Groomer Appointment" Codebehind="AddGroomerAppointment.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function valothers(event) {
            var kcode = event.keyCode;
             var other = document.getElementById('<%=txtOthers.ClientID %>').value;
             if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 39 || kcode == 40) { return true; }
            else
                if (other.length > 500) { return false }
            return true;
        }
    </script>


    <div class="innerContent">
        <div class="pageTitle">
            <h2>Add Groomer Appointment</h2>
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
        <asp:Label ID="lblDoubleBook" runat="server" Visible="True" ForeColor="Red" Text="This Appointment  Creates A Double Book." Font-Bold="True"></asp:Label>
        <%--Region Error/Success message end--%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 25%">
                    <asp:Label ID="Label1" runat="server" Text="Select Groomer:"></asp:Label>
                </td>
                <td style="width: 75%">
                    <asp:DropDownList ID="ddlGroomerlist" runat="server" CssClass="selectBox" AutoPostBack="true" OnSelectedIndexChanged="ddlGroomerlist_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ReqVAl2" Text="Select One" InitialValue="0" ControlToValidate="ddlGroomerlist"
                        ErrorMessage="<b>Required Field Missing</b><br />Groomer is required" Display="none"
                        ValidationGroup="valContactus" runat="server" SetFocusOnError="true" />
                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="ReqVAl2" Enabled="true" runat="Server" />
                </td>
            </tr>
            <tr>
                <td style="width: 80px;">Date/Time:
                </td>
                <td style="width: 120px;">
                    <asp:TextBox ID="txtDate" runat="server" MaxLength="20" AutoPostBack="true" ToolTip=" Example : 160503.1200-1400" AutoCompleteType="None" OnTextChanged="txtDate_TextChanged" CssClass="regTextField" Width="180px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtDate" Display="None" ErrorMessage="Appointment Date field should not be blank">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                        Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
           
            <tr>
                <td style="height: 131px">
                    <asp:Label ID="Label2" runat="server" Text="String:"></asp:Label>
                </td>
                <td style="height: 131px">
                    <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" CssClass="textarea"
                        onkeypress="return valothers(event);"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtOthers" Display="None" ErrorMessage="Appointment String field should not be blank"></asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidator5_ValidatorCalloutExtender"
                        Enabled="true" TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                </td>
            </tr>
            
            <tr>
                <td>
                 <asp:Label ID="lblcustEmail" runat="server" Text="Customer Email:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustEmail" runat="server" CssClass="textBox" AutoCompleteType="None" AutoPostBack="true" OnTextChanged="txtCustEmail_Chenged"> 
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Valid Email Address"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtCustEmail"></asp:RegularExpressionValidator>
                    <ajaxToolkit:ValidatorCalloutExtender ID="RegularExpressionValidator3_ValidatorCalloutExtender"
                        runat="server" Enabled="True" TargetControlID="RegularExpressionValidator3">
                    </ajaxToolkit:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCustName" runat="server" Text="Customer Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="textBox"> 
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalRevnueExpected" runat="server" Text="Expected Revenue(In $ Only):"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotalRevnueExpected" onkeypress="return IntegerNumbers(event);" runat="server" Width="180px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtTotalRevnueExpected" Display="None"
                        ErrorMessage="Revenue expected field should not be blank">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                        Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                    <asp:RegularExpressionValidator ID="repExpectedRevenue" runat="server" Display="None"
                        ErrorMessage="<b>Expected Revenue should be Dollars ($xxx.xx)" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtTotalRevnueExpected" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                        Enabled="true" TargetControlID="repExpectedRevenue" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExpectedpettime" runat="server" Text="Expected Pet Time: (In Hours)"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExpectedpettime" runat="server"  MaxLength="5" Width="180px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtExpectedpettime" Display="None"
                        ErrorMessage="Expected Pet Time field should not be blank">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7"
                        Enabled="true" TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight" />
                  
                    <asp:CompareValidator ID="cmpVal" runat="server" ErrorMessage="Expected time should not be greater than 10 Hrs."
                        ValueToCompare="10.00" Operator="LessThan" ControlToValidate="txtExpectedpettime"
                        Display="None" Type="Double"></asp:CompareValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="vldcal" Enabled="true" TargetControlID="cmpVal"
                        HighlightCssClass="validatorCalloutHighlight" />
                    <%--*Validation End--%>
                </td>
            </tr>
            <tr style="display: none">
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Sequence #:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSequence" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="3" Width="180px" CssClass="textBox"> 
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtSequence" Display="None" ErrorMessage="Sequence # field should not be blank">  
                    </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                        Enabled="true" TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                        ErrorMessage="<b>Sequence Number only allow numbers" ValidationGroup="valContactus"
                        SetFocusOnError="true" ControlToValidate="txtSequence" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6"
                        Enabled="true" TargetControlID="RegularExpressionValidator1" />
                </td>
            </tr>
          
        </table>
        <%--region is use to set button event --%>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg" ValidationGroup="valContactus" OnClick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" ToolTip="Cancel" CssClass="btnBg" OnClick="btnCancel_Click" />
        <%--region is use to set button event end --%>
    </div>
</asp:Content>
