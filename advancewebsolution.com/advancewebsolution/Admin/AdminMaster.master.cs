using System;
using System.Data;
using advancewebtosolution.BO;
using System.Diagnostics;

public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        /*
         *  Admin Master do following function 
         *     check SessionOut
         *     Set Admin Userame
         *     Set Link Path
         *     Check whether user have access for requesting page. function AccessNew();
         */
        if (Session["AdminUserName"] == null | Session["AdminID"] == null | Session["AdminUserType"] == null)
            Response.Redirect("~/Admin/default.aspx");
        if (!IsPostBack)
        {
            // Menubar links 
            lnkAdminHome.NavigateUrl = Session["AdminPath"] + "AdminHome.aspx";
            lnkManageUser.NavigateUrl = Session["AdminPath"] + "AdminUsers/ManageUser.aspx?SearchFor=0&SearchText=";
            lnkManageAgents.NavigateUrl = Session["AdminPath"] + "Agents/ManageAgents.aspx?SearchFor=0&SearchText=";
            lnkManageManger.NavigateUrl = Session["AdminPath"] + "Manager/ManageManager.aspx?SearchFor=0&SearchText=";
            lnkFriends.NavigateUrl = Session["AdminPath"] + "Friends/ManageFriends.aspx?SearchFor=0&SearchText=";
            lnkNews.NavigateUrl = Session["AdminPAth"] + "News/ManageNews.aspx?SearchFor=0&SearchText=";
            lnkServices.NavigateUrl = Session["AdminPath"] + "Services/ManageServices.aspx?SearchFor=0&SearchText=";
            lnkManageMembers.NavigateUrl = Session["AdminPath"] + "Users.aspx?SearchFor=0&SearchText=";
            lnkManageAppointment.NavigateUrl = Session["AdminPath"] + "Appointment.aspx?SearchFor=0&SearchText=";
            lnkContactus.NavigateUrl = Session["AdminPath"] + "ContactUs.aspx?SearchFor=0&SearchText=";
            lnkSuggestion.NavigateUrl = Session["AdminPath"] + "Suggestion.aspx?SearchFor=0&SearchText=";
            lnkVisitorVan.NavigateUrl = Session["AdminPath"] + "VisitVan.aspx";
            lnkZipCode.NavigateUrl = Session["AdminPath"] + "LocationService/ManageLocations.aspx?SearchFor=0&SearchText=";
            lnkLogout.NavigateUrl = Session["AdminPath"] + "Logout.aspx";
            lnkAdditionalService.NavigateUrl = Session["AdminPath"] + "ManageAdditionalService.aspx?SearchFor=0&SearchText=";
            lnkManageBreed.NavigateUrl = Session["AdminPath"] + "ManageBreed.aspx?SearchFor=0&SearchText=";
            lnkManageStyle.NavigateUrl = Session["AdminPath"] + "ManageStyle.aspx?SearchFor=0&SearchText=";
            lnkReferalSource.NavigateUrl = Session["AdminPath"] + "ManageReferalSource.aspx?SearchFor=0&SearchText=";
            lnkPassword.NavigateUrl = Session["AdminPath"] + "ChangePassword.aspx";
            lnkAccountSetting.NavigateUrl = Session["AdminPath"] + "ChangePassword.aspx";
            lnkMeta.NavigateUrl = Session["AdminPath"] + "MetaTags.aspx?PageID=1&SearchFor=0&SearchText=";
            lblUsername.Text = Session["AdminUserName"].ToString();
            lnkProducts.NavigateUrl = Session["AdminPath"] + "Products/ManageProducts.aspx?SearchFor=0&SearchText=";
            lnkStaticeContent.NavigateUrl = Session["AdminPath"] + "StaticWebPages.aspx";
            lnkImageManager.NavigateUrl = Session["AdminPath"] + "ImageManager.aspx";
            lnkManageHomePageService.NavigateUrl = Session["AdminPath"] + "ManageHomePageService.aspx";
            lnkManageFTService.NavigateUrl = Session["AdminPath"] + "ManageFleaTickService.aspx";
            lnkEmail.NavigateUrl = Session["AdminPath"] + "ManageEmail.aspx";
            lnkBackup.NavigateUrl = Session["AdminPath"] + "SiteBackup.aspx";
            lnkManageGroomer.NavigateUrl = Session["AdminPath"] + "Groomer/ManageGroomer.aspx?SearchFor=0&SearchText=";
            lnkEditExcel.NavigateUrl = Session["AdminPath"] + "Groomer/EditExcel.aspx";
            lnkGroomerAppointment.NavigateUrl = Session["AdminPath"] + "Groomer/ViewGroomerAppointment.aspx?SearchFor=0&SearchText=";
            lnkUploadDnloadExl.NavigateUrl = Session["AdminPath"] + "Groomer/UploadDnloadExcel.aspx";
            lnkUploadgroomerapt.NavigateUrl = Session["AdminPath"] + "Groomer/UploadGroomerAppointments.aspx";
            lnkAppointment.NavigateUrl = Session["AdminPath"] + "AppointmentSettings.aspx";
            lnkAppointmentDate.NavigateUrl = Session["AdminPath"] + "AppointmentDateSetting.aspx";
            HypUploadBanner.NavigateUrl = Session["AdminPath"] + "Banner/UploadBannerNew.aspx";
            HypBanner.NavigateUrl = Session["AdminPath"] + "Banner/ManageBaners.aspx";
            AccessNew();
        }
    }
    /* 
        Function Check that whether user have access to current requesting page 
     */
    private void AccessNew()
    {
        string currentpage = Request.Url.PathAndQuery.ToString().ToLower();

        Global get_pages = new Global();
        DataSet pageDs = get_pages.GetPageName(Convert.ToInt32(Session["AdminUserType"].ToString()));
        for (int i = 0; i < pageDs.Tables[0].Rows.Count; i++)
        {
            string pagename = pageDs.Tables[0].Rows[i]["PageName"].ToString().ToLower();
            if (currentpage.IndexOf(pagename) > -1)
            {
                //if (currentpage == pagename)
                Response.Redirect("~/Admin/NotAllow.aspx");
                return;
            }
        }
    }
}
