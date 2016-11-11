<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Baner_UploadBaner" Title="Admin - Upload Banner" CodeBehind="UploadBaner.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Upload Banner</h2>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" BorderWidth="1px" BorderColor="red" ForeColor="red" runat="server" />
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="lblImage" runat="server" Text="Upload Image :"></asp:Label>
                    <br />
                </td>
                <td>
                    <asp:Image ID="ImgService" runat="server" /><br />
                    <asp:FileUpload ID="flUploadDetail" onkeypress="return false;" runat="server"></asp:FileUpload>&nbsp;
                    <asp:Button ID="btnUpload" runat="server" CausesValidation="false" Text="Upload" ToolTip="Upload" CssClass="btnBg" OnClick="btnUpload_Click" />&nbsp;
                        File size should be 668 X 256 

                </td>
            </tr>
        </table>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg" OnClick="btnUpdate_Click" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btnBg" Text="Cancel" ToolTip="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>

