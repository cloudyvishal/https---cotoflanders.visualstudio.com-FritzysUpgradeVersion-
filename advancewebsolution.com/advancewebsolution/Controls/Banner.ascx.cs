using System;
using System.Data;
using System.Web.UI;
using advancewebtosolution.BO;

public partial class Controls_Banner : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int Count = 0;
        string PageName = GetCurrentPageName(); //RelativeURL("~" + HttpContext.Current.Request.ServerVariables["URL"].ToString());
        if (Session["UserType"].ToString() == "3")
            Count = 3;
        if (Session["UserType"].ToString() == "2")
            Count = 2;
        if (Session["UserType"].ToString() == "1")
            Count = 1;
        if (Session["IsLogin"].ToString() == "" || Session["IsLogin"] == null || Session["IsLogin"].ToString() == "0")
        {
            Count = 0;
        }
        DataSet ds = new DataSet();
        StoreFront ObjStore = new StoreFront();
        ds = ObjStore.GetBanerID(Count, PageName);
        if (ds.Tables[0].Rows.Count > 0)
            Count = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString()) + 1;
        /* Load the flash banner as per the User type  Which uses .swf file and XML for diiferent User type  */
        string file = "XML_Banner_Cat.swf?page=" + Count.ToString();

        string plyr = "<embed src=" + file + "  quality='high' pluginspage='http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' wmode='transparent' width='668' height='271'></embed> <script src='ieupdate.js' type='text/javascript'></script> <script type='text/javascript' src='ieupdate.js'></script>";
        plh.Controls.Add(new LiteralControl(plyr));
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



//<object codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"> 
//<param name=quality value=high> 
//<embed src="file.swf" quality=high pluginspage="" type="application/x-shockwave-flash" "> 
//</embed> 
//</object> 
//<script type="text/javascript" src="ieupdate.js"></script>