using System;

public partial class Inner_Page_MB_MasterPage : System.Web.UI.MasterPage
{
    /*
         *  Session["MemberName"] = Use for Registered User Name
         *  Session["UserID"] = Used For database User ID 
         *  Session["IsLogin"] used for to chaeck User is login or not 
         *  Session["UserType"]  Used for User type that is 
         *  1 - Cat User
         *  2 - Dog User 
         *  3 - Cat-Dog User 
         *  Default Cat-Dog User 
         *  Cookies["IsLogin"] is used to check whether user is login or not which will work irrespective to remember me on this PC
         */
   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != null)
            {
                dvLogin.Visible = true;
                dvLogoutusers.Visible = false;
            }
            else
            {
                dvLogoutusers.Visible = true;
                dvLogin.Visible = false;
                Session["UserType"] = "4";
            }
        }
        catch(Exception ex) { throw ex; }
    }
}
