<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="Mobile_MB_schedule_appointment"  Title="Mobile Grooming Services" EnableEventValidation="false" Codebehind="MB_schedule_appointment.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" defer="defer">
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
    <script type="text/javascript">
        function setList(i) {
            if (document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display == "none") {
                document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "block";
                document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).focus();
            }
            else {
                document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "block";
            }
            return false;
        }
        function HideList(i) {
            document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "block";
            return false;
        }

        function SetText(i) {
            var Source = document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i);
            var str = "";
            var str1 = "";
            for (j = 0; j < document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_lstAddservices" + i).length; j++) {
                if (Source.options[j].selected) {
                    if (str == "") {
                        str = Source.options[j].text;
                        str1 = Source.options[j].value;
                    }
                    else {
                        str = str + "," + Source.options[j].text;
                        str1 = str1 + "," + Source.options[j].value;
                    }
                }
            }

            document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_txtAddServices" + i).value = str;
            document.getSelectedCheckbox("ctl00_ContentPlaceHolder1_txtAddServicesID" + i).value = str1;
        }
    </script>

    <script type="text/javascript" language="javascript">
        function ShowDiv() {
            if (document.getElementById('<%=chkalt.ClientID %>').checked) {
                document.getElementById('<%=divalt.ClientID %>').style.display = "block";
            }
            else {
                document.getElementById('<%=divalt.ClientID %>').style.display = "none";
            }
        }


        function setred1() {
            if (document.getElementById('<%=red1.ClientID %>').checked) {
                document.getElementById('<%=txtAlternat.ClientID %>').disabled = true;
                document.getElementById('<%=txtPrimary.ClientID %>').disabled = false;
                document.getElementById('<%=red2.ClientID %>').checked = false;
            }
        }
        function setred2() {
            if (document.getElementById('<%=red2.ClientID %>').checked) {
                document.getElementById('<%=txtPrimary.ClientID %>').disabled = true;
                document.getElementById('<%=txtAlternat.ClientID %>').disabled = false;
                document.getElementById('<%=red1.ClientID %>').checked = false;
            }
        }

        function confirmation() {
            if (!confirm("Do you want to delete this pet?")) {
                return false;
            }
        }
    </script>
    <style>
        .chkMobileAppointment {
            margin-right: 236px;
        }
    </style>

    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Schedule An Appointment</h1>
            <h2>
                <span class="heading">Who? &amp; What?</span></h2>
        </div>
        <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"></asp:Label>
        <asp:Label ID="lblErrorDate" runat="server" Font-Size="Larger" ForeColor="red"></asp:Label>
        <asp:UpdatePanel ID="up12" runat="server">
            <ContentTemplate>
                <%--    For Pet 1--%>
                <div class="divfirstpetinfo" id="dvPet1" runat="server">
                    <div class="deletediv">
                        <asp:CheckBox CssClass="chkMobileAppointment" ID="chkPet1" runat="server" OnCheckedChanged="chkPet1_CheckedChanged" AutoPostBack="true" />
                        <asp:ImageButton ID="imgDelete1" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete1_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="petlabel" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType1" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType1_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID1" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="petnamelabel" CssClass="shortlabel" runat="server">Pet&nbsp;Name</asp:Label><br />
                        <asp:TextBox ID="txtPetName1" CssClass="shorttxtbox" MaxLength="20" Width=" 126px" runat="server"></asp:TextBox><br />
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
                        <asp:TextBox ID="txtPetWeight1" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
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
                        <asp:TextBox ID="txtPetLength1" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
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
                    <div class="petlabeldiv">
                        <asp:Label ID="spatreatmentlabel" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa1" Checked="true" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelabel" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle1" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList>
                        <br />
                       
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlabel" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID1" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices1" runat="server" OnClick="return getSelectedCheckboxValue(1);"
                                    Text="Select Service" CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                                <div class="petlabeldiv" style="width: 280px;">
                                    <asp:CheckBoxList ID="lstAddservices1" runat="Server" DataTextField="Name" DataValueField="ID"
                                        RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--    For Pet 2--%>
                <div class="divfirstpetinfo" id="dvPet2" runat="server">
                    <div class="deletediv">
                        <asp:CheckBox CssClass="chkMobileAppointment" ID="chkPet2" runat="server" AutoPostBack="true" OnCheckedChanged="chkPet2_CheckedChanged" />
                        <asp:ImageButton ID="imgDelete2" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete2_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label1" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType2" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType2_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID2" runat="server" Text="0" Visible="false"></asp:Label>
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
                        <asp:TextBox ID="txtDOB2" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
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
                        <asp:TextBox ID="txtPetWeight2" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
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
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrtlabel2" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa2" Checked="true" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelabel2" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle2" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList><br />

                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addserlabel2" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID2" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices2" runat="server" Text="Select Service" OnClick="return setList(2);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices2" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <%--    For Pet 3--%>
                <div class="divfirstpetinfo" id="dvPet3" runat="server">
                    <div class="deletediv">
                        <asp:CheckBox ID="chkPet3" CssClass="chkMobileAppointment" AutoPostBack="true" runat="server" OnCheckedChanged="chkPet3_CheckedChanged" />
                        <asp:ImageButton ID="imgDelete3" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete3_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label7" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType3" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType3_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID3" runat="server" Text="0" Visible="false"></asp:Label>
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
                        <asp:TextBox ID="txtDOB3" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
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
                        <asp:TextBox ID="txtPetWeight3" onkeypress="return decimalIntegerNumbers(event,this)"  runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
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
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt3" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox Checked="true" ID="chkSpa3" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl3" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle3" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList><br />
                      
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservicelbl3" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID3" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices3" runat="server" Text="Select Service" OnClick="return setList(3);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices3" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList3_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <%--    For Pet 4--%>
                <div class="divfirstpetinfo" id="dvPet4" runat="server">
                    <div class="deletediv">
                        <asp:CheckBox CssClass="chkMobileAppointment" ID="chkPet4" AutoPostBack="true" runat="server" OnCheckedChanged="chkPet4_CheckedChanged" />
                        <asp:ImageButton ID="imgDelete4" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete4_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label13" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType4" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType4_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID4" runat="server" Text="0" Visible="false"></asp:Label>
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
                        <asp:TextBox ID="txtDOB4" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
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
                        <asp:TextBox ID="txtPetWeight4" runat="server" onkeypress="return decimalIntegerNumbers(event,this)"  MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
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
                        <asp:TextBox ID="txtPetLength4" runat="server" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
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
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt4" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa4" Checked="true" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl4" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle4" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList><br />
                      
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlbl4" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID4" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices4" runat="server" Text="Select Service" OnClick="return setList(4);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices4" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList4_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <%--    For Pet 5--%>
                <div class="divfirstpetinfo" id="dvPet5" runat="server">
                    <div class="deletediv">
                        <asp:CheckBox CssClass="chkMobileAppointment" AutoPostBack="true" ID="chkPet5" runat="server" OnCheckedChanged="chkPet5_CheckedChanged" />
                        <asp:ImageButton ID="imgDelete5" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete5_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label19" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType5" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType5_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID5" runat="server" Text="0" Visible="false"></asp:Label>
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
                        <asp:TextBox ID="txtDOB5" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);" CssClass="shorttxtbox"></asp:TextBox><br />
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
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt5" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa5" Checked="true" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl5" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle5" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList><br />
                      
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlabel5" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID5" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices5" runat="server" Text="Select Service" OnClick="return setList(5);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices5" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList5_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                </div>
                <%--    For Pet 6--%>
                <div class="divfirstpetinfo" id="dvPet6" runat="server">
                    <div class="deletediv">
                        <asp:CheckBox CssClass="chkMobileAppointment" AutoPostBack="true" ID="chkPet6" runat="server" OnCheckedChanged="chkPet6_CheckedChanged" />
                        <asp:ImageButton ID="imgDelete6" runat="server" Height="20" Width="20" Visible="false"
                            ImageUrl="images/delete.png" ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="Label25" CssClass="shortlabel" runat="server">Pet</asp:Label><br />
                        <asp:DropDownList ID="ddlPetType6" CssClass="shortselectbox" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPetType6_OnSelectedIndexChanged">
                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="PetID6" runat="server" Text="0" Visible="false"></asp:Label>
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
                        <asp:TextBox ID="txtDOB6" runat="server" onkeypress="return IntegerNumbers(event);" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox><br />
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
                        <asp:TextBox ID="txtPetWeight6" runat="server" onkeypress="return decimalIntegerNumbers(event,this)" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs<br />
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
                        <asp:TextBox ID="txtPetLength6" runat="server" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches<br />
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
                    <div class="petlabeldiv">
                        <asp:Label ID="spatrt6" runat="server" CssClass="shortlabel">Spa Treatment</asp:Label><br />
                        <asp:CheckBox ID="chkSpa6" Checked="true" runat="server" />
                    </div>
                    <div class="petlabeldiv">
                        <asp:Label ID="stylelbl6" runat="server" CssClass="shortlabel">Style</asp:Label><br />
                        <asp:DropDownList ID="ddlStyle6" CssClass="shortselectbox" runat="server">
                        </asp:DropDownList><br />
                       
                    </div>
                    <div style="width: 298px; float: left;">
                        <div class="petlabeldiv" style="width: 280px;">
                            <asp:Label ID="addservlbl6" runat="server" CssClass="shortlabel">Additional Services</asp:Label><br />
                            <div>
                                <div style="display: none;">
                                    <asp:TextBox ID="txtAddServicesID6" runat="server"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtAddServices6" runat="server" Text="Select Service" OnClick="return setList(6);"
                                    CssClass="regddlFldAdservice" Style="display: none;"></asp:TextBox>
                            </div>
                            <div class="petlabeldiv" style="width: 280px;">
                                <asp:CheckBoxList ID="lstAddservices6" runat="Server" DataTextField="Name" DataValueField="ID"
                                    RepeatColumns="2" RepeatLayout="Table" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList6_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </div>
                        </div>
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
                <%--  <asp:AsyncPostBackTrigger ControlID="imgDelete6"  />--%>
            </Triggers>
        </asp:UpdatePanel>
        <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="imgAddmore" CssClass="button" runat="server" Text="Add More Pets" ValidationGroup="valReg_Basic" CausesValidation="true" OnClick="imgAddmore_Click" />&nbsp;&nbsp;
        <asp:Button runat="server" ID="ImageButton1" CssClass="button" Text="Edit My Account" ValidationGroup="valReg_Basic" CausesValidation="true" OnClick="ImageButton3_Click" />
        <br />
        <br />
        <asp:Label ID="lblNoPet" runat="server" ForeColor="red"></asp:Label>
        <div class="innerpageheading">
            <h2>
                <span class="heading">When?</span></h2>
            <div class="datediv">
                <br />
                <asp:Label ID="datelabel" CssClass="shortestlabel" runat="server">Date<span class="mand">*</span>:</asp:Label>
            </div>
            <div class="datediv">
                <asp:Label ID="mmlistlabel" CssClass="shortestlabel" runat="server">MM</asp:Label><br />
                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="dddrop">
                    <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                    <asp:ListItem Text="March" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                    <asp:ListItem Text="May" Value="5"></asp:ListItem>
                    <asp:ListItem Text="June" Value="6"></asp:ListItem>
                    <asp:ListItem Text="July" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Sept" Value="9"></asp:ListItem>
                    <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                    <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="datediv">
                <asp:Label ID="ddlistlabel" CssClass="shortestlabel" runat="server">DD</asp:Label><br />
                <asp:DropDownList ID="dddDay" CssClass="dddrop" runat="server">
                </asp:DropDownList>
            </div>
            <div class="datediv">
                <asp:Label ID="yylistlabel" CssClass="shortestlabel" runat="server">YY</asp:Label><br />
                <asp:DropDownList ID="ddlYear" CssClass="dddrop" runat="server">
                </asp:DropDownList>
            </div>
            <div class="datediv">
                <asp:Label ID="timelabel" CssClass="shortestlabel" runat="server">Time<span class="mand">*</span>:</asp:Label>
            </div>
            <div class="timediv">
                <asp:DropDownList ID="ddlhr" CssClass="timedrop" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlmin" CssClass="appTextFldAm" Visible="false" runat="server">
                    <asp:ListItem Value=" " Text=" "></asp:ListItem>
                    <asp:ListItem Value=" " Text=" "></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:CheckBox ID="chkalt" runat="server" Text="Flexible" CssClass="shortestlabel" onClick="ShowDiv();" />
            <div id="divalt" runat="server" style="display: none">
                <div class="timediv">
                    <asp:DropDownList ID="ddlFlex" runat="server" CssClass="appddlFldday"></asp:DropDownList>
                    <asp:DropDownList ID="ddlFlexDay" CssClass="appddlFldday" runat="server" Style="display: none;">
                        <asp:ListItem Text="Select One" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 day" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 day" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 day" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 day" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 day" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlFlexHr" CssClass="appddlFldhour" runat="server" Style="display: none;">
                        <asp:ListItem Text="1 hr" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 hr" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 hr" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 hr" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 hr" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <h2>
                <span class="heading">Where?</span></h2>
            <div class="wherediv">
                <asp:RadioButton ID="red1" runat="server" Text="Primary Address" Checked="true" onClick="return setred1();" /><br />
                <asp:TextBox ID="txtPrimary" runat="server" CssClass="wheretxtbox" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="wherediv">
                <asp:RadioButton ID="red2" runat="server" Text="Alternate Address" onClick="return setred2();" /><br />
                <asp:TextBox ID="txtAlternat" runat="server" CssClass="wheretxtbox" TextMode="MultiLine"></asp:TextBox>
            </div>
            <h2>
                <span class="heading">Confirm By</span></h2>
            <div class="wherediv">
                <asp:RadioButtonList ID="redConfirmBy" runat="server" RepeatDirection="Horizontal"
                    Width="200px">
                    <asp:ListItem Text="Email" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Phone" Value="1" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <h2>
                <span class="heading">Notes To The Groomer</span></h2>
            <asp:TextBox runat="server" ID="idtextarea" CssClass="txtarea" TextMode="MultiLine"
                MaxLength="250"></asp:TextBox>
            <asp:Button ID="IdNext" CssClass="button" Text="SCHEDULE" ValidationGroup="valReg_Basic" CausesValidation="true" runat="server" OnClick="IdNext_Click" />
        </div>
    </div>
</asp:Content>
