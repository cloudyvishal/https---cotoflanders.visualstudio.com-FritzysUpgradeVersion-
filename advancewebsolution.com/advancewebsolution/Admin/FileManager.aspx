<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_FileManager" Title="Manage Static content" Codebehind="FileManager.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">
<div class="pageTitle">
            <h2>
                Manage Static content</h2>
        </div>
        
        
         <asp:GridView ID="GrdFileManager" runat="server" Width="100%"  
                    GridLines="Horizontal" CellPadding="4"
                    HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle" AutoGenerateColumns="False"   >
                    <AlternatingRowStyle CssClass="altGridStyle" />
                    <Columns>
                         
                        <asp:TemplateField HeaderText="Select">
                            <ItemStyle CssClass="itemstyle" Width="8%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="File Name" ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle" DataNavigateUrlFields="ImageName" DataNavigateUrlFormatString="ViewPage.aspx?File={0}" DataTextField="ImageName" NavigateUrl="ViewPage.aspx" />
                         
                       
                        <asp:TemplateField HeaderText="Type">
                            <ItemStyle CssClass="itemstyle" Width="8%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblFileType" runat="server" CssClass="deptdesc" Text='<%# Bind("FileType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Size (KB)">
                            <ItemStyle CssClass="itemstyle" Width="10%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblFileSize" runat="server" CssClass="deptdesc" Text='<%# Bind("FileSize") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="LastModified">
                            <ItemStyle CssClass="itemstyle" Width="15%" />
                            <HeaderStyle CssClass="headerStyle" />
                            <ItemTemplate>
                                <asp:Label ID="lblLastModified" runat="server" CssClass="deptdesc" Text='<%# Bind("LastModified") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                   
                 
                    
                </asp:GridView>
          
          </div>
</asp:Content>

