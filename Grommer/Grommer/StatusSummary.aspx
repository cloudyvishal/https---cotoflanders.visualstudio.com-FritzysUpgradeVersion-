<%@ Page Title="Stats Summary" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" Inherits="StatusSummary" Codebehind="StatusSummary.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="forsummary">
      
        <div>
            <b>Deposited Amount:
                <asp:Label ID="lblDeposit" runat="server"></asp:Label></b>
        </div>
        <br />
        <div class="divrow2">
            <div class="div_content" style="border-top: 1px solid #666666;">
                &nbsp;
            </div>
            <!-- div_first div ends -->
            <div class="div_content" style="border-top: 1px solid #666666;">
                <b>Today</b>
            </div>
            <!-- div_second div ends -->
            <%--<div class="div_content" style="border-top: 1px solid #666666;">
<b>Deposit</b>
</div> <!-- div_third div ends -->--%>
            <div class="div_content" style="border-top: 1px solid #666666;">
                <b>Month</b>
            </div>
            <!-- div_fourth div ends -->
        </div>
        <div class="stat_content">
            <div class="div_content">
                Pets
            </div>
            <div class="div_content">
                <asp:Label ID="lblPets" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label Text="50" ID="lblPetsDepositSummary" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label Text="500" ID="lblPetsMonthSummary1" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                Rpt Pets
            </div>
            <div class="div_content">
                <asp:Label ID="lblRptPets" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblRptPetsd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblRptPetsm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                Rbk Pets
            </div>
            <div class="div_content">
                <asp:Label ID="lblRbkPets" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblRbkPetsd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblRbkPetsm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                PFRbk
            </div>
            <div class="div_content">
                <asp:Label ID="lblPFRbk" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label  ID="lblPFRbkd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblPFRbkm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                NewPets</div>
            <div class="div_content">
                <asp:Label ID="lblNewPets" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblNewPetsd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblNewPetsm" runat="server"></asp:Label>
            </div>
        </div>
        <!-- stat_content div ends -->
        <div class="stat_content">
            <div class="div_content">
                NRbkPets
            </div>
            <div class="div_content">
                <asp:Label ID="lblNRbkPets" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblNRbkPetsd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblNRbkPetsm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                Hours
            </div>
            <div class="div_content">
                <asp:Label ID="lblHours" runat="server"></asp:Label>&nbsp;
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblHoursd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblHoursm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                F&T22
            </div>
            <div class="div_content">
                <asp:Label ID="lblFandT22" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblFandT22d" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblFandT22m" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                F&T44</div>
            <div class="div_content">
                <asp:Label ID="lblFandT44" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblFandT44d" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblFandT44m" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                F&T88
            </div>
            <div class="div_content">
                <asp:Label ID="lblFandT88" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblFandT88d" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblFandT88m" runat="server"></asp:Label>
            </div>
        </div>
        <!-- stat_content div ends -->
        <div class="stat_content">
            <div class="div_content">
                F&T132
            </div>
            <div class="div_content">
                <asp:Label ID="lblFandT132" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblFandT132d" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblFandT132m" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                F&Tcat
            </div>
            <div class="div_content">
                <asp:Label ID="lblFandTcat" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblFandTcatd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblFandTcatm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                TB
            </div>
            <div class="div_content">
                <asp:Label ID="lblTB" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblTBd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblTBm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                Wham
            </div>
            <div class="div_content">
                <asp:Label ID="lblWham" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblWhamd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblWhamm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                Appts
            </div>
            <div class="div_content">
                <asp:Label ID="lblAppts" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblApptsd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblApptsm" runat="server"></asp:Label>
            </div>
        </div>
        <!-- stat_content div ends -->
        <div class="stat_content">
            <div class="div_content">
                Rev
            </div>
            <div class="div_content">
                <asp:Label ID="lblRev" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblRevd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblRevm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                Tips
            </div>
            <div class="div_content">
                <asp:Label ID="lblTips" runat="server"></asp:Label>
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblTipsd" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblTipsm" runat="server"></asp:Label>
            </div>
        </div>
        <div class="stat_content">
            <div class="div_content">
                Fuel
            </div>
            <div class="div_content">
                <asp:Label ID="lblFuel" runat="server"></asp:Label>&nbsp;
            </div>
            <%--<div class="div_content">
<asp:Label ID="lblFueld" runat="server"></asp:Label>
</div>--%>
            <div class="div_content">
                <asp:Label ID="lblFuelm" runat="server"></asp:Label>
            </div>
        </div>
        <!-- stat_content div ends -->
    </div>
</asp:Content>
