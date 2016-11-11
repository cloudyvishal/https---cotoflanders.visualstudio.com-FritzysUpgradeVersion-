<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_MetaTags" Title="Admin - Manage Metatags" CodeBehind="MetaTags.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

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

    <script type="text/javascript" language="javascript">
        function ValidateAdd() {
            if (document.getElementById('<%=txtName.ClientID %>').value == "") {
                            alert("Please enter meta name");
                            return false;
                        }

                        if (document.getElementById('<%=txtContent.ClientID %>').value == "") {
                            alert("Please enter meta tag description");
                            return false;
                        }
                        if (document.getElementById('<%=txtKeywords.ClientID %>').value == "") {
                            alert("Please enter meta tag Keywords");
                            return false;
                        }


                    }

                    function ValidateKeyword(num) {

                        if (num == "") {
                            return false;
                        }
                        var OnlyNumbers = /^[a-zA-Z0-9,\s]+$/;
                        if (OnlyNumbers.test(num)) {
                            if ((num.length < 1) || (num.length > 1000)) {
                                return false;
                            }
                            return true;
                        }
                        else {
                            return false;
                        }

                    }

                    function checkTextAreaMaxLength(textBox, e, length) {
                        var mLen = textBox["MaxLength"];
                        if (null == mLen)
                            mLen = length;
                        var maxLength = parseInt(mLen);
                        if (!checkSpecialKeys(e)) {
                            if (textBox.value.length > maxLength - 1) {
                                if (window.event)//IE
                                    e.returnValue = false;
                                else//Firefox
                                    e.preventDefault();
                            }
                        }
                    }

                    function Show() {
                        document.getElementById('<%=divShow.ClientID %>').style.display = "block";
    document.getElementById('<%=btnAdd.ClientID %>').style.display = "none";
    return false;
}
function Hide() {
    document.getElementById('<%=divShow.ClientID %>').style.display = "none";
    document.getElementById('<%=btnAdd.ClientID %>').style.display = "block";
    return false;
}
function ValidatePagetTitle() {
    if (document.getElementById('<%=txtPageTitle.ClientID %>').value == "") {
        alert("Please enter Page Title");
        return false;
    }

}
    </script>
    <div class="innerContent">



        <div class="pageTitle">
            <h2>Manage Meta tags</h2>
        </div>

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
        <br style="clear: both;" />

        <div id="divsearch" visible="false" runat="server" class="searchtopDiv">
            <table border="0" class="searchTable">
                <tr>

                    <td>
                        <asp:DropDownList ID="ddlSearch" runat="server">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Tag Name"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Tag Content"></asp:ListItem>

                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="servbtnBg" OnClientClick="return validate();" OnClick="btnSearch_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="VIEW ALL" CssClass="servbtnBg" OnClick="btnViewall_Click" />
                    </td>
                </tr>
            </table>
            <br style="clear: both;" />
        </div>

        <div id="divSelectPage" runat="server">
            <table class="setservPage" style="width: 60%;">
                <tr>
                    <td>Please Select Page : </td>
                    <td>
                        <asp:DropDownList ID="ddlPage" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Page Title :</td>
                    <td>
                        <asp:TextBox ID="txtPageTitle" runat="server"></asp:TextBox>
                        <asp:Button ID="btnUpdatePageTitle" Text="Update Page Title" ToolTip="Update Page Title" runat="server"
                            OnClientClick="return ValidatePagetTitle();" CssClass="btnBg" OnClick="btnUpdatePageTitle_Click" />
                    </td>
                </tr>

            </table>
        </div>




        <asp:GridView ID="GrdMeta" runat="server" DataKeyNames="MetaID" AutoGenerateColumns="False"
            AllowSorting="true" AllowPaging="true" PageSize="10"
            CellPadding="0" CellSpacing="0" GridLines="Vertical" Width="100%"
            HeaderStyle-CssClass="headerStyle" CssClass="gridStyle"
            AlternatingRowStyle-CssClass="altGridStyle"
            OnPageIndexChanging="GrdMeta_PageIndexChanging" OnSorting="GrdMeta_Sorting" OnDataBound="GrdMeta_DataBound"
            OnRowCreated="GrdMeta_RowCreated">
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
            <AlternatingRowStyle CssClass="altGridStyle" />
            <PagerStyle CssClass="gridPager" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:HyperLinkField ItemStyle-CssClass="itemstyle manageuser"
                    HeaderStyle-CssClass="headerStyle" DataNavigateUrlFields="MetaID, PageID"
                    DataNavigateUrlFormatString="EditMeta.aspx?PageID={1}&MetaID={0}"
                    DataTextField="Name" HeaderText="Tag Name"></asp:HyperLinkField>



                <asp:TemplateField HeaderText="Tag Name" Visible="false">
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemStyle CssClass="itemstyle" Width="20%" />
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tag Content">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblmetaContent" runat="server" Text='<%# Bind("MetaContent") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>


        </asp:GridView>

        <table>
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Meta" CssClass="btnBg" OnClientClick="return Show();" /></td>
                <td>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnBg" OnClick="btnDelete_Click" /></td>
            </tr>
        </table>
        <div id="divShow" runat="server" style="display: none; margin: 10px 0 0 0;" class="itemstyle">

            <div class="pageTitle">
                <h2>Add Metatag to this page</h2>
            </div>
            <table class="adduserTable" cellpadding="6" cellspacing="0">
                <tr>
                    <td>
                        <span class="star">*</span>Name :
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="star">*</span>Description :
                    </td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" Rows="5" Columns="60" TextMode="MultiLine"
                            MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'500');"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="star">*</span>Keywords :
                    </td>
                    <td>
                        <asp:TextBox ID="txtKeywords" runat="server" Rows="5" Columns="60" TextMode="MultiLine"
                            MaxLength="1000" onkeyDown="checkTextAreaMaxLength(this,event,'500');"></asp:TextBox>
                    </td>
                </tr>

            </table>
            <asp:Button ID="btnAdd1" runat="server" Text="Add" CssClass="btnBg" OnClientClick="return ValidateAdd()"
                OnClick="btnAdd_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBg" OnClientClick="return Hide()" />
        </div>
        <asp:Button ID="lnkNorec" runat="server" Text="Go Back" CssClass="btnBg" OnClick="lnkNorec_Click" Visible="false" />
    </div>
</asp:Content>

