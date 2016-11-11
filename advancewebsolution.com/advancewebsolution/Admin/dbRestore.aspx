<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default"
    MasterPageFile="~/Admin/AdminMaster.master" Title="Database Restore" Codebehind="DBRestore.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Pnlrestoredb" runat="server" HorizontalAlign="Center">
        <table style="width: 80%;" class="adduserTable">
            <tr>
                <td align="center" colspan="2">
                    <h2>Database Restore</h2>
                </td>
            </tr>
            <tr>
                <td style="width:25%;">
                    Select file to upload :
                </td>
                <td align="left">
                    <asp:FileUpload ID="uplfile" runat="server" Width="279px" />
                </td>
            </tr>
            <tr>
                <td style="width:25%;">
                    &nbsp;</td>
                <td align="left">
                    Select .zip file to upload.</td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvdbfile0" runat="server" 
                        ControlToValidate="uplfile" Display="Dynamic" ErrorMessage="File required." 
                        ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revfile0" runat="server" 
                        ControlToValidate="uplfile" Display="Dynamic" 
                        ErrorMessage="File format is not supported." 
                        ValidationExpression="^.*\.((z|Z)(i|I)(p|P))$" ValidationGroup="Submit" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="left">
                    <asp:Button ID="btnrestore" runat="server" Font-Bold="False" Text="Restore" ValidationGroup="Submit"
                        OnClick="btnrestore_Click" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
