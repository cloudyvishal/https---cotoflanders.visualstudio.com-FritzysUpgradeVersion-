<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Baner_ManageBanerNew" EnableEventValidation="true" Title="Manage Banner" Codebehind="ManageBanerNew.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript" language="javascript" src="../../Scripts/Validation.js" ></script>
    <script type="text/javascript" src="../../Scripts/phone_validation.js"></script>
<script language="javascript" type="text/javascript">
function CheckOnOff(rdoId,gridName)
{
    var rdo = document.getElementById(rdoId);
    /* Getting an array of all the "INPUT" controls on the form.*/
    var all = document.getElementsByTagName("input");
    for(i=0;i<all.length;i++)
    {  
        /*Checking if it is a radio button, and also checking if the
        id of that radio button is different than "rdoId" */
        if(all[i].type=="radio" && all[i].id != rdo.id)
        {
            var count=all[i].id.indexOf(gridName);
            if(count!=-1)
            {
               all[i].checked=false;
            }
        }
     }
     rdo.checked=true;/* Finally making the clicked radio button CHECKED */
}


</script>
        
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
                        onselectedindexchanged="ddlUserType_SelectedIndexChanged" >
                <asp:ListItem Value="0" Text="Unregistered User" ></asp:ListItem>
                <asp:ListItem Value="1" Text="Registerd User - Cat" ></asp:ListItem>
                <asp:ListItem Value="2" Text="Registerd User - Dog" ></asp:ListItem>
                <asp:ListItem Value="3" Text="Registerd User - Cat & Dog" ></asp:ListItem>
                </asp:DropDownList></td>
               
            </tr>
           
        </table>

        
        <asp:GridView ID="GrdBaner" runat="server" AutoGenerateColumns="False" AllowSorting="true"
            AllowPaging="true" PageSize="15" 
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
                <asp:TemplateField HeaderText="Banner Image">
                    <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="headerStyle1" HorizontalAlign="Center"/>
                    <ItemTemplate>
                        <img alt="Image" width="170" height="80" src='<%#DataBinder.Eval(Container.DataItem,"BannerPath") %>' runat="server" id="imgThumb"    />
                    </ItemTemplate>
                </asp:TemplateField>
              
                
                <asp:TemplateField HeaderText="Set as Default Banner">
                    <ItemStyle CssClass="itemstyle" Width="15%" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="headerStyle1" />                    
                    <ItemTemplate>                            
                            <asp:RadioButton id="rdoDefaultBanner"  runat="server" OnClick="javascript:CheckOnOff(this.id,'GrdBaner');" Checked = '<%#DataBinder.Eval(Container.DataItem,"IsDefaultCoupon") %>'></asp:RadioButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Set as Coupon">
                    <ItemStyle CssClass="itemstyle" Width="15%" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="headerStyle1" />                    
                    <ItemTemplate>
                        <asp:CheckBox ID="chkCoupon" runat="server" Checked = '<%#DataBinder.Eval(Container.DataItem,"IsCoupon") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Frequency">
                    <ItemStyle CssClass="itemstyle" Width="15%" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="headerStyle1" HorizontalAlign="Center"/>
                    
                    <ItemTemplate>
                        <asp:TextBox ID="txtFrequency" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" runat="server" CssClass="frequency_txt" Text = '<%#DataBinder.Eval(Container.DataItem,"Frequency") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Banner Id" Visible = "false">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />                    
                    <ItemTemplate>
                        <asp:Label ID="lblBannerId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BannerId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                 
            </Columns>
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <%--<script type="text/javascript" language="javascript">select_first();</script>--%>
        
        <br />
         <asp:Label ID="lblNorecNo" runat="server" Visible="false" Text="No record found"></asp:Label>
        <asp:Button ID="btnSubmit" CssClass="servbtnBg" runat="server" 
        Text="set Banner" onclick="btnSubmit_Click"   />
    <br />
        <asp:Label ID = "lblNote" runat = "server" Visible= "false" Text= "When frequnecy of all banner is  zero and default banner is not selected then First banner will set as Default banner." Font-Size="Smaller"></asp:Label>
    <br />
    <br />
 
    
    
    
     
     </div> 
</asp:Content>

