<%@ Page Title="" Language="C#" MasterPageFile="~/mobileweb/Inner_Page_MB_MasterPage.master"
    AutoEventWireup="true" Inherits="mobileweb_MB_appointment_registration_new" CodeBehind="MB_appointment_registration_new.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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
            if (IsNumeric(document.getElementById('<%=txtPhone.ClientID %>').value) == false) {
                alert("Not a valid Phone No.");
                document.getElementById('<%=txtPhone.ClientID %>').focus();
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

    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>Registration</h1>
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
            <asp:Label ID="lblErrorEmail" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Label ID="lblCaptchaError" runat="server" Visible="false" ForeColor="red"></asp:Label>
            <h2>
                <span class="heading">Your Information</span></h2>
            <div class="forform">
                <form action="#">
                    <asp:Label runat="server" ID="firstname" CssClass="label">First Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox CssClass="txtbox" ID="txtFirstName" MaxLength="30" runat="server"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lastname" CssClass="label">Last Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtLastName" MaxLength="30" CssClass="txtbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="streetaddresslabel" CssClass="label">Street Address<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtStreet" MaxLength="60" CssClass="txtbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="citylable" CssClass="label">City<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtCity" MaxLength="30" CssClass="txtbox"></asp:TextBox><br />
                    <div class="divforstate-zip">
                        <div class="divstate">
                            <asp:Label ID="statelabel" CssClass="shortlabel" runat="server">State<span class="mand">*</span></asp:Label><br />
                            <asp:DropDownList ID="ddlState" CssClass="shortselectbox" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="divstate">
                            <asp:Label runat="server" CssClass="shortlabel" ID="ziplabel">Zip<span class="mand">*</span></asp:Label><br />
                            <asp:TextBox runat="server" CssClass="shorttxtbox" MaxLength="5" ID="txtZip"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Label runat="server" CssClass="label" ID="phonelabel">Phone<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" MaxLength="15" ID="txtPhone"></asp:TextBox><br />
                    <asp:Label runat="server" CssClass="label" ID="Label32">Mobile</asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" ID="txtAltMobile"></asp:TextBox><br />
                    <asp:Label runat="server" CssClass="label" ID="mobilelabel">Alternate Contact</asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" ID="txtAltContact"></asp:TextBox><br />
                    <asp:Label runat="server" ID="altstreetaddress" CssClass="label">Alternate Street Address</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtAltStreet" CssClass="txtbox"></asp:TextBox><br />
                    <asp:Label runat="server" ID="alternatecitylabel" CssClass="label">City</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtAltCity" CssClass="txtbox"></asp:TextBox><br />
                    <div class="divforstate-zip">
                        <div class="divstate">
                            <asp:Label ID="alternatestatelabel" CssClass="shortlabel" runat="server">State</asp:Label><br />
                            <asp:DropDownList ID="ddlState1" CssClass="shortselectbox" runat="server">
                                <asp:ListItem>State</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="divstate">
                            <asp:Label runat="server" CssClass="shortlabel" ID="alternateziplabel">Zip</asp:Label><br />
                            <asp:TextBox runat="server" CssClass="shorttxtbox" ID="txtAltZip"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Label runat="server" CssClass="label" ID="Label33">Alternate Phone</asp:Label><br />
                    <asp:TextBox ID="txtAltPhone" CssClass="txtbox" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:Label runat="server" CssClass="label" ID="referrellabel">Referral Source<span class="mand">*</span></asp:Label><br />
                    <asp:DropDownList runat="server" CssClass="selectbox" ID="ddlReferralSource">
                    </asp:DropDownList>
                    <br />
                    <asp:Label runat="server" CssClass="label" ID="Label31">Preferred Groomer</asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" ID="txtGroomer"></asp:TextBox><br />
                    <asp:Label runat="server" CssClass="label" ID="Label34">Email</asp:Label><br />
                    <asp:TextBox runat="server" CssClass="txtbox" ID="txtEmailReg"></asp:TextBox><br />
                    <h2>
                        <span class="heading">Your Pet Information</span></h2>
                    <asp:UpdatePanel ID="up12" runat="server">
                        <ContentTemplate>
                            <%--    For Pet 1--%>
                            <div class="divfirstpetinfo" id="dvPet1" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete1" Height="20" Width="20" runat="server" ImageUrl="~/Mobile/images/delete.png"
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
                                    <asp:TextBox ID="txtPetName1" CssClass="shorttxtbox" MaxLength="20" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="breedlabel" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed1" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="birthlabel" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtPetDOB1" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="weightlabel" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight1" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="furlenghtlabel" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength1" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                </div>
                            </div>
                            <%--    For Pet 2--%>
                            <div class="divfirstpetinfo" id="dvPet2" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete2" Height="20" Width="20" runat="server" ImageUrl="~/Mobile/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete1_Click" />
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
                                    <asp:TextBox ID="txtPetName2" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label3" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed2" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label4" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB2" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label5" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight2" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label6" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength2" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                </div>
                            </div>
                            <%--    For Pet 3--%>
                            <div class="divfirstpetinfo" id="dvPet3" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete3" Height="20" Width="20" runat="server" ImageUrl="~/Mobile/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete1_Click" />
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
                                    <asp:TextBox ID="txtPetName3" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label9" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed3" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label10" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB3" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label11" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight3" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label12" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength3" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                </div>
                            </div>
                            <%--    For Pet 4--%>
                            <div class="divfirstpetinfo" id="dvPet4" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete4" Height="20" Width="20" runat="server" ImageUrl="~/Mobile/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete1_Click" />
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
                                    <asp:TextBox ID="txtPetName4" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label15" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed4" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label16" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB4" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label17" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight4" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label18" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength4" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                </div>
                            </div>
                            <%--    For Pet 5--%>
                            <div class="divfirstpetinfo" id="dvPet5" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete5" Height="20" Width="20" runat="server" ImageUrl="~/Mobile/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete1_Click" />
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
                                    <asp:TextBox ID="txtPetName5" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label21" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed5" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label22" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB5" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label23" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight5" MaxLength="6" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label24" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength5" MaxLength="6" runat="server" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                </div>
                            </div>
                            <%--    For Pet 6--%>
                            <div class="divfirstpetinfo" id="dvPet6" runat="server">
                                <div class="deletediv">
                                    <asp:ImageButton ID="imgDelete6" Height="20" Width="20" runat="server" ImageUrl="~/Mobile/images/delete.png"
                                        ToolTip="Delete" Visible="false" OnClientClick="return confirmation();" OnClick="imgDelete1_Click" />
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
                                    <asp:TextBox ID="txtPetName6" CssClass="shorttxtbox" MaxLength="30" runat="server"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label27" CssClass="shortlabel" runat="server">Breed</asp:Label><br />
                                    <asp:DropDownList ID="ddlBreed6" CssClass="shortselectbox" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label28" runat="server" CssClass="shortlabel">Birth Year</asp:Label><br />
                                    <asp:TextBox ID="txtDOB6" runat="server" MaxLength="4" CssClass="shorttxtbox"></asp:TextBox>
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label29" runat="server" CssClass="shortlabel">Weight</asp:Label><br />
                                    <asp:TextBox ID="txtPetWeight6" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;lbs
                                </div>
                                <div class="petlabeldiv">
                                    <asp:Label ID="Label30" runat="server" CssClass="shortlabel">Fur Length</asp:Label><br />
                                    <asp:TextBox ID="txtPetLength6" runat="server" MaxLength="6" CssClass="smalltxtbox"></asp:TextBox>&nbsp;&nbsp;inches
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Label ID="lblMessageSix" runat="server" Visible="false"></asp:Label>

                    <asp:Button ID="imgAddmore" CssClass="button" runat="server" Text="Add More Pets"
                        CausesValidation="true" OnClick="imgAddmore_Click" /><br />
                    <br />

                    <asp:Button runat="server" ID="IdNext" CssClass="button" Text="Update" OnClientClick="return validate();"
                        OnClick="IdNext_Click" />&nbsp;&nbsp;
                
                <asp:Button runat="server" ID="IdReset" CssClass="button" OnClick="IdReset_Click"
                    Text="Update &amp; Set Appointment" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
