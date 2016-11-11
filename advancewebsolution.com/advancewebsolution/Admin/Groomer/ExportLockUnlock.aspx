<%@ Page Title="Export Lock / Unlock" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_ExportLockUnlock" Codebehind="ExportLockUnlock.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
        <div class="pageTitle">
            <h2>           Upload / Download Excel Files</h2>
        </div>
 <%--Region Error/Success message start--%>
        <div class="errorDiv" id="divError" runat="server" visible="true">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="true" EFont-Bold="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--Region Error/Success message end--%>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
       
       <tr>
        <td>
        <td>
          <asp:GridView ID="GrdDownload" runat="server" DataKeyNames="FId" AutoGenerateColumns="False"
             AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GrdDownload_PageIndexChanging"  OnDataBound="GrdDownload_DataBound" OnRowCreated="GrdDownload_RowCreated"
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
                <asp:TemplateField HeaderText="File Name">
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("FileName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Status">
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="id" Visible="false" >
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                            <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server"  Text='<%# Bind("FID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </td>
        </td>
        </tr>
        <tr>
            <td></td>
            <td id="tdFile" runat="server">
                <asp:Button ID="btnStatus" runat="server" CssClass="btnBg" Text="Lock/Unlock" ToolTip="Lock/Unlock" OnClick="btnStatus_Click"  />
            </td>
        </tr>
        
        </table>
   
</div>
</asp:Content>

