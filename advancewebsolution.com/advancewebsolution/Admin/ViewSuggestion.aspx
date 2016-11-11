<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ViewSuggestion" Title="View Suggestions" Codebehind="ViewSuggestion.aspx.cs" %>
<%--this page is use to view suggestion --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Suggestion Details</h2>
        </div>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 13%;">
                    Name :
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Email :</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Phone :</td>
                <td>
                    <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    Comment :
                </td>
                <td>
                    <div class="ContactDtlsOverflow">
                        <asp:Label ID="lblComment" runat="server" Text=""></asp:Label></div>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel"   OnClientClick="parent.history.back(); return false;"
            CssClass="btnBg" />
    </div>
</asp:Content>
