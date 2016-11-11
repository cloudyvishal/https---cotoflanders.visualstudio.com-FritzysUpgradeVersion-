<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_EditPet" Title="Edit Pet " Codebehind="EditPet.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="Scripts/phone_validation.js"></script>

    <script language="javascript" type="text/javascript">
    
  
 
      function ValidateDateOfBirth(source, arguments)
      {
          if(document.getElementById('<%=txtPetDOB.ClientID %>').value == "" )  
          {
            arguments.IsValid = false;
          }
          else if(!RequiredYear(document.getElementById('<%=txtPetDOB.ClientID %>').value))
          {
            arguments.IsValid = false;
          }
          else
          {
            arguments.IsValid = true;
          }
          
      } 
      function ValYear(source, args)
      {
          var dteNow = new Date();
          var intYear = dteNow.getFullYear()
           
          if(args.Value  > intYear)
            args.IsValid = false;
          else
            args.IsValid = true;
      }
     
     function setList(i)
     {
        if(document.getElementById('<%=lstAddservices1.ClientID %>').style.display == "none")
        {   
            document.getElementById('<%=lstAddservices1.ClientID %>').style.display = "block";
            document.getElementById('<%=lstAddservices1.ClientID %>').focus();
        }
        else { 
        document.getElementById('<%=lstAddservices1.ClientID %>').style.display = "none"; }
        return false;
     }
     function HideList(i)
     {
         document.getElementById('<%=lstAddservices1.ClientID %>').style.display = "none";
         return false;
     }
 
    function SetText(i)
     {
         var Source = document.getElementById('<%=lstAddservices1.ClientID %>');
         var str = "";
         var str1 = "";
         //alert(Source.options.selectedIndex);
        for(j=0;j<document.getElementById('<%=lstAddservices1.ClientID %>').length; j++)
        {
              if(Source.options[j].selected)
              {
                 if(str =="")
                 {
                    str =  Source.options[j].text;
                    str1 = Source.options[j].value;
                 }
                 else
                 {
                    str = str + "," + Source.options[j].text;
                    str1 = str1 + "," + Source.options[j].value;
                 }
              }
        }
      
     document.getElementById('<%=txtAddServices1.ClientID %>').value = str;
     document.getElementById('<%=txtAddServicesID1.ClientID %>').value = str1 ;
 }

    </script>
 <div class="innerContent">
 <div class="pageTitle">
            <h2>
                Edit Pet Details</h2>
        </div>
    <div class="errorDiv" id="divError" runat="server" visible="false">
        <table width="100%">
            <tbody>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
     <table class="adduserTable" cellpadding="6" cellspacing="0">
         <tr>
             <td style="width:20%;">
                 Pet:
             </td>
             <td>
                 <asp:DropDownList ID="ddlPetType1" CssClass="regddlField" runat="server" AutoPostBack="true"
                     OnSelectedIndexChanged="ddlPetType1_SelectedIndexChanged">
                     <asp:ListItem Text="Cat" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Dog" Value="1"></asp:ListItem>
                 </asp:DropDownList>
             </td>
         </tr>
         <tr>
             <td>
                 Pet Name:
             </td>
             <td>
                 <asp:TextBox ID="txtPetName" CssClass="textBox" runat="server" MaxLength="15"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqVal1" ControlToValidate="txtPetName" ErrorMessage="<b>Required Field Missing</b><br />Pet name is required."
                     Display="None" ValidationGroup="valPet" runat="server" SetFocusOnError="true">  
                 </asp:RequiredFieldValidator>
                 <cc1:ValidatorCalloutExtender ID="VCEPet1" TargetControlID="ReqVal1" HighlightCssClass="validatorCalloutHighlight"
                     Enabled="true" runat="Server" />
             </td>
         </tr>
         <tr>
             <td>
                 Breed:
             </td>
             <td>
                 <asp:DropDownList ID="ddlBreed" CssClass="regddlFieldbig" runat="server">
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="ReqVAl2" Text="Selcect One" InitialValue="0" ControlToValidate="ddlBreed"
                     ErrorMessage="<b>Required Field Missing</b><br />Breed is required" Display="none"
                     ValidationGroup="valPet" runat="server" SetFocusOnError="true" />
                 <cc1:ValidatorCalloutExtender ID="VCEPet2" TargetControlID="ReqVal2" HighlightCssClass="validatorCalloutHighlight"
                     Enabled="true" runat="Server" />
             </td>
         </tr>
         <tr>
             <td>
                 Birth Year:
             </td>
             <td>
                 <asp:TextBox ID="txtPetDOB" CssClass="textBox" runat="server" MaxLength="4"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqVal3" ControlToValidate="txtPetDOB" ErrorMessage="<b>Required Field Missing</b><br />Pet birth year is required."
                     ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                 </asp:RequiredFieldValidator>
                 <cc1:ValidatorCalloutExtender ID="VCEPet3" TargetControlID="ReqVal3" HighlightCssClass="validatorCalloutHighlight"
                     Enabled="true" runat="Server" />
                 <asp:RegularExpressionValidator ID="ReqPet4" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct birth year ."
                     ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetDOB"
                     ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                 <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender1" TargetControlID="ReqPet4"
                     HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
                 <asp:CustomValidator runat="server" ID="custYear1" ValidationGroup="valPet" ControlToValidate="txtPetDOB"
                     Display="None" SetFocusOnError="true" ClientValidationFunction="ValYear" ErrorMessage="<b> Please enter correct year.</b> <br>Year should be less then or equal to current year."></asp:CustomValidator>
                 <cc1:ValidatorCalloutExtender runat="Server" ID="ValidatorCalloutExtender43" TargetControlID="custYear1"
                     HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
             </td>
         </tr>
         <tr>
             <td>
                 Weight:
             </td>
             <td>
                 <asp:TextBox ID="txtPetWeight" CssClass="textBox" runat="server" MaxLength="6"></asp:TextBox>&nbsp;lbs
                 <asp:RequiredFieldValidator ID="Reqval4" ControlToValidate="txtPetWeight" ErrorMessage="<b>Required Field Missing</b><br />Weight is required."
                     ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                 </asp:RequiredFieldValidator>
                 <cc1:ValidatorCalloutExtender ID="VCEPet4" TargetControlID="Reqval4" HighlightCssClass="validatorCalloutHighlight"
                     Enabled="true" runat="Server" />
                 <asp:RegularExpressionValidator ID="ReqPet6" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct Weight."
                     ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetWeight"
                     ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                 <cc1:ValidatorCalloutExtender runat="Server" ID="VCEPet5" TargetControlID="ReqPet6"
                     HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
             </td>
         </tr>
         <tr>
             <td>
                 Fur Length:
             </td>
             <td>
                 <asp:TextBox ID="txtPetLength" MaxLength="6" CssClass="textBox" runat="server"></asp:TextBox>&nbsp;inches
                 <asp:RequiredFieldValidator ID="Reqval7" ControlToValidate="txtPetLength" ErrorMessage="<b>Required Field Missing</b><br />Length is required."
                     ValidationGroup="valPet" Display="None" runat="server" SetFocusOnError="true">  
                 </asp:RequiredFieldValidator>
                 <cc1:ValidatorCalloutExtender ID="VCEPet6" TargetControlID="Reqval7" HighlightCssClass="validatorCalloutHighlight"
                     Enabled="true" runat="Server" />
                 <asp:RegularExpressionValidator ID="Reqval8" runat="server" Display="None" ErrorMessage="<b>Required Field Missing</b><br />Please enter correct length."
                     ValidationGroup="valPet" SetFocusOnError="true" ControlToValidate="txtPetLength"
                     ValidationExpression="^\d*(\.\d{1,4})?$"></asp:RegularExpressionValidator>
                 <cc1:ValidatorCalloutExtender runat="Server" ID="VCEPet7" TargetControlID="Reqval8"
                     HighlightCssClass="validatorCalloutHighlight" Enabled="true" />
             </td>
         </tr>
         <tr>
             <td>
                 Spa:
             </td>
             <td>
                 <asp:CheckBox ID="chkSpa1" runat="server" />
             </td>
         </tr>
         <tr>
             <td>
                 Style:
             </td>
             <td>
                 <asp:DropDownList ID="ddlStyle1" CssClass="regTextfldStyle" runat="server">
                 </asp:DropDownList>
             </td>
         </tr>
         <tr>
             <td>
                 Additional services:
             </td>
             <td>
                 <div>
                     <div style="display: none;">
                         <asp:TextBox ID="txtAddServicesID1" runat="server"></asp:TextBox>
                     </div>
                     <asp:TextBox ID="txtAddServices1" runat="server" OnClick="return setList(1);" Text="Select Service"
                         CssClass="regddlFldAdservice"></asp:TextBox>
                     <asp:ImageButton ID="ImgAdservices1" runat="server" ImageUrl="~/Images/DDImage.bmp"
                         OnClientClick="return setList(1);" CssClass="imgbutton" />
                 </div>
                 <div class="apptDrpDiv">
                     <asp:ListBox ID="lstAddservices1" runat="server" CssClass="apptListbox" SelectionMode="Multiple"
                         Style="display: none;" OnClick="return SetText(1);" onblur="return HideList(1);">
                     </asp:ListBox>
                 </div>
             </td>
         </tr>
     </table>
    <asp:Button ID="btnUpdate" runat="server" Text="Update" ToolTip="Update" 
        CausesValidation="true" UseSubmitBehavior="true" ValidationGroup="valPet" 
        onclick="btnUpdate_Click"  CssClass="btnBg"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click"  CssClass="btnBg"/>
    
    </div>
</asp:Content>
