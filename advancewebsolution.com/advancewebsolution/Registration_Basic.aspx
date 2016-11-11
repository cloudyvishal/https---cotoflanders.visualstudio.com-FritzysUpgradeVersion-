<%@ Page Language="C#" MasterPageFile="~/Main.master" EnableEventValidation="true"   AutoEventWireup="true" Inherits="Registration_Basic"  Title="Fritzy's pet care pros : Registration Basic" Codebehind="Registration_Basic.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Banner.ascx" TagName="Banner" TagPrefix="BN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="Scripts/Validation.js"></script>

    <script type="text/javascript" src="Scripts/phone_validation.js"></script>

    <script language="javascript" type="text/javascript">
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

        function ValidateDateOfBirth(source, arguments) {
            if (document.getElementById('<%=txtPetDOB1.ClientID %>').value == "") //document.getElementById('<%=txtConPasswordReg.ClientID %>').value)
            {
                arguments.IsValid = false;
            }
            else if (!RequiredYear(document.getElementById('<%=txtPetDOB1.ClientID %>').value)) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }

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
            document.getElementById('<%=divCall.ClientID %>').style.display = "None";
        }
        function ShowErrorMessage() {
            document.getElementById('<%=divCall.ClientID %>').style.display = "Block";
        }
    </script>

    <script type="text/javascript" language="javascript">
        function Openwin() {
            window.open("WhatsNew.aspx", "Window1", "menubar=no,width=500,height=410,toolbar=no,scrollbars=1");
        }
        function SetVAl() {
            alert("Ok");
        }
    </script>

    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <asp:HiddenField ID="hdnPetRow" runat="server" Value="1" />
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
                                <BN:Banner ID="Banner" runat="server" />
                            </div>
                            <div id="regRightTop">
                                <asp:Image ID="regrightimg" ImageUrl="~/Images/regRightImg.jpg" runat="server" /></div>
                        </div>
                        <!-- reg top end here -->
                        <div id="regTitle"><asp:Image ID="ImgTitle" ImageUrl="~/Images/regTitle.jpg" runat="server" /></div>
                        <div class="regBasicForm">
                            <div class="regFormTop">
                            </div>
                            <div class="regFormMid">
                                <div class="RegInfoDiv">
                                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="regFormBoottom">
                            </div>
                        </div>
                        <div class="regForm">
                            <div class="regFormTop"></div>
                            <div class="regFormMid">
                                <div class="regestrationForm" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ContentPlaceHolder1_IdSubmit')">
                                    <%--  Region User information Start --%>
                                    <asp:Label ID="lblCaptchaError" runat="server" Visible="false" ForeColor="red"></asp:Label>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="YourinfoTitle" ImageUrl="~/Images/yourinfotitle.jpg" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="4">
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Name <span>*</span></label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="regTextField" MaxLength="20" ValidationGroup="valReg_Basic"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender  ID="TBWE1" runat="server" TargetControlID="txtFirstName" WatermarkText="First Name" WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqFirstName" ControlToValidate="txtFirstName" ErrorMessage="<b>Required Field Missing</b><br />First name is required."
                                                    Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="VCE1" TargetControlID="ReqFirstName" HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopRight"
                                                    Enabled="true" runat="Server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastName" CssClass="regTextField" runat="server" MaxLength="20"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtLastName" WatermarkText="Last Name" WatermarkCssClass="regTextField1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label> Address</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStreet" CssClass="regTextField" runat="server" MaxLength="50"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE3" runat="server" TargetControlID="txtStreet"
                                                    WatermarkText="Street" WatermarkCssClass="regTextField1" />
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtCity" CssClass="regTextFldCity" runat="server" MaxLength="30"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TBWE4" runat="server" TargetControlID="txtCity"
                                                                WatermarkText="City" WatermarkCssClass="regTextFldCity1" />
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="regddlField">
                                                            </asp:DropDownList>
                                            
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtZip" onkeypress="return IntegerNumbers(event);" CssClass="regTextFldzip" runat="server" MaxLength="5"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE6" runat="server" TargetControlID="txtZip"
                                                    WatermarkText="Zip" WatermarkCssClass="regTextFldzip1" />
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Phone</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" CssClass="regTextField" runat="server" onkeydown="javascript:backspacerDOWN(this,event);"
                                                    onkeyup="javascript:backspacerUP(this,event);" MaxLength="15"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label> Referral Source<span>*</span></label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlReferralSource" CssClass="regddlFieldbig" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Reqref" Text="Selcect One" InitialValue="0" ControlToValidate="ddlReferralSource"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Referral source is required"
                                                    Display="none" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender42" TargetControlID="Reqref" 
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <%--  Region User information End  --%>
                                    <%--  Region Pet information Start --%>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="Yourpetinfo" runat="server" ImageUrl="~/Images/petinfotitle.jpg" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="up12" runat="server">
                                        <ContentTemplate>
                                            <table cellspacing="8">
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                     <th>
                                                        Pet Name
                                                    </th>
                                                    <th>
                                                        Pet
                                                    </th>                                                   
                                                    <th>
                                                        Breed
                                                    </th>
                                                    <th>
                                                        Birth Year
                                                    </th>
                                                    <th>
                                                        Weight
                                                    </th>
                                                    <th>
                                                        Fur Length
                                                    </th>
                                                    <th style="background: none; border: none;">
                                                    </th>
                                                </tr>
                                                <tr id="p1" runat="server">
                                                    <td>
                                                        1.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName1" CssClass="regTextFldpetname" runat="server" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVal1" ControlToValidate="txtPetName1" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet1" TargetControlID="ReqVal1" HighlightCssClass="validatorCalloutHighlight"
                                                            Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType1" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType1_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                   
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed1" CssClass="regddlFieldbig" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl2" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed1"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet2" TargetControlID="ReqVal2" HighlightCssClass="validatorCalloutHighlight"
                                                            Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetDOB1" onkeypress="return IntegerNumbers(event);" CssClass="regTextFldbyear" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVal3" ControlToValidate="txtPetDOB1" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet3" TargetControlID="ReqVal3" HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopRight"
                                                            Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqPet4" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year ."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetDOB1"
                                                            ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="ReqPet4" PopupPosition="TopRight"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear1" ValidationGroup="valPet" ControlToValidate="txtPetDOB1"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender43" TargetControlID="custYear1" PopupPosition="TopRight"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight1" onkeypress="return decimalIntegerNumbers(event,this)"  CssClass="regTextFldstate" runat="server" MaxLength="6"></asp:TextBox>&nbsp;lbs
                                                        <asp:RequiredFieldValidator ID="Reqval4" ControlToValidate="txtPetWeight1" ErrorMessage="<b>Required Field Missing</b><br />Weight is required."
                                                            ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet4" TargetControlID="Reqval4" HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopRight"
                                                            Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqPet6" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetWeight1"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="VCEPet5" TargetControlID="ReqPet6" PopupPosition="TopRight"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetLength1"  onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="regTextFldflength" runat="server"></asp:TextBox>&nbsp;inches
                                                        <asp:RequiredFieldValidator ID="Reqval7" ControlToValidate="txtPetLength1" ErrorMessage="<b>Required Field Missing</b><br />Length is required."
                                                            ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet6" TargetControlID="Reqval7" HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopRight"
                                                            Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="Reqval8" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetLength1"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="VCEPet7" TargetControlID="Reqval8" PopupPosition="TopRight"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete1" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr id="p2" runat="server">
                                                    <td>
                                                        2.
                                                    </td>
                                                      <td>
                                                        <asp:TextBox ID="txtPetName2" CssClass="regTextFldpetname" runat="server" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl21" ControlToValidate="txtPetName2" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" TargetControlID="ReqVAl21"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>

                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType2" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType2_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                  
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed2" CssClass="regddlFieldbig" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl22" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed2"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" TargetControlID="ReqVal22"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB2" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl23" ControlToValidate="txtDOB2" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="ReqVAl23"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB2" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtDOB2" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender7" TargetControlID="RegDOB2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear2" ValidationGroup="valPet" ControlToValidate="txtDOB2"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender44" TargetControlID="custYear2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight2" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5"></asp:TextBox>&nbsp;lbs
                                                        <asp:RequiredFieldValidator ID="ReqVAl24" ControlToValidate="txtPetWeight2" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="ReqVAl24"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight2" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetWeight2"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender8" TargetControlID="RegWeight2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetLength2" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5"></asp:TextBox>&nbsp;inches
                                                        <asp:RequiredFieldValidator ID="ReqVAl25" ControlToValidate="txtPetLength2" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="ReqVAl25"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength2" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetLength2"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender9" TargetControlID="ReqLength2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete2" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr id="p3" runat="server">
                                                    <td>
                                                        3.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName3" CssClass="regTextFldpetname" runat="server" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl31" ControlToValidate="txtPetName3" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" TargetControlID="ReqVAl31"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType3" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType3_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>                                                    
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed3" CssClass="regddlFieldbig" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl32" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed3"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" TargetControlID="ReqVAl32"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB3" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL33" ControlToValidate="txtDOB3" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" TargetControlID="ReqVAL33"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB3" ControlToValidate="txtDOB3" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender13" TargetControlID="RegDOB3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear3" ValidationGroup="valPet" ControlToValidate="txtDOB3"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender45" TargetControlID="custYear3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight3" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5"></asp:TextBox>&nbsp;lbs
                                                        <asp:RequiredFieldValidator ID="ReqVAl34" ControlToValidate="txtPetWeight3" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" TargetControlID="ReqVAl34"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight3" ControlToValidate="txtPetWeight3"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender15" TargetControlID="RegWeight3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetLength3" CssClass="regTextFldflength" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="5"></asp:TextBox>&nbsp;inches
                                                        <asp:RequiredFieldValidator ID="ReqVAL35" ControlToValidate="txtPetLength3" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" TargetControlID="ReqVAL35"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength3" ControlToValidate="txtPetLength3"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender17" TargetControlID="ReqLength3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete3" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr id="p4" runat="server">
                                                    <td>
                                                        4.
                                                    </td>
                                                     <td>
                                                        <asp:TextBox ID="txtPetName4" CssClass="regTextFldpetname" runat="server" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl41" ControlToValidate="txtPetName4" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" TargetControlID="ReqVAl41"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType4" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType4_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>                                                   
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed4" CssClass="regddlFieldbig" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl42" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed4"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" TargetControlID="ReqVAl42"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB4" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL43" ControlToValidate="txtDOB4" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" TargetControlID="ReqVAL43"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB4" ControlToValidate="txtDOB4" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender21" TargetControlID="RegDOB4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear4" ValidationGroup="valPet" ControlToValidate="txtDOB4"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender46" TargetControlID="custYear4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight4" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldstate" runat="server" MaxLength="5"></asp:TextBox>&nbsp;lbs
                                                        <asp:RequiredFieldValidator ID="ReqVAl44" ControlToValidate="txtPetWeight4" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" TargetControlID="ReqVAl44"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight4" ControlToValidate="txtPetWeight4"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender23" TargetControlID="RegWeight4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetLength4" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5"></asp:TextBox>&nbsp;inches
                                                        <asp:RequiredFieldValidator ID="ReqVAL45" ControlToValidate="txtPetLength4" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" TargetControlID="ReqVAL45"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength4" ControlToValidate="txtPetLength4"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender25" TargetControlID="ReqLength4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete4" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr id="p5" runat="server">
                                                    <td>
                                                        5.
                                                    </td>
                                                     <td>
                                                        <asp:TextBox ID="txtPetName5" CssClass="regTextFldpetname" runat="server" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl51" ControlToValidate="txtPetName5" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender26" TargetControlID="ReqVAl51"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType5" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType5_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>                                                   
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed5" CssClass="regddlFieldbig" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl52" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed5"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender27" TargetControlID="ReqVAl52"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB5" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL53" ControlToValidate="txtDOB5" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender28" TargetControlID="ReqVAL53"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB5" ControlToValidate="txtDOB5" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender29" TargetControlID="RegDOB5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear5" ValidationGroup="valPet" ControlToValidate="txtDOB5"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender47" TargetControlID="custYear5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight5" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5"></asp:TextBox>&nbsp;lbs
                                                        <asp:RequiredFieldValidator ID="ReqVAl54" ControlToValidate="txtPetWeight5" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender30" TargetControlID="ReqVAl54"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight5" ControlToValidate="txtPetWeight5"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender31" TargetControlID="RegWeight5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetLength5" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldflength" runat="server" MaxLength="5"></asp:TextBox>&nbsp;inches
                                                        <asp:RequiredFieldValidator ID="ReqVAL55" ControlToValidate="txtPetLength5" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender32" TargetControlID="ReqVAL55"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength5" ControlToValidate="txtPetLength5"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender33" TargetControlID="ReqLength5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete5" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr id="p6" runat="server">
                                                    <td>
                                                        6.
                                                    </td>
                                                     <td>
                                                        <asp:TextBox ID="txtPetName6" CssClass="regTextFldpetname" runat="server" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl61" ControlToValidate="txtPetName6" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender34" TargetControlID="ReqVAl61"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType6" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType6_OnSelectedIndexChanged">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                   
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed6" CssClass="regddlFieldbig" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl62" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed6"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender35" TargetControlID="ReqVAl62"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB6" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);" runat="server" MaxLength="4"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL63" ControlToValidate="txtDOB6" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender36" TargetControlID="ReqVAL63"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB6" ControlToValidate="txtDOB6" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender37" TargetControlID="RegDOB6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear6" ValidationGroup="valPet" ControlToValidate="txtDOB6"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender48" TargetControlID="custYear6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight6" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)" runat="server" MaxLength="5"></asp:TextBox>&nbsp;lbs
                                                        <asp:RequiredFieldValidator ID="ReqVAl64" ControlToValidate="txtPetWeight6" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender38" TargetControlID="ReqVAl64"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight6" ControlToValidate="txtPetWeight6"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender39" TargetControlID="RegWeight6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetLength6"  onkeypress="return decimalIntegerNumbers(event,this)" CssClass="regTextFldflength" runat="server" MaxLength="5"></asp:TextBox>&nbsp;inches
                                                        <asp:RequiredFieldValidator ID="ReqVAL65" ControlToValidate="txtPetLength6" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender40" TargetControlID="ReqVAL65"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength6" ControlToValidate="txtPetLength6"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender41" TargetControlID="ReqLength6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete6" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td colspan="5">
                                                        <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
                                                        <asp:ImageButton ID="imgAddmore" ImageUrl="~/Images/addMorepetButton.jpg" runat="server"
                                                            ValidationGroup="valPet" CausesValidation="true" OnClick="imgAddmore_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="ImgUserName" ImageUrl="~/Images/creatusertitle.jpg" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <%--  Region Pet information End --%>
                                    <%--  Region registration information Start --%>
                                    <table>
                                        <tr>
                                            <td class="tdstyle">
                                                <label> Email<span>*</span></label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtEmailReg" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE7" runat="server" TargetControlID="txtEmailReg" WatermarkText="Use as a User Name" WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqEmailReg" runat="server" ControlToValidate="txtEmailReg"
                                                    Display="None" ValidationGroup="valReg_Basic" ErrorMessage="<b>Required Field Missing</b><br />Email is required."
                                                    SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE2" TargetControlID="ReqEmailReg" PopupPosition="TopRight"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                <asp:RegularExpressionValidator ID="ReqEmailReg1" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                                                    ValidationGroup="valReg_Basic" SetFocusOnError="true" ControlToValidate="txtEmailReg"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                </asp:RegularExpressionValidator>
                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE3" TargetControlID="ReqEmailReg1" PopupPosition="TopRight"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Password<span>*</span></label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPasswordReg" CssClass="regTextField" TextMode="Password" runat="server"
                                                    MaxLength="15" ValidationGroup="valReg_Basic" OnFocus="return ShowErrorMessage();"
                                                    OnKeypress="return SetErrorMessage();"></asp:TextBox>
                                                <div id="divCall" runat="server">
                                                    <asp:RequiredFieldValidator ID="ReqPasswordReg" runat="server" ControlToValidate="txtPasswordReg"
                                                        Display="None" ValidationGroup="valReg_Basic" ErrorMessage="<b>Required Field Missing</b><br />Password is required."
                                                        SetFocusOnError="true">  
                                                    </asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE4" TargetControlID="ReqPasswordReg" PopupPosition="TopRight"
                                                        HighlightCssClass="validatorCalloutHighlight" />
                                                    <asp:CustomValidator runat="server" ID="custPasswordLength" ValidationGroup="valReg_Basic"
                                                        ControlToValidate="txtPasswordReg" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateLength"
                                                        ErrorMessage="<b>Required Field Missing</b><br />Password length should be in the range of 6 to 15 characters." />
                                                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custPasswordLength" PopupPosition="TopRight"
                                                        HighlightCssClass="validatorCalloutHighlight" />
                                                </div>
                                            </td>
                                            <td valign="Top">
                                                <asp:Label ID="lblStrength" runat="server" Text="Password Strength: " CssClass="lblStrength"></asp:Label>
                                                <cc1:PasswordStrength runat="server" ID="PasswordStrength1" TargetControlID="txtPasswordReg"
                                                    DisplayPosition="RightSide" PreferredPasswordLength="15" CalculationWeightings="25;25;15;35"
                                                    TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent" StrengthIndicatorType="BarIndicator"
                                                    HelpHandlePosition="AboveLeft" BarBorderCssClass="barIndicatorBorder" StrengthStyles="barIndicator_poor; barIndicator_weak; barIndicator_good; barIndicator_strong; barIndicator_excellent">
                                                </cc1:PasswordStrength>
                                                <cc1:PasswordStrength runat="server" ID="PasswordStrength2" TargetControlID="txtPasswordReg"
                                                    DisplayPosition="RightSide" PreferredPasswordLength="15" CalculationWeightings="25;25;15;35"
                                                    TextStrengthDescriptions="Poor; Weak; Good; Strong; Excellent" StrengthIndicatorType="Text"
                                                    PrefixText="" TextCssClass="strengthText" HelpHandlePosition="AboveLeft" BarBorderCssClass="barIndicatorBorder"
                                                    StrengthStyles="barIndicator_poor1; barIndicator_weak1; barIndicator_good1; barIndicator_strong1; barIndicator_excellent1">
                                                </cc1:PasswordStrength>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>
                                                    Confirm Password<span>*</span></label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtConPasswordReg" TextMode="Password" CssClass="regTextField" runat="server"
                                                    MaxLength="15" ValidationGroup="valReg_Basic"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ReqConPasswordReg" runat="server" ControlToValidate="txtConPasswordReg"
                                                    Display="None" ValidationGroup="valReg_Basic" ErrorMessage="<b>Required Field Missing</b><br />Confirm Password is required."
                                                    SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE6" TargetControlID="ReqConPasswordReg" PopupPosition="TopRight"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                <asp:CustomValidator runat="server" ID="ValConfirmPass" ValidationGroup="valReg_Basic"
                                                    ControlToValidate="txtConPasswordReg" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateConfirm"
                                                    ErrorMessage="Password and confirm password does not match" />
                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE7" TargetControlID="ValConfirmPass" PopupPosition="TopRight"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td colspan="2">
                                                <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
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
                                                <label>
                                                    Confirmation Code<span>*</span></label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtConfirmReg" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic" MaxLength="15"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ReqConfirmReg" runat="server" ControlToValidate="txtConfirmReg"
                                                    Display="None" ValidationGroup="valReg_Basic" ErrorMessage="<b>Required Field Missing</b><br />Confirmation Code is required."
                                                    SetFocusOnError="true">  
                                                </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender runat="Server" ID="VCE9" TargetControlID="ReqConfirmReg" PopupPosition="Right"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:CheckBox ID="chkRemember" runat="server" />Remember me
                                                <asp:HyperLink ID="IdWhat" runat="server" CssClass="whatsthislink" OnClick="Openwin();">What's this?</asp:HyperLink>
                                                <br />
                                                <p>
                                                    (Leave unchecked if this is a public computer)</p>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--  Region registration information End --%>
                                    <%--  Region Button Start--%>
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <asp:ImageButton ID="IdSubmit" ImageUrl="~/Images/regSubmitBtn.jpg" runat="server"
                                                    ValidationGroup="valReg_Basic" CausesValidation="true" OnClick="IdSubmit_Click" />
                                                <asp:ImageButton ID="IdReset" ImageUrl="~/Images/regResetbtn.jpg" runat="server"
                                                    CausesValidation="false" OnClick="IdReset_Click" />
                                            </td>
                                            <td align="right" style="padding-right: 10px;">
                                                <table>
                                                    <tr>
                                                        <td colspan="2" class="tdstylemend">
                                                            Note:
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdstylemendtory" align="left">
                                                            1.
                                                        </td>
                                                        <td class="tdstylemendtory" align="left">
                                                            <span>*</span>&nbsp;required
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdstylemendtory" align="left">
                                                            2.
                                                        </td>
                                                        <td class="tdstylemendtory">
                                                            6 Pets per Registration Maximum
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--  Region Button End--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="regFormBoottom"></div>
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
