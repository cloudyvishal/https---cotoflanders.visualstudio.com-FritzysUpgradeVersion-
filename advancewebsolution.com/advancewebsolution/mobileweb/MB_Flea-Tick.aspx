<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="MB_Flea_Tick" Title="Mobile Grooming Services" CodeBehind="MB_Flea-Tick.aspx.cs" %>

<%@ Register Src="MB_Controls/Product_Flea.ascx" TagName="Product" TagPrefix="PR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentinner_flea">
        <div class="innerpageheading-flea">
            <h1>Flea, Tick &amp; Hotspot Treatments</h1>
        </div>
        <div class="innercontent-flea">
            <h2>For Your Dogs</h2>
            <asp:Image ID="imgDogservice" runat="server" AlternateText="" />
            <p>
                <asp:Label ID="divDogService" runat="server"></asp:Label>
            </p>
            <p>
                <a href="MB_services.aspx?PetID=Dog" class="more" title="more">more</a>
            </p>
            <h2>For Your Cats</h2>
            <asp:Image ID="imgCatservice" runat="server" AlternateText="" />
            <p>
                <asp:Label ID="divCatService" runat="server"></asp:Label>
            </p>
            <p>
                <a href="MB_services.aspx?PetID=Cat" class="more" title="more">more</a>
            </p>
            <div class="productdiv">
                <h2>Products</h2>
                <PR:Product ID="Pro" runat="server" />

            </div>
        </div>
    </div>
</asp:Content>
