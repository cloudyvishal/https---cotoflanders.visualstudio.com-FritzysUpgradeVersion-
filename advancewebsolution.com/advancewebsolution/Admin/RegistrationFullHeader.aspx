<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true"
    ValidateRequest="false" Inherits="Admin_RegistrationFullHeader"
    Title="Registration" Codebehind="RegistrationFullHeader.aspx.cs" %>

<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Full Registration
            </h2>
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
        <%--Region fo rFCK Editor --%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td colspan="2">
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </table>
        <%--Region fo rFCK Editor --%>
        <%-- region for button --%>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg"
            OnClick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            ToolTip="Cancel" CssClass="btnBg" OnClick="btnCancel_Click" />
        <%-- region for button --%>
    </div>
</asp:Content>
