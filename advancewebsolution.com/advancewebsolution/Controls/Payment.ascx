<%@ Control Language="C#" AutoEventWireup="true" Inherits="Controls_Payment" Codebehind="Payment.ascx.cs" %>
<div class="makepayment" onkeypress="javascript:return FormPanel_FireDefaultButtonZip(event,'ctl00_ContentPlaceHolder1_ctlZipcode_imgZipcode')">
    <div class="zipcode">
        <asp:LinkButton ID="lnkPayment" runat="server" OnClick="lnkPayment_Click">Click Here</asp:LinkButton>
    </div>
</div>
