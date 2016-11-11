<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="Inventory" Title="Inventory" Codebehind="Inventory.aspx.cs" %>

<%@ Register TagPrefix="Mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function validate() {

            if (IsNumeric(document.getElementById('<%=txtFleaTick22.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaTick22.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtFleaTick22.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaTick44.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaTick44.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtFleaTick44.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaTick88.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaTick88.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtFleaTick88.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaTick132.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaTick132.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtFleaTick132.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtFleaTickCat.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblFleaTickCat.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtFleaTickCat.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtToothbrushes.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblToothbrushes.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtToothbrushes.ClientID %>').focus();
                return false;
            }

            if (IsNumeric(document.getElementById('<%=txtWham.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblWham.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtWham.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtTowels.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblTowels.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtTowels.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtTreats.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblTreats.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtTreats.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtCottonPads.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblCottonPads.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtCottonPads.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtCottonSwabs.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblCottonSwabs.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtCottonSwabs.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtVetWrap.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblVetWrap.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtVetWrap.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtPaperTowels.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblPaperTowels.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtPaperTowels.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtGarbageBags.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblGarbageBags.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtGarbageBags.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtReceipts.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblReceipts.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtReceipts.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtEnvelopes.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblEnvelopes.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtEnvelopes.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtBusinessCards.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblBusinessCards.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtBusinessCards.ClientID %>').focus();
                return false;
            }
            //Liquids
            if (IsNumeric(document.getElementById('<%=txtLiquid1.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq1.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid1.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid2.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq2.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid2.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid3.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq3.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid3.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid4.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq4.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid4.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid5.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq5.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid5.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid6.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq6.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid6.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid7.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq7.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid7.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid8.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq8.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid8.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid9.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq9.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid9.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid10.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq10.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid10.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid11.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq11.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid11.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid12.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq12.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid12.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid13.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq13.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid13.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid14.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq14.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid14.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid15.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq15.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid15.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid16.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq16.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid16.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid17.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq17.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid17.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid18.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq18.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid18.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid19.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq19.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid19.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid20.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq20.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid20.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid21.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq21.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid21.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid22.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq22.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid22.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid23.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq23.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid23.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid24.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq24.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid24.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtLiquid25.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblliq25.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtLiquid25.ClientID %>').focus();
                return false;
            }
            //Markiting
            if (IsNumeric(document.getElementById('<%=txtMarketing1.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblMarketing1.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtMarketing1.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtMarketing2.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblMarketing2.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtMarketing2.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtMarketing3.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblMarketing3.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtMarketing3.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtMarketing4.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblMarketing4.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtMarketing4.ClientID %>').focus();
                return false;
            }
            if (IsNumeric(document.getElementById('<%=txtMarketing5.ClientID %>').value) == false) {
                alert(document.getElementById('<%=lblMarketing5.ClientID %>').innerText + "  " + "Please enter 0-99");
                document.getElementById('<%=txtMarketing5.ClientID %>').focus();
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

    <h2>Inventory</h2>
    <div class="innercontent inventory">
        <%--Region Error/Success message start--%>
        <div style="width: 95%;" id="divError" runat="server">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <%--Region Error/Success message end--%>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblFleaTick22" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtFleaTick22" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%-- <br /><asp:CompareValidator ID="cmpFleaTick22" runat="server" ErrorMessage="Not a valid Flea & Tick -22" ControlToValidate="txtFleaTick22" Type="Integer" Operator="DataTypeCheck" CssClass="error_msg" Display="Dynamic"> </asp:CompareValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblFleaTick44" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtFleaTick44" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%-- <br /><asp:CompareValidator ID="cmvFleaTick44" runat="server" ErrorMessage="Not a valid Flea & Tick -44" ControlToValidate="txtFleaTick44" Type="Integer" Operator="DataTypeCheck" CssClass="error_msg" Display="Dynamic"> </asp:CompareValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblFleaTick88" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtFleaTick88" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:CompareValidator ID="cmvFleaTick88" runat="server" ErrorMessage="Not a valid Flea & Tick -88" ControlToValidate="txtFleaTick88" Type="Integer" Operator="DataTypeCheck" CssClass="error_msg" Display="Dynamic"> </asp:CompareValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblFleaTick132" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtFleaTick132" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Not a Valid Flea & Tick-132" ControlToValidate="txtFleaTick132" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblFleaTickCat" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtFleaTickCat" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Not a valid Flea & Tick-Cat" ControlToValidate="txtFleaTickCat" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic">  </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblToothbrushes" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtToothbrushes" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Not a Valid Entry" ControlToValidate="txtToothbrushes" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic">  </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblWham" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtWham" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Not a Valid What" ControlToValidate="txtWham" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblTowels" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtTowels" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Not a Valid Entry" ControlToValidate="txtTowels" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblTreats" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtTreats" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Not a Valid Treats" ControlToValidate="txtTreats" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblCottonPads" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtCottonPads" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Not a valid CottonPads"  ControlToValidate="txtCottonPads" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic">  </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblCottonSwabs" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtCottonSwabs" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Not a Valid CottonSwabs" ControlToValidate="txtCottonSwabs" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblVetWrap" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtVetWrap" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="Not a Valid VetWrap" ControlToValidate="txtVetWrap" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblPaperTowels" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtPaperTowels" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="Not a valid PaperTowels" ControlToValidate="txtPaperTowels" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic">  </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblGarbageBags" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtGarbageBags" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="Not a Valid GarbageBags" ControlToValidate="txtGarbageBags" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblReceipts" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtReceipts" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ErrorMessage="Not a Valid Receipts" ControlToValidate="txtReceipts" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"></asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblEnvelopes" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtEnvelopes" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%--<br /><asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ErrorMessage="Not a Valid Envelopes" ControlToValidate="txtEnvelopes" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"></asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblBusinessCards" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtBusinessCards" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
                <%-- <br /><asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ErrorMessage="Not a Valid BusinessCards"  ControlToValidate="txtBusinessCards" ValidationExpression="^\d*(\.\d{1,4})?$" CssClass="error_msg" Display="Dynamic"> </asp:RegularExpressionValidator>--%>
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblOther1" runat="server" CssClass="lbl"></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtOther1" runat="server" CssClass="txt txt90" MaxLength="256"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblOther2" runat="server" CssClass="lbl"></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtOther2" runat="server" CssClass="txt txt90" MaxLength="256"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblOther3" runat="server" CssClass="lbl"></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtOther3" runat="server" CssClass="txt txt90" MaxLength="256"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblOther4" runat="server" CssClass="lbl"></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtOther4" runat="server" CssClass="txt txt90" MaxLength="256"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblOther5" runat="server" CssClass="lbl"></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtOther5" runat="server" CssClass="txt txt90" MaxLength="256"></asp:TextBox>
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq1" runat="server" CssClass="lbl" Text=" "></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid1" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq2" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid2" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq3" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid3" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq4" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid4" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq5" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid5" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq6" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid6" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq7" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid7" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq8" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid8" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq9" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid9" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq10" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid10" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq11" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid11" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq12" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid12" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq13" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid13" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq14" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid14" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq15" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid15" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq16" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid16" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq17" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid17" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq18" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid18" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq19" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid19" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq20" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid20" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq21" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid21" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq22" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid22" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq23" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid23" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq24" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid24" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblliq25" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtLiquid25" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="spacer10">
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblMarketing1" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtMarketing1" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblMarketing2" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtMarketing2" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblMarketing3" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtMarketing3" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblMarketing4" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtMarketing4" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblMarketing5" runat="server" CssClass="lbl" Text=""></asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtMarketing5" runat="server" CssClass="txt txt90" MaxLength="2"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="spacer10">
    </div>
    <div class="innercontent">
        <div class="bottombtn">
            <asp:Button ID="btnLoad" runat="server" Text="Load" ToolTip="Load" CssClass="btn" OnClick="btnLoad_Click" />
            &nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" OnClientClick="return validate();" OnClick="btnSubmit_Click" CssClass="btn" />
        </div>
    </div>
</asp:Content>
