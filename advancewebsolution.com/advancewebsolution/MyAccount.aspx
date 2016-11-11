<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" Inherits="MyAccount" Title="Fritzy's pet care pros : My Account" CodeBehind="MyAccount.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="CSS/Admin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="Scripts/phone_validation.js" defer="defer"></script>

    <script type="text/javascript" language="javascript" src="Scripts/Validation.js" defer="defer"></script>

    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->

    <script type="text/javascript" language="javascript" defer="defer">
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
                                <asp:Image ID="regrightimg" ImageUrl="~/Images/regRightImg.jpg" runat="server" AlternateText="" />
                            </div>
                        </div>
                        <!-- reg top end here -->
                        <div id="regTitle">
                            <asp:Image ID="ImgTitle" ImageUrl="~/Images/my account.jpg" runat="server" AlternateText="" />
                        </div>

                        <div class="regForm">
                            <div class="regFormTop"></div>
                            <div class="regFormMid">
                                <div class="regestrationForm">
                                    <table width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblErrorEmail" runat="server" ForeColor="Red" Visible="False" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                                <asp:Label ID="lblsmsg" runat="server" Text="Your Payment Submitted Successfully!!!"
                                                    ForeColor="Green" Font-Bold="true" Font-Size="Medium" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Image ID="YourinfoTitle" ImageUrl="~/Images/yourinfotitle.jpg" runat="server"
                                                    AlternateText="" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="4">
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Name <span>*</span></label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic"
                                                    MaxLength="20"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE1" runat="server" TargetControlID="txtFirstName"
                                                    WatermarkText="First Name" WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqFirstName" ControlToValidate="txtFirstName" ErrorMessage="<b>Required Field Missing</b><br />First name is required."
                                                    Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="VCE1" TargetControlID="ReqFirstName" HighlightCssClass="validatorCalloutHighlight"
                                                    Enabled="true" runat="Server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLastName" CssClass="regTextField" runat="server" MaxLength="20"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtLastName"
                                                    WatermarkText="Last Name" WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqLastName" ControlToValidate="txtLastName" ErrorMessage="<b>Required Field Missing</b><br />Last name is required."
                                                    Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="ReqLastName"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Address <span>*</span></label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStreet" CssClass="regTextField" runat="server" MaxLength="20"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TBWE3" runat="server" TargetControlID="txtStreet"
                                                    WatermarkText="Street" WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqValStreet" ControlToValidate="txtStreet" ErrorMessage="<b>Required Field Missing</b><br />Street name is required."
                                                    ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="VCEPet2" TargetControlID="ReqValStreet" HighlightCssClass="validatorCalloutHighlight"
                                                    Enabled="true" runat="Server" />
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtCity" CssClass="regTextFldCity" runat="server" MaxLength="20"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TBWE4" runat="server" TargetControlID="txtCity"
                                                                WatermarkText="City" WatermarkCssClass="regTextFldCity1" />
                                                            <asp:RequiredFieldValidator ID="ReqValCity" ControlToValidate="txtCity" ErrorMessage="<b>Required Field Missing</b><br />City name is required."
                                                                ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" TargetControlID="ReqValCity"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        </td>
                                                        <td>

                                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="regddlField"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="State" InitialValue="0"
                                                                ControlToValidate="ddlState" ErrorMessage="<b>Required Field Missing</b><br />Please select state"
                                                                Display="none" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator1"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtZip" CssClass="regTextFldzip" runat="server" MaxLength="5"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TBWE6" runat="server" TargetControlID="txtZip"
                                                                WatermarkText="Zip" WatermarkCssClass="regTextFldzip1" />
                                                            <asp:RequiredFieldValidator ID="ReqValZip" ControlToValidate="txtZip" ErrorMessage="<b>Required Field Missing</b><br />Zipcode is required."
                                                                ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="ReqValZip"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" PopupPosition="Right" />
                                                            <asp:RegularExpressionValidator ID="RegValZip" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct zipcode ."
                                                                ValidationGroup="valReg_Basic" SetFocusOnError="true" ControlToValidate="txtZip"
                                                                ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
                                                            <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender49" TargetControlID="RegValZip"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Phone <span>*</span></label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPhone" CssClass="regTextField" runat="server" MaxLength="15"
                                                    onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtPhone"
                                                    WatermarkText="Primary Phone*" WatermarkCssClass="regTextField1" />
                                                <asp:RequiredFieldValidator ID="ReqPhone" ControlToValidate="txtPhone" ErrorMessage="<b>Required Field Missing</b><br />Primary phone is required."
                                                    ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="ReqPhone"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAltMobile" CssClass="regTextField" runat="server" MaxLength="15"
                                                    onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtAltMobile"
                                                    WatermarkText="Mobile Number" WatermarkCssClass="regTextField1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Alternate Contact</label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" ID="txtAltContact" CssClass="regTextField" runat="server" MaxLength="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Alternate Address</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAltStreet" CssClass="regTextField" runat="server" MaxLength="30"></asp:TextBox>
                                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="txtAltStreet"
                                                    WatermarkText="Street" WatermarkCssClass="regTextField1" />
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtAltCity" CssClass="regTextFldCity" runat="server" MaxLength="20"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtAltCity"
                                                                WatermarkText="City" WatermarkCssClass="regTextFldCity1" />
                                                        </td>
                                                        <td>

                                                            <asp:DropDownList ID="ddlState1" runat="server" CssClass="regddlField"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAltZip" CssClass="regTextFldzip" runat="server" MaxLength="5"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="txtAltZip"
                                                                WatermarkText="Zip" WatermarkCssClass="regTextFldzip1" />
                                                            <asp:RegularExpressionValidator ID="RegValzip1" runat="server" Display="None" ErrorMessage="Please enter correct zipcode ."
                                                                ValidationGroup="valReg_Basic" SetFocusOnError="true" ControlToValidate="txtAltZip"
                                                                ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
                                                            <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender50" TargetControlID="RegValzip1"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Alternate Phone</label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtAltPhone" CssClass="regTextField" runat="server" MaxLength="15"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Referral Source <span>*</span></label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlReferralSource" CssClass="regddlFieldbig" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="Reqref" Text="Selcect One" InitialValue="0" ControlToValidate="ddlReferralSource"
                                                    ErrorMessage="<b>Required Field Missing</b><br />Referral source is required"
                                                    Display="none" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender42" TargetControlID="Reqref"
                                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Preferred Groomer</label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtGroomer" CssClass="regTextField" runat="server" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdstyle">
                                                <label>Email <span>*</span></label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtEmailReg" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic"
                                                    MaxLength="30"></asp:TextBox>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="Yourpetinfo" runat="server" ImageUrl="~/Images/petinfotitle.jpg" AlternateText="" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="up2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                        <ContentTemplate>
                                            <table cellspacing="8">
                                                <tbody>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                        <th>Pet
                                                        </th>
                                                        <th>PetName
                                                        </th>
                                                        <th>Breed
                                                        </th>
                                                        <th>Birth Year
                                                        </th>
                                                        <th>Weight
                                                        </th>
                                                        <th>Fur Length
                                                        </th>
                                                        <th style="background: none; border: none;"></th>
                                                    </tr>
                                                    <tr id="p1" runat="server">
                                                        <td>
                                                            <%-- 1.--%>
                                                            <asp:Label ID="lblsrno1" runat="server" Text="1."></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPetType1" runat="server" CssClass="regddlField" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlPetType1_SelectedIndexChanged">
                                                                <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetName1" runat="server" MaxLength="30" CssClass="regTextFldpetname"></asp:TextBox>
                                                            <asp:Label ID="PetID1" runat="server" Text="0" Visible="false"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="ReqVal1" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                                ControlToValidate="txtPetName1">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="VCEPet1" runat="Server" TargetControlID="ReqVal1" PopupPosition="TopLeft"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBreed1" runat="server" CssClass="regddlFieldbig"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqVAl2" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                                ControlToValidate="ddlBreed1" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="Server" TargetControlID="ReqVal2" PopupPosition="TopLeft"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetDOB1" runat="server" MaxLength="4" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="ReqVal3" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                                ControlToValidate="txtPetDOB1">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="VCEPet3" runat="Server" TargetControlID="ReqVal3" PopupPosition="TopLeft"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="ReqPet4" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year ."
                                                                ControlToValidate="txtPetDOB1" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="Server" TargetControlID="ReqPet4" PopupPosition="TopLeft"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                            <asp:CustomValidator runat="server" ID="custYear1" ValidationGroup="valReg_Basic"
                                                                ControlToValidate="txtPetDOB1" Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear"
                                                                ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                            <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender51" TargetControlID="custYear1" PopupPosition="TopLeft"
                                                                HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetWeight1" runat="server" MaxLength="6" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;lbs
                                                            <asp:RequiredFieldValidator ID="Reqval4" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Weight is required."
                                                                ControlToValidate="txtPetWeight1">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="VCEPet4" runat="Server" TargetControlID="Reqval4" PopupPosition="TopLeft"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="ReqPet6" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                                ControlToValidate="txtPetWeight1" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                            <cc1:ValidatorCalloutExtender ID="VCEPet5" runat="Server" TargetControlID="ReqPet6"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetLength1" runat="server" MaxLength="6" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;inches
                                                            <asp:RequiredFieldValidator ID="Reqval7" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Length is required."
                                                                ControlToValidate="txtPetLength1">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="VCEPet6" runat="Server" TargetControlID="Reqval7" PopupPosition="TopLeft"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                            <asp:RegularExpressionValidator ID="Reqval8" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                                ControlToValidate="txtPetLength1" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                            <cc1:ValidatorCalloutExtender ID="VCEPet7" runat="Server" TargetControlID="Reqval8" PopupPosition="TopLeft"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgDelete1" runat="server" ImageUrl="~/Images/deleteicon.gif" ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete1_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr id="p2" runat="server">
                                                        <td>
                                                            <%--  2.--%>
                                                            <asp:Label ID="lblsrno2" runat="server" Text="2."></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPetType2" runat="server" CssClass="regddlField" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlPetType2_SelectedIndexChanged">
                                                                <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetName2" runat="server" MaxLength="20" CssClass="regTextFldpetname"></asp:TextBox>
                                                            <asp:Label ID="PetID2" runat="server" Text="0" Visible="false"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="ReqVAl21" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                                ControlToValidate="txtPetName2">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="Server" TargetControlID="ReqVAl21"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBreed2" runat="server" CssClass="regddlFieldbig"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqVAl22" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                                ControlToValidate="ddlBreed2" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="Server" TargetControlID="ReqVal22"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDOB2" runat="server" MaxLength="4" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetWeight2" runat="server" MaxLength="5" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;lbs
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetLength2" runat="server" MaxLength="5" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;inches
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
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgDelete2" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                                ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete2_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr id="p3" runat="server">
                                                        <td>
                                                            <%-- 3.--%>
                                                            <asp:Label ID="lblsrno3" runat="server" Text="3."></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPetType3" runat="server" CssClass="regddlField" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlPetType3_SelectedIndexChanged">
                                                                <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="PetID3" runat="server" Text="0" Visible="false"></asp:Label>
                                                            <asp:TextBox ID="txtPetName3" runat="server" MaxLength="30" CssClass="regTextFldpetname"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="ReqVAl31" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                                ControlToValidate="txtPetName3">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="Server" TargetControlID="ReqVAl31"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBreed3" runat="server" CssClass="regddlFieldbig"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqVAl32" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                                ControlToValidate="ddlBreed3" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="Server" TargetControlID="ReqVAl32"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDOB3" runat="server" MaxLength="4" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetWeight3" runat="server" MaxLength="5" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;lbs
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetLength3" runat="server" MaxLength="5" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;inches
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
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgDelete3" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                                ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete3_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr id="p4" runat="server">
                                                        <td>
                                                            <%-- 4.--%>
                                                            <asp:Label ID="lblsrno4" runat="server" Text="4."></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPetType4" runat="server" CssClass="regddlField" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlPetType4_SelectedIndexChanged">
                                                                <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetName4" runat="server" MaxLength="30" CssClass="regTextFldpetname"></asp:TextBox>
                                                            <asp:Label ID="PetID4" runat="server" Text="0" Visible="false"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="ReqVAl41" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                                ControlToValidate="txtPetName4">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="Server" TargetControlID="ReqVAl41"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBreed4" runat="server" CssClass="regddlFieldbig"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqVAl42" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                                ControlToValidate="ddlBreed4" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="Server" TargetControlID="ReqVAl42"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDOB4" runat="server" MaxLength="4" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetWeight4" runat="server" MaxLength="5" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;lbs
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetLength4" runat="server" MaxLength="5" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;inches
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
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgDelete4" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                                ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete4_Click"
                                                                Style="width: 20px" />
                                                        </td>
                                                    </tr>
                                                    <tr id="p5" runat="server">
                                                        <td>
                                                            <%-- 5.--%>
                                                            <asp:Label ID="lblsrno5" runat="server" Text="5."></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPetType5" runat="server" CssClass="regddlField" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlPetType5_SelectedIndexChanged">
                                                                <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetName5" runat="server" MaxLength="30" CssClass="regTextFldpetname"></asp:TextBox>
                                                            <asp:Label ID="PetID5" runat="server" Text="0" Visible="false"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="ReqVAl51" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                                ControlToValidate="txtPetName5">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender32" runat="Server" TargetControlID="ReqVAl51"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBreed5" runat="server" CssClass="regddlFieldbig"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqVAl52" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                                ControlToValidate="ddlBreed5" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" runat="Server" TargetControlID="ReqVAl52"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDOB5" runat="server" MaxLength="4" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetWeight5" runat="server" MaxLength="5" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;lbs
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetLength5" runat="server" MaxLength="5" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;inches
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
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgDelete5" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                                ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete5_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr id="p6" runat="server">
                                                        <td>
                                                            <%-- 6.--%>
                                                            <asp:Label ID="lblsrno6" runat="server" Text="6."></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPetType6" runat="server" CssClass="regddlField" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlPetType6_SelectedIndexChanged">
                                                                <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetName6" runat="server" MaxLength="30" CssClass="regTextFldpetname"></asp:TextBox>
                                                            <asp:Label ID="PetID6" runat="server" Text="0" Visible="false"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="ReqVAl61" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                                ControlToValidate="txtPetName6">  
                                                            </asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender40" runat="Server" TargetControlID="ReqVAl61"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBreed6" runat="server" CssClass="regddlFieldbig"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="ReqVAl62" runat="server" ValidationGroup="valReg_Basic"
                                                                SetFocusOnError="true" Display="none" ErrorMessage="<b>Required Field Missing</b><br />Breed is required"
                                                                ControlToValidate="ddlBreed6" InitialValue="0" Text="Selcect One"></asp:RequiredFieldValidator>
                                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender41" runat="Server" TargetControlID="ReqVAl62"
                                                                Enabled="true" HighlightCssClass="validatorCalloutHighlight">
                                                            </cc1:ValidatorCalloutExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDOB6" runat="server" MaxLength="4" CssClass="regTextFldbyear" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetWeight6" runat="server" MaxLength="5" CssClass="regTextFldstate" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;lbs
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
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPetLength6" runat="server" MaxLength="5" CssClass="regTextFldflength" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>&nbsp;inches
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
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="imgDelete6" runat="server" ImageUrl="~/Images/deleteicon.gif"
                                                                ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete6_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                        <td colspan="5">
                                                            <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
                                                            <asp:ImageButton ID="imgAddmore" OnClick="imgAddmore_Click" runat="server" ImageUrl="~/Images/addMorepetButton.jpg"
                                                                ValidationGroup="valReg_Basic" CausesValidation="true"></asp:ImageButton>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
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
                                    <table width="100%" border="0">
                                        <tr>
                                            <td align="left" style="padding-left: 25px; width: 12%;">
                                                <asp:ImageButton ID="IdNext" ImageUrl="~/Images/updatebtn.gif" runat="server" ValidationGroup="valReg_Basic" CausesValidation="true" OnClick="IdNext_Click" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="IdReset" Visible="true" ImageUrl="~/Images/setAppBtn.gif" runat="server" OnClick="IdReset_Click" ValidationGroup="valReg_Basic" CausesValidation="true" />
                                            </td>
                                            <td align="right" style="padding-right: 10px;"></td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Label ID="lblFutureApp" runat="server" Text="Future Appointments" Font-Bold="true" Font-Size="Medium" ForeColor="#009ddc"> </asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
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
                                                            <PagerStyle CssClass="gridPager" />
                                                            <RowStyle HorizontalAlign="Left" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                                                    <ItemStyle CssClass="itemstyle" />
                                                                    <HeaderStyle CssClass="headerStyle" Width="8%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAppointmentDate" runat="server" Text='<%# Eval("Date","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                        <asp:Label ID="lblApptDate" runat="server" Text='<%# Eval("Date")%>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Start Time">
                                                                    <HeaderStyle CssClass="headerStyle" Width="10%" />
                                                                    <ItemStyle CssClass="itemstyle" />
                                                                    <HeaderStyle CssClass="headerStyle" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbltxtExpectedPetTime" runat="server" Text='<%# Bind("T","{0:hh:mm tt}")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Appointment Detail">
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
                                                                        <asp:HyperLink ID="HypName" runat="server" NavigateUrl='<%#"PaymentPrepaid.aspx?"+EncryptQueryString(string.Format("PayAppID={0}&Type={1}",Eval("UserAppID"),Eval("Type"))) %>'
                                                                            Text="Make Payment"></asp:HyperLink>
                                                                        <asp:Label ID="lblPaidStatus" runat="server" Text='<%# Bind("PaymentStatus")%>' Visible="true"></asp:Label>
                                                                        <asp:Label ID="lblPaymentAmount" runat="server" Visible='<%#(Eval("PaymentStatus").ToString()=="Pending"?false:true) %>'>( $ <%#String.Format("{0:0.00}",Eval("PaymentAmount"))%>)</asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" Wrap="false" />
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="btnDeleteApp" runat="server" ImageUrl="images/deleteicon.gif"
                                                                            CommandName="Delete" ToolTip="Delete App" OnClientClick="return confirm('Are you sure you want to delete this ?');"
                                                                            CommandArgument='<%# Bind("UserAppID") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="headerStyle1" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Type" Visible="false">
                                                                    <ItemStyle CssClass="itemstyle" Width="5%" HorizontalAlign="left" Wrap="false" />
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
                                    <table width="100%" border="0">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Text="Appointment History" Font-Bold="true" Font-Size="Medium" ForeColor="#009ddc"> </asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblPastInfo" runat="server" Text="No history appointments are available."
                                                    Font-Bold="true" Visible="false"> </asp:Label>
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
                                                                <asp:TemplateField HeaderText="Appointment Detail">
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
                            <div class="regFormBoottom"></div>
                        </div>
                    </div>
                    <!-- reg main end here -->
                    <div class="leftInner">
                        <div class="visitOurVan">
                            <a href="Visitourvan.aspx" title="Visit our van">
                                <img src="images/visit_our_van.jpg" width="668" height="243" border="0" alt="Visit Our Van" /></a>
                        </div>
                    </div>
                </div>
                <!-- main content end here -->
                <div style="clear: both;"></div>
                <div id="mainBottomImg"></div>
            </div>
            <!-- wrapper end here -->
        </div>
    </div>
    <!-- main place holder end here -->
</asp:Content>
