<%@ Page Language="c#" Inherits="CyberSourceStore.DisplaySuccess"
    MasterPageFile="~/MasterPage.master" Codebehind="DisplaySuccess.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Payment Success</h1>
    <%= mMessage %>
    <p>
    </p>
    <p>
        <asp:Button ID="btndone" runat="server" CssClass="btn" Text="Next Appointment" OnClick="btndone_Click"
            ValidationGroup="Payment_Validation" Width="101px" /></p>
</asp:Content>
