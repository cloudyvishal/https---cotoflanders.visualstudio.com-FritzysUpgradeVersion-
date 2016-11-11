<%@ Page Language="C#" AutoEventWireup="true" Inherits="PrintCoupon" Title="Print Coupon" CodeBehind="PrintCoupon.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" language="javascript">
        function PrintCard() {
            document.getElementById('<%=divButton.ClientID %>').style.display = "none";
          window.print();
          return false;
      }
    </script>
    <link href="CSS/Styles.css" type="text/css" rel="Stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="width: 700px; height: 300px; background: #decfba; margin: 30px auto; text-align: center; padding: 20px;">
                <asp:Image ID="ImgGift" runat="server" border="0" alt="Print Coupon" />
                <br />
                <div id="divButton" runat="server" style="display: block;">
                    <asp:Button ID="btnPrint" runat="server" Text="Print" ToolTip="Print" CssClass="printbtnBg" OnClientClick="return PrintCard();" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
