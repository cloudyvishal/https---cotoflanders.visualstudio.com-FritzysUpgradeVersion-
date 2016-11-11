<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Baner_UpdateCoupon" Title="Update Coupon" Codebehind="UpdateBannerNew.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Update Coupon</h2>
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
        <table class="setservPage">
            <tr>
                <td>
                    Select Coupon For :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="drpcouponselect" runat="server" 
                        onselectedindexchanged="drpcouponselect_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Coupon Type</asp:ListItem>
                        <asp:ListItem Value="1">Main Website Coupon</asp:ListItem>
                        <asp:ListItem Value="2">Mobile Website Coupon</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td runat="server" id="tdmain" visible="false">
                    Select Coupon :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:FileUpload ID="flv" runat="server" onkeypress="return false" />
                </td>
            </tr>
            <tr>
                <td runat="server" id="tdmobile" visible="false">
                    Select Mobile Banner :
                    <asp:FileUpload ID="fup" runat="server" onkeypress="return false" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUp" runat="server" Text="Upload" OnClick="btnUp_Click" CssClass="btnBg" />
                    <asp:Button ID="btnSave" runat="server" Text="Mobile Upload" OnClick="btnSave_Click"
                        CssClass="btnBg" Enabled="False" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"
                        CssClass="btnBg" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
