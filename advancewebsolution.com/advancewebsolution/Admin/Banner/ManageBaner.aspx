<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Baner_ManageBaner" Title="Manage Banner" Codebehind="~/Admin/Banner/ManageBaner.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        
<div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Banner</h2>
        </div>
        
        <div class="errorDiv" id="divError" runat="server" visible="false">
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
        <br style="clear:both;" />
       <table class="setservPage">
            <tr>
                <td style="width:15%;"> Select Page :</td>
                <td>  <asp:DropDownList ID="ddlPage" runat="server"  AutoPostBack="true"
                        onselectedindexchanged="ddlPage_SelectedIndexChanged" >
                    <asp:ListItem Value="0" Text="Home" ></asp:ListItem>
                    <asp:ListItem Value="1" Text="Services" ></asp:ListItem>
                    <asp:ListItem Value="2" Text="ServiceDetail" ></asp:ListItem>
                    <asp:ListItem Value="3" Text="Product" ></asp:ListItem>
                    <asp:ListItem Value="4" Text="Flea" ></asp:ListItem>
                    <asp:ListItem Value="5" Text="Fritzy Friend" ></asp:ListItem>
                    <asp:ListItem Value="6" Text="About Us" ></asp:ListItem>
                    <asp:ListItem Value="7" Text="Contact Us" ></asp:ListItem>
                    <asp:ListItem Value="8" Text="Registration" ></asp:ListItem>
                    <asp:ListItem Value="9" Text="News Detail" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td> User Type : </td>
                <td><asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlPetType_SelectedIndexChanged" >
                <asp:ListItem Value="0" Text="Unregistered User" ></asp:ListItem>
                <asp:ListItem Value="1" Text="Registerd User - Cat" ></asp:ListItem>
                <asp:ListItem Value="2" Text="Registerd User - Dog" ></asp:ListItem>
                <asp:ListItem Value="3" Text="Registerd User - Cat & Dog" ></asp:ListItem>
                </asp:DropDownList></td>
               
            </tr>
            <tr>
                 <td>  Select Banner : </td>
                  <td>  <asp:FileUpload  ID="flv" runat="server" onkeypress="return false"/> <br />
                     
                      
                    
                </td>
            </tr>
            <tr>
                <td> Select Coupon :</td>
                <td><asp:FileUpload ID="FlvCoupon" runat="server" onkeypress="return false" />
                <asp:button ID="btnUp" runat="server" Text="Upload" OnClick="btnUp_Click" CssClass="loginbtnBg"  /></td>
            </tr>
            <tr>
                <td></td>
                <td>
            You can upload .JPEG, .GIF, .BMP, .PNG files for Banner and Coupon with maximum size of 666 X 256. 
                </td>
            </tr>
        </table>

        
        <asp:GridView ID="GrdBaner" runat="server" AutoGenerateColumns="False" AllowSorting="true"
            AllowPaging="true" PageSize="10" DataKeyNames="ImageName" 
        CellPadding="0" GridLines="Vertical"
            Width="100%"   HeaderStyle-CssClass="headerStyle"
            CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" 
        onrowdatabound="GrdBaner_RowDataBound" onpageindexchanging="GrdBaner_PageIndexChanging"  OnDataBound="GrdBaner_DataBound" 
                     OnRowCreated="GrdBaner_RowCreated">
         <PagerTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
                <asp:Label ID="pmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Page" CommandArgument="Prev">Prev</asp:LinkButton>
                <asp:LinkButton ID="p0" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p1" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p2" runat="server" >LinkButton</asp:LinkButton>
                <asp:Label ID="CurrentPage" runat="server" Text="Label"></asp:Label>
                <asp:LinkButton ID="p4" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p5" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="p6" runat="server" >LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Page" CommandArgument="Next">Next</asp:LinkButton>
                <asp:Label ID="nmore" runat="server" Text="..."></asp:Label>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Page" CommandArgument="Last">Last</asp:LinkButton>
               
                </PagerTemplate>
            <AlternatingRowStyle CssClass="altGridStyle" />
            <PagerStyle CssClass="gridPager" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Banner Name">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblImageName" runat="server" Text='<%# Bind("ImageName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                 <asp:TemplateField HeaderText="Banner Image">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <img alt="Image" width="170" height="80" src="#" runat="server" id="imgThumb"    />
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Coupon Name">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate> 
                              <img alt="ImageCoupon" width="170" height="80"  src="#" runat="server" id="ImageCoupon"    />
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate> 
                          <asp:HyperLink ID="lnkEdit" runat="server" Text="Update Coupon"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                
               
                 
            </Columns>
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        
        
        <br />
         <asp:Label ID="lblNorecNo" runat="server" Visible="false" Text="No record found"></asp:Label>
        <asp:Button ID="btnDelete" CssClass="servbtnBg" runat="server" 
        Text="Delete" onclick="btnDelete_Click"   />
    
    <br />
    <br />
    <div class="pageTitle">
        <h2>
            Default Coupon</h2>
    </div>
    
    <table class="adduserTable" cellpadding="6" cellspacing="0">
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Image  ID="ImgCoupon" runat="server"   Width="170" Height="80"  />
            </td>
        </tr>
        <tr>
            <td valign="top">Upload new coupon:</td>
            <td>
                <asp:FileUpload  ID="fluDefaultCoupon" runat="server" onkeypress="return false"/>
     <asp:Button ID="btnDefaultCoupon" runat="server" Text="Upload" CssClass="servbtnBg"
            onclick="btnDefaultCoupon_Click" />
            
            <br /><br />You can upload .JPEG, .GIF, .BMP, .PNG files for Coupon with maximum size of 666 X 256. 
            </td>
        </tr>
        
    </table>
    
    
    
     
     </div> 
</asp:Content>

