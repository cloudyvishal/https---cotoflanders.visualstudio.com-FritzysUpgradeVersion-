<%@ Page Language="C#" AutoEventWireup="true" Inherits="Admin_Baner_ReadXmml" CodeBehind="ReadXmml.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Banner</title>
    <%--<link href="CSS/Admin.css" type="text/css" rel="Stylesheet" />--%>
    <style type="text/css">
        body {
            background: #83613b;
            margin: 0;
            padding: 0;
        }

        .marqueediv {
            border: 5px solid #35291b;
            background: #DECFB9;
            width: 90%;
            margin: 120px auto;
            padding: 20px 20px;
        }

        .pageTitle {
            border-bottom: 2px solid #35291b;
            height: 42px;
            width: 100%;
            padding: 5px 0 0 0;
        }

        h2 {
            color: #503414;
            font-size: 18px;
            font-family: Times New Roman;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="marqueediv">
            <div class="pageTitle">
                <h2>View Banners</h2>
                <br />
            </div>
            <br />
            <%--  <marquee direction="left" loop="true" scrollamount="5" onmouseover="this.stop()"
            onmouseout="this.start()">--%>
            <asp:DataList ID="dtlPhoto" runat="server" OnItemDataBound="dtlPhotoCategory_ItemDataBound" RepeatColumns="8"
                RepeatDirection="Horizontal">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>

                                <img id="ImgShow" style="border: solid 2px #345834;"
                                    width="100" height="60"
                                    runat="server" />
                                <asp:Label ID="lblFileName" Text='<%# Bind("imagePath") %>' Visible="false" runat="server"></asp:Label>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>
            </asp:DataList>
            <%--  </marquee>--%>
        </div>
    </form>
</body>
</html>
