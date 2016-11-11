<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="MB_MyAccount" Title="Mobile Grooming Services" EnableEventValidation="false" CodeBehind="MB_MyAccount.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/MobileGridTable.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="../Scripts/phone_validation.js"></script>
    <script src="../Scripts/Validation.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/boostarpTable.css" rel="stylesheet" />

    <style>
        .divMyAccount {
            margin-top: 16px;
        }
    </style>

    <script type="text/javascript">
        function ValYear(source, args) {
            var dteNow = new Date();
            var intYear = dteNow.getFullYear()
            if (args.Value > intYear)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        function confirmation() {
            if (!confirm("Do you want to delete this pet?")) {
                return false;
            }
        }
        function validate() {

            if (document.getElementById('<%=txtFirstName.ClientID %>').value == "") {

                alert("Please Enter First Name.");
                document.getElementById('<%=txtFirstName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtLastName.ClientID %>').value == "") {

                alert("Please Enter Last Name.");
                document.getElementById('<%=txtLastName.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%=txtStreet.ClientID %>').value == "") {

                alert("Please Enter Address.");
                document.getElementById('<%=txtStreet.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%=txtCity.ClientID %>').value == "") {

                alert("Please Enter City.");
                document.getElementById('<%=txtCity.ClientID %>').focus();
                return false;
            }

            var StateValue = document.getElementById('<%= ddlState.ClientID %>').options[document.getElementById('<%= ddlState.ClientID %>').selectedIndex].value;

            if (StateValue == "0") {
                alert("Please Select State.");
                document.getElementById('<%=ddlState.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtZip.ClientID %>').value == "") {

                alert("Please Enter Zip Code.");
                document.getElementById('<%=txtZip.ClientID %>').focus();
                return false;
            }

            if (IsNumeric(document.getElementById('<%=txtZip.ClientID %>').value) == false) {
                alert("Not a valid Zip Code.");
                document.getElementById('<%=txtZip.ClientID %>').focus();
                return false;
            }

            var ReferralSource = document.getElementById('<%= ddlReferralSource.ClientID %>').options[document.getElementById('<%= ddlReferralSource.ClientID %>').selectedIndex].value;
            if (ReferralSource == "0") {
                alert("Please Select Referral Source.");
                document.getElementById('<%=ddlReferralSource.ClientID %>').focus();
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
    </script>

    <style>
        .chkPetSelect {
            margin-right: 236px;
        }

        .viewgridStyle {
            margin-right: 0px;
        }

        .grdViewAppoint {
            width: 300px;
            border: 0px;
            overflow-x: scroll;
        }
    </style>

    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>My Account</h1>
        </div>

        <div class="innercontent">
            <div class="reg-top-txt">
                Please include any additional information regarding your pet, grooming location,
                or groomer preference and complete all the required information in your profile,
                so that we can provide you with an appointment that will meet you and your pet's
                needs.
                <br />
                <br />
                For your convenience you may save your changes and schedule an appointment at the
                bottom of this page.
            </div>
            <div style="width: 80%;" id="divError" runat="server">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
            </div>
            <asp:Label ID="lblErrorEmail" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Medium" Visible="false"></asp:Label>
            <h2><span class="heading">Your Information</span></h2>
            <div class="forform">
                <div>
                    <asp:Label runat="server" ID="firstname" CssClass="label">First Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox CssClass="txtbox" ID="txtFirstName" MaxLength="30" runat="server" Width="276px"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TBWE1" runat="server" TargetControlID="txtFirstName"
                        WatermarkText="First Name" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqFirstName" ControlToValidate="txtFirstName" ErrorMessage="<b>*First name is required.</b>" Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="VCE1" TargetControlID="ReqFirstName" HighlightCssClass="validatorCalloutHighlight"
                        Enabled="true" runat="Server" PopupPosition="TopRight" />
                    <br />
                    <asp:Label runat="server" ID="lastname" CssClass="label">Last Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="30" CssClass="txtbox" Width="276px"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtLastName"
                        WatermarkText="Last Name" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqLastName" ControlToValidate="txtLastName" ErrorMessage="<b>*Last name is required.</b>" Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="ReqLastName"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" PopupPosition="TopRight" />
                    <asp:Label runat="server" ID="streetaddresslabel" CssClass="label">Street Address<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtStreet" MaxLength="60" Width="276px" CssClass="txtbox"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TBWE3" runat="server" TargetControlID="txtStreet" WatermarkText="Street" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqValStreet" ControlToValidate="txtStreet" ErrorMessage="<b>Street name is required.</b>" ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="VCEPet2" PopupPosition="TopRight" TargetControlID="ReqValStreet" HighlightCssClass="validatorCalloutHighlight"
                        Enabled="true" runat="Server" />
                    <asp:Label runat="server" ID="citylable" CssClass="label">City<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" Width="276px" ID="txtCity" MaxLength="30" CssClass="txtbox"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TBWE4" runat="server" TargetControlID="txtCity" WatermarkText="City" WatermarkCssClass="regTextFldCity1" />
                    <asp:RequiredFieldValidator ID="ReqValCity" ControlToValidate="txtCity" ErrorMessage="<b>*City name is required.</b>" ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" PopupPosition="TopRight" TargetControlID="ReqValCity" HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                    <div class="divforstate-zip">
                        <div class="divstate">
                            <asp:Label ID="statelabel" CssClass="shortlabel" runat="server">State<span class="mand">*</span></asp:Label><br />
                            <asp:DropDownList ID="ddlState" CssClass="shortselectbox" runat="server">
                            </asp:DropDownList><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="State" InitialValue="0"
                                ControlToValidate="ddlState" ErrorMessage="<b>*Please select state</b>"
                                Display="none" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator1"
                                HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopLeft" Enabled="true" runat="Server" />
                        </div>
                        <div class="divstate">
                            <asp:Label runat="server" CssClass="shortlabel" ID="ziplabel">Zip<span class="mand">*</span></asp:Label><br />
                            <asp:TextBox runat="server" Width="126px" onkeypress="return IntegerNumbers(event);" CssClass="shorttxtbox" MaxLength="5" ID="txtZip"></asp:TextBox><br />
                            <cc1:TextBoxWatermarkExtender ID="TBWE6" runat="server" TargetControlID="txtZip" WatermarkText="Zip" WatermarkCssClass="regTextFldzip1" />
                            <asp:RequiredFieldValidator ID="ReqValZip" ControlToValidate="txtZip" ErrorMessage="<b>*Zipcode is required.</b>" ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="ReqValZip"
                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" PopupPosition="TopLeft" />
                            <asp:RegularExpressionValidator ID="RegValZip" runat="server" Display="None" ErrorMessage="<b>*Please enter correct zipcode .</b>"
                                ValidationGroup="valReg_Basic" SetFocusOnError="true" ControlToValidate="txtZip" ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender49" TargetControlID="RegValZip" PopupPosition="TopLeft"
                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                        </div>
                    </div>
                    <asp:Label runat="server" CssClass="label" ID="phonelabel">Phone<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox Width="276px" runat="server" CssClass="txtbox" MaxLength="15" ID="txtPhone" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtPhone"
                        WatermarkText="Primary Phone*" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqPhone" ControlToValidate="txtPhone" ErrorMessage="<b>*Primary phone is required.</b>" ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="ReqPhone" PopupPosition="TopRight" HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                    <asp:Label runat="server" CssClass="label" ID="Label32">Mobile</asp:Label><br />
                    <asp:TextBox runat="server" onkeydown="javascript:backspacerDOWN(this,event);" Width="276px" onkeyup="javascript:backspacerUP(this,event);" CssClass="txtbox" ID="txtAltMobile"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtAltMobile"
                        WatermarkText="Mobile Number" WatermarkCssClass="regTextField1" />
                    <asp:Label runat="server" CssClass="label" ID="mobilelabel">Alternate Contact</asp:Label><br />
                    <asp:TextBox runat="server" Width="276px" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" CssClass="txtbox" ID="txtAltContact"></asp:TextBox><br />

                    <asp:Label runat="server" ID="altstreetaddress" CssClass="label">Alternate Street Address</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtAltStreet" MaxLength="60" Width="276px" CssClass="txtbox"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="txtAltStreet"
                        WatermarkText="Street" WatermarkCssClass="regTextField1" />
                    <asp:Label runat="server" ID="alternatecitylabel" CssClass="label">City</asp:Label><br />
                    <asp:TextBox runat="server" Width="276px" ID="txtAltCity" CssClass="txtbox"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtAltCity"
                        WatermarkText="Alt Street" WatermarkCssClass="regTextField1" />
                    <div class="divforstate-zip">
                        <div class="divstate">
                            <asp:Label ID="alternatestatelabel" CssClass="shortlabel" runat="server">State</asp:Label><br />
                            <asp:DropDownList ID="ddlState1" CssClass="shortselectbox" runat="server">
                                <asp:ListItem>State</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="divstate">
                            <asp:Label runat="server" CssClass="shortlabel" ID="alternateziplabel">Zip</asp:Label><br />
                            <asp:TextBox onkeypress="return IntegerNumbers(event);" CssClass="shorttxtbox" MaxLength="5" runat="server" Width="133px" ID="txtAltZip"></asp:TextBox><br />
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="txtAltZip"
                                WatermarkText="Zip" WatermarkCssClass="regTextFldzip1" />
                            <asp:RegularExpressionValidator ID="RegValzip1" runat="server" Display="None" ErrorMessage="Please enter correct zipcode ."
                                ValidationGroup="valReg_Basic" SetFocusOnError="true" ControlToValidate="txtAltZip"
                                ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
                            <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender50" TargetControlID="RegValzip1"
                                HighlightCssClass="validatorCalloutHighlight" Enabled="true">
                            </cc1:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <asp:Label runat="server" CssClass="label" ID="Label33">Alternate Phone</asp:Label><br />
                    <asp:TextBox ID="txtAltPhone" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" CssClass="txtbox" runat="server" Width="276px" MaxLength="15"></asp:TextBox>
                    <asp:Label runat="server" CssClass="label" ID="referrellabel">Referral Source<span class="mand">*</span></asp:Label><br />
                    <asp:DropDownList runat="server" CssClass="selectbox" ID="ddlReferralSource">
                    </asp:DropDownList><br />
                    <asp:RequiredFieldValidator ID="Reqref" Text="Selcect One" InitialValue="0" ControlToValidate="ddlReferralSource"
                        ErrorMessage="<b>Required Field Missing</b><br />Referral source is required"
                        Display="none" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender42" TargetControlID="Reqref"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                    <br />
                    <asp:Label runat="server" CssClass="label" ID="Label31">Preferred Groomer</asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" ID="txtGroomer"></asp:TextBox><br />
                    <asp:Label runat="server" CssClass="label" ID="Label34">Email<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" ID="txtEmailReg"></asp:TextBox><br />
                    <cc1:TextBoxWatermarkExtender ID="TBWE7" runat="server" TargetControlID="txtEmailReg"
                        WatermarkText="Use as a User Name" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqEmailReg" runat="server" ControlToValidate="txtEmailReg"
                        Display="None" ValidationGroup="valReg_Basic" ErrorMessage="<b>Required Field Missing</b><br />Email is required."
                        SetFocusOnError="true"> </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE2" TargetControlID="ReqEmailReg"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    <asp:RegularExpressionValidator ID="ReqEmailReg1" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                        ValidationGroup="valReg_Basic" SetFocusOnError="true" ControlToValidate="txtEmailReg"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE3" TargetControlID="ReqEmailReg1"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    <br />
                    <h2>
                        <span class="heading">Your Pet Information</span></h2>
                    <asp:UpdatePanel ID="up12" runat="server">
                        <ContentTemplate>
                            <%--    For Pet 1--%>
                            <div class="divfirstpetinfo" id="dvPet1" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete1" Height="20" Width="20" runat="server" ImageUrl="~/MobileWeb/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete1_Click" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="PetID1" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="petlabel" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType1" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType1_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="petnamelabel" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName1" CssClass="shorttxtbox" Width=" 126px" MaxLength="20" runat="server"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVal1" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>*Pet name is required.</b>"
                                        ControlToValidate="txtPetName1">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender PopupPosition="TopLeft" ID="VCEPet1" runat="Server" TargetControlID="ReqVal1"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="breedlabel" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed1" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl2" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>*Breed is required</b>"
                                        ControlToValidate="ddlBreed1" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender PopupPosition="TopRight" ID="ValidatorCalloutExtender6" runat="Server" TargetControlID="ReqVal2"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="birthlabel" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtPetDOB1" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVal3" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                        ControlToValidate="txtPetDOB1">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="VCEPet3" runat="Server" TargetControlID="ReqVal3"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReqPet4" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year ."
                                        ControlToValidate="txtPetDOB1" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="Server" TargetControlID="ReqPet4"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:CustomValidator runat="server" ID="custYear1" ValidationGroup="valReg_Basic"
                                        ControlToValidate="txtPetDOB1" Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear"
                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender51" TargetControlID="custYear1"
                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="weightlabel" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight1" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
                                    <asp:RequiredFieldValidator ID="Reqval4" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Weight is required."
                                        ControlToValidate="txtPetWeight1">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="VCEPet4" runat="Server" TargetControlID="Reqval4"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReqPet6" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                        ControlToValidate="txtPetWeight1" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="VCEPet5" runat="Server" TargetControlID="ReqPet6"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="furlenghtlabel" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength1" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
                                    <asp:RequiredFieldValidator ID="Reqval7" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Length is required."
                                        ControlToValidate="txtPetLength1">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="VCEPet6" runat="Server" TargetControlID="Reqval7"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="Reqval8" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                        ControlToValidate="txtPetLength1" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="VCEPet7" runat="Server" TargetControlID="Reqval8"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <%--    For Pet 2--%>
                            <div class="divfirstpetinfo" id="dvPet2" runat="server">
                                <div class="deletediv">
                                    <%--   <asp:CheckBox ID="chkPet2" CssClass="chkPetSelect" runat="server" />--%>
                                    <asp:ImageButton ID="imgDelete2" Height="20" Width="20" runat="server" ImageUrl="~/MobileWeb/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete2_Click" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="PetID2" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="Label1" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType2" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType2_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label2" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName2" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox><br />
                                    <asp:Label ID="Label35" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:RequiredFieldValidator ID="ReqVAl21" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                        ControlToValidate="txtPetName2">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="Server" TargetControlID="ReqVAl21"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label3" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed2" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl22" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                        ControlToValidate="ddlBreed2" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="Server" TargetControlID="ReqVal22"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label4" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB2" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl23" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                        ControlToValidate="txtDOB2">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="Server" TargetControlID="ReqVAl23"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegDOB2" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                        ControlToValidate="txtDOB2" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="Server" TargetControlID="RegDOB2"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:CustomValidator runat="server" ID="custYear2" ValidationGroup="valReg_Basic"
                                        ControlToValidate="txtDOB2" Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear"
                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender52" TargetControlID="custYear2"
                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label5" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight2" runat="server" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
                                    <asp:RequiredFieldValidator ID="ReqVAl24" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                        ControlToValidate="txtPetWeight2">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="Server" TargetControlID="ReqVAl24"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegWeight2" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                        ControlToValidate="txtPetWeight2" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="Server" TargetControlID="RegWeight2"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label6" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength2" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
                                    <asp:RequiredFieldValidator ID="ReqVAl25" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                        ControlToValidate="txtPetLength2">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="Server" TargetControlID="ReqVAl25"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReqLength2" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                        ControlToValidate="txtPetLength2" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="Server" TargetControlID="ReqLength2"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <%--    For Pet 3--%>
                            <div class="divfirstpetinfo" id="dvPet3" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete3" Height="20" Width="20" runat="server" ImageUrl="~/MobileWeb/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete3_Click" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="PetID3" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="Label7" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType3" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType3_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label8" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName3" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl31" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                        ControlToValidate="txtPetName3">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="Server" TargetControlID="ReqVAl31"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label9" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed3" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl32" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                        ControlToValidate="ddlBreed3" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="Server" TargetControlID="ReqVAl32"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label10" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB3" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAL33" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                        ControlToValidate="txtDOB3">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="Server" TargetControlID="ReqVAL33"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegDOB3" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                        ControlToValidate="txtDOB3" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="Server" TargetControlID="RegDOB3"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:CustomValidator runat="server" ID="custYear3" ValidationGroup="valReg_Basic"
                                        ControlToValidate="txtDOB3" Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear"
                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender53" TargetControlID="custYear3"
                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label11" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight3" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
                                    <asp:RequiredFieldValidator ID="ReqVAl34" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                        ControlToValidate="txtPetWeight3">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="Server" TargetControlID="ReqVAl34"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegWeight3" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                        ControlToValidate="txtPetWeight3" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="Server" TargetControlID="RegWeight3"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label12" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength3" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
                                    <asp:RequiredFieldValidator ID="ReqVAL35" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                        ControlToValidate="txtPetLength3">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="Server" TargetControlID="ReqVAL35"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReqLength3" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                        ControlToValidate="txtPetLength3" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="Server" TargetControlID="ReqLength3"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <%--    For Pet 4--%>
                            <div class="divfirstpetinfo" id="dvPet4" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete4" Height="20" Width="20" runat="server" ImageUrl="~/MobileWeb/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete4_Click" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="PetID4" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="Label13" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType4" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType4_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label14" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName4" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl41" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                        ControlToValidate="txtPetName4">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="Server" TargetControlID="ReqVAl41"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label15" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed4" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl42" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                        ControlToValidate="ddlBreed4" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="Server" TargetControlID="ReqVAl42"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label16" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB4" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAL43" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                        ControlToValidate="txtDOB4">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender26" runat="Server" TargetControlID="ReqVAL43"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegDOB4" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                        ControlToValidate="txtDOB4" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender27" runat="Server" TargetControlID="RegDOB4"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:CustomValidator runat="server" ID="custYear4" ValidationGroup="valReg_Basic"
                                        ControlToValidate="txtDOB4" Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear"
                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender54" TargetControlID="custYear4"
                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label17" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight4" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
                                    <asp:RequiredFieldValidator ID="ReqVAl44" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                        ControlToValidate="txtPetWeight4">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender28" runat="Server" TargetControlID="ReqVAl44"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegWeight4" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                        ControlToValidate="txtPetWeight4" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender29" runat="Server" TargetControlID="RegWeight4"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label18" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength4" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
                                    <asp:RequiredFieldValidator ID="ReqVAL45" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                        ControlToValidate="txtPetLength4">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender30" runat="Server" TargetControlID="ReqVAL45"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReqLength4" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                        ControlToValidate="txtPetLength4" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender31" runat="Server" TargetControlID="ReqLength4"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <%--    For Pet 5--%>
                            <div class="divfirstpetinfo" id="dvPet5" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete5" Height="20" Width="20" runat="server" ImageUrl="~/MobileWeb/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete5_Click" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="PetID5" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="Label19" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType5" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType5_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label20" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName5" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl51" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                        ControlToValidate="txtPetName5">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender32" runat="Server" TargetControlID="ReqVAl51"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label21" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed5" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl52" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                        ControlToValidate="ddlBreed5" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="Server" TargetControlID="ReqVAl52"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label22" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB5" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAL53" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                        ControlToValidate="txtDOB5">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender34" runat="Server" TargetControlID="ReqVAL53"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegDOB5" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                        ControlToValidate="txtDOB5" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender35" runat="Server" TargetControlID="RegDOB5"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:CustomValidator runat="server" ID="custYear5" ValidationGroup="valReg_Basic"
                                        ControlToValidate="txtDOB5" Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear"
                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender55" TargetControlID="custYear5"
                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label23" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight5" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
                                    <asp:RequiredFieldValidator ID="ReqVAl54" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                        ControlToValidate="txtPetWeight5">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender36" runat="Server" TargetControlID="ReqVAl54"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegWeight5" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                        ControlToValidate="txtPetWeight5" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender37" runat="Server" TargetControlID="RegWeight5"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label24" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength5" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
                                    <asp:RequiredFieldValidator ID="ReqVAL55" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                        ControlToValidate="txtPetLength5">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender38" runat="Server" TargetControlID="ReqVAL55"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReqLength5" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                        ControlToValidate="txtPetLength5" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender39" runat="Server" TargetControlID="ReqLength5"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <%--    For Pet 6--%>
                            <div class="divfirstpetinfo" id="dvPet6" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete6" Height="20" Width="20" runat="server" ImageUrl="~/MobileWeb/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete6_Click" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="PetID6" runat="server" Text="0" Visible="false"></asp:Label>
                                    <asp:Label ID="Label25" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                                    <asp:DropDownList ID="ddlPetType6" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPetType5_OnSelectedIndexChanged">
                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label26" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                                    <asp:TextBox ID="txtPetName6" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl61" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                        ControlToValidate="txtPetName6">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender40" runat="Server" TargetControlID="ReqVAl61"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label27" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed6" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList><br />
                                    <asp:RequiredFieldValidator ID="ReqVAl62" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                        ControlToValidate="ddlBreed6" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender41" runat="Server" TargetControlID="ReqVAl62"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label28" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB6" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="ReqVAL63" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                        ControlToValidate="txtDOB6">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender43" runat="Server" TargetControlID="ReqVAL63"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegDOB6" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                        ControlToValidate="txtDOB6" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender44" runat="Server" TargetControlID="RegDOB6"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:CustomValidator runat="server" ID="custYear6" ValidationGroup="valReg_Basic"
                                        ControlToValidate="txtDOB6" Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear"
                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender56" TargetControlID="custYear6"
                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label29" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight6" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
                                    <asp:RequiredFieldValidator ID="ReqVAl64" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                        ControlToValidate="txtPetWeight6">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender45" runat="Server" TargetControlID="ReqVAl64"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="RegWeight6" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                        ControlToValidate="txtPetWeight6" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender46" runat="Server" TargetControlID="RegWeight6"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label30" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox onkeypress="return decimalIntegerNumbers(event,this)" ID="txtPetLength6" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
                                    <asp:RequiredFieldValidator ID="ReqVAL65" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                        ControlToValidate="txtPetLength6">  
                                    </asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender47" runat="Server" TargetControlID="ReqVAL65"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                    <asp:RegularExpressionValidator ID="ReqLength6" runat="server" ValidationGroup="valReg_Basic"
                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                        ControlToValidate="txtPetLength6" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender48" runat="Server" TargetControlID="ReqLength6"
                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                    </cc1:ValidatorCalloutExtender>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="imgDelete1" />
                            <asp:AsyncPostBackTrigger ControlID="imgDelete2" />
                            <asp:AsyncPostBackTrigger ControlID="imgDelete3" />
                            <asp:AsyncPostBackTrigger ControlID="imgDelete4" />
                            <asp:AsyncPostBackTrigger ControlID="imgDelete5" />
                            <asp:AsyncPostBackTrigger ControlID="imgDelete6" />
                            <asp:AsyncPostBackTrigger ControlID="imgAddmore" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
                    <asp:Button ID="imgAddmore" CssClass="button" runat="server" Text="Add More Pets" ValidationGroup="valReg_Basic" CausesValidation="true" OnClick="imgAddmore_Click" /><br />
                    <br />
                    <asp:Button runat="server" CausesValidation="true" ValidationGroup="valReg_Basic" ID="IdNext" CssClass="button" Text="Update" OnClick="IdNext_Click" />&nbsp;&nbsp;
                    <asp:Button CausesValidation="true" ValidationGroup="valReg_Basic" runat="server" ID="IdReset" CssClass="button" OnClientClick="return validate();" OnClick="IdReset_Click" Text="Update &amp; Set Appointment" />
                </div>

                <div class="divMyAccount">
                    <asp:Label ID="lblFutureApp" runat="server" Text="Future Appointments" Font-Bold="true" Font-Size="Medium" ForeColor="#009ddc"> </asp:Label>
                </div>
                <div class="table-responsive">
                    <table border="0" class="table">
                        <tr>
                            <td>
                                <asp:Label ID="lblfutureinfo" runat="server" Text="No Future appointments are available." Font-Bold="true" Visible="false"> </asp:Label>
                                <asp:UpdatePanel runat="server" ID="upCalData" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                    <ContentTemplate>
                                        <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="UserAppID" AutoGenerateColumns="False"
                                            AllowSorting="True" AllowPaging="true" OnPageIndexChanging="GrdUsers_PageIndexChanging"
                                            OnRowDataBound="GrdUsers_RowDataBound" OnDataBound="GrdUsers_DataBound" PageSize="5"
                                            CellPadding="0" GridLines="Vertical" HeaderStyle-CssClass="headerStyle"
                                            CssClass="table table-hover" AlternatingRowStyle-CssClass="altGridStyle"
                                            OnSorting="GrdUsers_Sorting" OnRowCreated="GrdUsers_RowCreated" Width="100%"
                                            OnRowDeleting="GrdUsers_RowDeleting">
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
                                            <RowStyle HorizontalAlign="Left" />
                                            <PagerStyle CssClass="gridPager" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                    <ItemStyle CssClass="itemstyle" />
                                                    <HeaderStyle CssClass="headerStyle" Width="4%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                        <asp:Label ID="lblApptDate" runat="server" Text='<%# Eval("Date")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Time">
                                                    <ItemStyle CssClass="itemstyle" Width="10%" />
                                                    <HeaderStyle CssClass="headerStyle" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltxtExpectedPetTime" runat="server" Text='<%# Bind("T","{0:hh:mm tt}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="Appointment Detail String">
                                                    <ItemStyle CssClass="itemstyle" Width="40%" />
                                                    <HeaderStyle CssClass="headerStyle" Width="150px" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("String")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemStyle CssClass="itemstyle" Width="10%" />
                                                    <HeaderStyle CssClass="headerStyle" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblConfirm" runat="server" Text='<%# Bind("Confirmed") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment">
                                                    <ItemStyle CssClass="itemstyle" Width="12%" />
                                                    <HeaderStyle CssClass="headerStyle" />
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HypName" runat="server" NavigateUrl='<%#"~/Mobileweb/PaymentInfo.aspx?"+EncryptQueryString(string.Format("PayAppID={0}&Type={1}",Eval("UserAppID"),Eval("Type"))) %>'
                                                            Text="Make Payment"></asp:HyperLink>
                                                        <asp:Label ID="lblPaidStatus" runat="server" Text='<%# Bind("PaymentStatus")%>' Visible="true"></asp:Label>
                                                        <asp:Label ID="lblPaymentAmount" runat="server" Visible='<%#(Eval("PaymentStatus").ToString()=="Pending"?false:true) %>'>( $ <%#String.Format("{0:0.00}",Eval("PaymentAmount"))%>)</asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" Wrap="false" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDeleteApp" runat="server" ImageUrl="~/MobileWeb/images/delete.png"
                                                            CommandName="Delete" ToolTip="Delete App" OnClientClick="return confirm('Are you sure you want to delete this ?');"
                                                            CommandArgument='<%# Bind("UserAppID") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headerStyle1" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type" Visible="false">
                                                    <ItemStyle CssClass="itemstyle" HorizontalAlign="left" Wrap="false" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblType" runat="server" Text='<%# Bind("Type")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headerStyle1" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GrdUsers" EventName="PageIndexChanging" />
                                        <asp:AsyncPostBackTrigger ControlID="GrdUsers" EventName="RowDataBound" />
                                        <asp:AsyncPostBackTrigger ControlID="GrdUsers" EventName="DataBound" />
                                        <asp:AsyncPostBackTrigger ControlID="GrdUsers" EventName="Sorting" />
                                        <asp:AsyncPostBackTrigger ControlID="GrdUsers" EventName="RowCreated" />
                                        <asp:AsyncPostBackTrigger ControlID="GrdUsers" EventName="RowDeleting" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="divMyAccount">
                    <asp:Label ID="Label36" runat="server" Text="Appointment History" Font-Bold="true" Font-Size="Medium" ForeColor="#009ddc"> </asp:Label>
                </div>
                <div class="table-responsive">
                    <table border="0" class="table">
                        <tr>
                            <td>
                                <asp:Label ID="lblPastInfo" runat="server" Text="No history appointments are available." Font-Bold="true" Visible="false"> </asp:Label>
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView1" runat="server" DataKeyNames="AppointmentID" AutoGenerateColumns="False"
                                            AllowSorting="true" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound" PageSize="5"
                                            CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
                                            OnSorting="GridView1_Sorting" CssClass="table table-hover" AlternatingRowStyle-CssClass="altGridStyle" OnRowCreated="GridView1_RowCreated">
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
                                            <RowStyle HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                    <ItemStyle CssClass="itemstyle" />
                                                    <HeaderStyle CssClass="headerStyle" Width="1%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Start Time">
                                                    <ItemStyle CssClass="itemstyle" />
                                                    <HeaderStyle CssClass="headerStyle" Width="2%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltxtExpectedPetTime" runat="server" Text='<%# Bind("StartTime","{0:hh:mm tt}")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Appointment Detail String">
                                                    <ItemStyle CssClass="itemstyle" Width="9%" />
                                                    <HeaderStyle CssClass="headerStyle" Wrap="false" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAptETime" runat="server" Text='<%# Bind("AppointmentString")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemStyle CssClass="itemstyle" />
                                                    <HeaderStyle CssClass="headerStyle" Width="1%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblConfirm" runat="server" Text='<%# Bind("Confirmed") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Groomer">
                                                    <ItemStyle CssClass="itemstyle" />
                                                    <HeaderStyle CssClass="headerStyle" Width="9%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Cost">
                                                    <ItemStyle CssClass="itemstyle" />
                                                    <HeaderStyle CssClass="headerStyle" Width="3%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server">$ <%#String.Format("{0:0.00}",Eval("ExpectedTotalRevenue"))%></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanging" />
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="DataBound" />
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="Sorting" />
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCreated" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
