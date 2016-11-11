<%@ Page Language="C#" AutoEventWireup="true" Inherits="Home" Codebehind="Home.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="contentainer">
        <div class="maincontainer">
            <div class="containwrapper">
                <!-- HEADER STARTS -->
                <div class="header">
                    <div class="top_t">
                        <div class="top_tl">
                            <div class="top_tr">
                                <div class="headercontent">
                                    <div class="headLeft">
                                        <span class="normal">Welcome</span> <span class="big">
                                            <asp:Label ID="lblname" runat="server">Laura</asp:Label></span></div>
                                    <div class="headRight">
                                        <a href="ManageProfile.aspx" title="Manage Profile" accesskey="2">Manage Profile</a>&nbsp;|&nbsp;<a
                                            href="Default.aspx" title="Logout" accesskey="3">Logout</a></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- HEADER ENDS -->
                <!-- CONTENT STATRS -->
                <h2>
                    Daily Operations Log</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblVanID" runat="server" CssClass="lbl">Van ID:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtVanID" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblBeginningMileage" runat="server" CssClass="lbl">Beginning Mileage:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtBeginningMileage" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTotalHours" runat="server" CssClass="lbl">Total Hours:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtTotalHours" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblEndingMileage" runat="server" CssClass="lbl">Ending Mileage:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtEndingMileage" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFuelPurchased" runat="server" CssClass="lbl">Fuel Purchased:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtFuelPurchased" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblPriceperGallon" runat="server" CssClass="lbl">Price per Gallon:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtPriceperGallon" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                </div>
                <div class="spacer10">
                </div>
                <h2>
                    Appointment Reporting</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblDescription" runat="server" CssClass="lbl">Description:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtCustLastName" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            &nbsp;</div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="multitxt txt117" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblJob" runat="server" CssClass="lbl">Job:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtJob" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblZipCode" runat="server" CssClass="lbl">Zip Code:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtZipCode" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblPets" runat="server" CssClass="lbl">Pets:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtPets" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblRebook" runat="server" CssClass="lbl">Rebook:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoRebook" runat="server" CellPadding="1"
                                CellSpacing="0" CssClass="radiobtn">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFromRebook" runat="server" CssClass="lbl">From Rebook:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoFromRebook" runat="server"
                                CellPadding="1" CellSpacing="0" CssClass="radiobtn">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblNew" runat="server" CssClass="lbl">New:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButtonList RepeatDirection="Horizontal" ID="rdoNew" runat="server" CellPadding="1"
                                CellSpacing="0" CssClass="radiobtn">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTimeIn" runat="server" CssClass="lbl">Time In:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtTimeIn" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTimeOut" runat="server" CssClass="lbl">Time Out:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtTimeOut" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblPetTime" runat="server" CssClass="lbl">Pet Time:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtPetTime" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblExtraServices" runat="server" CssClass="lbl">Extra Services:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtExtraServices" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                </div>
                <div class="spacer10">
                </div>
                <h2>
                    Flea and Tick</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick22" runat="server" CssClass="lbl">Flea and Tick–22:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtFleaandTick22" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick44" runat="server" CssClass="lbl">Flea and Tick–44:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtFleaandTick44" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick88" runat="server" CssClass="lbl">Flea and Tick–88:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtFleaandTick88" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTick132" runat="server" CssClass="lbl">Flea and Tick–132:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtFleaandTick132" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblFleaandTickCat" runat="server" CssClass="lbl">Flea and Tick–Cat:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtFleaandTickCat" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTB" runat="server" CssClass="lbl">TB:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtTB" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblWham" runat="server" CssClass="lbl">Wham:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtWham" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                </div>
                <div class="spacer10">
                </div>
                <h2>
                    Revenue</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblCreditCard" runat="server" CssClass="lbl">Credit Card:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoCreditCard" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblCheck" runat="server" CssClass="lbl">Check:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoCheck" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblCash" runat="server" CssClass="lbl">Cash:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoCash" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblInvoice" runat="server" CssClass="lbl">Invoice:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="Invoice" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label1" runat="server" CssClass="lbl">&nbsp;</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtRevenue" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                </div>
                <div class="spacer10">
                </div>
                <h2>
                    Tip</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTipCreditCard" runat="server" CssClass="lbl">Credit Card:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoTipCreditCard" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTipCheck" runat="server" CssClass="lbl">Check:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoTipCheck" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTipCash" runat="server" CssClass="lbl">Cash:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoTipCash" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblTipInvoice" runat="server" CssClass="lbl">Invoice:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoTipInvoice" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label6" runat="server" CssClass="lbl">&nbsp;</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtTip" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                </div>
                <div class="spacer10">
                </div>
                <h2>
                    Prior Revenue</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblPriorCreditCard" runat="server" CssClass="lbl">Credit Card:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoPriorCreditCard" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblPriorCheck" runat="server" CssClass="lbl">Check:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoPriorCheck" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblPriorCash" runat="server" CssClass="lbl">Cash:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:RadioButton ID="rdoPriorCash" runat="server" CssClass="radiobtn" /></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="Label7" runat="server" CssClass="lbl">&nbsp;</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtPriorRevenue" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                </div>
                <div class="spacer10">
                </div>
                <h2>
                    Next Appointment</h2>
                <div class="innercontent">
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblNextDate" runat="server" CssClass="lbl">Date:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtNextDate" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblNextTime" runat="server" CssClass="lbl">Time:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtNextTime" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblServicesforPet1" runat="server" CssClass="lbl">Services for Pet-1:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtServicesforPet1" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblServicesforPet2" runat="server" CssClass="lbl">Services for Pet-2:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtServicesforPet2" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblServicesforPet3" runat="server" CssClass="lbl">Services for Pet-3:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtServicesforPet3" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblServicesforPet4" runat="server" CssClass="lbl">Services for Pet-4:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtServicesforPet4" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblServicesforPet5" runat="server" CssClass="lbl">Services for Pet-5:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtServicesforPet5" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div class="divrow">
                        <div class="divcell_left">
                            <asp:Label ID="lblServicesforPet6" runat="server" CssClass="lbl">Services for Pet-6:</asp:Label></div>
                        <div class="divcell_right">
                            <asp:TextBox ID="txtServicesforPet6" runat="server" CssClass="txt txt117" MaxLength="20"></asp:TextBox></div>
                    </div>
                </div>
                <div class="spacer10">
                </div>
                <div class="innercontent">
                    <div class="bottombtn">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Submit" CssClass="btn" />
                    </div>
                </div>
                <!-- CONTENT ENDS -->
                <br style="clear: both;" />
                <%--FOOTER STARTS--%>
                <div class="b">
                    <div class="bl">
                        <div class="br">
                            <div class="footer">
                                <div class="fright">
                                </div>
                                <div class="fleft">
                                    <a href="Operations.aspx" title="Home" accesskey="4">Home</a>&nbsp;| <a href="Inventory.aspx"
                                        title="Inventory" accesskey="5">Inventory</a>&nbsp;| <a href="ManageProfile.aspx"
                                            title="Manage Profile" accesskey="6">Manage Profile</a>&nbsp;| <a href="Default.aspx"
                                                title="Logout" accesskey="7">Logout</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--FOOTER ENDS--%>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
