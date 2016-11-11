<%@ Page Language="C#" AutoEventWireup="true" Inherits="WhatsNew" Title="Fritzy's pet care pros : What's New" Codebehind="WhatsNew.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<script language='javascript'>
function WinClose()
{
window.close()
}
</script>

    <title>Fitzy's</title>
    
    <style>
    .btnBg{ border:1px solid #bc9964; background:url(images/btnBg.jpg) repeat-x; font-family:"Times New Roman"; font-size:13px; font-weight:bold; padding:0; margin:10px auto;}

    </style>
</head>
<body style="background:#decfba; color:#604422; font-family:Verdana; font-size:11px;">
    <form id="form1" runat="server">
    
    <div style="padding-right: 20px; padding-left: 20px; background: #f3ece4; padding-bottom: 20px; line-height: 25px; padding-top: 20px">
     <asp:Literal ID="litContent"  runat="server"></asp:Literal>
     
     
     </div>
     <div style="text-align:center; width:100px; margin:0 auto;">
     <asp:Button ID="btnClose" CssClass="btnBg" OnClientClick="return WinClose()" Text="Close" runat="server" />
     </div>
    </form>
</body>
</html>
