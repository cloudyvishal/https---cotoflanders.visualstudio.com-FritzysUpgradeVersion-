<%@ Page Language="C#" AutoEventWireup="true" Inherits="PrintfinalCoupon" Title="Print Coupon" CodeBehind="PrintfinalCoupon.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function PrintIt() {
            window.print();
            window.close();
            return false;
        }
    </script>
    <link href="CSS/Styles.css" type="text/css" rel="Stylesheet" />

</head>
<body onload="PrintIt();">
    <form id="form1" runat="server">
        <div>
            <div style="width: 700px; height: 300px; background: #decfba; margin: 30px auto; text-align: center; padding: 20px;">
                <asp:Image ID="ImgGift" runat="server" border="0" alt="Print Coupon" />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
