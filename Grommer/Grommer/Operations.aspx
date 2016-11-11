<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="True" Inherits="Operations" MaintainScrollPositionOnPostback="true" Title="Appointment Log" EnableViewState="true" CodeBehind="Operations.aspx.cs" %>

<%@ Register TagPrefix="Mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .Space label {
            margin-left: 20px;
        }

        input[type="radio"] + label {
            margin-left: 2px;
        }
    </style>

    <script type="text/javascript">
        window.onbeforeunload = confirmExit;
        function confirmExit() {
            alert("Are you sure");
            var clickButton = document.getElementById("<%= btnConfirm.ClientID %>");
            clickButton.click();
            //return true;
        }
    </script>

    <script>
        function AppSubmittedAlready() {
            alert('Internet Connection Not Available but The Details Submitted Successfully.Please Login Again For Next Appointment.');
        }
        function AppTimeError() {
            alert('Appt.timings required.');
        }
        function AppChangesError() {
            alert('Appointment Changes required.');
        }
        function SyncRevenue() {
            alert('Please select credit card.');
        }
        function StartEndTime() {
            alert('Please Provide Appointment Start Time By Pressing Start Time Button On Top Of Page');
        }
        function FillEndTime() {
            alert('Please Provide Appointment End Time By Pressing End Time Button On Top Of Page');
        }
        function SyncRevenueFillAmount() {
            alert('Please Fill Revenue  Amount.');
        }
        function SyncRevenueChooseCreaditCard() {
            alert('Please select credit card.');
        }
        function SyncAgainToCustumerProfile() {
            alert('Please sink to custumer profile Again.');
        }
        function InstantPay() {
            alert('Please Enter Revenue Amount.');
            return false;
        }
        function SyncProfile() {
            alert('Customer email-id required.');
        }
    </script>

    <script type="text/javascript">

        function Reebook(mytext3) {
            var radioButtons = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRebook");

            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value == 0) {
                        document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
                    }
                    else {
                        document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
                    }
                }
            }
        }
        function getCheckedRevnue(mytext3) {
            var radioButtons3 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRevenue");
            var RevnueValue;
            for (var x = 0; x < radioButtons3.length; x++) {
                if (radioButtons3[x].checked) {
                    if (radioButtons3[x].value == 0) {
                        RevnueValue = 0;
                    }
                    else {
                        RevnueValue = 1;
                    }
                }
            }
            var radioButtons = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoTip");
            var TipValue;
            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value == 0) {
                        TipValue = 0;
                    }
                    else {
                        TipValue = 1;
                    }
                }
            }
            var radioButtons2 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoPrior");
            var PriorValue;
            for (var x = 0; x < radioButtons2.length; x++) {
                if (radioButtons2[x].checked) {
                    if (radioButtons2[x].value == 0) {

                        PriorValue = 0;
                    }
                    else {
                        PriorValue = 1;
                    }

                }

            }

            if (PriorValue == 0 || TipValue != 0 || RevnueValue != 0) {

                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            else {
                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            if (PriorValue != 0 || TipValue == 0 || RevnueValue != 0) {

                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            else {
                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            if (PriorValue != 0 || TipValue != 0 || RevnueValue == 0) {

                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }
            else {
                document.getElementById('<%=btnSubmit.ClientID %>').value = "Submit";
            }

        }


    </script>

    <script  type="text/javascript">
        function validate() {
            if (document.getElementById('<%=txtCustLastName.ClientID %>').value == "") {
                alert("Please Enter Last Name.");
                document.getElementById('<%=txtCustLastName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtJob.ClientID %>').value == "") {
                alert("Please Enter Job Mileage.");
                document.getElementById('<%=txtJob.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtJob.ClientID %>').value) == false) {
                alert("Not a valid Job Mileage.");
                document.getElementById('<%=txtJob.ClientID %>').focus();
                return false;
            }
            var JobMileage = '<%= Session["BeginningMileage"]%>';
            var jobtextvalue = parseInt(document.getElementById('<%=txtJob.ClientID %>').value);
            if (jobtextvalue < JobMileage) {
                alert("Job mileage should be greater than or equal to begning mileage.");
                document.getElementById('<%=txtJob.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtZipCode.ClientID %>').value == "") {
                alert("Please Enter Zip Code.");
                document.getElementById('<%=txtZipCode.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtZipCode.ClientID %>').value) == false) {
                alert("Not a valid Zip code.");
                document.getElementById('<%=txtZipCode.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtPets.ClientID %>').value == "") {
                alert("Please Enter Pets.");
                document.getElementById('<%=txtPets.ClientID %>').focus();
                return false;
            }
            /* Newly Added By Ganesh 15 Jan 2013 4:20PM */
            if (document.getElementById('<%=txtFleaandTick22.ClientID %>').value == "") {
                alert("Please Enter FleaandTick22.");
                document.getElementById('<%=txtFleaandTick22.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTick44.ClientID %>').value == "") {
                alert("Please Enter FleaandTick44.");
                document.getElementById('<%=txtFleaandTick44.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTick88.ClientID %>').value == "") {
                alert("Please Enter FleaandTick88.");
                document.getElementById('<%=txtFleaandTick88.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTick132.ClientID %>').value == "") {
                alert("Please Enter FleaandTick132.");
                document.getElementById('<%=txtFleaandTick132.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtFleaandTickCat.ClientID %>').value == "") {
                alert("Please Enter FleaandTickCat.");
                document.getElementById('<%=txtFleaandTickCat.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtTB.ClientID %>').value == "") {
                alert("Please Enter TB.");
                document.getElementById('<%=txtTB.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtWham.ClientID %>').value == "") {
                alert("Please Enter Wham.");
                document.getElementById('<%=txtWham.ClientID %>').focus();
                return false;
            }
           
            var radioButtonsReebok = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRebook");
            var ReebokValue;
            for (var x = 0; x < radioButtonsReebok.length; x++) {
                if (radioButtonsReebok[x].checked) {
                    if (radioButtonsReebok[x].value == 0) {
                        ReebokValue = 0;
                    }
                    else {
                        ReebokValue = 1;
                    }
                }
            }
            if (ReebokValue == 1) {
                var mydate1 = new Date();
                var theyear1 = mydate1.getFullYear();
                var themonth1 = mydate1.getMonth() + 1;
                var thetoday1 = mydate1.getDate();

                var currentdate1 = themonth1 + "/" + thetoday1 + "/" + theyear1;
                var NextAppMonth = document.getElementById('<%= lblNextAppDate.ClientID %>');

                var NextAppDate = NextAppMonth;
                if (Date.parse(NextAppDate) < Date.parse(currentdate1)) {
                    alert("Next App. Date. :" + "  " + " Next Appointment date should be future date !!!");
                    document.getElementById('<%=lblNextAppDate.ClientID %>').focus();
                    return false;
                }
                if (document.getElementById('<%=txtServicesforPet1.ClientID %>').value == "") {
                    alert("Services for pet 1 :" + "  " + "Please provide services for pet 1.");
                    document.getElementById('<%=txtServicesforPet1.ClientID %>').focus();
                    return false;
                }
            }
            if (IsNumeric(document.getElementById('<%=txtPets.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblPets.ClientID %>').innerText + "  " + "Not a valid Pets.");
                document.getElementById('<%=txtPets.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick22.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick22.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-22.");
                document.getElementById('<%=txtFleaandTick22.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick44.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick44.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-44.");
                document.getElementById('<%=txtFleaandTick44.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick88.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick88.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-88.");
                document.getElementById('<%=txtFleaandTick88.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTick132.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTick132.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-132.");
                document.getElementById('<%=txtFleaandTick132.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaandTickCat.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaandTickCat.ClientID %>').innerText + "  " + "Not a valid Flea and Tick-Cat.");
                document.getElementById('<%=txtFleaandTickCat.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtTB.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblTB.ClientID %>').innerText + "  " + "Not a valid TB.");
                document.getElementById('<%=txtTB.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtWham.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblWham.ClientID %>').innerText + "  " + "Not a valid Wham.");
                document.getElementById('<%=txtWham.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtRevenue.ClientID %>').value) == false) {
                alert("Revenue :" + "  " + "Not a valid Revenue.");
                document.getElementById('<%=txtRevenue.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtRevenue.ClientID %>').value == "") {
                alert("Revenue :" + "  " + "Please Enter Revenue.");
                document.getElementById('<%=txtRevenue.ClientID %>').focus();
                return false;
            }
            var ApptRevenue = parseFloat(document.getElementById('<%=txtRevenue.ClientID %>').value);
            var ApptPetTime = parseFloat(document.getElementById('<%=txtPetTime.ClientID %>').value);
            var ExpectedRev = parseFloat('<%= Session["ExpectedRev"]%>');
            var ExpectedPetTime = parseFloat('<%= Session["ExpectedPetTime"]%>');

            if (IsNumericRev(document.getElementById('<%=txtProductPrice.ClientID %>').value) == false) {
                alert(document.getElementById('<%=Label8.ClientID %>').innerText + "  " + "Not a valid Product Price.");
                document.getElementById('<%=txtProductPrice.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtSalestax.ClientID %>').value) == false) {
                alert(document.getElementById('<%=Label9.ClientID %>').innerText + "  " + "Not a valid Sales Tax.");
                document.getElementById('<%=txtSalestax.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtTip.ClientID %>').value) == false) {
                alert("Tip :" + "  " + "Not a valid Tip.");
                document.getElementById('<%=txtTip.ClientID %>').focus();
                return false;
            }
           

            var radioButtons3 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoRevenue");
            var RevnueValue;
            for (var x = 0; x < radioButtons3.length; x++) {
                if (radioButtons3[x].checked) {
                    if (radioButtons3[x].value == 0) {
                        RevnueValue = 0;
                    }
                    else {
                        RevnueValue = 1;
                    }
                }
            }

            var radioButtons = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoTip");
            var TipValue;
            for (var x = 0; x < radioButtons.length; x++) {
                if (radioButtons[x].checked) {
                    if (radioButtons[x].value == 0) {
                        TipValue = 0;
                    }
                    else {
                        TipValue = 1;
                    }
                }
            }

            var radioButtons2 = document.getElementsByName("ctl00$ContentPlaceHolder1$rdoPrior");
            var PriorValue;
            for (var x = 0; x < radioButtons2.length; x++) {
                if (radioButtons2[x].checked) {
                    if (radioButtons2[x].value == 0) {
                        PriorValue = 0;
                    }
                    else {
                        PriorValue = 1;
                    }
                }
            }
        }
        function IsNumeric(sText) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;
            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;
        }
        function IsNumericRev(sText) {
            var ValidChars = "0123456789.";
            var IsNumber = true;
            var Char;
            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <div style="width: 80%;" id="divError" runat="server">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <asp:Label ID="Label5" runat="server" Text="PrePaid Appointment" Font-Bold="true" Font-Size="Small" ForeColor="#009ddc" Visible="false"> </asp:Label>
            <table style="margin-left: -234px !important; width: 100%">
                <tr>
                    <td align="center" style="width: 63%">
                        <asp:Button ID="btnStartApt" runat="server" Text="Start Appt." CssClass="btn" Style="margin-left: 565px !important;" OnClick="btnStartApt_Click" />
                    </td>
                    <td align="center">
                        <asp:Button ID="btnEndApt" runat="server" Text="End Appt." Style="margin-left: 65px !important;" CssClass="btn" OnClick="btnEndApt_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <caption>
                        &nbsp;
                    </caption>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Appt. Start Time:-" CssClass="appnt_lbl"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblApptStartTime" runat="server" CssClass="appnt_detail"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Appt. End Time:-" CssClass="appnt_lbl"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblApptEndTime" runat="server" CssClass="appnt_detail"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px">
                        <asp:Label ID="Label3" runat="server" Text="Pet Time:-" CssClass="appnt_lbl"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblApptCompleteTime" runat="server" CssClass="appnt_detail"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="innercontent">
                <div class="divrow" id="divDetails" runat="server">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label11" runat="server" CssClass="appnt_lbl">Appt Date/Time:</asp:Label>
                        </div>
                        <div class="divcell_right" style="font-weight: normal;">
                            <asp:Label ID="lbl_time" runat="server" CssClass="appnt_detail" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label12" runat="server" CssClass="appnt_lbl">Description:</asp:Label>
                        </div>
                        <div class="divcell_right" style="font-weight: normal !important;">
                            <asp:Label ID="lbl_description" runat="server" CssClass="appnt_detail" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label4" runat="server" CssClass="appnt_lbl">Customer Username:</asp:Label>
                        </div>
                        <div class="divcell_right" style="font-weight: normal;">
                            <asp:TextBox ID="txtCustName" runat="server" placeHolder="name@example.com"></asp:TextBox>
                            <asp:Button ID="btnCustSync" runat="server" Text="Sync" OnClick="btnCustSync_Click" CssClass="btn" />
                        </div>
                    </div>
                    <div style="width: 85%;">
                        <asp:Label ID="lblAppSubmit" runat="server" ForeColor="Red" Text=""></asp:Label>
                        <asp:Label ID="lblAppSubmit1" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </div>
                </div>
                <div style="width: 85%;" id="div1" runat="server">
                    <asp:Label ID="lblErrorDate" runat="server" ForeColor="red" Visible="false"></asp:Label>
                </div>
                <div class="divrow">
                    <div class="divcell_left">
                        <asp:Label ID="lblDates" runat="server" CssClass="appnt_lbl">Date:</asp:Label>
                    </div>
                    <div class="divcell_right_two">
                        <asp:TextBox ID="txtDate" runat="server" CssClass="txt txt117" MaxLength="20"
                            TabIndex="1"></asp:TextBox>
                    </div>
                </div>
                <div class="divrow">
                    <div class="divcell_left">
                        <asp:Label ID="lblLastName" runat="server" CssClass="appnt_lbl" Text="Last Name:"></asp:Label><span
                            style="color: Red">*</span>
                    </div>
                    <div class="divcell_right_two">
                        <asp:TextBox ID="txtCustLastName" runat="server" CssClass="txt txt117" MaxLength="20"
                            TabIndex="2" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <div class="divrow">
                    <div class="divcell_left">
                        <asp:Label ID="lblJob" runat="server" CssClass="appnt_lbl" Text="Job Mileage:"></asp:Label><span
                            style="color: Red">*</span>
                    </div>
                    <div class="divcell_right_two">
                        <asp:TextBox ID="txtJob" runat="server" CssClass="txt txt117" MaxLength="20" TabIndex="3" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <div class="divrow">
                    <div class="divcell_left">
                        <asp:Label ID="lblZipCode" runat="server" CssClass="appnt_lbl" Text="Zip Code:"></asp:Label><span
                            style="color: Red">*</span>
                    </div>
                    <div class="divcell_right_two">
                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="txt txt117" MaxLength="5" TabIndex="4" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <div class="divrow">
                    <div class="divcell_left">
                        <asp:Label ID="lblPets" runat="server" CssClass="appnt_lbl" Text="Pets:"></asp:Label>
                        <span style="color: Red">*</span>
                    </div>
                    <div class="divcell_right_two">
                        <asp:TextBox ID="txtPets" runat="server" CssClass="txt txt117" MaxLength="2" TabIndex="5" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <div class="divrow" id="nextapp" runat="server" visible="false">
                    <div class="divcell_left">
                        <asp:Label ID="lblnext" runat="server" CssClass="appnt_lbl" Text="Next Appt.:"></asp:Label><br />
                        Exp.Start Time:<br />
                        Exp.End Time:
                    </div>
                    <div class="divcell_right_two">
                        <asp:Label ID="lblnextapp" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblexpstart" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblexpend" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="btnReSchedule" runat="server" Text="ReSchedule" CssClass="btn" OnClick="btnReSchedule_Click" />
                    </div>
                </div>
                <div class="divrow">
                    <div class="divcell_left">
                        <asp:Label ID="lblRebook" runat="server" CssClass="appnt_lbl">Rebook:</asp:Label>
                    </div>
                    <div class="divcell_right_two">
                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoRebook" runat="server" CellPadding="1" CellSpacing="0" CssClass="radiobtn" AutoPostBack="True" OnSelectedIndexChanged="rdoRebook_SelectedIndexChanged"
                            TabIndex="6">
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="innercontent" id="divNextAppoint" runat="server" visible="false">
                        <div>
                            <asp:Label ID="lbldatevalmsg" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                        </div>
                        <div class="divrow">
                            <div class="divcell_left">
                                Date:<span style="color: Red">*</span>
                            </div>
                            <div class="divcell_right_two" style="margin-bottom: 5px;">
                                <asp:Label ID="lblNextAppDate" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="divrow">
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="lblNextTime" runat="server" CssClass="appnt_lbl">Start Time:<span style="color:Red">*</span></asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:Label ID="lblNextStartTime" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="divrow">
                                    <div class="divcell_left">
                                        <asp:Label ID="Label10" runat="server" CssClass="appnt_lbl">End Time:<span style="color:Red">*</span></asp:Label>
                                    </div>
                                    <div class="divcell_right_two">
                                        <asp:Label ID="lblNextEndTime" runat="server" Text=""></asp:Label><br />
                                        <asp:Button ID="btnRebookNextApp" runat="server" Text="Rebook" CssClass="btn" OnClick="btnRebookNextApp_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="divrow">
                                <div class="divcell_left">
                                    <asp:Label ID="lblServicesforPet1" runat="server" CssClass="appnt_lbl">Services for Pet-1:</asp:Label>
                                </div>
                                <div class="divcell_right_two">
                                    <asp:TextBox ID="txtServicesforPet1" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divrow">
                                <div class="divcell_left">
                                    <asp:Label ID="lblServicesforPet2" runat="server" CssClass="appnt_lbl">Services for Pet-2:</asp:Label>
                                </div>
                                <div class="divcell_right_two">
                                    <asp:TextBox ID="txtServicesforPet2" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divrow">
                                <div class="divcell_left">
                                    <asp:Label ID="lblServicesforPet3" runat="server" CssClass="appnt_lbl">Services for Pet-3:</asp:Label>
                                </div>
                                <div class="divcell_right_two">
                                    <asp:TextBox ID="txtServicesforPet3" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divrow">
                                <div class="divcell_left">
                                    <asp:Label ID="lblServicesforPet4" runat="server" CssClass="appnt_lbl">Services for Pet-4:</asp:Label>
                                </div>
                                <div class="divcell_right_two">
                                    <asp:TextBox ID="txtServicesforPet4" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divrow">
                                <div class="divcell_left">
                                    <asp:Label ID="lblServicesforPet5" runat="server" CssClass="appnt_lbl">Services for Pet-5:</asp:Label>
                                </div>
                                <div class="divcell_right_two">
                                    <asp:TextBox ID="txtServicesforPet5" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                </div>
                            </div>
                            <div class="divrow">
                                <div class="divcell_left">
                                    <asp:Label ID="lblServicesforPet6" runat="server" CssClass="appnt_lbl">Services for Pet-6:</asp:Label>
                                </div>
                                <div class="divcell_right_two">
                                    <asp:TextBox ID="txtServicesforPet6" runat="server" CssClass="txt txt117" MaxLength="256"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="spacer10">
                        </div>
                    </div>
                  
                    <div class="divrow" id="dvnew" runat="server" visible="false">
                        <div class="divcell_left">
                            <asp:Label ID="lblNew" runat="server" CssClass="appnt_lbl">New:</asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoNew" runat="server" CellPadding="1"
                                CellSpacing="0" CssClass="radiobtn" TabIndex="8">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div class="spacer10"></div>
                <div style="display: none">
                    <div class="divcell_left">
                    </div>
                    <div class="divcell_right_two">
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtPetTime" runat="server" Width="0px" CssClass="pet_time" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="spacer10"></div>
                <h2 style="margin-left: 262px !important;">Supplies</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick22" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–22:"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtFleaandTick22" runat="server" CssClass="txt txt117" MaxLength="8" onkeypress="return IntegerNumbers(event);" TabIndex="15" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick44" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–44:"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtFleaandTick44" runat="server" CssClass="txt txt117" MaxLength="8" onkeypress="return IntegerNumbers(event);" TabIndex="16" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick88" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–88:"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtFleaandTick88" runat="server" CssClass="txt txt117" MaxLength="8" onkeypress="return IntegerNumbers(event);" TabIndex="17" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick132" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–132:"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtFleaandTick132" runat="server" CssClass="txt txt117" MaxLength="8" onkeypress="return IntegerNumbers(event);" TabIndex="18" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTickCat" runat="server" CssClass="appnt_lbl" Text="Flea & Tick–Cat:"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtFleaandTickCat" runat="server" CssClass="txt txt117" MaxLength="8" onkeypress="return IntegerNumbers(event);" TabIndex="19" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTB" runat="server" CssClass="appnt_lbl" Text="TB:"></asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtTB" runat="server" CssClass="txt txt117" MaxLength="4" TabIndex="20" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblWham" runat="server" CssClass="appnt_lbl">Wham:</asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtWham" runat="server" CssClass="txt txt117" MaxLength="4" TabIndex="21" onkeypress="return IntegerNumbers(event);" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="spacer10"></div>
                <h2 style="margin-left: 262px !important;">Revenue<span style="color: Red">*</span></h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            &nbsp;
                        </div>
                        <div class="divcell_right_two">
                            <asp:RadioButtonList ID="rdoRevenue" runat="server" CssClass="radiobtn" onclick="javascript: getCheckedRevnue(this);" OnSelectedIndexChanged="rdoRevenue_SelectedIndexChanged" AutoPostBack="True" TabIndex="22" Width="126px">
                                <asp:ListItem Text="Credit Card" Selected="True" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">CCY</asp:ListItem>
                                <asp:ListItem Text="Check" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Cash" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Invoice" Value="4"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblExtraServices0" runat="server" CssClass="appnt_lbl">Revenue 
                                Amt($)</asp:Label><span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtRevenue" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" CssClass="txt txt117" MaxLength="8" TabIndex="23" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblExtraServices" runat="server" CssClass="appnt_lbl">Appt Changes:</asp:Label>
                            <asp:Label ID="lblaptchangesreq" runat="server" CssClass="appnt_lbl" ForeColor="Red"
                                Visible="false">*</asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtExtraServices" runat="server" CssClass="txt txt117" Height="40px"
                                MaxLength="256" TabIndex="24" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div id="divaptchangesrequired" class="divrow" visible="false" runat="server">
                        <asp:Label ID="lblaptchange" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblComment" runat="server" CssClass="appnt_lbl">Comments:</asp:Label>
                            <asp:Label ID="lblCommentsreq" runat="server" CssClass="appnt_lbl" ForeColor="Red"
                                Visible="False"></asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtComments" runat="server" CssClass="txt txt117" Height="60px"
                                MaxLength="500" TabIndex="25" autocomplete="off" TextMode="MultiLine"
                                Font-Size="Small"></asp:TextBox><br />
                            <br />
                        </div>
                        <div class="divcell_left" style="margin-top: 71px;">
                            <asp:Label ID="lblDriveTime" runat="server" CssClass="appnt_lbl">Drive Time</asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:RadioButtonList ID="rdoDriveTime" runat="server" CssClass="Space" TabIndex="26" RepeatDirection="Horizontal" CellPadding="1" CellSpacing="0"
                                RepeatLayout="Flow" OnSelectedIndexChanged="rdoDriveTime_SelectedIndexChanged"  ValidationGroup="submit"
                                AutoPostBack="true">
                                <asp:ListItem Value="1">Good</asp:ListItem>
                                <asp:ListItem Value="0">Bad</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator runat="server" ID="radRfvDriveTime" ControlToValidate="rdoDriveTime"
                                 EnableClientScript="true" ErrorMessage="Enter Time Assessment(s)." SetFocusOnError="true"
                                ValidationGroup="submit"><br />Enter Time Assessment(s).</asp:RequiredFieldValidator>
                            <br />
                            <br />
                        </div>
                        <div class="divcell_left" style="margin-top: 28px;">
                            <asp:Label ID="lblPetTime" runat="server" CssClass="appnt_lbl">Pet Time</asp:Label>
                            <span style="color: Red">*</span>
                        </div>
                        <div class="divcell_right_two">
                            <asp:RadioButtonList ID="rdoPetTime" runat="server" TabIndex="27" RepeatDirection="Horizontal" ValidationGroup="submit"
                                RepeatLayout="Flow" CssClass="Space" OnSelectedIndexChanged="rdoPetTime_SelectedIndexChanged"
                                AutoPostBack="true">
                                <asp:ListItem Value="1">Good</asp:ListItem>
                                <asp:ListItem Value="0">Bad</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator runat="server" ID="radRfvPetTime" ControlToValidate="rdoPetTime"
                                EnableClientScript="true" ErrorMessage="Enter Time Assessment(s)." SetFocusOnError="true"
                                ValidationGroup="submit"><br />Enter Time Assessment(s).</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="spacer10"></div>
                <h2 style="margin-left: 262px !important;">Product</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label8" runat="server" CssClass="appnt_lbl" Text="Product Price:"></asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtProductPrice" runat="server" CssClass="txt txt117" MaxLength="8" onkeypress="return decimalIntegerNumbers(event,this)" TabIndex="28" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label9" runat="server" CssClass="appnt_lbl" Text="Sales Tax:"></asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtSalestax" runat="server" CssClass="txt txt117" MaxLength="8" onkeypress="return decimalIntegerNumbers(event,this)" TabIndex="29" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="spacer10"></div>
                <h2 style="margin-left: 262px !important;">Tip</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            &nbsp;
                        </div>
                        <div class="divcell_right_two">
                            <asp:RadioButtonList ID="rdoTip" runat="server" CssClass="radiobtn" onclick="javascript: getCheckedRevnue(this);"
                                AutoPostBack="True" OnSelectedIndexChanged="rdoTip_SelectedIndexChanged" TabIndex="30">
                                <asp:ListItem Text="Credit Card" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Check" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Invoice" Value="3"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblExtraServices1" runat="server" CssClass="appnt_lbl">Tip Amt ($):</asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtTip" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" CssClass="txt txt117" MaxLength="8" TabIndex="31" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="spacer10"></div>
                <h2 style="margin-left: 262px !important;">Prior Revenue</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            &nbsp;
                        </div>
                        <div class="divcell_right_two">
                            <asp:RadioButtonList ID="rdoPrior" runat="server" CssClass="radiobtn" onclick="javascript: getCheckedRevnue(this);"
                                AutoPostBack="True" OnSelectedIndexChanged="rdoPrior_SelectedIndexChanged" TabIndex="32">
                                <asp:ListItem Selected="True" Text="Credit Card" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Check" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblpriorrevamt" runat="server" CssClass="appnt_lbl">Prior Rev.Amt($):</asp:Label><asp:Label
                                ID="Label7" runat="server" CssClass="lbl">&nbsp;</asp:Label>
                        </div>
                        <div class="divcell_right_two">
                            <asp:TextBox ID="txtPriorRevenue" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" CssClass="txt txt117" MaxLength="8" TabIndex="33" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="spacer10">
                    </div>
                    <div id="chkdetails" runat="server" visible="false">
                        <h2>Check Details</h2>
                        <br />
                        <table border="0" width="100%" align="center" class="">
                            <tr>
                                <td style="width: 209px">
                                    <asp:Label ID="lblcustname" runat="server" CssClass="appnt_lbl">Name on check:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcname" runat="server" CssClass="txt txt117" MaxLength="200" ValidationGroup="submit"
                                        autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblcustaddress" runat="server" CssClass="appnt_lbl">Address on  check:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcaddr" runat="server" CssClass="txt txt117" MaxLength="250" ValidationGroup="submit" autocomplete="off"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="spacer10"></div>
               
                <table style="margin-left: 242px !important; width: 100%">
                    <tr>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" CssClass="btn"
                                OnClientClick="return validate();" OnClick="btnSubmit_Click" ValidationGroup="submit"
                                TabIndex="34" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnRevSync" runat="server" Text="Sync Revenue" CssClass="btn" OnClick="btnRevSync_Click"
                                    Visible="false" Width="100px" TabIndex="35" />
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelRev" runat="server" Text="Cancel Sync Revenue"
                                CssClass="btn" Width="150px" OnClick="btnCancelRev_Click" Visible="false" TabIndex="36" />
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCheckPayment" runat="server" Text="Verify Payment"
                                Visible="false" CssClass="btn" OnClick="btnCheckPayment_Click" Width="110px" TabIndex="37" />
                            <asp:Button ID="btnMakePayment" runat="server" Text="Instant Payment" CssClass="btn" TabIndex="38" OnClick="btnMakePayment_Click" Width="110px" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnStartApt" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnEndApt" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="rdoRevenue" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="rdoTip" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="rdoPrior" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="rdoRebook" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnCustSync" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnReSchedule" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRebookNextApp" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="rdoDriveTime" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="rdoPetTime" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Visible="true" CssClass="btnConfirm" Height="0px" Width="0px" BorderStyle="None" />
</asp:Content>
