<%@ Page Title="Daily Operations Log" Language="C#" MasterPageFile="~/MasterPage.master"    AutoEventWireup="true" Inherits="DailyOperationLog" Codebehind="DailyOperationLog.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/Validation.js"></script>
   <%-- <script src="Scripts/phone_validation.js"></script>--%>
    <script type="text/javascript">

        function validate() {

            if (document.getElementById('<%=txtVanID.ClientID %>').value == "") {
                alert("Van ID" + " : " + "Please Enter Van ID.");
                document.getElementById('<%=txtVanID.ClientID %>').focus();
                return false;
            }
            //begning  mileage code start
            if (document.getElementById('<%=txtBeginningMileage.ClientID %>').value == "") {
                alert("Beginning Mileage" + " : " + "Please Enter Beginning Mileage.");
                document.getElementById('<%=txtBeginningMileage.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtBeginningMileage.ClientID %>').value != "") {
                var a = document.getElementById('<%= txtBeginningMileage.ClientID %>').value;
                if (parseInt(a) <= 0) {
                    alert("Beginning Mileage" + " : " + "Not a valid Beginning Mileage.");
                    document.getElementById('<%=txtBeginningMileage.ClientID %>').focus();
                    return false;
                }
            }
            if (IsNumeric(document.getElementById('<%=txtBeginningMileage.ClientID %>').value) == false) {
                alert("Beginning Mileage" + " : " + "Not a valid Beginning Mileage.");
                document.getElementById('<%=txtBeginningMileage.ClientID %>').focus();
                return false;
            }

            /////begning  mileage code end


            //ending  mileage code start
            if (document.getElementById('<%=txtEndingMileage.ClientID %>').value == "") {
                alert("Ending Mileage" + " : " + "Please Enter Ending Mileage.");
                document.getElementById('<%=txtEndingMileage.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtEndingMileage.ClientID %>').value != "") {
                var a = document.getElementById('<%= txtEndingMileage.ClientID %>').value;
                if (parseInt(a) <= 0) {
                    alert("Ending Mileage" + " : " + "Not a valid Ending Mileage.");
                    document.getElementById('<%=txtEndingMileage.ClientID %>').focus();
                    return false;
                }
            }
            if (IsNumeric(document.getElementById('<%=txtEndingMileage.ClientID %>').value) == false) {
                alert("Ending Mileage" + " : " + "Not a valid Ending Mileage.");
                document.getElementById('<%=txtEndingMileage.ClientID %>').focus();
                return false;
            }

            /////ending  mileage code end


            if (IsNumericRev(document.getElementById('<%=txtTotalHours.ClientID %>').value) == false) {
                alert("Total Hours" + " : " + "Not a valid Total Hours.");
                document.getElementById('<%=txtTotalHours.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtEndingMileage.ClientID %>').value) == false) {
                alert("Ending Mileage" + " : " + "Not a valid Ending Mileage.");
                document.getElementById('<%=txtEndingMileage.ClientID %>').focus();
                return false;
            }
            var Bmileage = document.getElementById('<%=txtBeginningMileage.ClientID %>').value;
            var Emileage = document.getElementById('<%=txtEndingMileage.ClientID %>').value;
            if (document.getElementById('<%=txtEndingMileage.ClientID %>').value != "") {
                if (parseInt(Emileage) < parseInt(Bmileage)) {
                    alert("Ending Mileage" + " : " + "Ending mileage should be more than beginning mileage.");
                    document.getElementById('<%=txtEndingMileage.ClientID %>').focus();
                    return false;
                }
            }
            if (IsNumericRev(document.getElementById('<%=txtFuelPurchased.ClientID %>').value) == false) {
                alert("Fuel Purchased" + " : " + "Not a valid Fuel Purchased.");
                document.getElementById('<%=txtFuelPurchased.ClientID %>').focus();
                return false;
            }
            if (IsNumericRev(document.getElementById('<%=txtPriceperGallon.ClientID %>').value) == false) {
                alert("Price Per Gallon" + " : " + "Not a valid Price Per Gallon.");
                document.getElementById('<%=txtPriceperGallon.ClientID %>').focus();
                return false;
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

    <h2> Daily Operations Log</h2>
    <div class="innercontent">
        <%--Region Error/Success message start--%>
        <div style="width: 80%;" id="divError" runat="server">
            <asp:Label ID="lblError" runat="server"></asp:Label><br />
             <%--<asp:Label ID="lblHintMessage" runat="server" ForeColor="Green" ></asp:Label>--%>
        </div>
        <%--Region Error/Success message end--%>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="Label1" runat="server" CssClass="lbl">Date:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtDate" runat="server" ReadOnly="true" CssClass="txt txt117" MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblVanID" runat="server" CssClass="lbl">Van ID:<span style="color:Red">*</span></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtVanID" runat="server" CssClass="txt txt117"  onkeypress="return IntegerNumbers(event);"  MaxLength="10" AutoPostBack="true" OnTextChanged="txtVanID_TextChanged"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="ReqVal1" runat="server" ValidationGroup="valReg_Basic"  CausesValidation="true"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>*Van ID is required.</b>"
                                                                ControlToValidate="txtVanID">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender PopupPosition="TopLeft" ID="ValidatorCalloutExtender2" runat="Server" TargetControlID="ReqVal1"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight"></cc1:ValidatorCalloutExtender>
   </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblBeginningMileage" runat="server" CssClass="lbl">Beginning Mileage:<span style="color:Red">*</span></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtBeginningMileage"  onkeypress="return IntegerNumbers(event);"  runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqVal2" runat="server" ValidationGroup="valReg_Basic"  CausesValidation="true"  SetFocusOnError="true" Display="None" ErrorMessage="<b>*Beginning Mileage is required.</b>"  ControlToValidate="txtBeginningMileage">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender PopupPosition="TopLeft" ID="ValidatorCalloutExtender1" runat="Server" TargetControlID="ReqVal2"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight"></cc1:ValidatorCalloutExtender>
            </div>
        </div>
        <div class="divrow" style ="display:none">
            <div class="divcell_left">
                <asp:Label ID="lblTotalHours" runat="server" CssClass="lbl">Total Hours:<span style="color:Red">*</span></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtTotalHours"  onkeypress="return decimalIntegerNumbers(event,this)"  runat="server" CssClass="txt txt117"  MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="divrow" runat="server" id="divEndingMileage">
            <div class="divcell_left">
                <asp:Label ID="lblEndingMileage" runat="server" CssClass="lbl">Ending Mileage:</asp:Label>
                 <asp:Label ID="lblEndingMileageReq" runat="server" CssClass="appnt_lbl" ForeColor="Red"
                                Visible="false">*</asp:Label>
            </div>
            <div class="divcell_right">
                <asp:TextBox ID="txtEndingMileage"   onkeypress="return IntegerNumbers(event);"  runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
               <asp:RequiredFieldValidator ID="ReqVal3" runat="server" ValidationGroup="valReg_Basic"  CausesValidation="true"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>*Ending Mileage is required.</b>" ControlToValidate="txtEndingMileage">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender PopupPosition="TopLeft" ID="ValidatorCalloutExtender3" runat="Server" TargetControlID="ReqVal3"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight"></cc1:ValidatorCalloutExtender>
             <asp:CompareValidator ID="CompareValidator3" runat="server"  ControlToCompare="txtBeginningMileage" ValidationGroup="valReg_Basic"  CausesValidation="true"
                        ControlToValidate="txtEndingMileage" ErrorMessage="Ending Mileage should be greater than Beginning Mileage"  Operator="GreaterThan" Type="Integer" >
              <cc1:ValidatorCalloutExtender   PopupPosition="TopLeft" ID="ValidatorCalloutExtender4" runat="Server" TargetControlID="CompareValidator3"   Enabled="true" HighlightCssClass="validatorCalloutHighlight"></cc1:ValidatorCalloutExtender>
</asp:CompareValidator>
                 </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblFuelPurchased" runat="server" CssClass="lbl">Fuel Purchased:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtFuelPurchased"  onkeypress="return decimalIntegerNumbers(event,this)"   runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblPriceperGallon" runat="server" CssClass="lbl">Price per Gallon:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtPriceperGallon"  onkeypress="return decimalIntegerNumbers(event,this)"  runat="server" CssClass="txt txt117" MaxLength="8"></asp:TextBox>
            </div>
        </div>
        <div class="spacer10"></div>
        <div class="innercontent">
            <div class="bottombtnNew">
                <asp:Button ID="btnSubmit"   runat="server" Text="Submit" ToolTip="Submit" style="margin-left:432px !important;width: 100px; font-size: 14px;"  OnClick="btnSubmit_Click"   ValidationGroup="valReg_Basic"  CausesValidation="true" CssClass="btn"  />
           <%-- OnClientClick="return validate();"--%>
            </div>
        </div>
    </div>
</asp:Content>
