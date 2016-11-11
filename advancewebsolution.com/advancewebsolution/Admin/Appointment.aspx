<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Appointment" Title="Appointments" CodeBehind="Appointment.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
  function preventBack(){window.history.forward();}
  setTimeout("preventBack()", 0);
  window.onunload=function(){null};
</script>
    <style type="text/css">
        .lblHidden {
            display: none;
        }

        .lblDisplay {
            display: block;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function SelectedIndexChanged(id) {
            var e = document.getElementById(id);
            var strUser = e.options[e.selectedIndex].value;
            if (strUser == 1) {

            }
        }

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
            <h2>Manage Appointments</h2>
        </div>
        <%--Region Error/Success message start--%>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <%--Region Appointment Grid start --%>
        <asp:Label ID="lblError1" runat="server"></asp:Label>
        <asp:UpdatePanel ID="updApp" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="grdAppointment" runat="server" DataKeyNames="AppointmentID" AllowPaging="true"
                    AllowSorting="true" PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%"
                    HeaderStyle-CssClass="headerStyle" AutoGenerateColumns="false" CssClass="gridStyle itemstyle"
                    AlternatingRowStyle-CssClass="altGridStyle" OnPageIndexChanging="grdAppointment_PageIndexChanging"
                    OnDataBound="grdAppointment_DataBound" OnSorting="grdAppointment_Sorting" OnRowCreated="grdAppointment_RowCreated">

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
                                <asp:Label ID="lblAppointmentID" runat="server" Text='<%#Bind("AppointmentID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                            <ItemStyle CssClass="itemstyle" Width="15%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FullName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date/Time" SortExpression="Date">
                            <ItemStyle CssClass="itemstyle" Width="11%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <div runat="server" visible='<%# (Convert.ToBoolean(Eval("IsDelete"))) ? true : false %>'>
                                    <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("Date", "{0:MMM-dd-yyyy hh:mm tt}")  %>'></asp:Label>
                                </div>
                                <asp:HyperLink ID="hyp" Visible='<%# (Convert.ToBoolean(Eval("IsDelete"))) ? false : true %>' runat="server" Text='<%# Bind("Date", "{0:MMM-dd-yyyy hh:mm tt}")  %>' NavigateUrl='<%# "ViewAppointment.aspx?ID=" + Eval("AppointmentID") + "&p=1" %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Flexible">
                            <ItemStyle CssClass="itemstyle" Width="10%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblFlex" runat="server" Text='<%# Bind("Flex") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Confirm By" SortExpression="ConfirmBy">
                            <ItemStyle CssClass="itemstyle" Width="10%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblConfirmBy" runat="server" Text='<%# Bind("ConfirmBy") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Confirmed" SortExpression="Confirmed">
                            <ItemStyle CssClass="itemstyle" Width="12%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblConfirm" runat="server" Text='<%# Bind("Confirmed") %>'></asp:Label>
                                <span runat="server" visible='<%# (Convert.ToBoolean(Eval("IsDelete"))) ? false : true %>'>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Text="(Build)" NavigateUrl='<%#"ConfirmAppointment.aspx?"+EncryptQueryString(string.Format("CustomerName={0}&CustomerEmail={1}&AppointmentDate={2}&AppointmentID={3}",Eval("FullName"),Eval("UserName"),Eval("Date"),Eval("AppointmentID"))) %>'></asp:HyperLink>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Address">
                            <ItemStyle CssClass="itemstyle" Width="19%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Note">
                            <ItemStyle CssClass="itemstyle" Width="24" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblNote" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label ID="IsDelete" runat="server" Text='<%# Bind("Active")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headerStyle1" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <%--Region Appointment Grid end --%>
                <%-- Region  Button start --%>
                <div id="divBtn" runat="server" style="display: block;">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" OnClientClick="return confirm('Are  You Sure Want To permanentaly Delete selected Appointment ?')" CssClass="btnBg"
                        OnClick="btnDelete_Click1" />&nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnActiveInActive" runat="server" Text="Active/InActive" OnClientClick="return confirm('Are  You Sure Want To change selected appointments records?')" ToolTip="Active/InActive" CssClass="btnBg"
                 OnClick="btnActiveInActive_Click1" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnExp" runat="server" Text="EXPORT" ToolTip="Export" CssClass="btnBg" OnClientClick="return ShowDiv();" />
                </div>
                <%-- Region  Button end --%>
                <%-- Region  Search start --%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="grdAppointment" EventName="PageIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="grdAppointment" EventName="DataBound" />
                <asp:AsyncPostBackTrigger ControlID="grdAppointment" EventName="Sorting" />
                <asp:AsyncPostBackTrigger ControlID="grdAppointment" EventName="RowCreated" />
                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnActiveInActive" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnExp" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
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
        <%-- Region  Search end --%>
    </div>
</asp:Content>
