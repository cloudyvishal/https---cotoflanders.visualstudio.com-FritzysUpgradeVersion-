<%@ Page Title="" Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="mobileweb_MB_menu" CodeBehind="MB_menu.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            var userId = '<%= Session["UserID"] %>';
        if (userId == '') {
            $("#linkMakePayment").hide();
            $("#linkJoinFritzys").show();
        }
        else {
            $("#linkJoinFritzys").hide();
            $("#linkMakePayment").show();
        }
    });

    </script>
    <div style="width: 317px; margin: 0; padding: 0 2px 0 1px; float: left;" id="menumobile">
        <a href="MB_index.aspx">
            <img src="images/home_menu_title.jpg" width="317" height="37" alt="" title="Home" /></a>
        <a href="MB_aboutus.aspx">
            <img src="images/about_us_title.jpg" width="317" height="37" alt="" title="About Us" /></a>
        <a href="MB_services.aspx">
            <img src="images/mobile_grooming_services_title.jpg" width="317" height="37" alt="" title="Mobile Grooming Services" /></a>
        <a href="MB_pet-product-supplies.aspx">
            <img src="images/pet_product_and-_supplies_title.jpg" width="317" height="37" alt="" title="Pet Products & Supplies" /></a>
        <a href="MB_Flea-Tick.aspx">
            <img src="images/flea_tick_title.jpg" width="317" height="37" alt="" title="Flea,Tick & Hot Spot" /></a>
        <a id="linkJoinFritzys" href="MB_Registration.aspx">
            <img src="images/join_fritzy_club_title.jpg" width="317" height="37" alt="" title="Join Fritzy's Club" /></a>
        <a id="linkMakePayment" href="PaymentInfo.aspx">
            <img src="../Images/make.jpg" width="317" height="37" alt="" title="Make Payment" /></a>
        <a href="MB_visit-our-van.aspx">
            <img src="images/visit_our_van_title.jpg" width="317" height="37" alt="" title="Visitor Our Van" /></a>
        <a href="MB_contactus.aspx">
            <img src="images/contact_us_title.jpg" width="317" height="37" alt="" title="Contact Us" /></a>
    </div>
</asp:Content>
