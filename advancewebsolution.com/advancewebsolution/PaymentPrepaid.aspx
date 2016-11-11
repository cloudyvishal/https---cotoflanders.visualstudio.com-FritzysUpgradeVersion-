<%@ Page Language="C#" ClientIDMode="AutoID" AutoEventWireup="true" MasterPageFile="~/Main.master" Inherits="PaymentPrepaid" Title="Payment Prepaid" CodeBehind="PaymentPrepaid.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 882px;
        }

        .lblHidden {
            display: none;
        }

        .lblDisplay {
            display: block;
        }

        .viewgridStyle {
            margin-left: 81px;
        }

        .gridStyle {
            margin-left: 0px;
        }
    </style>
    <script src="js/payment.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function ValYear(source, args) {
            var dteNow = new Date();
            var intYear = dteNow.getFullYear()
            if (args.Value >= intYear)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        window.onload = function () {
            Sum();
        };
        function Sum() {
            var value1 = 0;
            var value2 = 0;
            var value3 = 0;
            var value4 = 0;

            if (document.getElementById('<%=lbl1RevenueCost.ClientID%>').className == 'appnt_lbl lblHidden') {
                value1 = document.getElementById('<%=txtRevenueCost.ClientID%>').value;
            } else {
                value1 = document.getElementById('<%=lbl1RevenueCost.ClientID%>').innerHTML;
            }
            if (value1.length < 1 || value1 < 0)
                value1 = 0;

            if (document.getElementById('<%=lbl1PriorRevenue.ClientID%>').className == 'appnt_lbl lblHidden') {
                value2 = document.getElementById('<%=txtPriorRevenue.ClientID%>').value;
            } else {
                value2 = document.getElementById('<%=lbl1PriorRevenue.ClientID%>').innerHTML;
            }
            if (value2.length < 1)
                value2 = 0;

            var value3 = document.getElementById('<%=txtTipAmt.ClientID%>').value;
            if (value3.length < 1 || value3 < 0)
                value3 = 0;

            value4 = parseFloat(value1) + parseFloat(value2) + parseFloat(value3);
            document.getElementById('<%=lblTotalAmt.ClientID%>').innerHTML = value4;
            document.getElementById('<%=this.hfTotalAmount.ClientID%>').value = value4;
            return false;
        }

        function checkRadioBtn(id) {
            var gv = document.getElementById('<%=GrdFutureApp.ClientID %>');
            for (var i = 1; i < gv.rows.length; i++) {
                var radioBtn = gv.rows[i].cells[0].getElementsByTagName("input");
                // Check if the id not same
                try {
                    if (radioBtn[0].id != id.id) {
                        radioBtn[0].checked = false;
                    }
                }
                catch (err) {
                    return false;
                }
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPlaceholder">
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <!-- reg main start here -->
                    <div id="idDivToUseIfQueryString" style="display: none;">
                        <asp:HiddenField ID="hfLblAppointmentDate" runat="server" />
                        <asp:HiddenField ID="hfLblStartTime" runat="server" />
                    </div>
                    <table align="center" style="width: 100%">
                        <tr>
                            <td>
                                <table align="center" style="width: 100%">
                                    <tr>
                                        <td colspan="2" class="auto-style1">
                                            <asp:Label ID="lblsmsg" runat="server" Text="Your Payment Submitted Successfully!!!"
                                                ForeColor="Green" Font-Bold="true" Font-Size="Larger" Visible="false"></asp:Label>
                                            <asp:Label ID="lblerrormsg" runat="server" Text="Negative Values are Not Allowed."
                                                ForeColor="Red" Font-Bold="true" Font-Size="Larger" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" class="auto-style1">
                                            <asp:ImageMap ID="ImageMap2" runat="server" ImageUrl="~/Images/cybersource.png"></asp:ImageMap>
                                        </td>
                                    </tr>
                                </table>
                                <div id="futureApp" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="left" colspan="3">
                                                <h2 id="lblFutureAppointmentLabel" runat="server">Future Appointments</h2>
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Label ID="lblfutureinfo" runat="server" Text="No Future appointments are available." Font-Bold="true" Visible="false"> </asp:Label>
                                                <asp:GridView ID="GrdFutureApp" runat="server" DataKeyNames="AppointmentID" AutoGenerateColumns="False" AllowPaging="true"
                                                    AllowSorting="True" CellPadding="3" Width="45%" HeaderStyle-CssClass="headerStyle" OnRowCommand="GrdFutureApp_RowCommand"
                                                    OnDataBound="GrdFutureApp_DataBound" OnPageIndexChanging="GrdFutureApp_PageIndexChanging"
                                                    OnSorting="GrdFutureApp_Sorting" OnRowCreated="GrdFutureApp_RowCreated"
                                                    PageSize="5" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                                                    <AlternatingRowStyle CssClass="altGridStyle" />
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
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemStyle Width="5%" />
                                                            <ItemTemplate>
                                                                <asp:RadioButton ID="RadioButton1" CssClass="rbRadio" runat="server" onclick="checkRadioBtn(this);" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Appointment ID" Visible="false">
                                                            <ItemStyle />
                                                            <HeaderStyle Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppointmentID" runat="server" Text='<%# Bind("AppointmentID")%>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemStyle />
                                                            <HeaderStyle Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Start Time">
                                                            <ItemStyle Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("T","{0:hh:mm tt}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Payment Status">
                                                            <ItemStyle Width="150px" />
                                                            <ItemTemplate>
                                                                <div runat="server" visible='<%# (Convert.ToBoolean(Eval("IsPaid"))) ? true : false %>'>
                                                                    <i class="glyphicon glyphicon-ok-sign" style="color: #73d900; font-size: larger;"></i>
                                                                    <asp:Label ID="lblPaymentStatus" runat="server" Text='<%# Bind("PaymentStatus")%>'></asp:Label>
                                                                </div>
                                                                <div runat="server" visible='<%# (Convert.ToBoolean(Eval("IsPaid"))) ? false : true %>'>
                                                                    <asp:Label ID="lblPaidMessage" runat="server" Text="Paid"></asp:Label>

                                                                </div>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                    <HeaderStyle CssClass="headerStyle" BackColor="#A55129" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                    <PagerStyle CssClass="gridPager" ForeColor="#8C4510" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table style="width: 100%">
                                    <tr>
                                        <td align="left" colspan="3">
                                            <h2>Payment Information</h2>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="33%">
                                            <asp:Label ID="lblRevenue" runat="server" Text="Revenue: " CssClass="appnt_lbl"></asp:Label>
                                            <span id="spanRevenue" style="color: Red">*</span>&nbsp;<span>$</span>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRevenueCost" runat="server" onchange="Sum();" onkeypress="return decimalIntegerNumbers(event,this)" placeHolder="Enter revenue amount" Visible="true"></asp:TextBox>
                                            <asp:Label ID="lbl1RevenueCost" runat="server" Text="0" ForeColor="#CC3300" CssClass="appnt_lbl lblHidden"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter revenue amount."
                                                ControlToValidate="txtRevenueCost" SetFocusOnError="true" Display="Dynamic" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPriorRev" runat="server" Text="Prior Revenue: " CssClass="appnt_lbl"></asp:Label>
                                            &nbsp;<span>$</span>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPriorRevenue" runat="server" onchange="Sum();" onkeypress="return decimalIntegerNumbers(event,this)" placeHolder="Enter prior amount" Visible="true"></asp:TextBox>
                                            <asp:Label ID="lbl1PriorRevenue" runat="server" Text="0" ForeColor="#CC3300" CssClass="appnt_lbl lblHidden"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTip" runat="server" Text="Tip Amt.: " CssClass="appnt_lbl"></asp:Label>
                                            &nbsp; <span>$</span>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTipAmt" runat="server" onchange="Sum();" onkeypress="return decimalIntegerNumbers(event,this)" placeHolder="Enter tip amount"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTotal" runat="server" Text="Total Amt. : " CssClass="appnt_lbl"></asp:Label>
                                            &nbsp; <span>$</span>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblTotalAmt" runat="server" Text="0" ForeColor="#CC3300" Enabled="false" CssClass="appnt_lbl"></asp:Label>
                                            <asp:HiddenField ID="hfTotalAmount" runat="server" />
                                        </td>
                                    </tr>

                                </table>
                                <table class="payment_page" width="100%">

                                    <tr>
                                        <td colspan="3">
                                            <h2>Billing Information</h2>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblMessage" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="33%">
                                            <div class="label_new">
                                                <asp:Label ID="lblCustomerName" runat="server" Text="First Name:" CssClass="appnt_lbl"></asp:Label>
                                                <span style="color: Red">*</span>
                                            </div>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:TextBox ID="billTo_firstName" runat="server" CssClass="txt txt117" MaxLength="20"
                                                autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:RequiredFieldValidator ID="rfvfname" runat="server" ControlToValidate="billTo_firstName"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter First Name" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right" width="33%">
                                            <asp:Label ID="lblCustomerLastName" runat="server" Text="Last Name:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:TextBox ID="billTo_lastname" runat="server" CssClass="txt txt117" MaxLength="20"
                                                autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td width="33%" align="left">
                                            <asp:RequiredFieldValidator ID="rfvlastname" runat="server" ControlToValidate="billTo_lastname"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Last Name" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblAddress1" runat="server" Text="Street Address:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="billTo_street1" runat="server" MaxLength="100" CssClass="txt txt117"
                                                autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvaddr1" runat="server" ControlToValidate="billTo_street1"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Street Address" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCity" runat="server" Text="City:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="billTo_city" runat="server" MaxLength="18" CssClass="txt txt117" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvcity" runat="server" ControlToValidate="billTo_city"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter City" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblstate" runat="server" Text="State:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="billTo_state" runat="server" MaxLength="18" CssClass="txt txt117" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvstate" runat="server" ControlToValidate="billTo_state"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter State" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblZip" runat="server" Text="Zip:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="billTo_postalCode" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="5" CssClass="txt txt117" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvzip" runat="server" ControlToValidate="billTo_postalCode"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Zip Code" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCountry" runat="server" Text="Country:" CssClass="appnt_lbl"></asp:Label>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="billTo_country" runat="server" CssClass="txt txt117" autocomplete="off"
                                                Text=""></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvcountry" runat="server" ControlToValidate="billTo_country"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Country" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblPhone" runat="server" Text="Phone:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" MaxLength="20" CssClass="txt txt117" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvphone" runat="server" ControlToValidate="txtPhone"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Phone Number" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblEmail" runat="server" Text="E-Mail:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="billTo_email" runat="server" autocomplete="off" CssClass="txt txt117"></asp:TextBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:RegularExpressionValidator ID="revemail" runat="server" ControlToValidate="billTo_email"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Proper Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                ValidationGroup="Payment_Validation"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="billTo_email"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Email Address" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <h2>Credit Card Information</h2>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center">
                                            <asp:ImageMap ID="ImageMap1" Style="margin-right: 223px;" runat="server" ImageUrl="~/Images/credit_card.png"></asp:ImageMap>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCreditCardNumber0" runat="server" Text="   CC Type :" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpCardType" runat="server" CssClass="txt117" Style="border: 1px solid #90734B; width: 172px;">
                                                <asp:ListItem Value="0" Selected="True">Select Card Type</asp:ListItem>
                                                <asp:ListItem Value="1">Visa</asp:ListItem>
                                                <asp:ListItem Value="2">Master Card</asp:ListItem>
                                                <asp:ListItem Value="3">American Express</asp:ListItem>
                                                <asp:ListItem Value="4">Discover</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="drpCardType" InitialValue="0" ValidationGroup="Payment_Validation" runat="server" ErrorMessage="Please select Card Type"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblCreditCardNumber" runat="server" Text="CC Number:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCardNumber" runat="server" MaxLength="20" CssClass="txt txt117" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvcardnum" runat="server" ControlToValidate="txtCardNumber" SetFocusOnError="true"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Credit Card Number"
                                                ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpirationMonth" runat="server" Text="Exp Month:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpMonth" runat="server" Style="width: 172px;" CssClass="txt117">
                                                <asp:ListItem Value="0">Select Month</asp:ListItem>
                                                <asp:ListItem Value="1">January</asp:ListItem>
                                                <asp:ListItem Value="2">February</asp:ListItem>
                                                <asp:ListItem Value="3">March</asp:ListItem>
                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                <asp:ListItem Value="8">August</asp:ListItem>
                                                <asp:ListItem Value="9">September</asp:ListItem>
                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                <asp:ListItem Value="12">December</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="rfvMonth" Display="Dynamic" ControlToValidate="drpMonth" InitialValue="0" ValidationGroup="Payment_Validation" runat="server" ErrorMessage="Please select Month"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblExpirationYear" runat="server" Text="Exp Year:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtExpYear" runat="server" MaxLength="4" CssClass="txt txt117" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:RequiredFieldValidator SetFocusOnError="true" ID="rfvcyear" runat="server" ControlToValidate="txtExpYear" CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Expiration Year" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                            <asp:CustomValidator SetFocusOnError="true" runat="server" ID="custYear1" ValidationGroup="Payment_Validation" ControlToValidate="txtExpYear" Display="Dynamic" ClientValidationFunction="ValYear"
                                                ErrorMessage="Card Expiration Year should be greater than or equal to current year."></asp:CustomValidator>
                                            <asp:RegularExpressionValidator ID="rfvYearLength" runat="server" ValidationGroup="Payment_Validation"
                                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter correct year ."
                                                ControlToValidate="txtExpYear" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblVerificationNo" runat="server" Text="CCV No:" CssClass="appnt_lbl"></asp:Label>
                                            <span style="color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVerificationNo" runat="server" MaxLength="3" CssClass="txt txt117" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:RequiredFieldValidator ID="RFVCVV" runat="server" ControlToValidate="txtVerificationNo" SetFocusOnError="true"
                                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter CVV NO." ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" style="width: 100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="ErrorMessage" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnSubmitInfo" runat="server" CssClass="btnBg" Text="Submit Payment"
                                                OnClick="btnSubmitInfo_Click" ValidationGroup="Payment_Validation" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="lblReason" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- reg top end here -->
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtRevenueCost").keypress(function (event) {
                if (event.which == 45) {
                    event.preventDefault();
                }
            });
            $("#txtPriorRevenue").keypress(function (event) {
                if (event.which == 45) {
                    event.preventDefault();
                }
            });
            $("#txtTipAmt").keypress(function (event) {
                if (event.which == 45) {
                    event.preventDefault();
                }
            });
        });
        function CancelSuccess() {
            alert("Request for Cancel Appointment/Refund Successfully Done.");
        }
    </script>
</asp:Content>


