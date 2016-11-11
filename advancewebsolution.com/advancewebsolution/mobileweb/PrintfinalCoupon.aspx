<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="Mobile_PrintfinalCoupon" Codebehind="PrintfinalCoupon.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="initial-scale=1.0,maximum-scale=1.0,minimum-scale=1.0,user-scalable=no, width=320;" />
    <meta name="cache-control" content="no-cache;" />
    <title>Print Coupon</title>

    <script language="javascript" type="text/javascript">
        function PrintIt() {
            window.print();
            window.close();
            return false;
        }
    </script>

    <link href="css/style.css" type="text/css" rel="Stylesheet" />
</head>
<body onload="PrintIt();">
    <div style="width: 320px; margin: 4px auto 0 auto;">
        <form id="form1" runat="server">
        <div class="container">
            <div style="width: 320px; height: 150px; background: #decfba; margin: 30px auto;
                text-align: center;">
                <asp:Image ID="ImgGift" runat="server" border="0" alt="Print Coupon" Height="142"
                    Width="320" />
                <br />
                <a href="javascript:history.go(-1)" title="Back">
                    <img src="images/back_button.jpg" alt="Back" /></a>
            </div>
        </div>
        </form>
    </div>
</body>
</html>
