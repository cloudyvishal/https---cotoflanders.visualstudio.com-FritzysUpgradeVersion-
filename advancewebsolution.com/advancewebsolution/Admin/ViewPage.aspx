<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" validateRequest="false" Inherits="Admin_ViewPage"   Codebehind="ViewPage.aspx.cs" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                <asp:Label ID="lblHead" runat="server" ></asp:Label> </h2>
        </div>
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
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td colspan="2">
                    <%--<FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>--%>
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg"
            OnClick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            ToolTip="Cancel" CssClass="btnBg" OnClick="btnCancel_Click" />
    </div>
             
             
</asp:Content>

