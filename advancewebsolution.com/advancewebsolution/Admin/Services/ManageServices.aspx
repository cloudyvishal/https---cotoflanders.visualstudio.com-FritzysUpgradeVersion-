<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" ValidateRequest="false" AutoEventWireup="true" Inherits="Admin_Services_ManageServices" Title="Admin - Manage Services" Codebehind="ManageServices.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript" language="javascript" >
            function Up()
            {
                if(document.getElementById('<%=lstOrder.ClientID %>').selectedIndex == "0")
                {
                    alert("Plese select correct service ");
                    return false ;
                }
 
            }
            function Down()
            {
                 
                if(document.getElementById('<%=lstOrder.ClientID %>').selectedIndex ==  document.getElementById('<%=lstOrder.ClientID %>').length - 1)
                {
                    alert("Plese select correct service ");
                    return false ;
                }
 
                return true;
            }
            function Hide()
            {
                document.getElementById('<%=divOrder.ClientID %>').style.display = "none";
                document.getElementById('<%=divOrderBtn.ClientID %>').style.display = "block";
                return false;
            }
            function Show()
            {
                document.getElementById('<%=divOrder.ClientID %>').style.display = "block";
                document.getElementById('<%=divOrderBtn.ClientID %>').style.display = "none";
                return false;
            }
            
   function validate()
    {
    if(document.getElementById('<%=ddlSearch.ClientID %>').value == "0")
    {
        alert("Please select search criteria");
        return false;
    }
     if(document.getElementById('<%=txtSearch.ClientID %>').value == "")
    {
        alert("Please enter search text");
        return false;
    }
}
            
          </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Services</h2>
        </div>
         <div class="previewLinkDiv">
                        <asp:LinkButton ID="btnPreview" runat="server" Text="Preview" ToolTip="Preview" OnClick="btnPreview_Click1"></asp:LinkButton>
                    </div>
                    
        <h3>
            Header Services</h3>
            
        <table border="0" width="100%">
            <tr>
                <td>
                    <table class="setservPage"  border="0">
                        <tr>
                            <td>
                                User Type :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="Registerd User - Cat"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Registerd User - Dog"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Registerd User - Cat & Dog"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Unregistered"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--Region Header Services Start --%>
        <asp:GridView ID="GrdService" runat="server" DataKeyNames="ServiceID" AutoGenerateColumns="False"
            PageSize="5" CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
            CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnRowDataBound="GrdService_RowDataBound" >
            <AlternatingRowStyle CssClass="altGridStyle" />
            <Columns>
                <asp:TemplateField HeaderText="Sr. No.">
                    <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="srno" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              
                     <asp:TemplateField HeaderText="Service Title">
                    <ItemStyle CssClass="itemstyle" Width="40%" />
                    <HeaderStyle CssClass="headerStyle" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%--<asp:Label ID="lblServiceTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>--%>
                      <asp:HyperLink  ID="lblServiceTitle" ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle" runat="server" Text='<%# Bind("Title") %>' SortExpression="Title"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Service Description">
                    <ItemStyle CssClass="itemstyle" Width="40%" />
                    <HeaderStyle CssClass="headerStyle" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Label ID="lblServiceFor" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Service For">
                    <ItemStyle CssClass="itemstyle" Width="10%" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblPetType" runat="server" Text='<%# Bind("PetType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Service For" Visible="false">
                    <ItemStyle CssClass="itemstyle" />
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblImageName" runat="server" Text='<%# Bind("ImageName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <ItemStyle CssClass="itemstyle"/>
                    <HeaderStyle CssClass="headerStyle"/>
                    <ItemTemplate>
                        <img id="ImageCoupon" alt="ImageService"  src="#" runat="server" width="80" height="80" />
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Order" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblServiceID" runat="server" Text='<%# Bind("ServiceID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--Region Header Services End --%>
        
        <%-- Region  grid start--%>
        <div class="itemstyle" id="divSelectpet" runat="server">
        
         
        <img src="../images/seperator.jpg" alt="" />
             <h3>
             Services</h3>
             
             <%--Region Error/Success message start--%>
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
        <%--Region Error/Success message end--%>
             
            
            
            <div id="divPet" runat="server">
                <table border="0" style="margin: 10px 0pt 0pt;" class="setservPage">
                    <tr>
                        <td style="width: 130px; font-size:12px;">
                            Please select pet :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPet" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPet_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Cat"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Dog"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            
            <div id="divsearch" runat="server" class="searchtopDiv">
                <table border="0" class="searchTable">
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlSearch" runat="server">
                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Service Title"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="servbtnBg" OnClientClick="return validate();"
                                OnClick="btnSearch_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="VIEW ALL" CssClass="servbtnBg" OnClick="btnViewall_Click" />
                        </td>
                    </tr>
                </table>
                <br style="clear: both;" />
            </div>
            <div style="width:826px;">
            <asp:GridView ID="gdvStaticFiles" runat="server" AutoGenerateColumns="False" CellPadding="0"
                AllowSorting="true" AllowPaging="True" DataKeyNames="serviceID" GridLines="Vertical"
                Width="100%" OnPageIndexChanging="gdvStaticFiles_PageIndexChanging" HeaderStyle-CssClass="headerStyle"
                CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnSorting="gdvStaticFiles_Sorting"
                OnRowDataBound="gdvStaticFiles_RowDataBound" OnDataBound="gdvStaticFiles_DataBound"
                OnRowCreated="gdvStaticFiles_RowCreated">
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
                    <asp:HyperLinkField SortExpression="ServiceTitle" ItemStyle-CssClass="itemstyle"
                        HeaderStyle-CssClass="headerStyle" DataNavigateUrlFields="ServiceID" DataNavigateUrlFormatString="EditService.aspx?ServiceID={0}"
                        DataTextField="ServiceTitle" HeaderText="Service Title"></asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Service For" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblServiceType" runat="server" Text='<%# Bind("ServiceType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Home Service" SortExpression="IsHome" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="12%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblIsHome" runat="server" Text='<%# Bind("IsHome") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Flea Service" SortExpression="IsFlea">
                        <ItemStyle CssClass="itemstyle" Width="12%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblIsFlea" runat="server" Text='<%# Bind("IsFlea") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Added on" SortExpression="Addedon">
                        <ItemStyle CssClass="itemstyle" Width="12%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAddedon" runat="server" Text='<%# Bind("Addedon", "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="5%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblImage" runat="server" Text='<%# Bind("Image") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FileName" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblFile" runat="server" Text='<%# Bind("PageName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblServiceID" runat="server" Text='<%# Bind("ServiceID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblPosition" runat="server" Text='<%# Bind("Position") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            <%-- Region  grid end --%>
            <%-- <asp:Label ID="lblNorec" runat="server" ForeColor="red"  Text="No record found"></asp:Label>--%>
            <%--region button starts --%>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnNew" runat="server" Text="Add" ToolTip="Add" CssClass="btnBg"
                            OnClick="btnNew_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg"
                            OnClick="btnDelete_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnStatus" runat="server" Text="Active/Inactive" ToolTip="Active/Inactive"
                            CssClass="btnBg" OnClick="btnStatus_Click" />
                    </td>
                    <td>
                        <div id="divOrderBtn" runat="server" visible="false">
                            <asp:Button ID="btnOrder" runat="server" Text="SET ORDER" ToolTip="Set Order" CssClass="btnBg"
                                OnClientClick="return Show();" />
                        </div>
                    </td>
                    <td>
                        <asp:Button ID="btnSetHome" runat="server" Text="Set Home Service" ToolTip="Set Home Service" Visible="false"
                            CssClass="btnBg" OnClick="btnSetHome_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnSetFlea" runat="server" Text="Set Flea Service" ToolTip="Set Flea Service"
                            CssClass="btnBg" OnClick="btnSetFlea_Click" />
                    </td>
                    
                </tr>
            </table>
            
            
            <%--region button end --%>
            <div id="divOrder" runat="server" style="display: none; margin: 20px 0 0 0;">
                <table>
                    <tr>
                        <td colspan="3" style="height: 138px">
                            <asp:ListBox ID="lstOrder" runat="server" CssClass="setorderListbox" Rows="10" SelectionMode="Multiple">
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnUP" runat="server" Text="Up" ToolTip="Up" CssClass="btnBg" OnClientClick="return Up();"
                                OnClick="btnUP_Click" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnDown" runat="server" Text="Down" ToolTip="Down" CssClass="btnBg"
                                OnClientClick="return Down();" OnClick="btnDown_Click" />
                        </td>
                        <td align="center">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBg" ToolTip="Cancel"
                                OnClientClick="return Hide()" />
                        </td>
                    </tr>
                </table>
            </div>
            
            
        </div>
        <asp:Button ID="btnLink" runat="server" Text="Go Back" CssClass="btnBg" OnClick="btnLink_Click" />
         
     </div>
    <%--</contenttemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

