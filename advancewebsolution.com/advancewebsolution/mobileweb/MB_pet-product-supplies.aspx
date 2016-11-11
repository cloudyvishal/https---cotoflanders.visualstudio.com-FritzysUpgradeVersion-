<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="MB_pet_product_supplies"
    Title="Mobile Grooming Services" Codebehind="MB_pet-product-supplies.aspx.cs" %>

<%@ Register Src="MB_Controls/Product_Flea.ascx" TagName="Product" TagPrefix="PR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>
                Pet Products &amp; Supplies</h1>
        </div>
        <PR:Product ID="Pro" runat="server" />
    </div>
</asp:Content>
