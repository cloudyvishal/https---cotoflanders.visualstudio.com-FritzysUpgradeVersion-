<%@ Page Title="View Groomers" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Groomer_GroomersForData" CodeBehind="GroomersForData.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">




    <div class="innerContent">
        <div class="pageTitle">
            <h2>Groomer's Operations Log Daily</h2>
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
                    <br style="clear: both;" />
                </td>
            </tr>

        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Select Groomer:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlGroomerlist" runat="server" CssClass="selectBox" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlGroomerlist_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

