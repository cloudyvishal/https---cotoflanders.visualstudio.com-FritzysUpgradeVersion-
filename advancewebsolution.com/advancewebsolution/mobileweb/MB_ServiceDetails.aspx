<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="MB_ServiceDetails" Title="Mobile Grooming Services" Codebehind="MB_ServiceDetails.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>
                <asp:Label ID="lblTitle" runat="server"></asp:Label><br />
                <br />
            </h1>
        </div>
       
        <div class="ServicesMidDiv">
            <asp:Image ID="ImgService" runat="server" AlternateText="" CssClass="imgfloatleft" />
            <span id="divDogService" runat="server"><b>
                <asp:Label ID="lblServiceDesc" CssClass="shortDesc" runat="server"></asp:Label></b>
            </span>
            <%--Literal control will show content of services--%>
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>

