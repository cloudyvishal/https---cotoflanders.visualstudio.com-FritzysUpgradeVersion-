<%@ Page Title="Export To Excel" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false" AutoEventWireup="true" Inherits="Admin_Groomer_ExportToExcel" Codebehind="ExportToExcel.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
<div class="pageTitle"><h2>Export To Excel</h2>     </div>
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

<table border="0" cellpadding="0" cellspacing="0" width="100%" >


    <div style="margin: 15px 0 0 0; width: 930px;">
        <table class="setservPage2" border="0"  cellpadding="0" cellspacing="0">
            <tr><td colspan="2" style="height:5px;"></td></tr>
            <tr>
                <td>Groomers List:</td>
                <td>
                    <asp:DropDownList ID="ddlGroomerlist" runat="server" CssClass="selectBox" AutoPostBack="true" onselectedindexchanged="ddlGroomerlist_SelectedIndexChanged" Width="120">      </asp:DropDownList>
                </td>
            </tr>            
            <tr>
                <td class="textwidth">Date:&nbsp;</td>
                <td>    
                    <asp:TextBox ID="txtStartDate" onkeypress="return false;" runat="server" CssClass="regTextField" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqDate" runat="server" ValidationGroup="valContactus" SetFocusOnError="true" ControlToValidate="txtStartDate" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Date is required">   </asp:RequiredFieldValidator>
                    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="valDate" Enabled="true" TargetControlID="reqDate" HighlightCssClass="validatorCalloutHighlight" />
                    <asp:ImageButton ID="imgCalPop" runat="server" ImageUrl="~/Images/calImage.jpg" CssClass="calbutton" /> 
                    <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format="MM/d/yyyy"  PopupButtonID="imgCalPop" TargetControlID="txtStartDate">    </ajaxtoolkit:calendarextender>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin: 15px 0 0 0;">
                        
                        <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="DailyLogID" AutoGenerateColumns="False"
                             AllowSorting="true" AllowPaging="true" 
                                OnPageIndexChanging="GrdUsers_PageIndexChanging" 
                                OnRowDataBound="GrdUsers_RowDataBound" 
                                OnSorting="GrdUsers_Sorting" 
                                OnDataBound="GrdUsers_DataBound" OnRowCreated="GrdUsers_RowCreated"
                                PageSize="10" CellPadding="0" GridLines="Vertical" Width="830px" HeaderStyle-CssClass="headerStyle"
                                CssClass="viewgridStyle" AlternatingRowStyle-CssClass="altGridStyle" 
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
                                    <asp:TemplateField HeaderText="Seq"  SortExpression="SequenceNo">
                                    <ItemStyle CssClass="itemstyle" Width="5%" />
                                    <HeaderStyle CssClass="headerStyle" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSequenceNo" runat="server" Text='<%# Bind("SequenceNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date / Time">
                                    <ItemStyle CssClass="itemstyle" Width="7%" />
                                    <HeaderStyle CssClass="headerStyle" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Bind("DateTimeFormat")%>'></asp:Label>
                                    </ItemTemplate>                                   
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="String">
                                    <ItemStyle CssClass="itemstyle" Width="50%" />
                                    <HeaderStyle CssClass="headerStyle" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblString" runat="server" Text='<%# Bind("Others")%>'></asp:Label>
                                    </ItemTemplate>                                   
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Revnue">
                                    <ItemStyle CssClass="itemstyle" Width="7%" HorizontalAlign="left" />
                                    <HeaderStyle CssClass="headerStyle1" HorizontalAlign="center" />
                                    <ItemTemplate>
                                        <%--<asp:Label ID="lblExpectedTotalRevenue" runat="server"  Text='<%# Bind("ExpectedTotalRevenue")%>'></asp:Label>--%>
                                        <asp:Label id="Label1" runat="server" Text='<%# DataBinder.Eval(Container,"DataItem.ExpectedTotalRevenue", "{0:C}") %>'></asp:Label>

                                    </ItemTemplate>                                     
                                </asp:TemplateField>
                                
                              
                                                                
                                <asp:TemplateField HeaderText="Pushed">
                                    <ItemStyle CssClass="itemstyle" Width="20%" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="headerStyle1" HorizontalAlign="center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExportToExcel" runat="server" Text='<%# Bind("ExportToExcel")%>'></asp:Label>
                                    </ItemTemplate>                                     
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <ItemStyle CssClass="itemstyle" Width="5%" />
                                    <HeaderStyle CssClass="headerStyle1" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkall" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle1"
                                    DataNavigateUrlFields="DailyLogID" DataNavigateUrlFormatString="GroomerAppointmentDetails.aspx?DailyLogID={0}"
                                    Text="Details" HeaderText="Details">
                                </asp:HyperLinkField>
                               
                                 
                         </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td colspan="2" align="center"><asp:Button ID="btnExport" runat="server" CssClass="gobackbtnBg" Text="Export To Excel" ValidationGroup="valContactus" onclick="btnExport_Click" Visible="false" /></td>            
            </tr>
        </table>
    </div>

<tr>
    <td colspan="4" style="height:100px"></td>
</tr>
</table>
</div>
</asp:Content>

