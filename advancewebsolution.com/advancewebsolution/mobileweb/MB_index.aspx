<%@ Page Language="C#" MasterPageFile="MB_MasterPage.master"  Inherits="MB_index" Title="Mobile Grooming Services" Codebehind="MB_index.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentsection">
        <div class="hometitle">
            <img src="images/home_title.jpg" height="15" width="294" alt="" />
        </div>
        <div class="dogtitle">
            <div class="divfordogtitle">
                <a href="MB_services.aspx?PetID=Dog" title="For Your Dogs">
                    <img src="images/for_dog.jpg" border="0" height="70" width="157" alt="For Your Dogs" /></a></div>
            <div class="divforcattitle">
                <a href="MB_services.aspx?PetID=Cat" title="For Your Cats">
                    <img src="images/for_cat.jpg" height="70" width="157" alt="For Your Cats" border="0" /></a></div>
        </div>
    </div>
    <div class="contentsection">
         <a href="PaymentInfo.aspx" title="Make Payment">
        <div class="makepayment" visible="false" id="divpayment" runat="server">
        </div>
             </a>
    </div>
    <div class="homebottom" id="dvloginusernew" runat="server">
        <a href="MB_visit-our-van.aspx" title="Visit Our Van">
            <div class="visitourvan" title="Visit Our Van">
            </div>
        </a><a href="MB_schedule_appointment.aspx" title="Make an Appointment">
            <div class="makeappoint" title="Login">
            </div>
        </a><a href="tel:18773748997">
            <div class="phonecall">
            </div>
        </a>
    </div>    
</asp:Content>
