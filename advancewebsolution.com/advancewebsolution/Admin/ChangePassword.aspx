<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ChangePassword" Title="Change Password" Codebehind="ChangePassword.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
        <div class="pageTitle">
            <h2>
                Change Password</h2>
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
        
    <div class="FooterTableDiv" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ContentPlaceHolder1_btnApply')" >
                            
                            <table class="adduserTable" cellpadding="6" cellspacing="0">
                               
                               <tr>
                                   <td style="width: 120px">
                                       <span class="star">*</span> Current Password:
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtCurrentPassword" CssClass="memberTextbox" TextMode="Password"
                                           runat="server" ValidationGroup="refer" MaxLength="15"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvCurrentPassword" Display="None" ControlToValidate="txtCurrentPassword"
                                           SetFocusOnError="true" ValidationGroup="refer" runat="server" ErrorMessage="<b>Required Field Missing</b><br />Current Password is required."></asp:RequiredFieldValidator>
                                       <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="vceCurrentPassword" TargetControlID="rfvCurrentPassword"
                                           HighlightCssClass="validatorCalloutHighlight" />
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <span class="star">*</span> New Password:
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtNewPassword" CssClass="memberTextbox" MaxLength="15" TextMode="Password"
                                           runat="server" ValidationGroup="refer"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvNewPassword" Display="None" ControlToValidate="txtNewPassword"
                                           SetFocusOnError="true" ValidationGroup="refer" runat="server" ErrorMessage="<b>Required Field Missing</b><br />New Password is required."></asp:RequiredFieldValidator>
                                       <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1"
                                           TargetControlID="rfvNewPassword" HighlightCssClass="validatorCalloutHighlight" />
                                     
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       <span class="star">*</span> Confirm Password:
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtConfirmPassword" CssClass="memberTextbox" TextMode="Password"
                                           MaxLength="15" runat="server" ValidationGroup="refer"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="rfvConfirmPassword" Display="None" ControlToValidate="txtConfirmPassword"
                                           SetFocusOnError="true" ValidationGroup="refer" runat="server" ErrorMessage="<b>Required Field Missing</b><br />Confirm Password is required."></asp:RequiredFieldValidator>
                                       <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                           TargetControlID="rfvConfirmPassword" HighlightCssClass="validatorCalloutHighlight" />
                                       <asp:CompareValidator ID="cmpPassword" ValidationGroup="refer" runat="server" ControlToCompare="txtNewPassword"
                                           SetFocusOnError="true" Display="None" ControlToValidate="txtConfirmPassword"
                                           ErrorMessage="Password does not match."></asp:CompareValidator>
                                       <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="vcePasswordErr" TargetControlID="cmpPassword"
                                           HighlightCssClass="validatorCalloutHighlight" />
                                   </td>
                               </tr>
                               
                           </table>
                            <asp:Button CssClass="btnBg" ID="btnApply" Text="Save" ValidationGroup="refer" 
                                                   runat="server" ToolTip="Save" onclick="btnApply_Click"/>
                       </div>
 
</asp:Content>

