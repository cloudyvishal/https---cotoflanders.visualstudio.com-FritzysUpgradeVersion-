<%@ Page Title="Upload Groomer Appointments" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_UploadGroomerAppointments" CodeBehind="UploadGroomerAppointments.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <div class="innerContent">
                <div class="pageTitle">
                    <h2>Upload Groomer Appointments Excel Files</h2>
                </div>
                <%--Region Error/Success message start--%>
                <div class="errorDiv" id="divError" runat="server" visible="true" style="height:66px !important">
                    <table width="100%">
                        <tbody>
                            <tr>
                                <td align="left" rowspan="2">
                                    <asp:Label ID="lblError" runat="server" Visible="true" EFont-Bold="True"></asp:Label>&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <%--Region Error/Success message end--%>
                <table class="adduserTable" cellpadding="6" cellspacing="0">
                    <tr id="trupload" runat="server">
                        <td valign="top">Upload File </td>
                        <td>
                            <asp:FileUpload ID="ApptFile" runat="server" CssClass="selectBox" />
                            <br />
                            <asp:RegularExpressionValidator ID="revImage" runat="server" ControlToValidate="ApptFile" ErrorMessage=" ! file format is not supported." ValidationExpression="^.*\.((x|X)(l|L)(s|S))$" ValidationGroup="Submit" />
                            <br />
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="Submit" CssClass="btnBg" />
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td style="width: 150px;">&nbsp;
                        </td>
                        <td valign="top">
                        </td>
                    </tr>
                </table>
                 <asp:Label ID="lblMessage" runat="server" Font-Bold="True" visible="false" ForeColor="Red">Please confirm the appointments </asp:Label>
                            <asp:Panel ID="pnlMatch" runat="server" Visible="false">
                                <asp:GridView ID="grdAppointment" runat="server" DataKeyNames="AppointmentID" AllowPaging="true"
                                    AllowSorting="true" PageSize="10" CellPadding="0" GridLines="Vertical" Width="100%"
                                    HeaderStyle-CssClass="headerStyle" AutoGenerateColumns="false" CssClass="gridStyle itemstyle"
                                    AlternatingRowStyle-CssClass="altGridStyle"
                                    OnPageIndexChanging="grdAppointment_PageIndexChanging"
                                    OnDataBound="grdAppointment_DataBound"
                                    OnSorting="grdAppointment_Sorting"
                                    OnRowCreated="grdAppointment_RowCreated">

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

                                        <asp:TemplateField HeaderText="Appointment Id" SortExpression="AppointmentID">
                                            <ItemStyle CssClass="itemstyle" Width="15%" />
                                            <HeaderStyle CssClass="headerStyle" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAppointmentID" runat="server" Text='<%# Bind("AppointmentID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemStyle CssClass="itemstyle" Width="15%" />
                                            <HeaderStyle CssClass="headerStyle" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFullName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Appointment Date" >
                                            <ItemStyle CssClass="itemstyle" Width="11%" />
                                            <HeaderStyle CssClass="headerStyle" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblDateAppointment" runat="server" Text='<%# Bind("AppointmentDate", "{0:MMM-dd-yyyy hh:mm tt}")  %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Groomer Name">
                                            <ItemStyle CssClass="itemstyle" Width="10%" />
                                            <HeaderStyle CssClass="headerStyle" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblConfirmBy" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ExpectedTotalRevenue">
                                            <ItemStyle CssClass="itemstyle" Width="12%" />
                                            <HeaderStyle CssClass="headerStyle" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblConfirm" runat="server"> $ <%#String.Format("{0:0.00}",Eval("ExpectedTotalRevenue"))%></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Appointment String">
                                            <ItemStyle CssClass="itemstyle" Width="19%" />
                                            <HeaderStyle CssClass="headerStyle" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Others") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
