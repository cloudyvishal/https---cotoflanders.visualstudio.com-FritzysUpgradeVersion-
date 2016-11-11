<%@ Page Title="Admin - Edit Appointment Time" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_EditAppointmentSetting" Codebehind="EditAppointmentSetting.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Edit Appointment Time</h2>
        </div>
        <table width="100%">
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server"  visible="false">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" rowspan="2">
                                        <asp:Label ID="lblError" runat="server" visible="false" ></asp:Label>&nbsp;
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
                    <div id="divsearch" runat="server">
                        <table class="setservPage AppSettingTable" cellpadding="4" cellspacing="0">
                            <tr>
                                <td style="width: 80px;">
                                    Select Date:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" Enabled="false" onkeypress="return false;" runat="server" CssClass="regTextField" Width="110px"></asp:TextBox>
                                   
                                </td>
                                <td style="padding-top: 5px;">
                                 
                                   
                                </td>
                            </tr>
                            </table>
                            <table class="setservPage AppSettingTable" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                 <td colspan="3" style="padding:5px 0 0 0;">
                                    &nbsp;Select Time:<br /><br />
                                    <asp:DataList ID="dtlTime" DataKeyField="APTId" runat="server" RepeatColumns="6" RepeatDirection="Horizontal" CssClass="AppSettingTable"  
                                        Width="100%" CellPadding="0" CellSpacing="0">
                                        <ItemTemplate>
                                            <div class="app_time">
                                                <table class="noborder">
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="chkTime"  runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTime" CssClass="description"  Text='<%# Bind("APTTime") %>'  runat="server"></asp:Label>
                                                            <asp:Label ID="lblTimeId" Visible="false"   CssClass="description"  Text='<%# Bind("APTId") %>'  runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                           
                          
                        </table>
                         <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Delete" 
                                    CssClass="btnBg" onclick="btnSave_Click"   />
                        <br style="clear: both;" />
                    </div>
                </td>
            </tr>
        </table> 
       
    </div>
</asp:Content>
