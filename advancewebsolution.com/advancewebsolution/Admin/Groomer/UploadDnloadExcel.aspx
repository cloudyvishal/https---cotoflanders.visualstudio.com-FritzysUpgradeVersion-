<%@ Page Title="Upload / Download Excel File" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_UploadDnloadExcel" CodeBehind="UploadDnloadExcel.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Upload / Download Excel Files</h2>
        </div>
        <%--Region Error/Success message start--%>
        <div class="errorDiv" id="divError" runat="server" visible="true">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="true" EFont-Bold="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--Region Error/Success message end--%>
        <asp:Button Style="display: none;" Text="Truncate Tables For Testing" runat="server" ID="btnTruncateTables" OnClientClick=" return confirm('Are you sure?')" CssClass="btnBg" OnClick="btnTruncateTables_Click" />
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr id="trupload" runat="server">
                <td valign="top">Upload File </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:FileUpload ID="FileUpload1" runat="server" ClientIDMode="Static" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" CssClass="btnBg" />
                </td>
            </tr>
            <tr id="tr2" runat="server">
                <td style="width: 150px;">Push to spreadsheet
                </td>
                <td valign="top">
                    <asp:Button ID="Push" runat="server" Text="Push to spreadsheet" OnClick="Push_Click" CssClass="btnBg" />
                    <asp:Panel ID="Panel3" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr id="trdownload" runat="server">
                <td style="width: 150px;">Download Excel File
                </td>
                <td valign="top">
                    <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" CssClass="btnBg" Visible="false" />
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
