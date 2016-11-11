<%@ Page Title="" Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master"
    AutoEventWireup="true" Inherits="Mobile_MB_newsdetail" Codebehind="MB_newsdetail.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>
                <asp:Label ID="lblnewstitle" runat="server"></asp:Label></h1>
        </div>
        <div class="innercontent">
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
