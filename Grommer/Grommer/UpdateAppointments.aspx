<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Inherits="UpdateAppointments" Title="Untitled Page" Codebehind="UpdateAppointments.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="calendar">
        <asp:Calendar ID="rbkOldCalendar" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" ShowGridLines="True"
            OnSelectionChanged="rbkOldCalendar_SelectionChanged">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        </asp:Calendar>
        <br />
        <br />
    </div>
    <div>
        <asp:GridView ID="grdOldApp" runat="server" AutoGenerateColumns="false" CellPadding="4"
            Font-Names="Times New Roman" Font-Size="Small" ForeColor="#333333" OnRowEditing="grdOldApp_RowEditing"
            DataKey="DailyLogId">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblDailylogID" runat="server" Text='<%#Eval("DailyLogId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Appointment Date">
                    <ItemTemplate>
                        <asp:Label ID="lblAppDate" runat="server" Text='<%#Eval("NextAppointmentDate")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                     <span class="lbl" style="font-weight: bold;">Month :</span>
                        <asp:DropDownList ID="ddlMonth" runat="server" Style="font-size: 11px;">
                                        <asp:ListItem Text="January" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="February" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="March" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="April" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="May" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="June" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="July" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="August" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="September" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="October" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="November" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="December" Value="12"></asp:ListItem>
                                    </asp:DropDownList><br /><br />
                                     <span class="lbl" style="font-weight: bold;">Day :</span>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="dddDay" runat="server">
                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                        <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    </asp:DropDownList><br /><br />
                                     <span class="lbl" style="font-weight: bold;">Year :</span>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlYear" runat="server">
                                        <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                                        <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                                        <asp:ListItem Text="2012" Value="2012" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                    </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Start Time">
                    <ItemTemplate>
                        <asp:Label ID="lblAppNextDate" runat="server" Text='<%#Eval("NextAppointmentTime")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span class="lbl" style="font-weight: bold;">Hrs :</span>
                        <asp:DropDownList ID="ddlhr" CssClass="appTextFldtime" runat="server">
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                            <asp:ListItem Text="1:00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                        </asp:DropDownList><br /><br />
                        <span class="lbl" style="font-weight: bold;">Min :</span><asp:DropDownList ID="ddlMin1"
                            CssClass="appTextFldAm" runat="server">
                            <asp:ListItem Text="00" Value="00"></asp:ListItem>
                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="25" Value="25"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="35" Value="35"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="45" Value="45"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="55" Value="55"></asp:ListItem>
                        </asp:DropDownList><br /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlmin" CssClass="appTextFldAm" runat="server">
                            <asp:ListItem Value="AM" Text="AM"></asp:ListItem>
                            <asp:ListItem Value="PM" Text="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="End Time">
                    <ItemTemplate>
                        <asp:Label ID="lblAppEndDate" runat="server" Text='<%#Eval("NextAppointmentEndTime")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span class="appnt_lbl" style="font-weight: bold;">Hrs :</span>
                        <asp:DropDownList ID="ddlEndTimeHrs" CssClass="appTextFldtime" runat="server">
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8:00" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9:00" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10:00" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11:00" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12:00" Value="12"></asp:ListItem>
                            <asp:ListItem Text="1:00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2:00" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3:00" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4:00" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5:00" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6:00" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7:00" Value="7"></asp:ListItem>
                        </asp:DropDownList><br /><br />
                        <span class="appnt_lbl" style="font-weight: bold;">Min :</span><asp:DropDownList
                            ID="ddlEndTimeMin1" CssClass="appTextFldAm" runat="server">
                            <asp:ListItem Text="00" Value="00"></asp:ListItem>
                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="25" Value="25"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="35" Value="35"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="45" Value="45"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="55" Value="55"></asp:ListItem>
                            <asp:ListItem>00</asp:ListItem>
                        </asp:DropDownList><br /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlEndTimeMin" CssClass="appTextFldAm" runat="server">
                            <asp:ListItem Value="AM" Text="AM"></asp:ListItem>
                            <asp:ListItem Value="PM" Text="PM"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" ImageUrl="~/images/1356628064_pensil.png"
                            ToolTip="Edit" Width="24px" Height="24px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" /><br />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnGoback" runat="server" Text="Go Back" CssClass="btn" 
                onclick="btnGoback_Click" />
    </div>
</asp:Content>
