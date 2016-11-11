using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using advancewebtosolution.BO;
using System.Configuration;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
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

        if (Request.Cookies["IsLogin"] == null)
        {
            HttpCookie c = new HttpCookie("IsLogin", "0");
            c.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
            Response.Cookies.Add(c);
        }
        if ((Request.Cookies["remUsername"] != null) && (Request.Cookies["remPassword"] != null) && (Request.Cookies["IsLogin"].Value.ToString() == "1"))
        {
            if (Session["MemberName"] != null && Session["UserID"] != null && Session["UserName"] != null)
            {
                string UserName = Request.Cookies["remUsername"].Value.ToString();
                string Password = Request.Cookies["remPassword"].Value.ToString();

                StoreFront objStoreFront = new StoreFront();
                DataSet ds = new DataSet();
                ds = objStoreFront.GetLoginUser(UserName, Password);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                    Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                    Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                    Session["IsLogin"] = "1";
                    Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                }
            }
        }
        else
        {
           Session["UserType"] = "4";
        }

        /*
         *  If User is registered and use remember me on this PC then Load Header_Logout.ascx Control ( Myaccount Link , Logout button )
         *  else Load Header_Login.ascx ( Registration Link and Ligin Button ) 
         *  
        */
        if (Session["MemberName"] != null)
        {
            Control bodyCntrl = LoadControl("~/Controls/Header_Logout.ascx");
            PhHeader.Controls.Add(bodyCntrl);
        }
        else
        {
            Control bodyCntrl = LoadControl("~/Controls/Header_Login.ascx");
            PhHeader.Controls.Add(bodyCntrl);
        }


        /* Meta of Page */
        string sPath = GetCurrentPageName();
        Global ObjGlobal = new Global();
        DataSet ds_Meta = new DataSet();
        ds_Meta = ObjGlobal.GetMetaFront(sPath);
        if (ds_Meta.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds_Meta.Tables[0].Rows[0];
            string Description = Convert.ToString(row["MetaContent"]);
            string Keywords = Convert.ToString(row["Keywords"]);
            if (Description != string.Empty)
            {
                HtmlMeta meta = new HtmlMeta();
                meta.Name = "Description";
                meta.Content = Description;
                Page.Header.Controls.Add(meta);
            }
            if (Keywords != string.Empty)
            {
                HtmlMeta Keyword = new HtmlMeta();
                Keyword.Name = "keywords";
                Keyword.Content = Keywords;
                Page.Header.Controls.Add(Keyword);
            }
        }
        if (ds_Meta.Tables[1].Rows.Count > 0)
        {
            Page.Title = ds_Meta.Tables[1].Rows[0]["PageTitle"].ToString();
        }
    }
    public string GetCurrentPageName()
    {
        string pageUrl = Request.Url.PathAndQuery.ToString().ToLower();
        char[] separator = new char[] { '/' };
        string[] str = pageUrl.Split(separator);
        int i = str[str.Length - 1].LastIndexOf('?');
        if (i == -1)
            pageUrl = str[str.Length - 1].ToString();
        else
            pageUrl = str[str.Length - 1].Substring(0, i);
        return pageUrl;
    }
}
