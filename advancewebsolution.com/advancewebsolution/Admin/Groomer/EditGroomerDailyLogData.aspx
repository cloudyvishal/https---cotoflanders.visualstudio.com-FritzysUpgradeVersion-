<%@ Page Title="Edit Daily Operations Log" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_EditGroomerDailyLogData" Codebehind="EditGroomerDailyLogData.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
               Edit Daily Operations Log</h2>
        </div>
        <div id="divsearch" runat="server" class="searchtopDiv">
            <table border="0" class="setservPage">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Select Date:<asp:DropDownList ID="ddlLastweek" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlLastweek_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <%--Region Error/Success message start--%>
            <div style="width: 95%;" id="divError" runat="server">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </div>
            <div style="width: 95%;" id="div1" runat="server">
                <asp:Label ID="lblErrorDate" runat="server" ForeColor="red" Visible="false"></asp:Label>
            </div>
            <%--Region Error/Success message end--%>
        <br />
        
        <div id="dvoperations" runat="server">
        <h3>
               Daily Operations Log</h3>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Label2" runat="server" CssClass="lbl">Date:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDate" ReadOnly="true" runat="server" CssClass="textBox" Width="80px" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="lblVanID" runat="server" CssClass="lbl">Van ID:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtVanID" runat="server" CssClass="textBox" Width="80px" MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="lblBeginningMileage" runat="server" CssClass="lbl">Beginning Mileage:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBeginningMileage" runat="server" CssClass="textBox" Width="80px" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="lblTotalHours" runat="server" CssClass="lbl">Total Hours:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotalHours" runat="server" CssClass="textBox" Width="80px" MaxLength="8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="lblEndingMileage" runat="server" CssClass="lbl">Ending Mileage:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndingMileage" runat="server" CssClass="textBox" Width="80px" MaxLength="6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="lblFuelPurchased" runat="server" CssClass="lbl">Fuel Purchased:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFuelPurchased" runat="server" CssClass="textBox" Width="80px" MaxLength="8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="lblPriceperGallon" runat="server" CssClass="lbl">Price per Gallon:</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPriceperGallon" runat="server" CssClass="textBox" Width="80px" MaxLength="8"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <div id="app_div" runat="server">
            <img alt="" src="../images/seperator.jpg"/>
            <h3>
                Appointment Reporting</h3>
              
            <table class="adduserTable" cellpadding="6" cellspacing="0">
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblLastName" runat="server" CssClass="lbl">Last Name:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustLastName" runat="server" CssClass="textBox" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px;" valign="top">
                        <asp:Label ID="lblDescription" runat="server" CssClass="lbl">Description:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="MultilinetextBox" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                    <asp:Label ID="lblJob" runat="server" CssClass="lbl">Job Mileage:</asp:Label>
                    </td>
                    <td>
                    <asp:TextBox ID="txtJob" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblZipCode" runat="server" CssClass="lbl">Zip Code:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipCode" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblPets" runat="server" CssClass="lbl">Pets:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPets" runat="server" CssClass="textBox" Width="50px"  MaxLength="3"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*"
                            ControlToValidate="txtPets" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblRebook" runat="server" CssClass="lbl">Rebook:</asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoRebook" runat="server" CellPadding="1"
                            CellSpacing="0" CssClass="radiobtn">
                            <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFromRebook" runat="server" CssClass="lbl">From Rebook:</asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoFromRebook" runat="server"
                            CellPadding="1" CellSpacing="0" CssClass="radiobtn">
                            <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblNew" runat="server" CssClass="lbl">New:</asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoNew" runat="server" CellPadding="1"
                            CellSpacing="0" CssClass="radiobtn">
                            <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblTimeIn" runat="server" CssClass="lbl">Time In:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTimeIn" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblTimeOut" runat="server" CssClass="lbl">Time Out:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTimeOut" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblPetTime" runat="server" CssClass="lbl">Pet Time:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPetTime" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblExtraServices" runat="server" CssClass="lbl">Extra Services:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtExtraServices" runat="server" CssClass="textBox" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <img alt="" src="../images/seperator.jpg"/>
            <h3>
                Supplies</h3>
            <table class="adduserTable" cellpadding="6" cellspacing="0">
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFleaandTick22" runat="server" CssClass="lbl">Flea and Tick–22:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFleaandTick22" runat="server" CssClass="textBox" Width="50px" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*"
                            ControlToValidate="txtFleaandTick22" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFleaandTick44" runat="server" CssClass="lbl">Flea and Tick–44:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFleaandTick44" runat="server" CssClass="textBox" Width="50px" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="*"
                            ControlToValidate="txtFleaandTick44" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFleaandTick88" runat="server" CssClass="lbl">Flea and Tick–88:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFleaandTick88" runat="server" CssClass="textBox" Width="50px" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*"
                            ControlToValidate="txtFleaandTick88" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFleaandTick132" runat="server" CssClass="lbl">Flea and Tick–132:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFleaandTick132" runat="server" CssClass="textBox" Width="50px" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="*"
                            ControlToValidate="txtFleaandTick132" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblFleaandTickCat" runat="server" CssClass="lbl">Flea and Tick–Cat:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFleaandTickCat" runat="server" CssClass="textBox" Width="50px" MaxLength="8"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                            ErrorMessage="*" ControlToValidate="txtFleaandTickCat" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblTB" runat="server" CssClass="lbl">TB:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTB" runat="server" CssClass="textBox" Width="50px" MaxLength="4"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                            ErrorMessage="*" ControlToValidate="txtTB" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblWham" runat="server" CssClass="lbl">Wham:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtWham" runat="server" CssClass="textBox" Width="50px" MaxLength="4"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                            ErrorMessage="*" ControlToValidate="txtWham" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <img alt="" src="../images/seperator.jpg"/>
            <h3>
                Revenue</h3>
            <table class="adduserTable" cellpadding="6" cellspacing="0">
                <tr>
                    <td style="width: 120px">
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdoRevenue" runat="server" CssClass="radiobtn">
                            <asp:ListItem Text="Credit Card" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Check" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Invoice" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label1" runat="server" CssClass="lbl">&nbsp;</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRevenue" runat="server" CssClass="textBox" Width="80px"  MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                            ErrorMessage="*" ControlToValidate="txtRevenue" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <img alt="" src="../images/seperator.jpg"/>
            <h3>
                Tip</h3>
            <table class="adduserTable" cellpadding="6" cellspacing="0">
                <tr>
                    <td style="width: 120px">
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdoTip" runat="server" CssClass="radiobtn">
                            <asp:ListItem Text="Credit Card" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Check" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Invoice" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label6" runat="server" CssClass="lbl">&nbsp;</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTip" runat="server" CssClass="textBox" Width="80px"  MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                            ErrorMessage="*" ControlToValidate="txtTip" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <img alt="" src="../images/seperator.jpg"/>
            <h3>
                Prior Revenue</h3>
            <table class="adduserTable" cellpadding="6" cellspacing="0">
                <tr>
                    <td style="width: 120px">
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdoPrior" runat="server" CssClass="radiobtn">
                            <asp:ListItem Text="Credit Card" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Check" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Cash" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="Label7" runat="server" CssClass="lbl">&nbsp;</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPriorRevenue" runat="server" CssClass="textBox" Width="80px"  MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                            ErrorMessage="*" ControlToValidate="txtPriorRevenue" ValidationExpression="^\d*(\.\d{1,4})?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <img alt="" src="../images/seperator.jpg"/>
            <h3>
                Next Appointment</h3>
            <table class="adduserTable" cellpadding="6" cellspacing="0">
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblNextDate" runat="server" CssClass="lbl">Date:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server">
                            <asp:ListItem Text="January" Value="01"></asp:ListItem>
                            <asp:ListItem Text="Febuary" Value="02"></asp:ListItem>
                            <asp:ListItem Text="March" Value="03"></asp:ListItem>
                            <asp:ListItem Text="April" Value="04"></asp:ListItem>
                            <asp:ListItem Text="May" Value="05"></asp:ListItem>
                            <asp:ListItem Text="June" Value="06"></asp:ListItem>
                            <asp:ListItem Text="July" Value="07"></asp:ListItem>
                            <asp:ListItem Text="August" Value="08"></asp:ListItem>
                            <asp:ListItem Text="September" Value="09"></asp:ListItem>
                            <asp:ListItem Text="October" Value="10"></asp:ListItem>
                            <asp:ListItem Text="November" Value="11"></asp:ListItem>
                            <asp:ListItem Text="December" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="dddDay" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblNextTime" runat="server" CssClass="lbl">Time:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlhr" CssClass="appTextFldtime" runat="server">
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                            <asp:ListItem Text="1:00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlmin" CssClass="appTextFldAm" runat="server">
                            <asp:ListItem Value="AM" Text="AM"></asp:ListItem>
                            <asp:ListItem Value="PM" Text="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblServicesforPet1" runat="server" CssClass="lbl">Services for Pet-1:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServicesforPet1" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblServicesforPet2" runat="server" CssClass="lbl">Services for Pet-2:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServicesforPet2" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblServicesforPet3" runat="server" CssClass="lbl">Services for Pet-3:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServicesforPet3" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblServicesforPet4" runat="server" CssClass="lbl">Services for Pet-4:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServicesforPet4" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblServicesforPet5" runat="server" CssClass="lbl">Services for Pet-5:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServicesforPet5" runat="server" CssClass="textBox" Width="80px"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblServicesforPet6" runat="server" CssClass="lbl">Services for Pet-6:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtServicesforPet6" runat="server" CssClass="textBox" Width="80px" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" CssClass="btnBg"
                        OnClick="btnSubmit_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
            </div>
    </div>
</asp:Content>

