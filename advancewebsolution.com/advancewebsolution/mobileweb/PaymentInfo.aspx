<%@ Page Title="Payment" Language="C#" MasterPageFile="~/mobileweb/Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="mobileweb_PaymentInfo" CodeBehind="PaymentInfo.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

            if (document.getElementById('<%=lbl1RevenueCost.ClientID%>').className == 'label lblHidden') {
                value1 = document.getElementById('<%=txtRevenueCost.ClientID%>').value;
            } else {
                value1 = document.getElementById('<%=lbl1RevenueCost.ClientID%>').innerHTML;
            }
            if (value1.length < 1 || value1 < 0)
                value1 = 0;

            if (document.getElementById('<%=lbl1PriorRevenue.ClientID%>').className == 'label lblHidden') {
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
    <script type="text/javascript" src="../scripts/phone_validation.js"></script>
    <div class="contentinnersection">
        <div class="innercontent">
            <asp:Label ID="lblsmsg" runat="server" Text="Your Payment Submitted Successfully" ForeColor="Green" Font-Bold="true" Font-Size="Medium" Visible="false"></asp:Label>
            <asp:ImageMap ID="ImageMap2" runat="server" ImageUrl="~/Images/cybersource.png"></asp:ImageMap><br />
            <asp:Label ID="lblerrormsg" runat="server" Text="Negative Values are Not Allowed." ForeColor="Red" Font-Bold="true" Font-Size="Medium" Visible="false"></asp:Label><br />
            <div class="forform">
                <div id="idDivToUseIfQueryString" style="display: none;">
                    <asp:HiddenField ID="hfLblAppointmentDate" runat="server" />
                    <asp:HiddenField ID="hfLblStartTime" runat="server" />
                </div>
                <div class="divGrid">
                    <span runat="server" class="heading" id="lblFutureAppointmentLabel">Future Appointments</span>
                    <hr />
                    <asp:Label ID="lblfutureinfo" runat="server" Text="No Future appointments are available." Font-Bold="true" Visible="false"> </asp:Label>
                    <asp:GridView ID="GrdFutureApp" runat="server" DataKeyNames="AppointmentID" AutoGenerateColumns="False"
                        AllowSorting="True" AllowPaging="true"
                        OnDataBound="GrdFutureApp_DataBound" OnPageIndexChanging="GrdFutureApp_PageIndexChanging"
                        OnSorting="GrdFutureApp_Sorting" OnRowCreated="GrdFutureApp_RowCreated" OnRowCommand="GrdFutureApp_RowCommand"
                        PageSize="5"
                        HeaderStyle-CssClass="headerStyle"
                        CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle">
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
                            <asp:TemplateField>
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <asp:RadioButton ID="RadioButton1" runat="server" onclick="checkRadioBtn(this);" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Appointment ID" Visible="false">
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:Label ID="lblAppointmentID" runat="server" Text='<%# Bind("AppointmentID")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemStyle />
                                <HeaderStyle Width="75px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Time">
                                <ItemStyle Width="100px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("T","{0:hh:mm tt}")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment Status">
                                <ItemStyle Width="125px" />
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

                        <HeaderStyle CssClass="headerStyle"></HeaderStyle>

                    </asp:GridView>
                </div>
                <div class="divpayment">
                    <span class="heading">Payment Information</span>
                    <hr />
                    <asp:Label ID="lblRevenue" runat="server" CssClass="label">Revenue: $<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="txtRevenueCost" runat="server" onchange="Sum();" onkeypress="return decimalIntegerNumbers(event,this)" placeHolder="Enter revenue amount" Visible="true" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter revenue amount." ControlToValidate="txtRevenueCost" SetFocusOnError="true" Display="Dynamic" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <asp:Label ID="lbl1RevenueCost" runat="server" Text="0" ForeColor="#CC3300" CssClass="label lblHidden"></asp:Label>
                    <br />
                    <asp:Label ID="lblPriorRevenue" runat="server" Text="Prior Revenue: $" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtPriorRevenue" runat="server" onchange="Sum();" onkeypress="return decimalIntegerNumbers(event,this)" placeHolder="Enter Additional amount" Visible="true" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <asp:Label ID="lbl1PriorRevenue" runat="server" CssClass="label lblHidden"></asp:Label>
                    <br />
                    <asp:Label ID="lblTip" runat="server" Text="Tip: $" CssClass="label"></asp:Label>
                    <asp:TextBox ID="txtTipAmt" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" CssClass="txtbox" onchange="Sum();" placeHolder="Enter Tip amount"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Total Amt: $" CssClass="label"></asp:Label>
                    <asp:Label ID="lblTotalAmt" runat="server" CssClass="label" ForeColor="#CC3300" Font-Bold="true"></asp:Label><br />
                    <asp:HiddenField ID="hfTotalAmount" runat="server" />
                </div>
                <div class="divpayment">

                    <span class="heading">Enter Billing Information </span>
                    <hr />
                    <asp:Label ID="lblMessage" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>

                    <asp:Label ID="lblCustomerName" runat="server" CssClass="label">First Name:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="billTo_firstName" runat="server" CssClass="txtbox" MaxLength="20" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvfname" runat="server" ControlToValidate="billTo_firstName"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter First Name" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblCustomerLastName" runat="server" CssClass="label">Last Name:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="billTo_lastname" runat="server" CssClass="txtbox" MaxLength="20" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvlastname" runat="server" ControlToValidate="billTo_lastname"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Last Name" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblAddress1" runat="server" CssClass="label">Street Address:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="billTo_street1" runat="server" MaxLength="100" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvaddr1" runat="server" ControlToValidate="billTo_street1"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Street Address" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />

                    <asp:Label ID="lblCity" runat="server" CssClass="label">City:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="billTo_city" runat="server" MaxLength="18" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvcity" runat="server" ControlToValidate="billTo_city"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter City" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />
                    <div class="divforstate-zip">
                        <div class="divstate">
                            <asp:Label ID="lblstate" runat="server" CssClass="label">State:<span class="mand">*</span></asp:Label>
                            <asp:TextBox ID="billTo_state" runat="server" MaxLength="18" CssClass="shorttxtbox" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvstate" runat="server" ControlToValidate="billTo_state"
                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter State" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                        </div>
                        <div class="divstate">
                            <asp:Label ID="lblZip" runat="server" CssClass="label">Zip:<span class="mand">*</span></asp:Label>
                            <asp:TextBox ID="billTo_postalCode" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="5" CssClass="shorttxtbox" autocomplete="off"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvzip" runat="server" ControlToValidate="billTo_postalCode"
                                CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Zip Code" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Label ID="lblCountry" runat="server" CssClass="label">Country:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="billTo_country" runat="server" CssClass="txtbox" autocomplete="off"
                        Text="USA"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvcountry" runat="server" ControlToValidate="billTo_country"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Country" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblPhone" runat="server" CssClass="label">Phone:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="txtPhone" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" runat="server" MaxLength="20" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvphone" runat="server" ControlToValidate="txtPhone"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Phone Number" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblEmail" runat="server" CssClass="label">Email:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="billTo_email" runat="server" MaxLength="20" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revemail" runat="server" ControlToValidate="billTo_email"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Proper Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="Payment_Validation"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="billTo_email"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Email Address" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                </div>
                <div class="divpayment">
                    <span class="heading">Credit Card Information</span>
                    <hr />
                    <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/Images/credit_card.png"></asp:ImageMap>
                    <br />
                    <asp:Label ID="lblCreditCardNumber0" runat="server" CssClass="label">   CC Type :<span class="mand">*</span></asp:Label>
                    <asp:DropDownList ID="drpCardType" runat="server" CssClass="selectbox" Style="border: 1px solid #90734B;">
                        <asp:ListItem Selected="True" Value="0">Select Card Type</asp:ListItem>
                        <asp:ListItem Value="1">Visa</asp:ListItem>
                        <asp:ListItem Value="2">Master Card</asp:ListItem>
                        <asp:ListItem Value="3">American Express</asp:ListItem>
                        <asp:ListItem Value="4">Discover</asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" ControlToValidate="drpCardType" InitialValue="0" ValidationGroup="Payment_Validation" runat="server" SetFocusOnError="true" ErrorMessage="<br/>Please select Card Type"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblCreditCardNumber" runat="server" CssClass="label">CC Number:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="txtCardNumber" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="20" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvcardnum" runat="server" ControlToValidate="txtCardNumber"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Credit Card Number" SetFocusOnError="true"
                        ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblExpirationMonth" runat="server" CssClass="label">Exp Month:<span class="mand">*</span></asp:Label>
                    <asp:DropDownList ID="drpMonth" runat="server" CssClass="selectbox">
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
                    <br />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="rfvMonth" Display="Dynamic" ControlToValidate="drpMonth" InitialValue="0" ValidationGroup="Payment_Validation" runat="server" ErrorMessage="Please select Month"></asp:RequiredFieldValidator>

                    <br />
                    <asp:Label ID="lblExpirationYear" runat="server" CssClass="label">Exp Year:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="txtExpYear" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="txtbox" autocomplete="off"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvcyear" runat="server" ControlToValidate="txtExpYear" SetFocusOnError="true"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter Expiration Year" ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <asp:CustomValidator SetFocusOnError="true" runat="server" ID="custYear1" ValidationGroup="Payment_Validation" ControlToValidate="txtExpYear" Display="Dynamic" ClientValidationFunction="ValYear"
                        ErrorMessage="Card Expiration Year should be greater than or equal to current year."></asp:CustomValidator>
                    <asp:RegularExpressionValidator ID="rfvYearLength" runat="server" ValidationGroup="Payment_Validation"
                        SetFocusOnError="true" Display="Dynamic" ErrorMessage="Please enter correct year ."
                        ControlToValidate="txtExpYear" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                    <br />
                    <asp:Label ID="lblVerificationNo" runat="server" CssClass="label">CVV No.:<span class="mand">*</span></asp:Label>
                    <asp:TextBox ID="txtVerificationNo" runat="server" MaxLength="3" CssClass="txtbox" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVCVV" runat="server" ControlToValidate="txtVerificationNo" SetFocusOnError="true"
                        CssClass="error_msg" Display="Dynamic" ErrorMessage="Enter CVV NO." ValidationGroup="Payment_Validation"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <br />
                <asp:Label ID="ErrorMessage" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label><br />
                <asp:Button ID="btnSubmitInfo" runat="server" CssClass="button" Text="Submit Payment" OnClick="btnSubmitInfo_Click" ValidationGroup="Payment_Validation" /><br />
                <asp:Label ID="lblReason" runat="server" CssClass="error_msg" ForeColor="#CC3300"></asp:Label>
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
