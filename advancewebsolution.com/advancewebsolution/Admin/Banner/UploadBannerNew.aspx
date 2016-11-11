<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Baner_UploadBannerNew" Title="Upload Banner" Codebehind="UploadBannerNew.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function DeleteConfirmation() {
            if (confirm("Are you sure,want to delete selected records ?") == true)
                return true;
            else
                return false;
        }
    </script>

    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Upload Banner</h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="true">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblSuccess" runat="server" Visible="false" Text="Banner Uploaded Successfully"
                                Font-Bold="true"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 13%;" valign="top">
                    Select Banner :
                </td>
                <td>
                    <asp:FileUpload ID="flv" runat="server" contenteditable="false" onkeypress="return false" />
                    <br />
                    You can upload .JPEG, .GIF, .BMP, .PNG files for Banner with maximum size of 666
                    X 256.
                </td>
            </tr>
            <tr>
                <td style="width: 15%;">
                    Banner Id :
                </td>
                <td>
                    <asp:TextBox ID="txtId" runat="server" MaxLength="6" Width="80px" Enabled="false"
                        CssClass="txtdisabled" ForeColor="Black" />
                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbBannerId" runat="server" TargetControlID="txtId"
                        FilterType="Numbers" />
                </td>
            </tr>
        </table>
        <asp:Button ID="btnUp" runat="server" Text="Upload" OnClick="btnUp_Click" CssClass="servbtnBg" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="servbtnBg" OnClick="btnCancel_Click" />
        &nbsp;<br />
        <img src="../images/seperator.jpg" alt="" />
        <br />
        <div>
            <asp:GridView ID="GrdBaner" runat="server" AutoGenerateColumns="False" AllowSorting="true"
                AllowPaging="true" PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%"
                HeaderStyle-CssClass="headerStyle" CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle"
                OnPageIndexChanging="GrdBaner_PageIndexChanging" OnDataBound="GrdBaner_DataBound"
                OnRowCreated="GrdBaner_RowCreated" OnRowDataBound="GrdBaner_RowDataBound">
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
                <PagerStyle CssClass="gridPager1" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No." Visible="false">
                        <ItemStyle CssClass="itemstyle1" Width="5%" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="headerStyle2" />
                        <ItemTemplate>
                            <asp:Label ID="srno" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Banner Id">
                        <ItemStyle CssClass="itemstyle1" Width="12%" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="headerStyle2" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle CssClass="itemstyle1" Width="7%" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="headerStyle2" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkall" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Banner Image">
                        <ItemStyle CssClass="itemstyle" HorizontalAlign="center" />
                        <HeaderStyle CssClass="headerStyle1" HorizontalAlign="left" />
                        <ItemTemplate>
                            <div style="padding: 5px 0px; width: 180px; border: 0px solid #f00;">
                                <img alt="Image" width="170" height="80" src='<%#DataBinder.Eval(Container.DataItem,"BannerPath") %>'
                                    runat="server" id="imgThumb" /></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile Image">
                        <ItemStyle CssClass="itemstyle" HorizontalAlign="center" />
                        <HeaderStyle CssClass="headerStyle1" HorizontalAlign="left" />
                        <ItemTemplate>
                            <div style="padding: 5px 0px; width: 180px; border: 0px solid #f00;">
                                <img alt="Image" width="170" height="80" src='<%#DataBinder.Eval(Container.DataItem,"virtualmobilepath") %>'
                                    runat="server" id="imgThumbMobile" /></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Used In">
                        <ItemStyle CssClass="itemstyle1" Width="50%" HorizontalAlign="Center" />
                        <HeaderStyle CssClass="headerStyle2" />
                        <ItemTemplate>
                            <div style="width: 400px; word-wrap: break-word;">
                                <asp:Label ID="lblUserForms" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"UsedForms") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Banner Id" Visible="false">
                        <ItemStyle CssClass="itemstyle" Width="5%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblBannerId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"BannerId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
        <asp:Button ID="btnDelete" CssClass="servbtnBg" runat="server" OnClientClick="return DeleteConfirmation();" Text="Delete" OnClick="btnDelete_Click"/>
        <br />
        <asp:Label ID="Label1" runat="server" Text="0=Unregistered User, 1=Registered User-Cat, 2=Registered User-Dog, 3=Registered User-Cat & Dog." Font-Size="Smaller"></asp:Label>
    </div>
</asp:Content>
