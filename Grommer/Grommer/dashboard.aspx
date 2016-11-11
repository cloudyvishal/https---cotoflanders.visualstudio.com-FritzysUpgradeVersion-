<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="dashboard" CodeBehind="dashboard.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innercontent">
        <%--Region Error/Success message start--%>
        <div id="divMsg" runat="server">
            <asp:Label ID="lblMsg" runat="server" class="not_avail"></asp:Label>
        </div>

        <div id="divError" runat="server">
            <asp:Label ID="lblError" runat="server" class="avail"></asp:Label>
        </div>


        <div class="divrow" id="divDetails" runat="server">
            <div class="divrow">
                <div class="divcell_left1" style="margin-left: -111px !important;">
                    <asp:Label ID="Label1" runat="server" CssClass="appnt_lbl">Appointment  Date/Time:</asp:Label>
                </div>
                <%-- class="divcell_right"--%>
                <div>
                    <asp:Label ID="lbl_time" runat="server" CssClass="appnt_detail" Text=""></asp:Label>
                </div>
            </div>

            <div class="divrow">
                <div class="divcell_left">
                    <asp:Label ID="Label2" runat="server" CssClass="appnt_lbl">String:</asp:Label>
                </div>
                <div class="divcell_right">
                    <asp:Label ID="lbl_description" runat="server" CssClass="appnt_detail" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="divrow">
            <div class="go_btn">
                <asp:Button ID="Button1" Visible="false" runat="server" Text="Go" ToolTip="Go" CssClass="btn" Style="margin-left: -157px; width: 100px; font-size: 14px;" OnClick="Button1_Click" />
            </div>
        </div>

        <div class="spacer10"></div>
    </div>
</asp:Content>
