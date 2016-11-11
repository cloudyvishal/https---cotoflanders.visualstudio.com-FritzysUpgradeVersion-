<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Users" Title="Manage Users" Codebehind="Users.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<script type="text/javascript" language="javascript" >
function ShowDiv()
{
    document.getElementById('<%=divShow.ClientID %>').style.display = "Block";
    document.getElementById('<%=divBtn.ClientID %>').style.display = "none";
    return false;
}

function HideDiv()
{
    document.getElementById('<%=divShow.ClientID %>').style.display = "none";
    document.getElementById('<%=divBtn.ClientID %>').style.display = "block";
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

function ShowExport()
{
    document.getElementById('<%=divExport.ClientID %>').style.display = "Block";
    document.getElementById('<%=divBtn.ClientID %>').style.display = "none";
    document.getElementById('<%=txtStartDate.ClientID %>').value="";
    document.getElementById('<%=txtEndDate.ClientID %>').value="";
    return false;
}

function HideExport()
{
    document.getElementById('<%=divExport.ClientID %>').style.display = "none";
    document.getElementById('<%=divBtn.ClientID %>').style.display = "block";
    return false;
}

function ValidateExport()
{
    if(document.getElementById('<%=txtStartDate.ClientID %>').value == "")
    {
        alert("Please select start date");
        document.getElementById('<%=txtStartDate.ClientID %>').focus();
        return false;
    }
     if(document.getElementById('<%=txtEndDate.ClientID %>').value == "")
    {
        alert("Please select end date");
        document.getElementById('<%=txtEndDate.ClientID %>').focus();
        return false;
     }
    if(document.getElementById('<%=txtStartDate.ClientID %>').value != "" & document.getElementById('<%=txtEndDate.ClientID %>').value!="")
        var StartDate =document.getElementById('<%=txtStartDate.ClientID %>').value;
        var EndDate   = document.getElementById('<%=txtEndDate.ClientID %>').value;
        var eDate = new Date(EndDate);
        var sDate = new Date(StartDate);
        if (StartDate != '' && StartDate != '' && sDate > eDate) {
            alert("Please ensure that the End Date is greater than or equal to the Start Date.");
            return false;
        }
}
 

</script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Manage Members</h2>
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
        <br style="clear:both;" />
        </td>
    </tr>
    
    <tr>
        <td>
            <div id="divsearch" runat="server" class="searchtopDiv">
                        <table border="0" class="searchTable">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSearch" runat="server">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Member Name"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Email"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Referral Name"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" ToolTip="SEARCH" CssClass="servbtnBg"
                                        OnClick="btnSearch_Click" OnClientClick="return validate();" />
                                </td>
                                <td>
                                    <asp:Button ID="btnViewall" runat="server" Text="View All" ToolTip="VIEW ALL" CssClass="servbtnBg" OnClick="btnViewall_Click" />
                                </td>
                            </tr>
                        </table><div style="clear:both;"></div>
                    </div>
        </td>
    </tr>
    
</table>
    
       <br style="clear:both;" />
        
        
   <asp:UpdatePanel ChildrenAsTriggers="true" runat="server" UpdateMode="Conditional" >
       <ContentTemplate>
        <%--Region Error/Success message end--%>
        <%-- Region  grid start--%>  
        <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="UserID" AutoGenerateColumns="False" 
            OnPageIndexChanging="GrdUsers_PageIndexChanging" AllowSorting="true" AllowPaging="true"
            PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
            CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" OnSorting="GrdUsers_Sorting" OnDataBound="GrdUsers_DataBound" OnRowCreated="GrdUsers_RowCreated">
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
            <AlternatingRowStyle CssClass="altGridStyle" HorizontalAlign="Left" />
            <RowStyle HorizontalAlign="Left" />
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

              <asp:TemplateField HeaderText="Member Name" SortExpression="FirstName">
                     <ItemStyle CssClass="itemstyle" Width="5%" />
                    <HeaderStyle CssClass="headerStyle" />
                  <ItemTemplate>
                      <asp:Label visible='<%# (Eval("IsActive").ToString()=="InActive") ? true : false %>' runat="server" ID="lblUserName" Text='<%#Bind("fullName") %>'></asp:Label>
                  <asp:HyperLink ID="hpLnkName" 
                      NavigateUrl='<%# String.Format("ViewUsers.aspx?ID={0}&p=1", Eval("UserID")) %>'
                       runat="server" visible='<%# (Eval("IsActive").ToString()=="InActive") ? false : true %>' Text='<%#Bind("fullName") %>' />
                  </ItemTemplate>
              </asp:TemplateField>

               
                   
                <asp:TemplateField HeaderText="Email" SortExpression="FirstName">
                    <ItemStyle CssClass="itemstyle"  Width="30%"/>
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblRefLink" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Referral Name" SortExpression="ReferalName">
                    <ItemStyle CssClass="itemstyle"  Width="20%"/>
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblRefName" runat="server" Text='<%# Bind("ReferalName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Added On" SortExpression="AddedOn">
                    <ItemStyle CssClass="itemstyle"  Width="12%"/>
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblRefaddedon" runat="server" Text='<%# Bind("AddedOn" , "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Status">
                    <ItemStyle CssClass="itemstyle"  Width="12%"/>
                    <HeaderStyle CssClass="headerStyle" />
                    <ItemTemplate>
                        <asp:Label ID="lblActive" runat="server" Text='<%# Bind("IsActive")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <%--region button start--%>
         <div id="divBtn" runat="server" style="display:block;">
        <asp:Button ID="btnDelete" OnClientClick="return confirm('Are  You Sure Want To Permanentaly Delete selected users records?')" runat="server" Text="Delete" ToolTip="Delete" CssClass="btnBg" OnClick="btnDelete_Click1" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnActiveInActive" OnClientClick="return confirm('Are  You Sure Want To change status of selected users records?')"  runat="server" Text="Active/InActive" ToolTip="Active/InActive" CssClass="btnBg" OnClick="btnActiveInActive_Click" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnExpo" runat="server" Text="Export" ToolTip="Export Users" CssClass="btnBg"  OnClientClick="return ShowExport();" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnImport" runat="server" Text="Import" CssClass="btnBg" OnClientClick="return ShowDiv();" ToolTip="Import" />
       <asp:Button ID="lnkNorec" runat="server" CssClass="btnBg" Text="Go Back" Visible="false" OnClick="lnkNorec_Click" />
        <%--region button end --%>
       </div>
           </ContentTemplate>
       <triggers>
           <asp:asyncpostbacktrigger controlid="grdusers"  eventname="pageindexchanging"/>
            <asp:asyncpostbacktrigger controlid="btndelete"  eventname="click"/>
            <asp:asyncpostbacktrigger controlid="btnactiveinactive"  eventname="click"/>
            <asp:asyncpostbacktrigger controlid="btnexpo"  eventname="click"/>
            <asp:asyncpostbacktrigger controlid="btnimport"  eventname="click"/>
             <asp:asyncpostbacktrigger controlid="lnknorec"  eventname="click"/>
       </triggers>
       </asp:updatepanel>
     
        <%-- Region  grid end --%>
      
       
        <div id="divShow" runat="server" style="display: none; margin:10px 0 0 0; " class="itemstyle">
        <table border="0" style="margin: 10px 0pt 0pt;">
            <tr>
                <td>
                    <span class="star" style="color:#f00;">*</span> Upload file
                </td>
                <td>
                    <input id="flUpload" runat="server" type="file" onkeypress="return false;" />
                </td>
                <td >
                    <asp:Button ID="btnUpload" Text="Upload" runat="server" CssClass="servbtnBg" border="0" OnClick="btnUpload_Click" />
                    <asp:Button ID="btnHide" Text="Cancel" runat="server" CssClass="servbtnBg" border="0" OnClientClick="return HideDiv();"/>
                </td>
            </tr>
        </table>
    </div>
      
      
      <div id="divExport" runat="server" style="margin: 10px 0pt 0pt;display:none;" class="itemstyle">
      <table border="0" style="margin: 10px 0pt 0pt;">
        <tr>
            <td>Start Date :</td>
            <td>
            <asp:TextBox ID="txtStartDate" onkeypress="return false;"   runat="server" ></asp:TextBox>
            <asp:ImageButton ID="imgCalPop" runat="server" ImageUrl="~/Images/calImage.jpg"   />
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/d/yyyy" PopupButtonID="imgCalPop" TargetControlID="txtStartDate"></cc1:CalendarExtender>
            </td>
            <td>End Date : </td>
            <td>
            <asp:TextBox ID="txtEndDate" onkeypress="return false;"   runat="server" ></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calImage.jpg"   />
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/d/yyyy" PopupButtonID="ImageButton1"  TargetControlID="txtEndDate"  ></cc1:CalendarExtender>
            </td>
            <td>
            <asp:Button ID="btnExport" runat="server" Text="Export" ToolTip="Export Users" OnClientClick="return ValidateExport();" CssClass="servbtnBg" OnClick="btnExport_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="servbtnBg" OnClientClick="return HideExport();" />
            </td>
        </tr>
      </table>
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
             <br />
                                              
            
            
             
        </div>
      
    </div>
</asp:Content>