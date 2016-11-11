<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ViewUsers" Title="View Users" Codebehind="ViewUsers.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--This page is use to view user detail with there pet and appointment --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../Scripts/phone_validation.js"></script>

    <script type="text/javascript" language="javascript" src="../Scripts/Validation.js"></script>

    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->

    <script type="text/javascript" language="javascript">
        function Validate() {
            if (!confirm("Do you want to delete pet")) {
                return false;
            }
        }
    </script>

    <script language="javascript" type="text/javascript">

        function ValidateLength(source, arguments) {

            if ((document.getElementById('<%=txtPasswordReg.ClientID %>').value.length < 6) || (document.getElementById('<%=txtPasswordReg.ClientID %>').value.length > 15)) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
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
            //return;
            //document.getElementById('<%=divCall.ClientID %>').style.display = "Block";
        }
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Member Details</h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <h3>
            Personal Details</h3>
        <table class="adduserTable" cellpadding="6" cellspacing="0" border="0" style="margin-bottom: 0;">
            <tr>
                <td>
                    <span class="star">*</span>Name
                </td>
                <td style="width: 190px;">
                    <asp:TextBox ID="txtFirstName" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic"
                        MaxLength="20"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TBWE1" runat="server" TargetControlID="txtFirstName"
                        WatermarkText="First Name" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqFirstName" ControlToValidate="txtFirstName" ErrorMessage="<b>Required Field Missing</b><br />First name is required."
                        Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="VCE1" TargetControlID="ReqFirstName" HighlightCssClass="validatorCalloutHighlight"
                        Enabled="true" runat="Server" />
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" CssClass="regTextField" runat="server" MaxLength="20"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtLastName"
                        WatermarkText="Last Name" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqLastName" ControlToValidate="txtLastName" ErrorMessage="<b>Required Field Missing</b><br />Last name is required."
                        Display="None" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="ReqLastName"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span>Address
                </td>
                <td>
                    <asp:TextBox ID="txtStreet" CssClass="regTextField" runat="server" MaxLength="50"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TBWE3" runat="server" TargetControlID="txtStreet"
                        WatermarkText="Street" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqValStreet" ControlToValidate="txtStreet" ErrorMessage="<b>Required Field Missing</b><br />Street name is required."
                        ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="VCEPet2" TargetControlID="ReqValStreet" HighlightCssClass="validatorCalloutHighlight"
                        Enabled="true" runat="Server" />
                </td>
                <td>
                    <table>
                        <tr>
                            <td style="border-bottom: none;">
                                <asp:TextBox ID="txtCity" CssClass="regTextFldCity" runat="server" MaxLength="20"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TBWE4" runat="server" TargetControlID="txtCity"
                                    WatermarkText="City" WatermarkCssClass="regTextFldCity1" />
                                <asp:RequiredFieldValidator ID="ReqValCity" ControlToValidate="txtCity" ErrorMessage="<b>Required Field Missing</b><br />City name is required."
                                    ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true">  
                                </asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" TargetControlID="ReqValCity"
                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                            </td>
                            <td style="border-bottom: none;">
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="regddlField">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="State" InitialValue="0"
                                    ControlToValidate="ddlState" ErrorMessage="<b>Required Field Missing</b><br />Please select state"
                                    Display="none" ValidationGroup="valReg_Basic" runat="server" SetFocusOnError="true" />
                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" TargetControlID="RequiredFieldValidator1"
                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                            </td>
                            <td style="border-bottom: none;">
                                <asp:TextBox ID="txtZip" CssClass="regTextFldzip" runat="server" MaxLength="5"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TBWE6" runat="server" TargetControlID="txtZip"
                                    WatermarkText="Zip" WatermarkCssClass="regTextFldzip1" />
                                <asp:RequiredFieldValidator ID="ReqValZip" ControlToValidate="txtZip" ErrorMessage="<b>Required Field Missing</b><br />Zipcode is required."
                                    ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true">  
                                </asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="ReqValZip"
                                    HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
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
                <td>
                    <span class="star">*</span> Phone
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" CssClass="regTextField" runat="server" MaxLength="15"
                        onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtPhone"
                        WatermarkText="Primary Phone" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqVAlPhone" ControlToValidate="txtPhone" ErrorMessage="<b>Required Field Missing</b><br />Phone is required."
                        ValidationGroup="valReg_Basic" Display="None" runat="server" SetFocusOnError="true">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender48" TargetControlID="ReqVAlPhone"
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
                <td>
                    Alternate Contact
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtAltContact" CssClass="regTextField" runat="server" MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Alternate Address
                </td>
                <td>
                    <asp:TextBox ID="txtAltStreet" CssClass="regTextField" runat="server" MaxLength="50"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="txtAltStreet"
                        WatermarkText="Street" WatermarkCssClass="regTextField1" />
                </td>
                <td>
                    <table>
                        <tr>
                            <td style="border-bottom: none;">
                                <asp:TextBox ID="txtAltCity" CssClass="regTextFldCity" runat="server" MaxLength="20"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtAltCity"
                                    WatermarkText="City" WatermarkCssClass="regTextFldCity1" />
                            </td>
                            <td style="border-bottom: none;">
                                <asp:DropDownList ID="ddlState1" runat="server" CssClass="regddlField">
                                </asp:DropDownList>
                            </td>
                            <td style="border-bottom: none;">
                                <asp:TextBox ID="txtAltZip" CssClass="regTextFldzip" runat="server" MaxLength="5"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="txtAltZip"
                                    WatermarkText="Zip" WatermarkCssClass="regTextFldzip1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Alternate Phone
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtAltPhone" CssClass="regTextField" runat="server" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span>Referral Source
                </td>
                <td colspan="2">
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
                <td>
                    Preferred Groomer
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtGroomer" CssClass="regTextField" runat="server" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Email
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtEmailReg" CssClass="regTextField" runat="server" ValidationGroup="valReg_Basic"
                        MaxLength="50"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="TBWE7" runat="server" TargetControlID="txtEmailReg"
                        WatermarkText="Use as a User Name" WatermarkCssClass="regTextField1" />
                    <asp:RequiredFieldValidator ID="ReqEmailReg" runat="server" ControlToValidate="txtEmailReg"
                        Display="None" ValidationGroup="valReg_Basic" ErrorMessage="<b>Required Field Missing</b><br />Email is required."
                        SetFocusOnError="true">  
                    </asp:RequiredFieldValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE2" TargetControlID="ReqEmailReg"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                    <asp:RegularExpressionValidator ID="ReqEmailReg1" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct email."
                        ValidationGroup="valReg_Basic" SetFocusOnError="true" ControlToValidate="txtEmailReg"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                    <cc1:ValidatorCalloutExtender runat="Server" ID="VCE3" TargetControlID="ReqEmailReg1"
                        HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="star">*</span> Password
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPasswordReg" CssClass="regTextField" runat="server" MaxLength="15"
                        ValidationGroup="valReg_Basic" OnFocus="return ShowErrorMessage();" OnKeypress="return SetErrorMessage();"></asp:TextBox>
                    <div id="divCall" runat="server">
                        <asp:RequiredFieldValidator ID="ReqPasswordReg" runat="server" ControlToValidate="txtPasswordReg"
                            Display="None" ValidationGroup="valReg_Basic" ErrorMessage="<b>Required Field Missing</b><br />Password is required."
                            SetFocusOnError="true">  
                        </asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender runat="Server" ID="VCE4" TargetControlID="ReqPasswordReg"
                            HighlightCssClass="validatorCalloutHighlight" />
                        <asp:CustomValidator runat="server" ID="custPasswordLength" ValidationGroup="valReg_Basic"
                            ControlToValidate="txtPasswordReg" Display="None" SetFocusOnError="true" ClientValidationFunction="ValidateLength"
                            ErrorMessage="Password length should be in the range of 6 to 15 characters." />
                        <cc1:ValidatorCalloutExtender runat="Server" ID="VCE5" TargetControlID="custPasswordLength"
                            HighlightCssClass="validatorCalloutHighlight" />
                    </div>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update" CssClass="btnBg"
                        CausesValidation="true" UseSubmitBehavior="true" ValidationGroup="valReg_Basic"
                        OnClick="btnUpdate_Click" />
                </td>
            </tr>
        </table>
        <%--First table will show the user detail start--%>
        <table class="adduserTable" cellpadding="6" cellspacing="0" style="display: none;">
            <tr>
                <td style="width: 20%;">
                    First Name :
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    Last Name :
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Address :
                </td>
                <td>
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Phone :
                </td>
                <td>
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile :
                </td>
                <td>
                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Referral Source :
                </td>
                <td>
                    <asp:Label ID="lblReferralSource" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Alternate Contact :
                </td>
                <td>
                    <asp:Label ID="lblAlternate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Alternate Address :
                </td>
                <td>
                    <asp:Label ID="lblAlternateAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Alternate Phone :
                </td>
                <td>
                    <asp:Label ID="lblAlternatePhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Preferred Groomer :
                </td>
                <td>
                    <asp:Label ID="lblPreferredGroomer" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Email :
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <%--Table End --%>
        <%--Second is grid which shows the all pet information start--%>
        <img src="images/seperator.jpg" alt="" />
        <br />
        <br />
        <h3>
            Pet Details</h3>
        <asp:GridView ID="grdPet" runat="server" CellPadding="0" GridLines="Vertical" Width="100%"
            HeaderStyle-CssClass="headerStyle" AutoGenerateColumns="false" CssClass="gridStyle itemstyle"
            AlternatingRowStyle-CssClass="altGridStyle" Visible="false">
            <AlternatingRowStyle CssClass="altGridStyle" />
            <PagerStyle CssClass="gridPager" />
            <Columns>
                <asp:TemplateField HeaderText="Pet Type">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPetType" runat="server" Text='<%# Bind("Pettype") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pet Name">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPetName" runat="server" Text='<%# Bind("PetName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Breed Name">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblBreedName" runat="server" Text='<%# Bind("BreedName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Birth Year">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblYears" runat="server" Text='<%# Bind("Years") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Weight">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblWeight" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Length">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblLength" runat="server" Text='<%# Bind("Length") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Spa">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblSpa" runat="server" Text='<%# Bind("Spa") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Style Name">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblStyleName" runat="server" Text='<%# Bind("StyleName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--Second is data list  which shows the all pet information start--%>
        <asp:DataList ID="dlPet" runat="server" RepeatColumns="2" Width="100%" CellPadding="6"
            RepeatDirection="Vertical" CellSpacing="0" OnItemDataBound="dlPet_ItemDataBound"
            CssClass="petdtlsTable" OnDeleteCommand="dlPet_DeleteCommand">
            <ItemStyle />
            <ItemTemplate>
                <table cellpadding="6" cellspacing="0" class="rghtborder">
                    <tr>
                        <td>
                            <table cellpadding="3" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 35%;">
                                        Pet :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Pettype") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Pet Name :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("PetName") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Breed Name :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("BreedName") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Birth Year :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Years") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Weight :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Length :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Length") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Spa :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Spa") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Style Name :
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text='<%# (string.IsNullOrEmpty(Eval("StyleName").ToString()) ? "No-Style" : Eval("StyleName")) %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Additional Services :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAdditionalServices" runat="server" Text='<%# Bind("AdditionalService") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr style="background: #f7f2ea; height: 25px;">
                                    <td colspan="2">
                                        <asp:LinkButton Text="Delete" ToolTip="Delete" CssClass="petlink" CommandName="Delete"
                                            OnClientClick="return Validate();" CommandArgument='<%# Bind("PetID") %>' runat="server"
                                            ID="delete" />
                                        &nbsp;
                                        <asp:HyperLink ID="hypEdit" runat="server" Text="Edit" ToolTip="Edit" CssClass="petlink"
                                            NavigateUrl='<%# "EditPet.aspx?PetID=" +  Eval("PetID") + "&ID=" + Request.QueryString["ID"].ToString() + "&p=" + Request.QueryString["p"].ToString()  %>'></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <%--Grid End --%>
        <div class="errorDiv" id="NoPetDiv" runat="server" style="display: none;">
            <asp:Label ID="lblNoPet" runat="server" CssClass="errorTable"></asp:Label>
        </div>
        <br />
        <%--third region is appointment detail--%>
        <img src="images/seperator.jpg" alt="" />
        <h3>Appointment Details</h3>
        <asp:GridView ID="grdAppointment" runat="server" CellPadding="0" GridLines="Vertical"
            DataKeyNames="AppointmentID" Width="100%" HeaderStyle-CssClass="headerStyle"
            AutoGenerateColumns="false" CssClass="gridStyle itemstyle" AlternatingRowStyle-CssClass="altGridStyle"
            AllowPaging="true" AllowSorting="true" PageSize="5" OnSorting="grdAppointment_Sorting"
            OnPageIndexChanging="grdAppointment_PageIndexChanging">
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
                <asp:TemplateField HeaderText="Date/Time" SortExpression="Date">
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date", "{0:MMM-dd-yyyy hh:mm tt}")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Flexible">
                    <ItemStyle CssClass="itemstyle" Width="12%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblFlex" runat="server" Text='<%# Bind("Flex") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ConfirmBy">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblConfirmBy" runat="server" Text='<%# Bind("ConfirmBy") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Note">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblNote" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="errorDiv" id="NoAppintmentDiv" runat="server" style="display: none;">
            <asp:Label ID="lblNoAppintment" runat="server" CssClass="errorTable"></asp:Label>
        </div>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBg" ToolTip="Cancel"
            OnClick="btnCancel_Click" />
    </div>
    <%--Region End --%>
    <%--Region Pet DataListt--%>
</asp:Content>
