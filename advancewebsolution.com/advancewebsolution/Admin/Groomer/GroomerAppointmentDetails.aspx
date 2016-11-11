<%@ Page Title="Groomer Appointment Details" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_GroomerAppointmentDetails" Codebehind="GroomerAppointmentDetails.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
        <div class="pageTitle">
            <h2>
                Groomer Appointment Details</h2>
        </div>
        <%--Region Error/Success message start--%>
        
        <%--Region Error/Success message end--%>
        
        <div id="dvgroomers" runat="server" >
        <div class="groomer_outerdiv">
            <div class="groomer_inner_scroll">
            <asp:GridView ID="GrdGroomer" runat="server" 
                    AutoGenerateColumns="False" ShowFooter="True"
            PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%"
            CssClass="log_table" HeaderStyle-CssClass="log_table_header" FooterStyle-CssClass="log_table_footer"
                    >
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
            
               <asp:BoundField HeaderText="Description" HeaderStyle-Width="2%" DataField="CustomerName"/>
               <asp:BoundField HeaderText="Pets" HeaderStyle-Width="2%" DataField="Pets"/>
               <asp:BoundField HeaderText="Rebook" HeaderStyle-Width="2%" DataField="Rebook"/>
               <asp:BoundField HeaderText="Time in" HeaderStyle-Width="2%" DataField="TimeIn"/>
               <asp:BoundField HeaderText="Time out" HeaderStyle-Width="2%" DataField="TimeOut"/>
               <asp:BoundField HeaderText="Pet Time" HeaderStyle-Width="2%" DataField="PetTime"/>
               <asp:BoundField HeaderText="Upto 22 lbs" HeaderStyle-Width="2%" DataField="FleaandTick22"/>
               <asp:BoundField HeaderText="23 to 44 lbs" HeaderStyle-Width="2%" DataField="FleaandTick44"/>
               <asp:BoundField HeaderText="45 to 88 lbs" HeaderStyle-Width="2%" DataField="FleaandTick88"/>
               <asp:BoundField HeaderText="89 to 132 lbs" HeaderStyle-Width="2%" DataField="FleaandTick132"/>
               <asp:BoundField HeaderText="Cats" HeaderStyle-Width="2%" DataField="FleaandTickCat"/>
               <asp:BoundField HeaderText="TB" HeaderStyle-Width="2%" DataField="TB"/>
               <asp:BoundField HeaderText="Wham" HeaderStyle-Width="2%" DataField="Wham"/>
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
            </Columns>
        </asp:GridView>
            
            </div>
        </div>   
        
        </div> 
         <div id="divBtn" runat="server" style="display: block;">
            
            <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" onclick="lnkNorec_Click"  
                />
            <%--region button end --%>
        </div>   
</div>
</asp:Content>