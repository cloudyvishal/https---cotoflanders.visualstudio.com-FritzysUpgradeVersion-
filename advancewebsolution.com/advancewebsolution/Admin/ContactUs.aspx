<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ContactUs" Title="Admin - Contact Us" CodeBehind="ContactUs.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById('<%=ddlSearch.ClientID %>').value == "0") {
        alert("Please select search criteria");
        return false;
    }
    if (document.getElementById('<%=txtSearch.ClientID %>').value == "") {
        alert("Please enter search text");
        return false;
    }
}
    </script>
    <script language="javascript" type="text/javascript">
        function ShowDiv() {
            document.getElementById('<%=divShow.ClientID %>').style.display = "Block";
    document.getElementById('<%=divBtn.ClientID %>').style.display = "none";
    document.getElementById('<%=txtStartDate.ClientID %>').value = "";
    document.getElementById('<%=txtEndDate.ClientID %>').value = "";
    return false;
}

function HideDiv() {
    document.getElementById('<%=divShow.ClientID %>').style.display = "none";
    document.getElementById('<%=divBtn.ClientID %>').style.display = "block";
    return false;
}

function ValidateExport() {
    if (document.getElementById('<%=txtStartDate.ClientID %>').value == "") {
        document.getElementById('<%=txtStartDate.ClientID %>').focus();
        alert("Please select start date");
        return false;
    }
    if (document.getElementById('<%=txtEndDate.ClientID %>').value == "") {
        document.getElementById('<%=txtEndDate.ClientID %>').focus();
        alert("Please select end date");
        return false;
    }
    if (document.getElementById('<%=txtStartDate.ClientID %>').value != "" & document.getElementById('<%=txtEndDate.ClientID %>').value != "")
        var StartDate = document.getElementById('<%=txtStartDate.ClientID %>').value;
     var EndDate = document.getElementById('<%=txtEndDate.ClientID %>').value;
    var eDate = new Date(EndDate);
    var sDate = new Date(StartDate);
    if (StartDate != '' && StartDate != '' && sDate > eDate) {
        alert("Please ensure that the End Date is greater than or equal to the Start Date.");
        return false;
    }
}
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>Contact Us</h2>
        </div>

        <%--Region Error/Success message start--%>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--Region Error/Success message end--%>

        <div id="divsearch" runat="server" class="searchtopDiv">
            <table border="0" class="searchTable">
                <tr>

                    <td>
                        <asp:DropDownList ID="ddlSearch" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Name"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Message"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Email"></asp:ListItem>

                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="servbtnBg" OnClientClick="return validate();"
                            OnClick="btnSearch_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="View All" CssClass="servbtnBg"
                            OnClick="btnViewall_Click" />
                    </td>
                </tr>
            </table>
            <br style="clear: both;" />
        </div>

        <%-- Region  grid start--%>
        <asp:GridView ID="gdvContactUs" runat="server" AutoGenerateColumns="False" CellPadding="0" PageIndex="2"
            AllowPaging="True" DataKeyNames="ContactID" GridLines="Vertical" Width="100%" AllowSorting="true" OnSorting="gdvContactUs_Sorting"
            OnPageIndexChanging="gdvContactUs_PageIndexChanging" OnDataBound="gdvContactUs_DataBound" OnRowCreated="gdvContactUs_RowCreated" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle">
            <PagerTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
                <asp:Label ID="pmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Page" CommandArgument="Prev">Prev</asp:LinkButton>
                <asp:LinkButton ID="p0" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p1" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p2" runat="server">LinkButton</asp:LinkButton>
                <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="p4" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p5" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p6" runat="server">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Page" CommandArgument="Next">Next</asp:LinkButton>
                <asp:Label ID="nmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Page" CommandArgument="Last">Last</asp:LinkButton>
            </PagerTemplate>
            <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
            <PagerStyle CssClass="gridPager" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="center" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="center" />
                    <HeaderStyle CssClass="headerStyle" />
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle" DataNavigateUrlFields="ContactID" DataNavigateUrlFormatString="ContactUsDetail.aspx?ID={0}&p=2"
                    DataTextField="fullName" HeaderText="Name" SortExpression="fullName"></asp:HyperLinkField>
                <asp:TemplateField HeaderText="Message" SortExpression="Message">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <div class="contactOverflow">
                            <asp:Label ID="lblImage" runat="server" Text='<%# Bind("Message") %>'></asp:Label></div>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                    <ItemStyle CssClass="itemstyle" Width="20%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddedon" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Date" SortExpression="Addedon">
                    <ItemStyle CssClass="itemstyle" Width="13%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblFile" runat="server" Text='<%# Bind("Addedon", "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        <%-- Region  grid end --%>
        <%-- Region  Button start --%>
        <div id="divBtn" runat="server" style="display: block; margin-top: 15px;">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg" OnClick="btnDelete_Click" />
            <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
            <asp:Label ID="lblMsg" runat="server" Text="No Record Found" Visible="false" />
            <asp:Button ID="btnExp" runat="server" Text="EXPORT" ToolTip="Export" CssClass="btnBg"
                OnClientClick="return ShowDiv();" />
        </div>
        <%-- Region  button end --%>
        <%-- Region  export end --%>

        <div class="itemstyle" style="margin: 10px 0pt 0pt; display: none;" id="divShow"
            runat="server">
            <table border="0" style="margin: 10px 0pt 0pt;">
                <tr>
                    <td>Start Date :
                    </td>
                    <td>
                        <asp:TextBox ID="txtStartDate" onkeypress="return false;" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgCalPop" runat="server" ImageUrl="~/Images/calImage.jpg" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/d/yyyy" PopupButtonID="imgCalPop"
                            TargetControlID="txtStartDate"></cc1:CalendarExtender>
                    </td>
                    <td>End Date :
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndDate" onkeypress="return false;" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calImage.jpg" />
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/d/yyyy" PopupButtonID="ImageButton1"
                            TargetControlID="txtEndDate"></cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:Button ID="btnExport" runat="server" Text="Export" ToolTip="Export" CssClass="servbtnBg"
                            OnClientClick="return ValidateExport();" OnClick="btnExport_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="servbtnBg"
                            OnClientClick="return HideDiv();" />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <%-- Region  export end --%>
    </div>
</asp:Content>

