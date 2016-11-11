<%@ Control Language="C#" AutoEventWireup="true" Inherits=" MB_Controls_Product_Flea" Codebehind="Product_Flea.ascx.cs" %>

<div>
            
                
           <%--  Data list is use to bind all services of cat Start --%>
            <asp:DataList ID="dlProducts" runat="server" RepeatColumns="1" Width="100%" 
                CellPadding="0"   RepeatDirection="Vertical"
                CellSpacing="0" onitemdatabound="dlProducts_ItemDataBound">
                <ItemTemplate>
                    <div class="innercontent">
       <div class="productlistdiv">
                        <div class="productimg">
                         <img alt="Image Product" height="62" width="73" src="#" runat="server" id="ImgProduct" />
                        <asp:Label ID="lblImage"  Text='<%#Eval("ImageName") %>' Visible="false" runat="server"></asp:Label>
                        </div>
                   
                         <div class="product_shortdesc">
                             <span>
                         <asp:Label ID="lblProductName" Font-Bold="true" Text='<%#Eval("ProductName") %>' runat="server"></asp:Label></span>
                             <div id="divProducts" runat="server" class="innerParaDiv">
                                 
                                 <p>
                         <asp:Label ID="lblProductDescription"  Text='<%#Eval("ProductDescription") %>' runat="server"></asp:Label>
                         </p>
                             </div>
                              <div class="pricediv">
                        Our Price: $ <asp:Label ID="Label1"  Text='<%# String.Format("{0:F}", Eval("Price")) %>'  runat="server"></asp:Label></span>
                                 </div>
                        <div class="buydiv"><a href="MB_contactus.aspx" title="Buy">
                                    <img src="images/buy_button.jpg" alt="" />
                                 </a></div>
                                  </div>
                     </div>
                   </div>  
                </ItemTemplate>
            </asp:DataList>
            
            <%--  Data list is use to bind all services of cat End --%>
        </div>