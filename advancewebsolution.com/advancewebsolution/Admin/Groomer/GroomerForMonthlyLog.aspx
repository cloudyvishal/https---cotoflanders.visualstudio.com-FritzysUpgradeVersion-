<%@ Page Title="Groomer For Monthly Log" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_GroomerForMonthlyLog" Codebehind="GroomerForMonthlyLog.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript" language="javascript" >
 

function validate()
{
    if(document.getElementById('<%=ddlSearch.ClientID %>').value == "0")
    {
        alert("Please select search criteria");
        return false;
    }
     if(document.getElementById('<%=txtSearch.ClientID %>').value == "")
    {
        alert("Please enter search text");
        return false;
    }
}


</script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Groomer For Monthly Log</h2>
        </div>
        <%--Region Error/Success message start--%>
        <table>
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server" visible="false">
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
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divsearch" runat="server" class="searchtopDiv">
                        <table border="0" class="searchTable">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSearch" runat="server">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Name"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClientClick="return validate();" ToolTip="SEARCH" OnClick="btnSearch_Click" CssClass="servbtnBg"/>
                                </td>
                                <td>
                                    <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="VIEW ALL" CssClass="servbtnBg" OnClick="btnViewall_Click"
                                         />
                                </td>
                            </tr>
                        </table>
                       
                    </div>
                </td>
            </tr>
        </table>
      
        <%--Region Error/Success message end--%>
        <%-- Region  grid start--%>
        <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="GID" AutoGenerateColumns="False"
             AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GrdUsers_PageIndexChanging" OnSorting="GrdUsers_Sorting" OnDataBound="GrdUsers_DataBound" OnRowCreated="GrdUsers_RowCreated"
            PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
            CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle"
            >
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
                  <asp:TemplateField HeaderText="Groomer Name" SortExpression="Name">
                    <ItemStyle CssClass="itemstyle" Width="30%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                    DataNavigateUrlFields="GID" DataNavigateUrlFormatString="GroomerMonthlyOperationLog.aspx?GID={0}&p=1"
                     HeaderText="Groomer monthly operation log"  Text="View monthly log">
                </asp:HyperLinkField>
                
                </Columns>
        </asp:GridView>
        <%-- Region  grid end --%>
          </div>
</asp:Content>

