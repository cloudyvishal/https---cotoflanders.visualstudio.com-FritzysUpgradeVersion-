<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="MB_contactus" EnableViewState="false" ViewStateMode="Disabled" Title="Mobile Grooming Services" CodeBehind="MB_contactus.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function validate() {

            if (document.getElementById('<%=txtFName.ClientID %>').value == "") {

                alert("Please Enter First Name.");
                document.getElementById('<%=txtFName.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtLName.ClientID %>').value == "") {

                alert("Please Enter Last Name.");
                document.getElementById('<%=txtLName.ClientID %>').focus();
                return false;
            }

            if (document.getElementById('<%=txtContactEmail.ClientID %>').value == "") {

                alert("Please Enter Email.");
                document.getElementById('<%=txtContactEmail.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtMobile.ClientID %>').value) == false) {
                alert("Not a valid Phone No.");
                document.getElementById('<%=txtMobile.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtMessage.ClientID %>').value == "") {

                alert("Please Enter Message.");
                document.getElementById('<%=txtMessage.ClientID %>').focus();
                return false;
            }
            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/
            var Email = document.getElementById('<%=txtContactEmail.ClientID %>').value;
            var EmailmatchArray = Email.match(emailPat);
            if (EmailmatchArray == null) {
                alert("Your email address seems incorrect. Please try again.");
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
            <h1>Contact Us <a href="tel:18773748997"><span class="subheading">&nbsp;&nbsp;Call! 877-374-8997</span></a></h1>
        </div>
        <div class="innercontent">
            <p class="contactustxt">
                <b>Fritzy's Pet Care Pros, Incorporated</b>
            </p>
            <p class="contactustxt">
                15510 Rockfield Blvd., Suite B110,<br />
                Irvine, CA, 92618.
            </p>
            <p class="contactustxt">
                Email:&nbsp;<a href="mailto:customerservice@fritziespetcarepros.com" class="contactus"><b>customerservice@fritziespetcarepros.com</b></a>
            </p>
            <div id="divError" runat="server" visible="false">
                <table width="100%">
                    <tbody>
                        <tr>
                            <td align="left" rowspan="2">
                                <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="forform">
                <form action="#">
                    <asp:Label runat="server" ID="LblLastName" CssClass="label">First Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox CssClass="txtbox" ID="txtFName" runat="server" EnableViewState="false" autocomplete="off" ViewStateMode="Disabled"></asp:TextBox><br />
                    <asp:Label runat="server" ID="lastname" CssClass="label">Last Name<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtLName" CssClass="txtbox" autocomplete="off" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox><br />
                    <asp:Label runat="server" ID="emaillabel" CssClass="label">Email<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtContactEmail" CssClass="txtbox" autocomplete="off" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                    <br />
                    <asp:Label runat="server" ID="phonelabel" CssClass="label">Phone</asp:Label><br />
                    <asp:TextBox runat="server" ID="txtMobile" CssClass="txtbox" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox><br />
                    <asp:Label runat="server" ID="msglabel" CssClass="label">Message<span class="mand">*</span></asp:Label><br />
                    <asp:TextBox runat="server" ID="txtMessage" CssClass="txtarea" TextMode="MultiLine" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox><br />
                    <asp:Button runat="server" CssClass="button" ID="btnSave" OnClientClick="return validate();"
                        OnClick="btnSave_Click" Text="SEND" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
