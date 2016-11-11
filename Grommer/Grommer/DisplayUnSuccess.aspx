<%@ Page Language="c#" Inherits="CyberSourceStore.DisplayUnSuccess"
    MasterPageFile="~/MasterPage.master" Codebehind="DisplayUnSuccess.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Payment UnSuccessful</h1>
    <%= mMessage %>
    <p>
    </p>
    <%= Transresult%>
    <p>
    </p>
    <p>
        <asp:Button ID="btndone" runat="server" CssClass="btn" Text="Try Again" OnClick="btndone_Click"
            ValidationGroup="Payment_Validation" Width="101px" /></p>
</asp:Content>
