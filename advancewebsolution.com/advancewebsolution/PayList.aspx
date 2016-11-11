<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    Inherits="PayList" Title="Payment List" Codebehind="PayList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPlaceholder">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <!-- reg main start here -->
                    <table align="center" style="width: 100%">
                        <tr>
                            <td>
                                <table align="center" style="width: 100%">
                                    <tr>
                                        <td align="left" colspan="2">
                                            <h2>
                                                Payments
                                                <br />
                                            </h2>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblsmsg" runat="server" Text="Your Payment Submitted Successfully!!!"
                                                    ForeColor="Green" Font-Bold="true" Font-Size="Medium" Visible="false"></asp:Label></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="right" width="108">
                                           <span style="font-size:medium; font-weight:bolder" > <asp:Label ID="lblSyncPayment" runat="server" Text="Sync Payment"></asp:Label></span>
                                            &nbsp;
                                        </td>
                                        <td align="left" width="210">
                                          <span style="font-size:medium; font-weight:bolder" >  <asp:LinkButton ID="btnSycAppLink" runat="server" Enabled="false" OnClick="btnSycAppLink_Click">Sync Appointment Payment</asp:LinkButton></span>
                                        </td>
                                    </tr>
                                  
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- reg top end here -->
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
