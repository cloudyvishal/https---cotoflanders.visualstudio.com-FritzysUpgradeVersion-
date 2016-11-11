<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="UpdateCoupon" Title="Update Coupon" CodeBehind="~/Admin/Banner/UpdateCoupon.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Update Coupon</h2>
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
                <td>Select Coupon :<asp:FileUpload ID="flv" runat="server" onkeypress="return false" />
                    <br />

                    <asp:Button ID="btnUp" runat="server" Text="Upload" OnClick="btnUp_Click" CssClass="btnBg" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click" CssClass="btnBg" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
