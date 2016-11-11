<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" Inherits="Registration_Full" Title="Fritzy's pet care pros : Register" CodeBehind="Registration_Full.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="Scripts/phone_validation.js"></script>
    <script type="text/javascript" language="javascript" src="Scripts/Validation.js"></script>
    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <script language="javascript">

        function ValidateLength(source, arguments) {

            if ((document.getElementById('<%=txtPasswordReg.ClientID %>').value.length < 6) || (document.getElementById('<%=txtPasswordReg.ClientID %>').value.length > 15)) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }
        }
        function ValidateConfirm(source, arguments) {

            if (document.getElementById('<%=txtPasswordReg.ClientID %>').value == document.getElementById('<%=txtConPasswordReg.ClientID %>').value) {
                arguments.IsValid = true;
            }
            else {
                arguments.IsValid = false;
            }
        }


        function Openwin() {

            window.open("WhatsNew.aspx", "Window1", "menubar=no,width=500,height=410,toolbar=no");

        }
        function ValYear(source, args) {
            var dteNow = new Date();
            var intYear = dteNow.getFullYear()

            if (args.Value > intYear)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
        function SetErrorMessage() {

            document.getElementById("ctl00_ContentPlaceHolder1_VCE4_popupTable").style.display = "none";


            return true;
        }

        function SetErrorMessage() {
            document.getElementById('<%=divCall.ClientID %>').style.display = "None";
      }
      function ShowErrorMessage() {
          document.getElementById('<%=divCall.ClientID %>').style.display = "Block";
     }
    </script>


    <div id="mainPlaceholder">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="regMain">
                        <!-- reg main start here -->
                        <div id="regTopContent">
                            <!-- reg top start here -->
                            <div id="regLeftTop">
                                <asp:Literal ID="litContent" runat="server"></asp:Literal>

                            </div>
                            <div id="regRightTop">
                                <asp:Image ID="regrightimg" ImageUrl="~/Images/regRightImg.jpg" runat="server" />
                            </div>
                        </div>
                        <!-- reg top end here -->
                        <div id="regTitle">
                            <asp:Image ID="ImgTitle" ImageUrl="~/Images/regTitle.jpg" runat="server" />
                        </div>
                        <div class="regForm">
                            <div class="regFormTop">
                            </div>
                            <div class="regFormMid">
                                <div class="regestrationForm" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ContentPlaceHolder1_IdSubmit')">
                                    <asp:Label ID="lblCaptchaError" runat="server" Visible="false" ForeColor="red"></asp:Label>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="YourinfoTitle" ImageUrl="~/Images/yourinfotitle.jpg" runat="server" /></td>
                                        </tr>
                                    </table>
                                    <%--Your information region start--%>
                                    <table cellspacing="4">
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Name <span>*</span></label></td>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic" MaxLength="20"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE1" runat="server"
                                                    TargetControlID="txtFirstName"
                                                    WatermarkText="First Name"
                                                    WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqFirstName" ControlToValidate="txtFirstName"
                                                    ErrorMessage="<b>Required Field Missing</b><br />First name is required."
                                                    Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="VCE1" TargetControlID="ReqFirstName"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastName" CssClass="regTextField" runat="server" MaxLength="20"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                                    TargetControlID="txtLastName"
                                                    WatermarkText="Last Name"
                                                    WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqLastName" ControlToValidate="txtLastName"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Last name is required."
                                                    Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="ReqLastName"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Address <span>*</span></label></td>
                                            <td>
                                                <asp:TextBox ID="txtStreet" CssClass="regTextField" runat="server" MaxLength="50"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE3" runat="server"
                                                    TargetControlID="txtStreet"
                                                    WatermarkText="Street"
                                                    WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator
                                                    ID="ReqValStreet"
                                                    ControlToValidate="txtStreet"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Street name is required."
                                                    ValidationGroup="valReg_Basic"
                                                    Display="None" runat="server" SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>

                                                <cc1:ValidatorCalloutExtender
                                                    ID="VCEPet2"
                                                    TargetControlID="ReqValStreet"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtCity" CssClass="regTextFldCity" runat="server" MaxLength="20"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TBWE4" runat="server"
                                                                TargetControlID="txtCity"
                                                                WatermarkText="City"
                                                                WatermarkCssClass="regTextFldCity1" />
                                                            <asp:RequiredFieldValidator
                                                                ID="ReqValCity"
                                                                ControlToValidate="txtCity"
                                                                ErrorMessage="<b>Required Field Missing</b><br />City name is required."
                                                                ValidationGroup="valReg_Basic"
                                                                Display="None" runat="server" SetFocusOnError="true">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender
                                                                ID="ValidatorCalloutExtender2"
                                                                TargetControlID="ReqValCity"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        </td>
                                                        <td>


                                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="regddlField">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator1"
                                                                Text="State"
                                                                InitialValue="0"
                                                                ControlToValidate="ddlState"
                                                                ErrorMessage="<b>Required Field Missing</b><br />Please select state"
                                                                Display="none"
                                                                ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator1"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtZip" CssClass="regTextFldzip" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="5"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TBWE6" runat="server"
                                                                TargetControlID="txtZip"
                                                                WatermarkText="Zip"
                                                                WatermarkCssClass="regTextFldzip1" />
                                                            <asp:RequiredFieldValidator
                                                                ID="ReqValZip"
                                                                ControlToValidate="txtZip"
                                                                ErrorMessage="<b>Required Field Missing</b><br />Zipcode is required."
                                                                ValidationGroup="valReg_Basic"
                                                                Display="None" runat="server" SetFocusOnError="true">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender
                                                                ID="ValidatorCalloutExtender4"
                                                                TargetControlID="ReqValZip"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />

                                                            <asp:RegularExpressionValidator ID="RegValZip" runat="server" Display="None"
                                                                ErrorMessage="<b>Required Field Missing</b><br />Please enter correct zipcode ." ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" ControlToValidate="txtZip" ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
                                                            <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender49" TargetControlID="RegValZip"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Phone <span>*</span></label></td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" CssClass="regTextField" runat="server" MaxLength="15" onkeydown="javascript:backspacerDOWN(this,event);"
                                                    onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                                                    TargetControlID="txtPhone"
                                                    WatermarkText="Primary Phone*"
                                                    WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator
                                                    ID="ReqVAlPhone"
                                                    ControlToValidate="txtPhone"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Phone is required."
                                                    ValidationGroup="valReg_Basic"
                                                    Display="None" runat="server" SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender
                                                    ID="ValidatorCalloutExtender48"
                                                    TargetControlID="ReqVAlPhone"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />

                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAltMobile" CssClass="regTextField" runat="server" MaxLength="15" onkeydown="javascript:backspacerDOWN(this,event);"
                                                    onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                                                    TargetControlID="txtAltMobile"
                                                    WatermarkText="Mobile Number"
                                                    WatermarkCssClass="regTextField1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Alternate Contact</label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtAltContact" CssClass="regTextField" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" runat="server" MaxLength="50"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Alternate Address</label></td>
                                            <td>
                                                <asp:TextBox ID="txtAltStreet" CssClass="regTextField" runat="server" MaxLength="50"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server"
                                                    TargetControlID="txtAltStreet"
                                                    WatermarkText="Street"
                                                    WatermarkCssClass="regTextField1" />
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtAltCity" CssClass="regTextFldCity" runat="server" MaxLength="20"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server"
                                                                TargetControlID="txtAltCity"
                                                                WatermarkText="City"
                                                                WatermarkCssClass="regTextFldCity1" />
                                                        </td>
                                                        <td>

                                                            <asp:DropDownList ID="ddlState1" runat="server" CssClass="regddlField">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAltZip" CssClass="regTextFldzip" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="5"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server"
                                                                TargetControlID="txtAltZip"
                                                                WatermarkText="Zip"
                                                                WatermarkCssClass="regTextFldzip1" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Alternate Phone</label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtAltPhone" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" CssClass="regTextField" runat="server" MaxLength="15"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Referral Source<span>*</span></label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlReferralSource" CssClass="regddlFieldbig" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator
                                                    ID="Reqref"
                                                    Text="Selcect One"
                                                    InitialValue="0"
                                                    ControlToValidate="ddlReferralSource"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Referral source is required"
                                                    Display="none"
                                                    ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender42" TargetControlID="Reqref"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Preferred Groomer</label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtGroomer" CssClass="regTextField" runat="server" MaxLength="30"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                    </table>
                                    <%--Your information region End--%>
                                    <%--Pet information region start--%>

                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="Yourpetinfo" runat="server" ImageUrl="~/Images/petinfotitle.jpg" /></td>
                                        </tr>
                                    </table>

                                    <table cellspacing="8">
                                        <tbody>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <th>Pet</th>
                                                <th>Pet Name</th>
                                                <th>Breed</th>
                                                <th>Birth Year</th>
                                                <th>Weight</th>
                                                <th>Fur Length</th>
                                                <th style="background: none; border: none;"></th>
                                            </tr>
                                            <tr id="p1" runat="server">
                                                <td>1.</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPetType1" runat="server" CssClass="regddlField" AutoPostBack="true" OnSelectedIndexChanged="ddlPetType1_SelectedIndexChanged">
                                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetName1" runat="server" MaxLength="20" CssClass="regTextFldpetname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVal1" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                        ControlToValidate="txtPetName1">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="VCEPet1" runat="Server" TargetControlID="ReqVal1"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBreed1" runat="server" CssClass="regddlFieldbig">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="ReqVAl2" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                        ControlToValidate="ddlBreed1" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="Server" TargetControlID="ReqVal2"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetDOB1" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="regTextFldbyear"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVal3" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                        ControlToValidate="txtPetDOB1">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="VCEPet3" runat="Server" TargetControlID="ReqVal3"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="ReqPet4" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year ."
                                                        ControlToValidate="txtPetDOB1" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="Server" TargetControlID="ReqPet4"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>

                                                    <asp:CustomValidator runat="server" ID="custYear1" ValidationGroup="valPet"
                                                        ControlToValidate="txtPetDOB1" Display="None" SetFocusOnError="true"
                                                        ClientValidationFunction="ValYear"
                                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender50" TargetControlID="custYear1"
                                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetWeight1" runat="server" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldstate"></asp:TextBox>&nbsp;lbs
                                                <asp:RequiredFieldValidator ID="Reqval4" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Weight is required."
                                                    ControlToValidate="txtPetWeight1">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="VCEPet4" runat="Server" TargetControlID="Reqval4"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="ReqPet6" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                        ControlToValidate="txtPetWeight1" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="VCEPet5" runat="Server" TargetControlID="ReqPet6"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetLength1" runat="server" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldflength"></asp:TextBox>&nbsp;inches
                                                <asp:RequiredFieldValidator ID="Reqval7" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Length is required."
                                                    ControlToValidate="txtPetLength1">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="VCEPet6" runat="Server" TargetControlID="Reqval7"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="Reqval8" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                        ControlToValidate="txtPetLength1" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="VCEPet7" runat="Server" TargetControlID="Reqval8"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgDelete1" runat="server" ImageUrl="~/Images/deleteicon.gif" ToolTip="Delete" Visible="false" /></td>
                                            </tr>
                                            <tr id="p2" runat="server">
                                                <td>2.</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPetType2" runat="server" CssClass="regddlField" AutoPostBack="true" OnSelectedIndexChanged="ddlPetType2_SelectedIndexChanged">
                                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetName2" runat="server" MaxLength="50" CssClass="regTextFldpetname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAl21" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                        ControlToValidate="txtPetName2">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="Server" TargetControlID="ReqVAl21"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBreed2" runat="server" CssClass="regddlFieldbig">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="ReqVAl22" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                        ControlToValidate="ddlBreed2" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="Server" TargetControlID="ReqVal22"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDOB2" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);" CssClass="regTextFldbyear"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAl23" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                        ControlToValidate="txtDOB2">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="Server" TargetControlID="ReqVAl23"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegDOB2" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                        ControlToValidate="txtDOB2" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="Server" TargetControlID="RegDOB2"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>

                                                    <asp:CustomValidator runat="server" ID="custYear2" ValidationGroup="valPet"
                                                        ControlToValidate="txtDOB2" Display="None" SetFocusOnError="true"
                                                        ClientValidationFunction="ValYear"
                                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender51" TargetControlID="custYear2"
                                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />


                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetWeight2" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="5" CssClass="regTextFldstate"></asp:TextBox>&nbsp;lbs
                                                <asp:RequiredFieldValidator ID="ReqVAl24" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                    ControlToValidate="txtPetWeight2">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="Server" TargetControlID="ReqVAl24"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegWeight2" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                        ControlToValidate="txtPetWeight2" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="Server" TargetControlID="RegWeight2"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetLength2" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldflength"></asp:TextBox>&nbsp;inches
                                                <asp:RequiredFieldValidator ID="ReqVAl25" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                    ControlToValidate="txtPetLength2">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="Server" TargetControlID="ReqVAl25"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="ReqLength2" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                        ControlToValidate="txtPetLength2" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="Server" TargetControlID="ReqLength2"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgDelete2" runat="server" ImageUrl="~/Images/deleteicon.gif" ToolTip="Delete" Visible="false" /></td>
                                            </tr>
                                            <tr id="p3" runat="server">
                                                <td>3.</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPetType3" runat="server" CssClass="regddlField" AutoPostBack="true" OnSelectedIndexChanged="ddlPetType3_SelectedIndexChanged">
                                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetName3" runat="server" MaxLength="50" CssClass="regTextFldpetname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAl31" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                        ControlToValidate="txtPetName3">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="Server" TargetControlID="ReqVAl31"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBreed3" runat="server" CssClass="regddlFieldbig">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="ReqVAl32" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                        ControlToValidate="ddlBreed3" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="Server" TargetControlID="ReqVAl32"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDOB3" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="regTextFldbyear"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAL33" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                        ControlToValidate="txtDOB3">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="Server" TargetControlID="ReqVAL33"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegDOB3" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                        ControlToValidate="txtDOB3" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="Server" TargetControlID="RegDOB3"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>

                                                    <asp:CustomValidator runat="server" ID="custYear3" ValidationGroup="valPet"
                                                        ControlToValidate="txtDOB3" Display="None" SetFocusOnError="true"
                                                        ClientValidationFunction="ValYear"
                                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender52" TargetControlID="custYear3"
                                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetWeight3" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="5" CssClass="regTextFldstate"></asp:TextBox>&nbsp;lbs
                                                <asp:RequiredFieldValidator ID="ReqVAl34" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                    ControlToValidate="txtPetWeight3">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="Server" TargetControlID="ReqVAl34"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegWeight3" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                        ControlToValidate="txtPetWeight3" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="Server" TargetControlID="RegWeight3"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetLength3" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="5" CssClass="regTextFldflength"></asp:TextBox>&nbsp;inches
                                                <asp:RequiredFieldValidator ID="ReqVAL35" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                    ControlToValidate="txtPetLength3">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="Server" TargetControlID="ReqVAL35"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="ReqLength3" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                        ControlToValidate="txtPetLength3" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="Server" TargetControlID="ReqLength3"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgDelete3" runat="server" ImageUrl="~/Images/deleteicon.gif" ToolTip="Delete" Visible="false" /></td>
                                            </tr>
                                            <tr id="p4" runat="server">
                                                <td>4.</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPetType4" runat="server" CssClass="regddlField" AutoPostBack="true" OnSelectedIndexChanged="ddlPetType4_SelectedIndexChanged">
                                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetName4" runat="server" MaxLength="50" CssClass="regTextFldpetname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAl41" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                        ControlToValidate="txtPetName4">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="Server" TargetControlID="ReqVAl41"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBreed4" runat="server" CssClass="regddlFieldbig">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="ReqVAl42" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                        ControlToValidate="ddlBreed4" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="Server" TargetControlID="ReqVAl42"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDOB4" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="regTextFldbyear"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAL43" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                        ControlToValidate="txtDOB4">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="Server" TargetControlID="ReqVAL43"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegDOB4" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                        ControlToValidate="txtDOB4" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender26" runat="Server" TargetControlID="RegDOB4"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>

                                                    <asp:CustomValidator runat="server" ID="custYear4" ValidationGroup="valPet"
                                                        ControlToValidate="txtDOB4" Display="None" SetFocusOnError="true"
                                                        ClientValidationFunction="ValYear"
                                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender53" TargetControlID="custYear4"
                                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />


                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetWeight4" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="5" CssClass="regTextFldstate"></asp:TextBox>&nbsp;lbs
                                                <asp:RequiredFieldValidator ID="ReqVAl44" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                    ControlToValidate="txtPetWeight4">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender27" runat="Server" TargetControlID="ReqVAl44"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegWeight4" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                        ControlToValidate="txtPetWeight4" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender28" runat="Server" TargetControlID="RegWeight4"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetLength4" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldflength"></asp:TextBox>&nbsp;inches
                                                <asp:RequiredFieldValidator ID="ReqVAL45" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                    ControlToValidate="txtPetLength4">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender29" runat="Server" TargetControlID="ReqVAL45"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="ReqLength4" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                        ControlToValidate="txtPetLength4" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender30" runat="Server" TargetControlID="ReqLength4"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgDelete4" runat="server" ImageUrl="~/Images/deleteicon.gif" ToolTip="Delete" Visible="false" /></td>
                                            </tr>
                                            <tr id="p5" runat="server">
                                                <td>5.</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPetType5" runat="server" CssClass="regddlField" AutoPostBack="true" OnSelectedIndexChanged="ddlPetType5_SelectedIndexChanged">
                                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetName5" runat="server" MaxLength="50" CssClass="regTextFldpetname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAl51" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                        ControlToValidate="txtPetName5">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender31" runat="Server" TargetControlID="ReqVAl51"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBreed5" runat="server" CssClass="regddlFieldbig">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="ReqVAl52" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                        ControlToValidate="ddlBreed5" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender32" runat="Server" TargetControlID="ReqVAl52"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDOB5" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="regTextFldbyear"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAL53" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                        ControlToValidate="txtDOB5">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="Server" TargetControlID="ReqVAL53"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegDOB5" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                        ControlToValidate="txtDOB5" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender34" runat="Server" TargetControlID="RegDOB5"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:CustomValidator runat="server" ID="custYear5" ValidationGroup="valPet"
                                                        ControlToValidate="txtDOB5" Display="None" SetFocusOnError="true"
                                                        ClientValidationFunction="ValYear"
                                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender54" TargetControlID="custYear5"
                                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />


                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetWeight5" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldstate"></asp:TextBox>&nbsp;lbs
                                                <asp:RequiredFieldValidator ID="ReqVAl54" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                    ControlToValidate="txtPetWeight5">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender35" runat="Server" TargetControlID="ReqVAl54"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegWeight5" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                        ControlToValidate="txtPetWeight5" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender36" runat="Server" TargetControlID="RegWeight5"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetLength5" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="5" CssClass="regTextFldflength"></asp:TextBox>&nbsp;inches
                                                <asp:RequiredFieldValidator ID="ReqVAL55" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                    ControlToValidate="txtPetLength5">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender37" runat="Server" TargetControlID="ReqVAL55"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="ReqLength5" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                        ControlToValidate="txtPetLength5" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender38" runat="Server" TargetControlID="ReqLength5"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgDelete5" runat="server" ImageUrl="~/Images/deleteicon.gif" ToolTip="Delete" Visible="false" /></td>

                                            </tr>
                                            <tr id="p6" runat="server">
                                                <td>6.</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPetType6" runat="server" CssClass="regddlField" AutoPostBack="true" OnSelectedIndexChanged="ddlPetType6_SelectedIndexChanged">
                                                        <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetName6" runat="server" MaxLength="50" CssClass="regTextFldpetname"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAl61" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                        ControlToValidate="txtPetName6">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender39" runat="Server" TargetControlID="ReqVAl61"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBreed6" runat="server" CssClass="regddlFieldbig">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="ReqVAl62" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                        ControlToValidate="ddlBreed6" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender40" runat="Server" TargetControlID="ReqVAl62"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDOB6" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="regTextFldbyear"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqVAL63" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                        ControlToValidate="txtDOB6">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender41" runat="Server" TargetControlID="ReqVAL63"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegDOB6" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                        ControlToValidate="txtDOB6" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender43" runat="Server" TargetControlID="RegDOB6"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>

                                                    <asp:CustomValidator runat="server" ID="custYear6" ValidationGroup="valPet"
                                                        ControlToValidate="txtDOB6" Display="None" SetFocusOnError="true"
                                                        ClientValidationFunction="ValYear"
                                                        ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender55" TargetControlID="custYear6"
                                                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />


                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetWeight6" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5" CssClass="regTextFldstate"></asp:TextBox>&nbsp;lbs
                                                <asp:RequiredFieldValidator ID="ReqVAl64" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                    ControlToValidate="txtPetWeight6">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender44" runat="Server" TargetControlID="ReqVAl64"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="RegWeight6" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                        ControlToValidate="txtPetWeight6" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender45" runat="Server" TargetControlID="RegWeight6"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPetLength6" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldflength"></asp:TextBox>&nbsp;inches
                                                <asp:RequiredFieldValidator ID="ReqVAL65" runat="server" ValidationGroup="valPet"
                                                    SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                    ControlToValidate="txtPetLength6">  
                                                </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender46" runat="Server" TargetControlID="ReqVAL65"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                    <asp:RegularExpressionValidator ID="ReqLength6" runat="server" ValidationGroup="valPet"
                                                        SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                        ControlToValidate="txtPetLength6" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender47" runat="Server" TargetControlID="ReqLength6"
                                                        Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                    </cc1:ValidatorCalloutExtender>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgDelete6" runat="server" ImageUrl="~/Images/deleteicon.gif" ToolTip="Delete" Visible="false" /></td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td colspan="5">
                                                    <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
                                                    <asp:ImageButton ID="imgAddmore" OnClick="imgAddmore_Click" runat="server" ImageUrl="~/Images/addMorepetButton.jpg"
                                                        ValidationGroup="valPet" CausesValidation="true"></asp:ImageButton></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="ImgUserName" runat="server" ImageUrl="~/Images/creatusertitle.jpg"></asp:Image></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <%--Pet information region End--%>
                                    <%--Registration information region Starts--%>
                                    <table>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Email<span>*</span></label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtEmailReg" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE7" runat="server"
                                                    TargetControlID="txtEmailReg"
                                                    WatermarkText="Use as a User Name"
                                                    WatermarkCssClass="regTextField1" />

                                                <asp:RequiredFieldValidator ID="ReqEmailReg" runat="server"
                                                    ControlToValidate="txtEmailReg" Display="None" ValidationGroup="valReg_Basic"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Email is required." SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>

                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE2" TargetControlID="ReqEmailReg"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />

                                                <asp:RegularExpressionValidator ID="ReqEmailReg1" runat="server" Display="None"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email." ValidationGroup="valReg_Basic"
                                                    SetFocusOnError="true" ControlToValidate="txtEmailReg" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>

                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE3" TargetControlID="ReqEmailReg1"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>password<span>*</span></label></td>
                                            <td>
                                                <asp:TextBox ID="txtPasswordReg" CssClass="regTextField" TextMode="Password" runat="server" MaxLength="15" ValidationGroup="valReg_Basic" OnFocus="return ShowErrorMessage();" OnKeypress="return SetErrorMessage();"></asp:TextBox>

                                                <div id="divCall" runat="server">

                                                    <asp:RequiredFieldValidator ID="ReqPasswordReg" runat="server"
                                                        ControlToValidate="txtPasswordReg" Display="None" ValidationGroup="valReg_Basic"
                                                        ErrorMessage="<b>Required Field Missing</b><br />Password is required." SetFocusOnError="true">  
                                                    </asp:RequiredFieldValidator>

                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE4" TargetControlID="ReqPasswordReg"
                                                        HighlightCssClass="validatorCalloutHighlight" />

                                                    <asp:CustomValidator runat="server" ID="custPasswordLength" ValidationGroup="valReg_Basic"
                                                        ControlToValidate="txtPasswordReg" Display="None" SetFocusOnError="true"
                                                        ClientValidationFunction="ValidateLength"
                                                        ErrorMessage="Password length should be in the range of 6 to 15 characters." />

                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custPasswordLength"
                                                        HighlightCssClass="validatorCalloutHighlight" />

                                                </div>
                                            </td>

                                            <td valign="Top">
                                                <asp:Label ID="lblStrength" runat="server" Text="Password Strength: " CssClass="lblStrength"></asp:Label>

                                                <cc1:PasswordStrength runat="server" ID="PasswordStrength1"
                                                    TargetControlID="txtPasswordReg"
                                                    DisplayPosition="RightSide"
                                                    PreferredPasswordLength="15"
                                                    CalculationWeightings="25;25;15;35"
                                                    TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent"
                                                    StrengthIndicatorType="BarIndicator"
                                                    HelpHandlePosition="AboveLeft"
                                                    BarBorderCssClass="barIndicatorBorder"
                                                    StrengthStyles="barIndicator_poor; barIndicator_weak; barIndicator_good; barIndicator_strong; barIndicator_excellent"></cc1:PasswordStrength>

                                                <cc1:PasswordStrength runat="server" ID="PasswordStrength2"
                                                    TargetControlID="txtPasswordReg"
                                                    DisplayPosition="RightSide"
                                                    PreferredPasswordLength="15"
                                                    CalculationWeightings="25;25;15;35"
                                                    TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent"
                                                    StrengthIndicatorType="Text"
                                                    PrefixText=""
                                                    TextCssClass="strengthText"
                                                    HelpHandlePosition="AboveLeft"
                                                    BarBorderCssClass="barIndicatorBorder"
                                                    StrengthStyles="barIndicator_poor1; barIndicator_weak1; barIndicator_good1; barIndicator_strong1; barIndicator_excellent1"></cc1:PasswordStrength>

                                            </td>


                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Confirm Password<span>*</span></label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtConPasswordReg" TextMode="Password" CssClass="regTextField" runat="server" MaxLength="50" ValidationGroup="valReg_Basic"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ReqConPasswordReg" runat="server"
                                                    ControlToValidate="txtConPasswordReg" Display="None" ValidationGroup="valReg_Basic"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Confirm Password is required." SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>

                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE6" TargetControlID="ReqConPasswordReg"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />

                                                <asp:CustomValidator runat="server" ID="ValConfirmPass" ValidationGroup="valReg_Basic"
                                                    ControlToValidate="txtConPasswordReg" Display="None" SetFocusOnError="true"
                                                    ClientValidationFunction="ValidateConfirm"
                                                    ErrorMessage="Password and confirm password does not match" />

                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE7" TargetControlID="ValConfirmPass"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />

                                            </td>

                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td colspan="2">
                                                <asp:UpdatePanel ID="up1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:Image ID="imgCaptcha" runat="server" Height="60px" Width="182px" />
                                                        <asp:ImageButton ID="ImageButton1" CausesValidation="false" ToolTip="Refresh" ImageUrl="~/Images/refreshbutton.jpg"
                                                            runat="server" OnClick="ImageButton1_Click" />
                                                        &nbsp; Refresh the image
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="ImageButton1" />
                                                    </Triggers>
                                                </asp:UpdatePanel>


                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Confirmation Code<span>*</span></label></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtConfirmReg" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ReqConfirmReg" runat="server"
                                                    ControlToValidate="txtConfirmReg" Display="None" ValidationGroup="valReg_Basic"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Confirmation Code is required." SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>

                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE9" TargetControlID="ReqConfirmReg" PopupPosition="Right"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:CheckBox ID="chkRemember" runat="server" />Remember me 
                                <asp:HyperLink ID="IdWhat" runat="server" CssClass="whatsthislink" OnClick="return Openwin();">What's this?</asp:HyperLink>
                                                <br />
                                                <p>(Leave unchecked if this is a public computer)</p>
                                            </td>
                                        </tr>


                                    </table>
                                    <%--Registration information region End--%>

                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:ImageButton ID="IdSubmit" ImageUrl="~/Images/regSubmitBtn.jpg" runat="server" ValidationGroup="valReg_Basic" CausesValidation="true" OnClick="IdSubmit_Click" />
                                                <asp:ImageButton ID="IdReset" ImageUrl="~/Images/regResetbtn.jpg" runat="server" OnClick="IdReset_Click" />
                                            </td>
                                            <td align="right" style="padding-right: 10px;">
                                                <table>
                                                    <tr>
                                                        <td colspan="2" class="tdstylemend" align="left">Note:</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdstylemendtory" align="left">1.</td>
                                                        <td class="tdstylemendtory" align="left">
                                                            <span>*</span>&nbsp;required</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdstylemendtory" align="left">2.</td>
                                                        <td class="tdstylemendtory">6 Pets per Registration Maximum</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="regFormBoottom">
                            </div>
                        </div>
                    </div>
                    <!-- reg main end here -->
                </div>
                <!-- main content end here -->
                <div style="clear: both;">
                </div>
                <div id="mainBottomImg">
                </div>
            </div>
            <!-- wrapper end here -->
        </div>
    </div>
    <!-- main place holder end here -->
</asp:Content>
