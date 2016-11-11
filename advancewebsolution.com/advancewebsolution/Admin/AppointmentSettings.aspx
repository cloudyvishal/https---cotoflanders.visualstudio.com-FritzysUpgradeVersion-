<%@ Page Title="Admin - Manage Appointment Time" Language="C#" MasterPageFile="~/Admin/AdminMaster.master"
    AutoEventWireup="true" Inherits="Admin_AppointmentSettings" Codebehind="AppointmentSettings.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>Manage Appointment Time</h2>
        </div>
        <table>
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server" visible="false">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" rowspan="2">
                                        <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <br style="clear: both;" />
                </td>
            </tr>
        </table>
        <table width="100%">

            <tr>
                <td>
                    <div id="divsearch" runat="server">
                        <table class="setservPage AppSettingTable" cellpadding="4" cellspacing="0" border="0">
                            <tr>
                                <td style="width: 120px;">&nbsp;
                                </td>
                                <td style="width: 120px;">&nbsp;
                                   
                                </td>
                                <td style="padding-top: 7px;">

                                    <asp:ImageButton ID="imgCalPop" runat="server" ImageUrl="~/Images/calImage.jpg" Visible="false" />
                                    
                                    <asp:UpdatePanel runat="server" ID="upCalData" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                        <ContentTemplate>
                                            <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <asp:UpdatePanel runat="server" ID="upTxtTransDate" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                                        </Triggers>
                                        <ContentTemplate>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date:
                                    <asp:TextBox ID="txtDate" onkeypress="return false;" runat="server" ReadOnly="true" CssClass="regTextField" Width="120px"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>

                        </table>
                        <table class="setservPage AppSettingTable" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td colspan="3" style="padding: 5px 0 0 0;">&nbsp;Select Time:<br />
                                    <br />
                                    <asp:DataList ID="dtlTime" DataKeyField="APTId" runat="server" RepeatColumns="6" RepeatDirection="Horizontal" CssClass="AppSettingTable"
                                        Width="100%" CellPadding="0" CellSpacing="0">
                                        <ItemTemplate>
                                            <div class="app_time">
                                                <table class="noborder">
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkTime" Checked="true" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTime" CssClass="description" Text='<%# Bind("APTTime") %>' runat="server"></asp:Label>
                                                            <asp:Label ID="lblTimeId" Visible="false" CssClass="description" Text='<%# Bind("APTId") %>' runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>



                        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save"
                            CssClass="btnBg" OnClick="btnSave_Click" />

                        <br style="clear: both;" />
                    </div>
                </td>
            </tr>
        </table>
        <asp:GridView ID="gdvBreed" runat="server" AutoGenerateColumns="False" CellPadding="0"
            AllowSorting="true" AllowPaging="True" GridLines="Vertical"
            Width="100%" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle"
            AlternatingRowStyle-CssClass="altGridStyle"
         OnDataBound="gdvBreed_DataBound" OnSorting="gdvBreed_Sorting" OnRowCreated="gdvBreed_RowCreated" OnPageIndexChanging="gdvBreed_PageIndexChanging">
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
                    <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="headerStyle1" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="headerStyle1" HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Appointment Date Type" SortExpression="AppDate">
                    <ItemStyle CssClass="itemstyle" Width="30%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("AppDate") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEdit" runat="server" Text="Edit" NavigateUrl='<%# Eval("AppDate", "~/Admin/EditAppointmentSetting.aspx?dt={0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div id="DivlnkShowBreed" runat="server" style="display: block">
            <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete"
                CssClass="btnBg" OnClick="btnDelete_Click" />
        </div>
    </div>
</asp:Content>
