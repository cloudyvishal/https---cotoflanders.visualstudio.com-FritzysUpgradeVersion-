<%@ Page Language="C#" AutoEventWireup="true" Inherits="PrintGift" CodeBehind="PrintGift.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print GiftCard</title>

    <script type="text/javascript" language="javascript">
        function PrintCard() {
            document.getElementById('<%=btnPrint.ClientID %>').style.display = "none";
      window.print();
  }
    </script>
    <link href="CSS/Styles.css" type="text/css" rel="Stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="width: 400px; height: 200px; background: #decfba; margin: 30px auto; text-align: center; padding: 20px;">
                <img src="images/giftcard1.jpg" border="0" alt="Fritzy's GiftCard" /><br />
                <asp:Button ID="btnPrint" runat="server" Text="Print" ToolTip="Print" CssClass="printbtnBg" OnClientClick="return PrintCard();" />
            </div>
        </div>
    </form>
</body>
</html>