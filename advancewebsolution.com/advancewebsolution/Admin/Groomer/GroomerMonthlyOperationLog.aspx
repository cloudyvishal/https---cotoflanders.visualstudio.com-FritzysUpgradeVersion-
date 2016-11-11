<%@ Page Title="Groomer Monthly Operation Log" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" ValidateRequest="false" Inherits="Admin_Groomer_GroomerMonthlyOperationLog" Codebehind="GroomerMonthlyOperationLog.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
        <div class="pageTitle">
            <h2>
                Groomer Monthly Log Data</h2>
        </div>
        <%--Region Error/Success message start--%>
        <table>
            <tr>
                <td>
                    <div class="errorDivlarge" id="divError" runat="server" visible="false">
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
                    <br style="clear: both;" />
                </td>
            </tr>
            
        </table>
        <%--Region Error/Success message end--%>
          
          <table class="setservPage1" border="0">
            <tr>
            <td class="textwidth">
                Start Date:&nbsp;<asp:TextBox ID="txtStartDate" onkeypress="return false;" runat="server" CssClass="regTextField"
                    Width="120px"></asp:TextBox></td>
            
                <td class="calenderwidth"><asp:ImageButton ID="imgCalPop" runat="server" ImageUrl="~/Images/calImage.jpg" /> <ajaxtoolkit:calendarextender ID="CalendarExtender1" runat="server" Format="MM/d/yyyy"
                    PopupButtonID="imgCalPop" TargetControlID="txtStartDate">
                </ajaxtoolkit:calendarextender></td>
               
               
                <td class="textwidth">End Date:&nbsp;<asp:TextBox ID="txtEndDate" onkeypress="return false;" runat="server" CssClass="regTextField"
                    Width="120px"></asp:TextBox></td>
                <td class="calenderwidth"><asp:ImageButton ID="imgCalPop2" runat="server" ImageUrl="~/Images/calImage.jpg" />
                <ajaxtoolkit:calendarextender ID="CalendarExtender2" runat="server" Format="MM/d/yyyy"
                    PopupButtonID="imgCalPop2" TargetControlID="txtEndDate">
                </ajaxtoolkit:calendarextender>
            </td>    
            </tr>
            <tr>
            <td><asp:Button ID="btnGeneratereport" runat="server" CssClass="gobackbtnBg" 
                    Text="Generate  Report" onclick="btnGeneratereport_Click" /></td>
            </tr>
        </table>          
     
        <div id="dvgroomers" runat="server" >
          
        <div class="groomer_outerdiv">
            <div class="groomer_inner_scroll">
            
            <asp:GridView ID="GrdGroomer" runat="server" DataKeyNames="GID" 
                    AutoGenerateColumns="False" ShowFooter="True"
            PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%"
            CssClass="log_table" HeaderStyle-CssClass="log_table_header" FooterStyle-CssClass="log_table_footer"
                    onrowdatabound="GrdGroomer_RowDataBound" 
                    onrowcreated="GrdGroomer_RowCreated" >
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
            <Columns>
             
                <asp:BoundField HeaderText="Date" HeaderStyle-Width="2%" DataField="addedon"/>
                <asp:TemplateField HeaderText="Pets" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPets" runat="server" Text='<%# Eval("Pets").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPetsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Rebook" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblRebookPets" runat="server" Text='<%# Eval("Rebook").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblRebookPetsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Pets From Rebook" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPetsfromRebook" runat="server" Text='<%# Eval("FromRebook").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPetsfromRebookTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="New Pets" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblNewpets" runat="server" Text='<%# Eval("New").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblNewPetsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Hours" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblHours" runat="server" Text='<%# Eval("TotlaHours").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblHoursTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="Upto 22 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaandTick22" runat="server" Text='<%# Eval("FleaandTick22").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaandTick22Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="23 to 44 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaandTick44" runat="server" Text='<%# Eval("FleaandTick44").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaandTick44Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="45 to 88 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaandTick88" runat="server" Text='<%# Eval("FleaandTick88").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaandTick88Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="89 to 132 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaandTick132" runat="server" Text='<%# Eval("FleaandTick132").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaandTick132Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Cats" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaandTickCat" runat="server" Text='<%# Eval("FleaandTickCat").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaandTickCatTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="TB" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblTB" runat="server" Text='<%# Eval("TB").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTBTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Wham" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblWham" runat="server" Text='<%# Eval("Wham").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblWhamTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                    
                </asp:TemplateField>
               <asp:BoundField HeaderText="Start Miles" HeaderStyle-Width="2%" DataField="BeginningMileage"/>
               <asp:BoundField HeaderText="End Miles" HeaderStyle-Width="2%" DataField="EndingMileage"/>
                               
                <asp:TemplateField HeaderText="CC" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblRevenueCreditCard" runat="server" Text='<%# "$"+Eval("RevenueCreditCard").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblRevenueCreditCardTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CK" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblRevenueCheck" runat="server" Text='<%# "$"+Eval("RevenueCheck").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblRevenueCheckTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RevenueCash" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblRevenueCash" runat="server" Text='<%# "$"+Eval("RevenueCash").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblRevenueCashTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoice" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblRevenueCheck" runat="server" Text='<%# "$"+Eval("RevenueInvoice").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblRevenueInvoiceTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CC Tip" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblTipCreditCard" runat="server" Text='<%# "$"+Eval("TipCreditCard").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTipCreditCardTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CK Tip" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblTipCheck" runat="server" Text='<%# "$"+Eval("TipCheck").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTipCheckTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cash Tip" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblTipCash" runat="server" Text='<%# "$"+Eval("TipCash").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTipCashTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cash Invoice" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblTipInvoice" runat="server" Text='<%# "$"+Eval("TipInvoice").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTipInvoiceTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prior CC" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPriorCreditCard" runat="server" Text='<%# "$"+Eval("PriorCreditCard").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPriorCreditCardTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prior CK" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPriorCheck" runat="server" Text='<%# "$"+Eval("PriorCheck").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPriorCheckTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prior Cash" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPriorCash" runat="server" Text='<%# "$"+Eval("PriorCash").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPriorCashTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Fuel Purchased" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFuelPurchased" runat="server" Text='<%# "$"+Eval("FuelPurchased").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFuelPurchasedTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Price Per Gallon" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPricePerGallon" runat="server" Text='<%# "$"+Eval("PricePerGallon").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPricePerGallonTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="22 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaTick22" runat="server" Text='<%# Eval("FleaTick22").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaTick22Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="44 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaTick44" runat="server" Text='<%# Eval("FleaTick44").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaTick44Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="88 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaTick88" runat="server" Text='<%# Eval("FleaTick88").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaTick88Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="132 lbs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaTick132" runat="server" Text='<%# Eval("FleaTick132").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaTick132Total" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Cats" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblFleaTickcAT" runat="server" Text='<%# Eval("FleaTickcAT").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblFleaTickcATTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="TB" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblToothbrushes" runat="server" Text='<%# Eval("Toothbrushes").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblToothbrushesTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Wham" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblWhamInventory" runat="server" Text='<%# Eval("WhamInventory").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblWhamInventoryTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Towels" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblTowels" runat="server" Text='<%# Eval("Towels").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTowelsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cotton Pads" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblCottonPads" runat="server" Text='<%# Eval("CottonPads").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblCottonPadsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Cotton Swabs" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblCottonSwabs" runat="server" Text='<%# Eval("CottonSwabs").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblCottonSwabsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Paper Towels" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblPaperTowels" runat="server" Text='<%# Eval("PaperTowels").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblPaperTowelsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Garbage Bags" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblGarbageBags" runat="server" Text='<%# Eval("GarbageBags").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblGarbageBagsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Treats" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblTreats" runat="server" Text='<%# Eval("Treats").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTreatsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Vet Wrap" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblVetWrap" runat="server" Text='<%# Eval("VetWrap").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblVetWrapTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Wipes" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblWipes" runat="server" Text='<%# Eval("Wipes").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblWipesTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Envelopes" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblEnvelopes" runat="server" Text='<%# Eval("Envelopes").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblEnvelopesTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Quick Stop" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblQuickStop" runat="server" Text='<%# Eval("QuickStop").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblQuickStopTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Liquid Bandaid" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblLiquidBandaid" runat="server" Text='<%# Eval("LiquidBandaid").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblLiquidBandaidTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Receipts" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblReceipts" runat="server" Text='<%# Eval("Receipts").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblReceiptsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Business Cards" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblBusinessCards" runat="server" Text='<%# Eval("BusinessCards").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblBusinessCardsTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Blades Sharp" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblBladesSharpened" runat="server" Text='<%# Eval("BladesSharpened").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblBladesSharpenedTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Scissors Sharp" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblScissorsSharpened" runat="server" Text='<%# Eval("ScissorsSharpened").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblScissorsSharpenedTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SunGuard" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblSunGuard" runat="server" Text='<%# Eval("SunGuard").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblSunGuardTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="EZ Shed" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblEZShed" runat="server" Text='<%# Eval("EZShed").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblEZShedTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="EZ Dematt" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblEZDematt" runat="server" Text='<%# Eval("EZDematt").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblEZDemattTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Skunk Kit" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblSkunkKit" runat="server" Text='<%# Eval("SkunkKit").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblSkunkKitTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Other" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblOther" runat="server" Text='<%# Eval("Other").ToString()%>'>
                        </asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblOtherTotal" runat="server"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            
            </div>
        </div>   
        
        <div> <asp:Button ID="btnExportToExcel" runat="server" CssClass="gobackbtnBg" Text="Export To Excel" onclick="btnExportToExcel_Click" /> </div> 
                
            
        
        </div> 
         <div id="divBtn" runat="server" style="display: block;">
            
            <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" onclick="lnkNorec_Click" 
                />
            <%--region button end --%>
        </div>   
</div>
</asp:Content>

