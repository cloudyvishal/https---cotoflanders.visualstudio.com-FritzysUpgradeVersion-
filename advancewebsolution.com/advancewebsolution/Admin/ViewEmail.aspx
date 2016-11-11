<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_ViewEmail" Title="Untitled Page" Codebehind="ViewEmail.aspx.cs" %>



<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript" >
    function Validate()
    {
        if(document.getElementById('<%=txtSubject.ClientID %>').value == "")
        {
            alert("Please enter subject mail");
            document.getElementById('<%=txtSubject.ClientID %>').focus();
            return false;
        }
    }
</script>
    <div class="innerContent">
        <div class="pageTitle">
            <h2>
                <asp:Label ID="lblHead" runat="server" ></asp:Label> </h2>
        </div>
        <div class="errorDiv" id="divError" runat="server" visible="false">
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
        <br style="clear:both;" />
        <table>
            <tr>
                <td>Subject : </td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" Width="500px" ></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td colspan="2">
                    
                    <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" CssClass="btnBg"
            OnClick="btnSave_Click" OnClientClick="return Validate();" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
            ToolTip="Cancel" CssClass="btnBg" OnClick="btnCancel_Click" />
    </div>
</asp:Content>

