<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_EditMeta" Title="Admin - Edit Metatags" Codebehind="EditMeta.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function ValidateAdd() {
        if (document.getElementById('<%=txtName.ClientID %>').value == "") {
            alert("Please enter meta name");
            return false;
        }

        if (document.getElementById('<%=txtContent.ClientID %>').value == "") {
            alert("Please enter meta tag description");
            return false;
        }
        if (document.getElementById('<%=txtKeywords.ClientID %>').value == "") {
            alert("Please enter meta tag Keywords");
            return false;
        }
        

    }

    function ValidateKeyword(num) {

        if (num == "") {
            return false;
        }
        var OnlyNumbers = /^[a-zA-Z0-9,\s]+$/;
        if (OnlyNumbers.test(num)) {
            if ((num.length < 1) || (num.length > 1000)) {
                return false;
            }
            return true;
        }
        else {
            return false;
        }

    }

    function checkTextAreaMaxLength(textBox, e, length) {
        var mLen = textBox["MaxLength"];
        if (null == mLen)
            mLen = length;
        var maxLength = parseInt(mLen);
        if (!checkSpecialKeys(e)) {
            if (textBox.value.length > maxLength - 1) {
                if (window.event)//IE
                    e.returnValue = false;
                else//Firefox
                    e.preventDefault();
            }
        }
    }
        
</script>
 <div class="innerContent">
<div class="pageTitle">
    <h2>
        Edit Meta tags</h2>
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
     <table class="adduserTable" cellpadding="6" cellspacing="0">
            <tr>
                <td>
                    <span class="star">*</span>Name :
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   <span class="star">*</span>Description :
                </td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" Rows="5" Columns="60" TextMode="MultiLine"
                        MaxLength="500" onkeyDown="checkTextAreaMaxLength(this,event,'300');"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                   <span class="star">*</span>Keywords :
                </td>
                <td>
                    <asp:TextBox ID="txtKeywords" runat="server" Rows="5" Columns="60" TextMode="MultiLine"
                        MaxLength="1000" onkeyDown="checkTextAreaMaxLength(this,event,'300');"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                              
                </td>
            </tr>
        </table>
     
     <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnBg" OnClientClick="return ValidateAdd()"
                        OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
         CssClass="btnBg"  
         onclick="btnCancel_Click" />
                    
</div>
</asp:Content>

