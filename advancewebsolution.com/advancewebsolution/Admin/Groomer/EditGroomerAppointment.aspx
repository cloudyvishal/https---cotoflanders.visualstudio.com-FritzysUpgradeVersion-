<%@ Page Title="Edit Groomer Appointment" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_EditGroomerAppointment" Codebehind="EditGroomerAppointment.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Edit Groomer Appointment</h2>
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
            <td style="width: 25%;">
                <asp:Label ID="Label1" runat="server" Text="Select Groomer:"></asp:Label>
            </td>
            <td style="width: 75%;" align="left">
                <asp:DropDownList ID="ddlGroomerlist" runat="server" CssClass="selectBox"> 
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ReqVAl2" Text="Select One" InitialValue="0" ControlToValidate="ddlGroomerlist"
                                            ErrorMessage="<b>Required Field Missing</b><br />Groomer is required" Display="none"
                                            ValidationGroup="valContactus" runat="server" SetFocusOnError="true" />
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="ReqVAl2"
                                             Enabled="true" runat="Server" />
            </td>
        </tr>
        <tr>
            <td>
                Date/Time:
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="regTextField"
                    Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                    SetFocusOnError="true" ControlToValidate="txtDate" Display="None" ErrorMessage="Appointment Date field should not be blank">  
                </asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                    Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
            </td>
        </tr>
      
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="String:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" CssClass="textarea"> 
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTotalRevnueExpected" runat="server" Text="Expected Revenue(In $ Only):"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTotalRevnueExpected" runat="server" MaxLength="10" Width="180px"
                    CssClass="textBox"> 
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valContactus"
                    SetFocusOnError="true" ControlToValidate="txtTotalRevnueExpected" Display="None"
                    ErrorMessage="Total revenue expected field should not be blank">  
                </asp:RequiredFieldValidator>
                <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                    Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                    <asp:RegularExpressionValidator ID="repExpectedRevenue" runat="server" Display="None" ErrorMessage="<b>Expected Revenue should be Dollars ($xxx.xx)"
                                            ValidationGroup="valContactus" SetFocusOnError="true" ControlToValidate="txtTotalRevnueExpected"
                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                              <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                    Enabled="true" TargetControlID="repExpectedRevenue" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Sequence No:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSequence" runat="server" MaxLength="3" Width="180px" CssClass="textBox"> 
                </asp:TextBox>
            </td>
        </tr>
        
    </table>
    <%--region is use to set button event --%>
    <asp:Button ID="btnUpdate" runat="server" Text="Update Appointment" 
            ToolTip="Update Appointment" CssClass="btnBg"
        ValidationGroup="valContactus" onclick="btnUpdate_Click" />&nbsp;
    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
        ToolTip="Cancel" CssClass="btnBg" onclick="btnCancel_Click"  />
    <%--region is use to set button event end --%>
    </div>

</asp:Content>

