<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="giftcard.ascx.cs" Inherits="Controls_giftcard" %>

<script type="text/javascript" language="javascript">
    function GotoPrint()
    {
        window.open('GiftCard.aspx','windowname1', 'width=500, height=500, scrollbars=1'); 
        return false;
    }
</script>

<div class="img">
    <a href="Contactus.aspx" title="Fritzy's giftcard">
        <img src="images/giftcard.jpg" border="0" alt="Fritzy's GiftCard" onclick="return GotoPrint();" /></a>
</div>
