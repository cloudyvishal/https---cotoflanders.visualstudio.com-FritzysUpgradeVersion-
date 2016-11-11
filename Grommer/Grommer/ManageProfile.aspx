<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="ManageProfile" Title="Manage Profile" Codebehind="ManageProfile.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="Scripts/phone_validation.js"></script>

    <script type="text/javascript" language="javascript" src="Scripts/Validation.js"></script>

    <h2>
        Manage Profile</h2>
    <div class="innercontent">
        <%--Region Error/Success message start--%>
        <div style="width: 95%;" id="divError" runat="server">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
        <%--Region Error/Success message end--%>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblName" runat="server" CssClass="lbl">Name:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtName" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="error_msg" runat="server"
                    ValidationGroup="Profile" ErrorMessage="Please enter name" ControlToValidate="txtName"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblAddress" runat="server" CssClass="lbl">Address:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="multitxt txt117"
                    MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblBaseCity" runat="server" CssClass="lbl">Base City:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtBaseCity" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Profile"
                    ErrorMessage="Please enter base city" ControlToValidate="txtBaseCity" CssClass="error_msg"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="Label1" runat="server" CssClass="lbl">State:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtState" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="Profile"
                    ErrorMessage="Please enter state" ControlToValidate="txtState" CssClass="error_msg"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="Label2" runat="server" CssClass="lbl">Zipcode:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtZipcode" runat="server" CssClass="txt txt117" MaxLength="5"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="Profile"
                    ErrorMessage="Please enter zipcode" ControlToValidate="txtZipcode" CssClass="error_msg"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblHomePhone" runat="server" CssClass="lbl">Phone 1:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtHomePhone" runat="server" CssClass="txt txt117" MaxLength="20"
                    onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Profile"
                    ErrorMessage="Please enter phone 1" ControlToValidate="txtHomePhone" CssClass="error_msg"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblPersonalCellPhone" runat="server" CssClass="lbl">Phone 2:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtPersonalCellPhone" runat="server" CssClass="txt txt117" onkeydown="javascript:backspacerDOWN(this,event);"
                    onkeyup="javascript:backspacerUP(this,event);" MaxLength="20"></asp:TextBox>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblEmailID" runat="server" CssClass="lbl">Email ID:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtEmailID" runat="server" CssClass="txt txt117" ></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Profile"
                    ErrorMessage="Please enter email id" ControlToValidate="txtEmailID" CssClass="error_msg"
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REEmailId" runat="server" ErrorMessage="Please enter correct email"
                    ControlToValidate="txtEmailID" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    CssClass="error_msg" Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>
         <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="Label3" runat="server" CssClass="lbl">Time Zone:</asp:Label></div>
            <div class="divcell_right">
                <asp:Label ID="lblTimeZone" runat="server" Text="" CssClass="lbl"></asp:Label>
                <br />
               
            </div>
        </div>
        <div class="innercontent">
            <div class="bottombtn">
                <asp:Button ID="btnProfile" runat="server" ValidationGroup="Profile" Text="Update"
                    Width="105" ToolTip="Update" CssClass="btn" OnClick="btnProfile_Click" />
            </div>
        </div>
    </div>
    <div class="spacer10">
    </div>
    <h2>
        Change Password</h2>
    <div class="innercontent">
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblCurrentPassword" runat="server" CssClass="lbl">Current Password:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="txt txt117" MaxLength="20"
                    TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="req1" runat="server" ErrorMessage="Please enter current password"
                    ControlToValidate="txtCurrentPassword" CssClass="error_msg" Display="Dynamic"></asp:RequiredFieldValidator></div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblNewPassword" runat="server" CssClass="lbl">New Password:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="txt txt117" MaxLength="20"
                    TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter new password"
                    ControlToValidate="txtNewPassword" CssClass="error_msg" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="divrow">
            <div class="divcell_left">
                <asp:Label ID="lblConfirmPassword" runat="server" CssClass="lbl">Confirm Password:</asp:Label></div>
            <div class="divcell_right">
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="txt txt117" MaxLength="20"
                    TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please confirm new password"
                    ControlToValidate="txtConfirmPassword" CssClass="error_msg" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="spacer10">
    </div>
    <div class="innercontent">
        <div class="bottombtn">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="105" ToolTip="Update" CssClass="btn" OnClick="btnUpdate_Click" />
        </div>
    </div>
</asp:Content>
