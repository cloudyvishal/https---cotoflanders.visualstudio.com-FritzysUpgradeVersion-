<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_LocationService_AddServiceLocation" Title="Admin - Add Service Location" Codebehind="AddServiceLocation.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="innerContent">

<div class="pageTitle">
                    <h2>Add Service Location</h2>
                </div>
             <%--Region Error/Success message start--%>


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
<%--Region Error/Success message end--%>

    <%--region to add location service area form --%>            
<table class="adduserTable" cellpadding="6" cellspacing="0">
    <tr>
        <td style="width:20%;"> <span class="star">*</span>Zip Code :</td>
        <td> <asp:TextBox ID="txtZipCode" CssClass="textBox" runat="server" MaxLength="5" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtZipCode" Display="None"   SetFocusOnError="true"
            ErrorMessage="<b>Required Field Missing</b><br />Zipcode name is required.">  
            </asp:RequiredFieldValidator>
             
            <ajaxToolkit:ValidatorCalloutExtender  runat="Server" ID="ValidatorCalloutExtender0" TargetControlID="RequiredFieldValidator1"
             HighlightCssClass="validatorCalloutHighlight" />
            
            <asp:RegularExpressionValidator ID="RegValZip" runat="server" Display="None" 
            ErrorMessage="<b>Required Field Missing</b><br />Please enter correct zipcode ."  
            SetFocusOnError="true" ControlToValidate="txtZipCode" ValidationExpression="\d{5}"  ></asp:RegularExpressionValidator>
            <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender49" TargetControlID="RegValZip"  
            HighlightCssClass="validatorCalloutHighlight" Enabled="true" />   
        
        </td>
    </tr>
    <tr>
        <td><span class="star">*</span> City :
        </td>
        <td><asp:TextBox ID="txtCity" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtCity" Display="None"  SetFocusOnError="true"
            ErrorMessage="<b>Required Field Missing</b><br />City is required.">  
             </asp:RequiredFieldValidator>
             
             <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator2"
                                    HighlightCssClass="validatorCalloutHighlight" />
        </td>
    </tr>
    <tr>
        <td> <span class="star">*</span> State : 
        </td>
        <td><asp:TextBox ID="txtState" CssClass="textBox" runat="server" MaxLength="45"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtState" Display="None"  SetFocusOnError="true"
            ErrorMessage="<b>Required Field Missing</b><br />State is required.">  
        </asp:RequiredFieldValidator>
        
        <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender2" TargetControlID="RequiredFieldValidator3"
                                    HighlightCssClass="validatorCalloutHighlight" />
        </td>
    </tr>
    
    <tr style="display:none;">
         <td>
             <span class="star">*</span>Status :</td>
             <td><asp:DropDownList ID="ddlStatus" runat="server">
                <asp:ListItem Value="1" Text="Active"></asp:ListItem>
                <asp:ListItem Value="0" Text="InActive"></asp:ListItem>
             </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="<b>Required Field Missing</b><br />Status is required" Display=None ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>
                 <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender4" TargetControlID="RequiredFieldValidator5"
                                    HighlightCssClass="validatorCalloutHighlight" />
                 </td>
         
    </tr>
    <tr>
        <td>
            <span class="star">*</span>Zipcode Type :
        </td>
        <td>
            <asp:DropDownList ID="ddlZipType" runat="server">
                <asp:ListItem Text="STANDARD" Value="STANDARD"></asp:ListItem>
                <asp:ListItem Text="UNIQUE" Value="UNIQUE"></asp:ListItem>
                <asp:ListItem Text="PO BOX ONLY" Value="PO BOX ONLY"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
   
   
</table>

<%--region form end--%>

<asp:Button ID="AddUser" runat="server" Text="Add ZipCode" ToolTip="Add ZipCode" CssClass="btnBg" OnClick="AddUser_Click"   /> 
            <asp:Button ID="btnBack" runat="server" Text="Cancel" ToolTip="Cancel" CssClass="btnBg" CausesValidation="false" PostBackUrl="~/Admin/LocationService/ManageLocations.aspx?SearchFor=0&SearchText=" />
</div>
</asp:Content>

    