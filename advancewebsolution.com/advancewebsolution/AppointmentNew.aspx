<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" Inherits="AppointmentNew" MaintainScrollPositionOnPostback="true" CodeBehind="AppointmentNew.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>

    <script type="text/javascript" language="javascript">

        function setList(i) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display == "none") {
                document.getElementById("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_lstAddservices" + i).focus();
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "none";
            }
            return false;
        }
        function HideList(i) {
            document.getElementById("ctl00_ContentPlaceHolder1_lstAddservices" + i).style.display = "none";
            return false;
        }

        function SetText(i) {
            var Source = document.getElementById("ctl00_ContentPlaceHolder1_lstAddservices" + i);
            var str = "";
            var str1 = "";
            for (j = 0; j < document.getElementById("ctl00_ContentPlaceHolder1_lstAddservices" + i).length; j++) {
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

            document.getElementById("ctl00_ContentPlaceHolder1_txtAddServices" + i).value = str;
            document.getElementById("ctl00_ContentPlaceHolder1_txtAddServicesID" + i).value = str1;
        }


        function checkTextAreaMaxLength(textBox, e, length) {
            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;
            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                        e.returnValue = false;
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
        function checkSpecialKeys(e) {
            if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40)
                return false;
            else
                return true;
        }

        function ValYear(source, args) {
            var dteNow = new Date();
            var intYear = dteNow.getFullYear()
            if (args.Value.length != 4)
                args.IsValid = false;
            else if (args.Value == "0000")
                args.IsValid = false;
            else if (args.Value > intYear)
                args.IsValid = false;
            else
                args.IsValid = true;
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

        function SetAddress() {
            alert(document.getElementById("ctl00_ContentPlaceHolder1_redlist_1").Value);
            if (document.getElementById('<%=hdn.ClientID %>').value == "0") {
                //alert("1");
                document.getElementById('<%=txtPrimary.ClientID %>').enabled = true;
                document.getElementById('<%=txtAlternat.ClientID %>').enabled = false;
                document.getElementById('<%=hdn.ClientID %>').value = "1";
                return true;
            }
            else {
                //alert("2");
                document.getElementById('<%=hdn.ClientID %>').value = "0";
                document.getElementById('<%=txtPrimary.ClientID %>').enabled = false;
                document.getElementById('<%=txtAlternat.ClientID %>').enabled = true;
                return true;
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
        function Notify() {
            if (alert("Please Select Pet")) {
                return false;
            }
        }

    </script>

    <!--[if IE]>
	    <link href="ie.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <asp:HiddenField ID="hdn" runat="server" Value="0" />
    <div id="mainPlaceholder">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="regMain">
                        <!-- reg main start here -->
                        <div id="regTitle">
                            <asp:Image ID="ImgScheduled" ImageUrl="~/Images/regScheduleTitle.jpg" runat="server" />
                        </div>
                        <div id="regTopContent">
                            <!-- reg top start here -->
                            <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        </div>
                        <!-- reg top end here -->
                        <div style="clear: both;">
                        </div>
                        <div class="regForm">
                            <div class="regFormTop">
                            </div>
                            <div class="regFormMid">
                                <div class="ApptForm" onkeypress="javascript:return FormPanel_FireDefaultButton(event,'ctl00_ContentPlaceHolder1_IdNext')">
                                    <div id="divSuccess" runat="server">
                                        <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblErrorDate" runat="server" ForeColor="Blue" Font-Bold="true" Font-Size="Small"></asp:Label>
                                        <asp:Label ID="lblerror" runat="server" Text="" Visible="false" ForeColor="Red" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                    </div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="IdWhoWhat" ImageUrl="~/Images/reg_who_what_title1.jpg" runat="server" Width="602px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:UpdatePanel ID="up123" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <table cellspacing="6" border="0">
                                                <tr>
                                                    <th>Select<br />
                                                        Pet </th>
                                                    <th>Pet</th>
                                                    <th style="width: auto">PetName</th>
                                                    <th>Breed</th>
                                                    <th>Birth Year </th>
                                                    <th>Weight<br />
                                                        <p>(lbs)</p>
                                                    </th>
                                                    <th class="auto-style1">Fur Length<br />
                                                        <p>(inches) </p>
                                                    </th>
                                                    <th>Spa<br />
                                                        Treatment</th>
                                                    <th>Style</th>
                                                    <th width="87px">Additional Services<br />
                                                        <p>
                                                            Ctrl+click for<br />
                                                            multiple selection
                                                        </p>
                                                    </th>
                                                </tr>
                                                <tr id="p1" runat="server">
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkPet1" runat="server" />
                                                    </td>
                                                    <td>

                                                        <asp:DropDownList ID="ddlPetType1" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType1_SelectedIndexChanged" Width="50px">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName1" CssClass="regTextFldpetnameAppoint" runat="server"
                                                            MaxLength="20" Width="99px"></asp:TextBox>
                                                        <asp:Label ID="PetID1" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ReqVal1" ControlToValidate="txtPetName1" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet1" TargetControlID="ReqVal1" HighlightCssClass="validatorCalloutHighlight"
                                                            Enabled="true" runat="Server" PopupPosition="TopLeft" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed1" CssClass="regTextFldBread1Appt" runat="server" OnSelectedIndexChanged="ddlBreed1_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl2" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed1"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" TargetControlID="ReqVal2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" PopupPosition="TopLeft" />
                                                    </td>

                                                    <td>
                                                        <asp:TextBox ID="txtPetDOB1" CssClass="regTextFldbyearAppoint" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVal3" ControlToValidate="txtPetDOB1" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet3" TargetControlID="ReqVal3" HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopLeft"
                                                            Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqPet4" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year ."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetDOB1"
                                                            ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender6" TargetControlID="ReqPet4" PopupPosition="TopLeft"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear1" ValidationGroup="valPet" ControlToValidate="txtPetDOB1"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="custYear1" PopupPosition="TopLeft"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight1" CssClass="regTextFldstate" runat="server" MaxLength="6" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Reqval4" ControlToValidate="txtPetWeight1" ErrorMessage="<b>Required Field Missing</b><br />Weight is required."
                                                            ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet4" TargetControlID="Reqval4" HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopLeft"
                                                            Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqPet6" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetWeight1"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="VCEPet5" TargetControlID="ReqPet6" PopupPosition="TopLeft"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:TextBox ID="txtPetLength1" MaxLength="6" CssClass="regTextFldflengthApp" runat="server" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Reqval7" ControlToValidate="txtPetLength1" ErrorMessage="<b>Required Field Missing</b><br />Length is required."
                                                            ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="VCEPet6" TargetControlID="Reqval7" HighlightCssClass="validatorCalloutHighlight" PopupPosition="TopLeft"
                                                            Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="Reqval8" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetLength1"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="VCEPet7" TargetControlID="Reqval8" PopupPosition="TopLeft"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSpa1" runat="server" Checked="true" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStyle1" CssClass="regTextfldStyle" runat="server" Width="90px">
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <div>
                                                            <div style="display: none;">
                                                                <asp:TextBox ID="txtAddServicesID1" runat="server"></asp:TextBox>
                                                            </div>
                                                            <asp:TextBox ID="txtAddServices1" runat="server" OnClick="return setList(1);" Text="Select Service"
                                                                CssClass="regddlFldAdservice" placeHolder="Select Service"></asp:TextBox>
                                                            <asp:ImageButton ID="ImgAdservices1" Style="margin-top: 0px;" runat="server" ImageUrl="~/Images/DDImage.bmp"
                                                                OnClientClick="return setList(1);" CssClass="imgbutton" />
                                                        </div>
                                                        <div class="apptDrpDiv">
                                                            <asp:ListBox ID="lstAddservices1" runat="server" CssClass="apptListbox" onclick="return SetText(1);" SelectionMode="Multiple"
                                                                Style="display: none;" onblur="return HideList(1);"
                                                                placeHolder="Select Service"></asp:ListBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete1" runat="server" Visible="false" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" OnClick="imgDelete1_Click" OnClientClick="return confirmation();" />
                                                    </td>
                                                </tr>

                                                <tr id="p2" runat="server">

                                                    <td align="center">
                                                        <asp:CheckBox ID="chkPet2" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType2" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType2_SelectedIndexChanged" Width="50px">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName2" CssClass="regTextFldpetnameAppoint" runat="server"
                                                            MaxLength="20" Width="99px"></asp:TextBox>
                                                        <asp:Label ID="PetID2" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ReqVAl21" ControlToValidate="txtPetName2" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" TargetControlID="ReqVAl21"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed2" CssClass="regTextFldBread1Appt" runat="server" OnSelectedIndexChanged="ddlBreed2_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl22" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed2"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" TargetControlID="ReqVal22"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB2" CssClass="regTextFldbyearAppoint" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl23" ControlToValidate="txtDOB2" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" TargetControlID="ReqVAl23"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB2" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtDOB2" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender10" TargetControlID="RegDOB2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear2" ValidationGroup="valPet" ControlToValidate="txtDOB2"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="custYear2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight2" CssClass="regTextFldstate" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl24" ControlToValidate="txtPetWeight2" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" TargetControlID="ReqVAl24"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight2" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetWeight2"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender12" TargetControlID="RegWeight2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:TextBox ID="txtPetLength2" CssClass="regTextFldflengthApp" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl25" ControlToValidate="txtPetLength2" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" TargetControlID="ReqVAl25"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength2" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetLength2"
                                                            ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender14" TargetControlID="ReqLength2"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSpa2" runat="server" Checked="true" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStyle2" CssClass="regTextfldStyle" runat="server" Width="90px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <div style="display: none;">
                                                                <asp:TextBox ID="txtAddServicesID2" runat="server"></asp:TextBox>
                                                            </div>
                                                            <asp:TextBox ID="txtAddServices2" runat="server" Text="Select Service" OnClick="return setList(2);"
                                                                CssClass="regddlFldAdservice" placeHolder="Select Service"> </asp:TextBox>
                                                            <asp:ImageButton ID="ImgAdservices2" Style="margin-top: 0px;" runat="server" ImageUrl="~/Images/DDImage.bmp"
                                                                OnClientClick="return setList(2);" CssClass="imgbutton" />
                                                        </div>
                                                        <div class="apptDrpDiv">
                                                            <asp:ListBox ID="lstAddservices2" runat="server" CssClass="apptListbox" SelectionMode="Multiple"
                                                                Style="display: none;" OnClick="return SetText(2);" onblur="return HideList(2);"
                                                                placeHolder="Select Service"></asp:ListBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete2" runat="server" Visible="false" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" OnClick="imgDelete2_Click" OnClientClick="return confirmation();" />
                                                    </td>
                                                </tr>
                                                <tr id="p3" runat="server">

                                                    <td align="center">
                                                        <asp:CheckBox ID="chkPet3" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType3" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType3_SelectedIndexChanged" Width="50px">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName3" CssClass="regTextFldpetnameAppoint" runat="server"
                                                            MaxLength="30" Width="99px"></asp:TextBox>
                                                        <asp:Label ID="PetID3" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ReqVAl31" ControlToValidate="txtPetName3" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" TargetControlID="ReqVAl31"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed3" CssClass="regTextFldBread1Appt" runat="server" OnSelectedIndexChanged="ddlBreed3_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl32" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed3"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" TargetControlID="ReqVAl32"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB3" CssClass="regTextFldbyearAppoint" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL33" ControlToValidate="txtDOB3" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" TargetControlID="ReqVAL33"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB3" ControlToValidate="txtDOB3" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender18" TargetControlID="RegDOB3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear3" ValidationGroup="valPet" ControlToValidate="txtDOB3"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender3" TargetControlID="custYear3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight3" CssClass="regTextFldstate" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl34" ControlToValidate="txtPetWeight3" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" TargetControlID="ReqVAl34"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight3" ControlToValidate="txtPetWeight3"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender20" TargetControlID="RegWeight3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:TextBox ID="txtPetLength3" CssClass="regTextFldflengthApp" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL35" ControlToValidate="txtPetLength3" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" TargetControlID="ReqVAL35"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength3" ControlToValidate="txtPetLength3"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender22" TargetControlID="ReqLength3"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSpa3" runat="server" Checked="true" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStyle3" CssClass="regTextfldStyle" runat="server" Width="90px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <div style="display: none;">
                                                                <asp:TextBox ID="txtAddServicesID3" runat="server"></asp:TextBox>
                                                            </div>
                                                            <asp:TextBox ID="txtAddServices3" runat="server" Text="Select Service" OnClick="return setList(3);"
                                                                CssClass="regddlFldAdservice" placeHolder="Select Service"></asp:TextBox>
                                                            <asp:ImageButton ID="ImgAdservices3" Style="margin-top: 0px;" runat="server" ImageUrl="~/Images/DDImage.bmp"
                                                                OnClientClick="return setList(3);" CssClass="imgbutton" />
                                                        </div>
                                                        <div class="apptDrpDiv">
                                                            <asp:ListBox ID="lstAddservices3" runat="server" CssClass="apptListbox" SelectionMode="Multiple"
                                                                Style="display: none;" OnClick="return SetText(3);" onblur="return HideList(3);"
                                                                placeHolder="Select Service"></asp:ListBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete3" runat="server" Visible="false" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" OnClick="imgDelete3_Click" OnClientClick="return confirmation();" />
                                                    </td>
                                                </tr>
                                                <tr id="p4" runat="server">

                                                    <td align="center">
                                                        <asp:CheckBox ID="chkPet4" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType4" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType4_SelectedIndexChanged" Width="50px">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName4" CssClass="regTextFldpetnameAppoint" runat="server"
                                                            MaxLength="30" Width="99px"></asp:TextBox>
                                                        <asp:Label ID="PetID4" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ReqVAl41" ControlToValidate="txtPetName4" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" TargetControlID="ReqVAl41"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed4" CssClass="regTextFldBread1Appt" runat="server" OnSelectedIndexChanged="ddlBreed4_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl42" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed4"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" TargetControlID="ReqVAl42"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB4" CssClass="regTextFldbyearAppoint" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL43" ControlToValidate="txtDOB4" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" TargetControlID="ReqVAL43"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB4" ControlToValidate="txtDOB4" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender26" TargetControlID="RegDOB4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear4" ValidationGroup="valPet" ControlToValidate="txtDOB4"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4" TargetControlID="custYear4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight4" CssClass="regTextFldstate" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl44" ControlToValidate="txtPetWeight4" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender27" TargetControlID="ReqVAl44"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight4" ControlToValidate="txtPetWeight4"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender28" TargetControlID="RegWeight4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:TextBox ID="txtPetLength4" CssClass="regTextFldflengthApp" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL45" ControlToValidate="txtPetLength4" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender29" TargetControlID="ReqVAL45"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength4" ControlToValidate="txtPetLength4"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender30" TargetControlID="ReqLength4"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSpa4" runat="server" Checked="true" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStyle4" CssClass="regTextfldStyle" runat="server" Width="90px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <div style="display: none;">
                                                                <asp:TextBox ID="txtAddServicesID4" runat="server"></asp:TextBox>
                                                            </div>
                                                            <asp:TextBox ID="txtAddServices4" runat="server" Text="Select Service" OnClick="return setList(4);"
                                                                CssClass="regddlFldAdservice" placeHolder="Select Service"></asp:TextBox>
                                                            <asp:ImageButton ID="ImgAdservices4" Style="margin-top: 0px;" runat="server" ImageUrl="~/Images/DDImage.bmp"
                                                                OnClientClick="return setList(4);" CssClass="imgbutton" />
                                                        </div>
                                                        <div class="apptDrpDiv">
                                                            <asp:ListBox ID="lstAddservices4" runat="server" CssClass="apptListbox" SelectionMode="Multiple"
                                                                Style="display: none;" OnClick="return SetText(4);" onblur="return HideList(4);"
                                                                placeHolder="Select Service"></asp:ListBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete4" runat="server" Visible="false" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" OnClick="imgDelete4_Click" OnClientClick="return confirmation();" />
                                                    </td>
                                                </tr>
                                                <tr id="p5" runat="server">

                                                    <td align="center">
                                                        <asp:CheckBox ID="chkPet5" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType5" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType5_SelectedIndexChanged" Width="50px">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName5" CssClass="regTextFldpetnameAppoint" runat="server"
                                                            MaxLength="30" Width="99px"></asp:TextBox>
                                                        <asp:Label ID="PetID5" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ReqVAl51" ControlToValidate="txtPetName5" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender31" TargetControlID="ReqVAl51"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed5" CssClass="regTextFldBread1Appt" runat="server" OnSelectedIndexChanged="ddlBreed5_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl52" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed5"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender32" TargetControlID="ReqVAl52"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB5" CssClass="regTextFldbyearAppoint" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL53" ControlToValidate="txtDOB5" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender33" TargetControlID="ReqVAL53"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB5" ControlToValidate="txtDOB5" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender34" TargetControlID="RegDOB5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear5" ValidationGroup="valPet" ControlToValidate="txtDOB5"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender42" TargetControlID="custYear5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight5" CssClass="regTextFldstate" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl54" ControlToValidate="txtPetWeight5" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender35" TargetControlID="ReqVAl54"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight5" ControlToValidate="txtPetWeight5"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender36" TargetControlID="RegWeight5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:TextBox ID="txtPetLength5" CssClass="regTextFldflengthApp" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL55" ControlToValidate="txtPetLength5" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender37" TargetControlID="ReqVAL55"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength5" ControlToValidate="txtPetLength5"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender38" TargetControlID="ReqLength5"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSpa5" runat="server" Checked="true" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStyle5" CssClass="regTextfldStyle" runat="server" Width="90px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <div style="display: none;">
                                                                <asp:TextBox ID="txtAddServicesID5" runat="server"></asp:TextBox>
                                                            </div>
                                                            <asp:TextBox ID="txtAddServices5" runat="server" Text="Select Service" OnClick="return setList(5);"
                                                                CssClass="regddlFldAdservice" placeHolder="Select Service"></asp:TextBox>
                                                            <asp:ImageButton ID="ImgAdservices5" Style="margin-top: 0px;" runat="server" ImageUrl="~/Images/DDImage.bmp"
                                                                OnClientClick="return setList(5);" CssClass="imgbutton" />
                                                        </div>
                                                        <div class="apptDrpDiv">
                                                            <asp:ListBox ID="lstAddservices5" runat="server" CssClass="apptListbox" SelectionMode="Multiple"
                                                                Style="display: none;" OnClick="return SetText(5);" onblur="return HideList(5);"
                                                                placeHolder="Select Service"></asp:ListBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete5" runat="server" Visible="false" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" OnClick="imgDelete5_Click" OnClientClick="return confirmation();" />
                                                    </td>
                                                </tr>
                                                <tr id="p6" runat="server">

                                                    <td align="center">
                                                        <asp:CheckBox ID="chkPet6" runat="server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPetType6" CssClass="regddlField" runat="server" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlPetType6_SelectedIndexChanged" Width="50px">
                                                            <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetName6" CssClass="regTextFldpetnameAppoint" runat="server"
                                                            MaxLength="20" Width="99px"></asp:TextBox>
                                                        <asp:Label ID="PetID6" runat="server" Text="0" Visible="false"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="ReqVAl61" ControlToValidate="txtPetName6" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender39" TargetControlID="ReqVAl61"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBreed6" CssClass="regTextFldBread1Appt" runat="server" OnSelectedIndexChanged="ddlBreed6_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="ReqVAl62" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed6"
                                                            ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                                                            ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender40" TargetControlID="ReqVAl62"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDOB6" CssClass="regTextFldbyearAppoint" runat="server" MaxLength="4" onkeypress="return IntegerNumbers(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL63" ControlToValidate="txtDOB6" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender41" TargetControlID="ReqVAL63"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegDOB6" ControlToValidate="txtDOB6" runat="server"
                                                            Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender43" TargetControlID="RegDOB6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                        <asp:CustomValidator runat="server" ID="custYear6" ValidationGroup="valPet" ControlToValidate="txtDOB6"
                                                            Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender48" TargetControlID="custYear6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPetWeight6" CssClass="regTextFldstate" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAl64" ControlToValidate="txtPetWeight6" ErrorMessage="<b>Required Field Missing</b><br />Pet weight is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender44" TargetControlID="ReqVAl64"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="RegWeight6" ControlToValidate="txtPetWeight6"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender45" TargetControlID="RegWeight6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td class="auto-style1">
                                                        <asp:TextBox ID="txtPetLength6" CssClass="regTextFldflengthApp" runat="server" MaxLength="5" onkeypress="return decimalIntegerNumbers(event,this)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ReqVAL65" ControlToValidate="txtPetLength6" ErrorMessage="<b>Required Field Missing</b><br />Fur length is required."
                                                            Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                                                        </asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender46" TargetControlID="ReqVAL65"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" runat="Server" />
                                                        <asp:RegularExpressionValidator ID="ReqLength6" ControlToValidate="txtPetLength6"
                                                            runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                                                            ValidationGroup="valPet" SetFocusOnError="true" ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender47" TargetControlID="ReqLength6"
                                                            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:CheckBox ID="chkSpa6" runat="server" Checked="true" />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStyle6" CssClass="regTextfldStyle" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <div>
                                                            <div style="display: none;">
                                                                <asp:TextBox ID="txtAddServicesID6" runat="server" Width="90px"></asp:TextBox>
                                                            </div>
                                                            <asp:TextBox ID="txtAddServices6" runat="server" Text="Select Service" OnClick="return setList(6);"
                                                                CssClass="regddlFldAdservice" placeHolder="Select Service"></asp:TextBox>
                                                            <asp:ImageButton ID="ImgAdservices6" runat="server" Style="margin-top: 0px;" ImageUrl="~/Images/DDImage.bmp"
                                                                OnClientClick="return setList(6);" CssClass="imgbutton" />
                                                        </div>
                                                        <div class="apptDrpDiv">
                                                            <asp:ListBox ID="lstAddservices6" runat="server" CssClass="apptListbox" SelectionMode="Multiple"
                                                                Style="display: none;" OnClick="return SetText(6);" onblur="return HideList(6);"
                                                                placeHolder="Select Service"></asp:ListBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="imgDelete6" runat="server" Visible="false" ImageUrl="~/Images/deleteicon.gif"
                                                            ToolTip="Delete" OnClick="imgDelete6_Click" OnClientClick="return confirmation();" />
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td colspan="8">
                                                        <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>
                                                        <asp:ImageButton ID="imgAddmore" ImageUrl="~/Images/regAddpetbtn.jpg" runat="server"
                                                            OnClick="imgAddmore_Click" CausesValidation="true" ValidationGroup="valPet" />
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td colspan="8">
                                                        <asp:ImageButton ID="ImageButton1" ImageUrl="~/Images/regEDitbtn.jpg" runat="server"
                                                            OnClick="ImageButton3_Click" />
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td colspan="8">
                                                        <asp:Label ID="lblNoPet" runat="server" ForeColor="red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="9">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlBreed1" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlBreed2" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlBreed3" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlBreed4" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlBreed5" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlBreed6" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="ImgWhenTitle" runat="server" ImageUrl="~/Images/reg_when_title.jpg" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="calendertable">
                                        <tr>
                                            <td colspan="2" class="paddingforcalender">
                                                <asp:ImageButton ID="imgCalPop" runat="server" ImageUrl="~/Images/calImage.jpg" Visible="false" />



                                                <asp:UpdatePanel runat="server" ID="upCalData" UpdateMode="Conditional" ChildrenAsTriggers="True">
                                                    <ContentTemplate>
                                                        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel runat="server" ID="upTxtTransDate" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtDate" runat="server" Width="0px" Height="0px" CssClass="dateTxt" AutoPostBack="true"
                                                            Text="01/01/2009"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="appointtd">
                                                <label>
                                                    Date</label><span>*</span>
                                            </td>
                                            <td style="width: 214px">

                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtSelectDate" ReadOnly="true" CssClass="regTextFldpetnameAppoint"
                                                            runat="server"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="appointtd">
                                                <label>
                                                    Time</label><span>*</span>
                                            </td>
                                            <td style="width: 214px">
                                                <asp:UpdatePanel ID="UpButton1" runat="server">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                                                        <asp:PostBackTrigger ControlID="ddlhr" />
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:Button ID="Button1" runat="server" Style="display: none" OnClick="Button1_Click"
                                                            Text="Button" />
                                                        <asp:DropDownList ID="ddlhr" CssClass="appTextFldtime2" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlmin" CssClass="appTextFldAm" Visible="false" runat="server">
                                                            <asp:ListItem Value=" " Text=" "></asp:ListItem>
                                                            <asp:ListItem Value=" " Text=" "></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td style="width: 214px">
                                                <asp:CheckBox ID="chkalt" runat="server" Text="Flexible" onClick="ShowDiv();" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                            <td style="width: 214px">
                                                <div id="divalt" runat="server" style="display: none">
                                                    <asp:DropDownList ID="ddlFlex" runat="server" CssClass="appddlFldday">
                                                    </asp:DropDownList>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/reg_where_title.jpg" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="8">
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="red1" runat="server" Text="Primary Address" Checked="true" onClick="return setred1();" />
                                                <br />
                                                <asp:TextBox Height="60px" Rows="5" Columns="20" TextMode="MultiLine" ID="txtPrimary"
                                                    CssClass="appTextFldprimary" runat="server" onkeyDown="checkTextAreaMaxLength(this,event,'99');"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="red2" runat="server" Text="Alternate Address" onClick="return setred2();" />
                                                <br />
                                                <asp:TextBox Height="60px" Rows="5" Columns="20" TextMode="MultiLine" ID="txtAlternat"
                                                    CssClass="appTextFldAlternate" runat="server" onkeyDown="checkTextAreaMaxLength(this,event,'99');"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/reg_confirmby.jpg" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="8">
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="redConfirmBy" runat="server" RepeatDirection="Horizontal"
                                                    Width="200px">
                                                    <asp:ListItem Text="Email" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Phone" Value="1" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/reg_notes.jpg" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table cellspacing="8">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="idtextarea" Rows="5" Columns="20" TextMode="MultiLine" CssClass="appTextFldTextArea"
                                                    runat="server" onkeyDown="checkTextAreaMaxLength(this,event,'200');"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="padding-left: 5px;">
                                                <asp:ImageButton ID="IdNext" ImageUrl="~/Images/regScheduleBtn.jpg" runat="server" OnClick="IdNext_Click" OnClientClick="return checkPetSelection();" />
                                            </td>
                                            <td align="right" style="padding-right: 10px;">
                                                <table>
                                                    <tr>
                                                        <td colspan="2" class="tdstylemend" align="left">Note:
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdstylemendtory" align="left">1.
                                                        </td>
                                                        <td class="tdstylemendtory" align="left">
                                                            <span>*</span>&nbsp;required
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdstylemendtory" align="left">2.
                                                        </td>
                                                        <td class="tdstylemendtory">6 Pets per Registration Maximum
                                                        </td>
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
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 71px;
        }
    </style>
</asp:Content>

