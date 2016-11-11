<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ViewAppointment" Title="View Appointment" Codebehind="ViewAppointment.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                Appointment Details
            </h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td style="width: 15%;">
                    Name :
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Address :
                </td>
                <td>
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Email :
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Phone :
                </td>
                <td>
                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Date :
                </td>
                <td>
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 15%;">
                    Confirmed :
                </td>
                <td>
                     <asp:Label ID="lblConfirm" runat="server" Visible="true"></asp:Label>
                    <asp:DropDownList ID="ddlConfirm" runat="server" OnSelectedIndexChanged="ddlConfirm_SelectedIndexChanged" AutoPostBack="True" Visible="false" >
                        <asp:ListItem Value="No">No</asp:ListItem>
                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Confirm By :
                </td>
                <td>
                    <asp:Label ID="lblConfirmBy" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Flexible :
                </td>
                <td>
                    <asp:Label ID="lblFlex" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Note :
                </td>
                <td>
                    <asp:Label ID="lblNote" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Pet :
                </td>
                <td>
                    <asp:Label ID="lblPetName" runat="server"></asp:Label>
                </td>
            </tr>
               <tr>
            <td>Paid Status : </td>
            <td><asp:Label ID="lblPaidStatus" runat="server"></asp:Label></td>
            </tr>
             <tr>
            <td>Paid Amount : </td>
            <td><asp:Label ID="lblPaidAmount" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td>Services : </td>
            <td><asp:Label ID="lblPetServices" runat="server"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="txt1" runat="server" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btnBg" ToolTip="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="btnBg" ToolTip="Update the changes" OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnBg" ToolTip="Cancel"   OnClick="btnCancel_Click" />
    </div>
</asp:Content>
