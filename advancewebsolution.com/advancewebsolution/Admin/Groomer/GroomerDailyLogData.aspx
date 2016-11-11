<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_GroomerDailyLogData" Title="Groomer Daily Log Data" Codebehind="GroomerDailyLogData.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
        <div class="pageTitle">
            <h2>
                Groomer Daily Log Data</h2>
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
        
        <table class="setservPage" border="0">
            <tr>
                <td style="width:22%;">Select Date of Last Week:</td>
                <td> <asp:DropDownList ID="ddlLastweek" runat="server" 
                AutoPostBack="True" onselectedindexchanged="ddlLastweek_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        </table>
       
     
        <div id="dvgroomers" runat="server" >
            <table border="0" class="adduserTable" cellpadding="6" cellspacing="0" style="margin:0;">
                <tr>
                    <td style="width: 7%; font-weight:bold;">
                        Name :
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" class="adduserTable" cellpadding="6" cellspacing="0" style="margin:0 0 10px 0;">
                <tr>
                    <td style="width: 17%;">
                        <b>Beginning Mileage :</b>
                    </td>
                    <td style="width: 8%;">
                        <asp:Label ID="lblBeginningMileage" runat="server"></asp:Label>
                    </td>
                    <td style="width: 15%;">
                        <b>Ending Mileage :</b>
                    </td>
                    <td>
                        <asp:Label ID="lblEndingMileage" runat="server"></asp:Label>
                    </td>
                    <td style="width: 7%;">
                        <b>Date :</b>
                    </td>
                    <td style="width: 20%;">
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
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
               <asp:BoundField HeaderText="Van" HeaderStyle-Width="2%" DataField="VanId"/>
               <asp:BoundField HeaderText="Mileage" HeaderStyle-Width="2%" DataField="BeginningMileage"/>
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
               <%-- <asp:BoundField HeaderText="Rebook Date & Time" HeaderStyle-Width="2%" DataField="Rebook" />--%>
            </Columns>
        </asp:GridView>
            
            </div>
        </div>   
        
        <div> <asp:Button ID="btnExportToExcel" runat="server" CssClass="gobackbtnBg" 
                Text="Export To Excel" onclick="btnExportToExcel_Click" /> </div> 
        
        </div> 
         <div id="divBtn" runat="server" style="display: block;">
            
            <asp:Button ID="lnkNorec" runat="server" CssClass="gobackbtnBg" Text="Go Back" onclick="lnkNorec_Click" 
                />
            <%--region button end --%>
        </div>   
</div>
</asp:Content>

