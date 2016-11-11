<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_AdminHome" Title="Admin - Home" Codebehind="AdminHome.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <asp:Label ID="lblWelcomehome" runat="server" CssClass="welcomemsg" Text="Welcome to Fritzy's Pet Care Pros Administration"></asp:Label>
        <asp:Label ID="lblDate" runat="server" CssClass="lblhomedate"></asp:Label>
        <%--region Suggestion --%>
        <br style="clear: both;" />
        <div class="pageTitle">
            <h2>
                Recent Suggestions</h2>
        </div>
        <div style="width: 826px;">
            <div style="margin: 10px 0 0 0;">
                <asp:Label ID="lblNorec" runat="server" CssClass="errorTable" Text="Sorry, No suggestions found."></asp:Label>
            </div>
            <asp:GridView ID="GrdSuggestion" runat="server" AutoGenerateColumns="False" CellPadding="0"
                GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle"
                AlternatingRowStyle-CssClass="altGridStyle">
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
                    <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                        DataNavigateUrlFields="SuggestionID" DataNavigateUrlFormatString="ViewSuggestion.aspx?SuggestionID={0}"
                        DataTextField="VisiterName" HeaderText="Visitor Name" SortExpression="VisiterName">
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Suggestion">
                        <ItemStyle CssClass="itemstyle" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <div class="contactOverflow">
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Comment") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemStyle CssClass="itemstyle" Width="20%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date" SortExpression="Addedon">
                        <ItemStyle CssClass="itemstyle" Width="12%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAddedon" runat="server" Text='<%# Bind("Addedon", "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HyperLink ID="lnkSuggestion" runat="server" Text="View More" ToolTip="View More"
                CssClass="viewmorelink" NavigateUrl="~/Admin/Suggestion.aspx?SearchFor=0&SearchText="></asp:HyperLink>
            <br style="clear: both;" />
        </div>
        <%--region Suggestion End  --%>
        <%-- Region Users --%>
        <div class="pageTitle">
            <h2>
                Recent Members</h2>
        </div>
        <div style="width: 826px;">
            <div style="margin: 10px 0 0 0;">
                <asp:Label ID="lblNoUser" runat="server" CssClass="errorTable" Text="Sorry, No users found"></asp:Label>
            </div>
            <asp:GridView ID="GrdUsers" runat="server" DataKeyNames="UserID" AutoGenerateColumns="False"
                CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
                CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle">
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
                    <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                        DataNavigateUrlFields="UserID" DataNavigateUrlFormatString="ViewUsers.aspx?ID={0}&p=0"
                        DataTextField="fullName" HeaderText="User Name" SortExpression="FirstName"></asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemStyle CssClass="itemstyle" Width="30%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblRefLink" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Referral Name">
                        <ItemStyle CssClass="itemstyle" Width="20%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblRefName" runat="server" Text='<%# Bind("ReferalName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Added On" SortExpression="AddedOn">
                        <ItemStyle CssClass="itemstyle" Width="12%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblRefaddedon" runat="server" Text='<%# Bind("AddedOn", "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HyperLink ID="lnkUser" runat="server" Text="View More" ToolTip="View More" CssClass="viewmorelink"
                NavigateUrl="~/Admin/Users.aspx?SearchFor=0&SearchText="></asp:HyperLink>
            <br style="clear: both;" />
        </div>
        <%-- Region Users end --%>
        <%-- Region Contact us --%>
        <div class="pageTitle">
            <h2>
                Recent Contacts</h2>
        </div>
        <div style="width: 826px;">
            <div style="margin: 10px 0 0 0;">
                <asp:Label ID="lblNoContactus" runat="server" CssClass="errorTable" Text="Sorry, No request"></asp:Label>
            </div>
            <asp:GridView ID="grdContactUs" runat="server" AutoGenerateColumns="False" CellPadding="0"
                GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle" CssClass="gridStyle"
                AlternatingRowStyle-CssClass="altGridStyle">
                <AlternatingRowStyle CssClass="altGridStyle" />
                <PagerStyle CssClass="gridPager" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemStyle CssClass="itemstyle" Width="5%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="srnoContact" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField ItemStyle-CssClass="itemstyle" HeaderStyle-CssClass="headerStyle"
                        DataNavigateUrlFields="ContactID" DataNavigateUrlFormatString="ContactUsDetail.aspx?ID={0}&p=1"
                        DataTextField="fullName" HeaderText="Name" SortExpression="fullName"></asp:HyperLinkField>
                    <asp:TemplateField HeaderText="Message" SortExpression="Message">
                        <ItemStyle CssClass="itemstyle" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <div class="contactOverflow">
                                <asp:Label ID="lblImage" runat="server" Text='<%# Bind("Message") %>'></asp:Label></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" SortExpression="Email">
                        <ItemStyle CssClass="itemstyle" Width="20%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAddedon" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date" SortExpression="Addedon">
                        <ItemStyle CssClass="itemstyle" Width="12%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblFile" runat="server" Text='<%# Bind("Addedon", "{0:MMM-dd-yyyy hh:mm tt}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HyperLink ID="hypContactUS" runat="server" Text="View More" ToolTip="View More"
                CssClass="viewmorelink" NavigateUrl="~/Admin/ContactUs.aspx?SearchFor=0&SearchText="></asp:HyperLink>
            <br style="clear: both;" />
        </div>
        <%-- Region Contact us end--%>
        <%-- Region Appointment --%>
        <div class="pageTitle">
            <h2>
                Recent Appointments</h2>
        </div>
        <div style="width: 826px;">
            <div style="margin: 10px 0 0 0;">
                <asp:Label ID="lblNoAppointment" runat="server" CssClass="errorTable" Text="Sorry, No Appointment"></asp:Label>
            </div>
            <asp:GridView ID="grdAppointment" runat="server" DataKeyNames="UserID" AutoGenerateColumns="False"
                CellPadding="0" GridLines="Vertical" Width="100%" HeaderStyle-CssClass="headerStyle"
                CssClass="gridStyle" AlternatingRowStyle-CssClass="altGridStyle">
                <AlternatingRowStyle CssClass="altGridStyle" />
                <PagerStyle CssClass="gridPager" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No.">
                        <ItemStyle CssClass="itemstyle" Width="5%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="srnoAppointment" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemStyle CssClass="itemstyle" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:HyperLink ID="hypUser" runat="server" Text='<%# Bind("FullName")  %>' NavigateUrl='<%# "ViewUsers.aspx?ID=" + Eval("UserID") + "&p=0" %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date/Time">
                        <ItemStyle CssClass="itemstyle" Width="12%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:HyperLink ID="hyp" runat="server" Text='<%# Bind("Date", "{0:MMM-dd-yyyy hh:mm tt}")  %>'
                                NavigateUrl='<%# "ViewAppointment.aspx?ID=" + Eval("AppointmentID") + "&p=0" %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Flexible">
                        <ItemStyle CssClass="itemstyle" Width="14%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblFlex" runat="server" Text='<%# Bind("Flex") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemStyle CssClass="itemstyle" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ConfirmBy">
                        <ItemStyle CssClass="itemstyle" Width="10%" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblConfirmBy" runat="server" Text='<%# Bind("ConfirmBy") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Note" Visible="false">
                        <ItemStyle CssClass="itemstyle" />
                        <HeaderStyle CssClass="headerStyle" />
                        <ItemTemplate>
                            <asp:Label ID="lblNote" runat="server" Text='<%# Bind("Note") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HyperLink ID="hypAppointment" runat="server" Text="View More" ToolTip="View More"
                CssClass="viewmorelink" NavigateUrl="~/Admin/Appointment.aspx?SearchFor=0&SearchText="></asp:HyperLink>
            <br style="clear: both;" />
        </div>
        <%-- Region Appointment end --%>
    </div>
</asp:Content>
