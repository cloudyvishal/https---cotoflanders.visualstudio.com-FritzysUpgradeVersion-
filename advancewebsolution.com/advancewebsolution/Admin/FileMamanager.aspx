<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_FileMamanager" Title="Untitled Page" Codebehind="FileMamanager.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="pageTitle">
            <h2>
                Manage Statice content</h2>
        </div>
        
        
         <asp:GridView ID="GrdFileManager" runat="server" Width="100%" PageSize="10" AllowPaging="true"
                    Height="20px" GridLines="Horizontal" CellPadding="4" BorderWidth="1px" BackColor="White"
                    CssClass="tableborder" AutoGenerateColumns="False"   >
                    <FooterStyle BackColor="#507CD1" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"
                        VerticalAlign="Middle"></FooterStyle>
                    <Columns>
                         
                        <asp:TemplateField HeaderText="Select">
                            <ItemStyle CssClass="tableborder" HorizontalAlign="Center" Width="5%"></ItemStyle>
                            <HeaderStyle CssClass="tableborder" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="ImageName" DataNavigateUrlFormatString="ViewPage.aspx?File={0}" DataTextField="ImageName" NavigateUrl="ViewPage.aspx" />
                         
                        <asp:TemplateField HeaderText="Image Name">
                            <ItemStyle CssClass="tableborder" HorizontalAlign="Left"></ItemStyle>
                            <HeaderStyle CssClass="tableborder"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblImageName" runat="server" CssClass="deptdesc" Text='<%#  Bind("ImageName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type">
                            <ItemStyle CssClass="tableborder" HorizontalAlign="Center" ></ItemStyle>
                            <HeaderStyle CssClass="tableborder" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblFileType" runat="server" CssClass="deptdesc" Text='<%# Bind("FileType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Size (KB)">
                            <ItemStyle CssClass="tableborder" HorizontalAlign="Center" ></ItemStyle>
                            <HeaderStyle CssClass="tableborder" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblFileSize" runat="server" CssClass="deptdesc" Text='<%# Bind("FileSize") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="LastModified">
                            <ItemStyle CssClass="tableborder" HorizontalAlign="Center" ></ItemStyle>
                            <HeaderStyle CssClass="tableborder" HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblLastModified" runat="server" CssClass="deptdesc" Text='<%# Bind("LastModified") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <RowStyle BackColor="White"></RowStyle>
                    <SelectedRowStyle BackColor="#738A9C" ForeColor="#F7F7F7" Font-Bold="True"></SelectedRowStyle>
                    <PagerStyle BackColor="White" ForeColor="#4A3C8C" CssClass="link2" HorizontalAlign="Center"
                        VerticalAlign="Middle"></PagerStyle>
                    <HeaderStyle CssClass="tableheading" HorizontalAlign="Center"></HeaderStyle>
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                </asp:GridView>
</asp:Content>

