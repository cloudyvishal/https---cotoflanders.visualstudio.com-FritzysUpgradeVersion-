<%@ Page Title="View Grooming Appointments" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false" AutoEventWireup="true" Inherits="Admin_Groomer_ViewGroomerAppointmentv2" CodeBehind="ViewGroomerAppointment.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }

        .itemstyleEdit a {
            float: left;
            clear: both;
        }

        .itemstyleSeq input {
            width: 15px !important;
        }

        .ViewAptGrid {
            margin: 15px 0 0 0;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function singleDelete(chkId) {
            document.getElementById(chkId).checked = true;
            if (delconfirm()) {
                return true;
            }
            else {
                document.getElementById(chkId).checked = false;
                return false;

            }
        }

        function showDeleteAllButton() {

            var countChecked = 0;s
            var inputs = document.getElementsByTagName("input");

            for (i in inputs) {
                if (inputs[i].id != null && inputs[i].id.startsWith("chkDelete")) {
                    if (inputs[i].checked) {
                        countChecked++;
                    }
                }
            }

            document.getElementById("buttonDeleteSelectedAppt").disabled = (countChecked == 0);
        }

        function delconfirm(flag) {
            if (flag != "13") {
                return confirm("Do You Want To Delete Selected Groomer(s) Appointment?");
            }

        }

        function valOther(event) {
            var kcode = event.keyCode;
            alert(kcode);
            var other = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtOthers").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 39 || kcode == 40) { return true; }
            else
                if (other.length > 500) { return false }
            return true;

        }

        function valDate(event) {
            var kcode = event.keyCode;
            alert(kcode);
            var other = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtAppointmentDate").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 39 || kcode == 40) { return true; }
            else
                if (other.length > 20) { return false }
            return true;

        }

        function valRev(event) {
            var kcode = event.keyCode;
            alert(kcode);
            var Rev = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtExpectedTotalRevenue").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 39 || kcode == 40) { return true; }
            else
                if (Rev.length > 8) { return false }
            return true;

        }

        function valPetTime(event) {
            var kcode = event.keyCode;
            alert(kcode);
            var PetTime = document.getElementById("ctl00_ContentPlaceHolder1_GrdUsers_ctl02_txtExpectedPetTime").value;
            if (kcode == 8 || kcode == 46 || kcode == 37 || kcode == 38 || kcode == 13 || kcode == 39 || kcode == 40) { return true; }
            else
                if (PetTime.length > 4) { return false }
            return true;

        }

        function ShowDiv() {
            document.getElementById('<%=divShow.ClientID %>').style.display = "Block";
            return false;
        }
        function HideDiv() {
            document.getElementById('<%=divShow.ClientID %>').style.display = "none";
            return false;
        }

    </script>
    <script type="text/javascript">
        function togglevisibility(id) {
            //debugger;
            // console.log(id);
            var e = document.getElementById(id);
            if (e.style.display == 'block')
                e.style.display = 'none';
            else
                e.style.display = 'block';
        }
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>View Grooming Appointments</h2>
        </div>
        <%--Region Error/Success message start--%>
        <p style="float: right; font-size: 12px; font-family: Verdana">
            <asp:Label ID="lblSelectDate" runat="server"></asp:Label>
            <br />
            <br />
        </p>
        <table width="100%">
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" ToolTip="Add Groomers Appointment" CssClass="btnBg" OnClick="btnAdd_Click" Width="75" /></td>
                <td>
                    <asp:Button ID="btnDeleteAppointment" runat="server" Text="Delete Old" OnClientClick="return ShowDiv();" CssClass="btnBg" ToolTip="Delete Old Appointment" OnClick="btnDeleteAppointment_Click" Width="145" /></td>
                <td>
                    <asp:Button ID="buttonDeleteSelectedAppt" OnClientClick="return confirm('Are  You Sure Want To Delete Selected Groomer(s) Appointment?')" Width="235" runat="server" Text="Delete Selected" ToolTip="Delete" CssClass="btnBg" OnClick="btnDeleteAppointment_Click" />
                </td>
                <td>
                    <input type="button" value="Pick Date" onclick="togglevisibility('callcalendar');" class="btnBg" style="width: 145px" />
                    <div id="callcalendar" style="display: none; z-index: 9999; position: absolute; top: 359px; right: 348px;">
                        <asp:Calendar ID="calDate" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" OnVisibleMonthChanged="calDate_VisibleMonthChanged"
                            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#663399" ShowGridLines="True" Width="50%" OnDayRender="calDate_DayRender"
                            OnSelectionChanged="calDate_SelectionChanged">
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                        </asp:Calendar>
                    </div>
                </td>
                <td>
                    <asp:Button ID="btnPush" runat="server" OnClientClick="return confirm('Are  You Sure Want To UnPush  Selected Groomer(s) Appointment to Spreadsheet?')" Text="Unpush" ToolTip="UnPush Groomers Appointment" CssClass="btnBg" OnClick="btnPush_Click" Width="75" />
                </td>
                <%-- Active and Inactive button code--%>
                <%-- <td>
                    <asp:Button ID="btnChangeStatus" OnClientClick="return confirm('Are  You Sure Want To change Status of Selected Groomer(s) Appointment?')" runat="server" Text="Active/InActive" ToolTip="Change Status of Groomers Appointment" CssClass="btnBg" OnClick="btnChangeStatus_Click" Width="145" />
                </td>--%>

                <%--<td>
             <asp:TextBox ID="txtStartDate1" OnTextChanged="txtStartDate1_TextChanged" runat="server"></asp:TextBox><asp:ImageButton ID="imgCalPop1" runat="server" AlternateText="Pick Date" ImageUrl="~/Images/calImage.jpg"   />
            <ajaxToolkit:calendarextender ID="CalendarExtender2" runat="server" Format="MM/d/yyyy" OnClientDateSelectionChanged="" PopupButtonID="imgCalPop1" TargetControlID="txtStartDate1"  ></ajaxToolkit:calendarextender>
            </td>--%>
            </tr>
        </table>
        <asp:UpdatePanel ID="GrdUsersUpdatePanel" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
            <ContentTemplate>
                <%--   Begin     Grid View Area--%>
                <div class="ViewAptGrid" id="DvAptGrid" runat="server" style="overflow: auto; width: 945px; margin-left: -47px;">
                    <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="AppointmentID" AutoGenerateColumns="False"
                        AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GrdUsers_PageIndexChanging"
                        OnSorting="GrdUsers_Sorting" OnRowDataBound="GrdUsers_RowDataBound"
                        OnDataBound="GrdUsers_DataBound" PageSize="100"
                        CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle" OnRowCreated="GrdUsers_RowCreated"
                        CssClass="viewgridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowDeleting="GrdUsers_RowDeleting"
                        OnRowCommand="GrdUsers_RowCommand" OnSelectedIndexChanged="GrdUsers_SelectedIndexChanged">
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
                        <HeaderStyle CssClass="headerStyle" />
                        <PagerStyle CssClass="gridPager" />
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="Seq" Visible="false" SortExpression="SequenceNo">
                                <ItemStyle CssClass="itemstyle itemstyleSeq" Width="0%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSequenceNo" runat="server" Text='<%# Eval("SequenceNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemStyle CssClass="itemstyle" Width="3%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkall" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Groomer" SortExpression="Name">
                                <ItemStyle CssClass="itemstyle" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date / Time" SortExpression="AppointmentDate">
                                <ItemStyle CssClass="itemstyle" Width="10%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Eval("DateTimeFormat")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Customer">
                                <ItemStyle CssClass="itemstyle" Width="20" />
                                <HeaderStyle CssClass="headerStyle" Width="20" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcustEmail" runat="server" Text='<%#Eval("custEmail")%>' CssClass="custEmail"></asp:Label>&nbsp;&nbsp;
                                 <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("CustomerName")%>' CssClass="custName"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="String">
                                <ItemStyle CssClass="itemstyle" Width="50%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblString" runat="server" Text='<%# Eval("Others")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rev ($)">
                                <ItemStyle CssClass="itemstyle" Width="9%" HorizontalAlign="left" />
                                <HeaderStyle CssClass="headerStyle1" />
                                <ItemTemplate>
                                    <asp:Label ID="lblExpectedTotalRevenue" Text='<%# Eval("ExpectedTotalRevenue")%>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time (Hr)" SortExpression="ExpPetTime">
                                <ItemStyle CssClass="itemstyle" Width="7%" HorizontalAlign="left" />
                                <HeaderStyle CssClass="headerStyle1" />
                                <ItemTemplate>
                                    <asp:Label ID="lbltxtExpectedPetTime" runat="server" Text='<%# Eval("ExpPetTime")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Presented">
                                <ItemStyle CssClass="itemstyle" Width="5%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusPresented" runat="server" Text='<%# Eval("StatusPresentedDt")%>'></asp:Label>
                                    <%--      <asp:Label ID="lblStartTime" runat="server" Text='<%# Eval("ApptLoggedInTime","{0:hh:mm:ss tt}")%>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Time">
                                <ItemStyle CssClass="itemstyle" Width="8%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAptSTime" runat="server" Text='<%# Eval("AppStartTime","{0:hh:mm:ss tt}")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Time">
                                <ItemStyle CssClass="itemstyle" Width="8%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAptETime" runat="server" Text='<%# Eval("AppEndTime")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IsCompleted">
                                <ItemStyle CssClass="itemstyle" Width="" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Seq" SortExpression="SequenceNo" Visible="false">
                                <ItemStyle CssClass="itemstyle" Width="1%" />
                                <HeaderStyle CssClass="headerStyle" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAppointmentID" runat="server" Text='<%# Eval("AppointmentID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GID" Visible="false">
                                <ItemStyle CssClass="itemstyle" Width="1%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGId" runat="server" Text='<%# Eval("GID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Astatus" Visible="false">
                                <ItemStyle CssClass="itemstyle" Width="1%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAStatusId" runat="server" Text='<%# Eval("AStatus")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Astatus" Visible="false">
                                <ItemStyle CssClass="itemstyle" Width="1%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSPresented" runat="server" Text='<%# Eval("StatusPresented")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowHeader="true" HeaderText="Edit" ShowSelectButton="true" SelectText="Edit" CausesValidation="True" ValidationGroup="valContactus">
                                <ItemStyle CssClass="itemstyle itemstyleEdit" />
                                <HeaderStyle CssClass="headerStyle" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Select">
                                <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" />
                                <ItemTemplate>
                                    <input type="checkbox" name="chkDelete<%# Eval("AppointmentID") %>" id="ChkSelect1" class="checkboxfloatleft" />
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="DeleteRow" CssClass="deletebtnmargintop"
                                        CommandArgument='<%# Eval("AppointmentID").ToString() %>' ImageUrl="/images/deleteicon.gif"
                                        OnClientClick="return confirm('Do You Want To Delete Selected Groomer(s) Appointment?')" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="headerStyle1" />
                            </asp:TemplateField>
                            
                            <%--Active and push show/hide code--%>

                            <%-- <asp:TemplateField HeaderText="Status">
                                <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" />
                                <ItemTemplate>
                                    <asp:Label ID="IsDelete" runat="server" Text='<%# Eval("Active")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="headerStyle1" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pushed Status">
                                <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" />
                                <ItemTemplate>
                                    <asp:Label ID="IsPushed" runat="server" Text='<%# Eval("Push")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="headerStyle1" />
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </div>

                <%--   End     Grid View Area--%>


                <div id="divShow" runat="server" style="margin: 10px 0 0 0; display: none" class="itemstyle">
                    <table border="0" style="margin: 10px 0pt 0pt;">
                        <tr>
                            <td>
                                <span class="star" style="color: #f00;">*</span>Select Date:</td>
                            <td>
                                <asp:DropDownList ID="ddlMonth" runat="server">
                                    <asp:ListItem Text="January" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Febuary" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="April" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="August" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="September" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;<asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                            </td>
                            <td valign="top">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBgsmall" OnClientClick="return confirm('Are  You Sure Want To Delete All Appointment Of This Month Appointment?');" OnClick="btnDelete_Click" />
                                <asp:Button ID="btnHide" Text="Cancel" runat="server" CssClass="servbtnBg" border="0" OnClientClick="return HideDiv();" />
                            </td>
                        </tr>
                    </table>
                </div>

                <%--   Begin     formodelpopup  Area--%>

                <div id="formodelpopup">
                    <asp:UpdatePanel runat="server" ID="upPopUp" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />

                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" Drag="true" PopupDragHandleControlID="PopupHeader"
                                TargetControlID="btnShowPopup" PopupControlID="pnlpopup" BackgroundCssClass="modalBackground" ValidateRequestMode="Enabled" DropShadow="true">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Style="display: none" EnableViewState="true">
                                <table class="adduserTable" style="text-align: left" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td colspan="2">
                                            <div class="popup_Titlebar" id="PopupHeader">
                                                <div class="TitlebarLeft">Edit Groomer Appointment</div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblDoubleBook" runat="server" Visible="false" ForeColor="Red" Text="This Appointment  Creates A Double Book." Font-Bold="True"></asp:Label><br />
                                            <asp:Label ID="lblUpdateError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                            <asp:HiddenField ID="hfAppointmentId" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">
                                            <asp:Label ID="Label1" runat="server" Text="Select Groomer:"></asp:Label>
                                        </td>
                                        <td style="width: 75%">
                                            <asp:DropDownList ID="ddlGroomerlist" EnableViewState="true" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlGroomerlist_SelectedIndexChanged" CssClass="selectBox">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="ReqVAl2" Text="Select One" InitialValue="0" ControlToValidate="ddlGroomerlist"
                                                ErrorMessage="<b>Required Field Missing</b><br />Groomer is required" Display="none"
                                                ValidationGroup="valContactus" runat="server" SetFocusOnError="true" />
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="ReqVAl2" Enabled="true" runat="Server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 80px;">Date/Time:</td>
                                        <td style="width: 120px;">
                                            <asp:TextBox ID="txtDate" EnableViewState="true" runat="server" MaxLength="20" AutoPostBack="true" ToolTip=" Example : 160503.1200-1400"
                                                OnTextChanged="txtDate_TextChanged" CssClass="regTextField" Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtDate" Display="None" ErrorMessage="Appointment Date field should not be blank">  
                                            </asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight" />
                                        </td>
                                    </tr>

                                  

                                    <tr>
                                        <td style="height: 131px">
                                            <asp:Label ID="Label2" runat="server" Text="String:"></asp:Label>
                                        </td>
                                        <td style="height: 131px">
                                            <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" CssClass="textarea"
                                                onkeypress="return valothers(event);"> 
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtOthers" Display="None" ErrorMessage="Appointment String field should not be blank"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidator5_ValidatorCalloutExtender"
                                                Enabled="true" TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblcustEmail" runat="server" Text="Customer Email:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustEmail" EnableViewState="true" runat="server" CssClass="textBox" AutoCompleteType="None" AutoPostBack="true" OnTextChanged="txtCustEmail_Chenged"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Valid Email Address"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtCustEmail"></asp:RegularExpressionValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RegularExpressionValidator3_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="RegularExpressionValidator3">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCustName" runat="server" Text="Customer Name:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="textBox"> 
                                            </asp:TextBox>
                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtCustomerName" Display="None" ErrorMessage="Customer Name should not be blank"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="RequiredFieldValidator6_ValidatorCalloutExtender"
                                                Enabled="true" TargetControlID="RequiredFieldValidator6" HighlightCssClass="validatorCalloutHighlight" />--%>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTotalRevnueExpected" runat="server" Text="Expected Revenue(In $ Only):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTotalRevnueExpected" runat="server" MaxLength="8" Width="180px"
                                                CssClass="textBox"> 
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtTotalRevnueExpected" Display="None"
                                                ErrorMessage="Revenue expected field should not be blank">  
                                            </asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2"
                                                Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight" />
                                            <asp:RegularExpressionValidator ID="repExpectedRevenue" runat="server" Display="None"
                                                ErrorMessage="<b>Expected Revenue should be Dollars ($xxx.xx)" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtTotalRevnueExpected" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3"
                                                Enabled="true" TargetControlID="repExpectedRevenue" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblExpectedpettime" runat="server" Text="Expected Pet Time(In Hours):"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpectedpettime" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5" Width="180px" CssClass="textBox"> 
                                            </asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtExpectedpettime" Display="None"
                                                ErrorMessage="Expected Pet Time field should not be blank">  
                                            </asp:RequiredFieldValidator>
                                            
                                            <asp:CompareValidator ID="cmpVal" runat="server" ErrorMessage="Expected time should not be greater than 10 Hrs."
                                                ValueToCompare="10.00" Operator="LessThan" ControlToValidate="txtExpectedpettime"
                                                Display="None" Type="Double"></asp:CompareValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="vldcal" Enabled="true" TargetControlID="cmpVal"
                                                HighlightCssClass="validatorCalloutHighlight" />

                                            <%--*Validation End--%>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Sequence #:" Style="display: none;"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSequence" runat="server" MaxLength="3" Width="180px" CssClass="textBox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtSequence" Display="None" ErrorMessage="Sequence # field should not be blank">  
                                            </asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4"
                                                Enabled="true" TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                                                ErrorMessage="<b>Sequence Number only allow numbers" ValidationGroup="valContactus"
                                                SetFocusOnError="true" ControlToValidate="txtSequence" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6"
                                                Enabled="true" TargetControlID="RegularExpressionValidator1" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnUpdate" ToolTip="Update" runat="server" ValidationGroup="valContactus" Text="Update" OnClick="btnUpdate_Click" />
                                            <asp:Button ID="btnCancel" ToolTip="Cancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlGroomerlist" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="txtDate" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GrdUsers" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        <%--Region Error/Success message Begin--%>
        <table>
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server">
                        <table width="100%">
                            <tbody>
                                <tr>
                                    <td align="left" rowspan="2">
                                        <asp:Label ID="lblError" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <br style="clear: both;" />
                </td>
            </tr>
            <tr>
                <td class="keepcenter"></td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function ShowCalender() {
            $("#callcalendar").show();
        }
    </script>
</asp:Content>
