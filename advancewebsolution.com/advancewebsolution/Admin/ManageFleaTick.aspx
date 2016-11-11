<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ManageFleaTick" Title="Admin - Manage Flea Tick & Hot Spot"  Codebehind="ManageFleaTick.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
<div class="pageTitle">
                    <h2>Manage Flea, Tick and Hot Spot</h2>
                </div>
    <div class="errorDiv" id="divError" runat="server" visible="false">
        <table width="100%">
            <tbody>
                <tr>
                    <td align="left" rowspan="2">
                        <asp:Label ID="lblError" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                </tbody>
        </table>
    </div>
               
                <div class="setServDiv">    
                    <div id="divCat" runat="server">
                        <table border="0" class="setservPage">
                            <tr>
                                <td style="width:10%;">
                                    Cat :
                                </td>
                                <td style="width:70%;">
                                    <asp:DropDownList ID="ddlCat" CssClass="setServPageDdl" runat="server">
                                    </asp:DropDownList>
                                    
                                </td>
                                <td valign="top">
                                    <asp:Button ID="btnCat" runat="server" Text="Set Service" ToolTip="Set Service" OnClick="btnCat_Click"
                                        CssClass="servbtnBg" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                    <div id="divDog" runat="server">
                        <table border="0" class="setservPage">
                            <tr>
                                <td style="width:10%;">
                                    Dog :
                                </td>
                                <td style="width:70%;">
                                    <asp:DropDownList ID="ddlDog" CssClass="setServPageDdl" runat="server">
                                    </asp:DropDownList>
                                    
                                </td>
                                <td valign="top">
                                    <asp:Button ID="btnDog" runat="server" Text="Set Service" ToolTip="Set Service" OnClick="btnDog_Click"
                                        CssClass="servbtnBg" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
               
               
            

            <asp:GridView ID="GrdServiceHome" runat="server" DataKeyNames="ServiceID" AutoGenerateColumns="False"
                    PageSize="5" CellPadding="0" GridLines="Vertical" Width="100%" 
                    HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle">
                    <AlternatingRowStyle CssClass="altGridStyle" />
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
                        
                 
                        
                        <asp:TemplateField HeaderText="Service Title"  >
                          <ItemStyle CssClass="itemstyle"   />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblRefLink" runat="server" Text='<%# Bind("ServiceTitle") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Service For"  >
                             <ItemStyle CssClass="itemstyle" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblServiceFor" runat="server" Text='<%# Bind("ServiceFor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Service For" Visible="false"   >
                             <ItemStyle CssClass="itemstyle"  />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblServiceType" runat="server" Text='<%# Bind("ServiceType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Service For" Visible="false"   >
                             <ItemStyle CssClass="itemstyle"   />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblServiceID" runat="server" Text='<%# Bind("ServiceID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Status" Visible="false"  >
                             <ItemStyle CssClass="itemstyle" Width="8%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                   
                </asp:GridView>
                
                <asp:Button ID="btnRemove" runat="server" Text="Remove"  CssClass="btnBg" ToolTip="Remove" OnClick="btnRemove_Click" />
               
                 
                </div>
               
</asp:Content>

