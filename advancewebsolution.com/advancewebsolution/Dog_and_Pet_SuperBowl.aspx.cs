using System;
using System.Data;
using System.Web;
using System.Web.UI;
using advancewebtosolution.BO;

public partial class Dog_and_Pet_SuperBowl : System.Web.UI.Page
{
    int ServiceId = 84;
    int pageid = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
int Count = 0;
        //string PageName = GetCurrentPageName(); //RelativeURL("~" + HttpContext.Current.Request.ServerVariables["URL"].ToString());
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
        ds = ObjStore.GetBanerID(Count, "ServiceDetails.aspx");
        if (ds.Tables[0].Rows.Count > 0)
            Count = Convert.ToInt32(ds.Tables[0].Rows[0]["BannerID"].ToString()) + 1;
        /* Load the flash banner as per the User type  Which uses .swf file and XML for diiferent User type  */
        string file = "XML_Banner_Cat.swf?page=" + Count.ToString();

        string plyr = "<embed src=" + file + "  quality='high' pluginspage='http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' wmode='transparent' width='668' height='271'></embed> <script src='ieupdate.js' type='text/javascript'></script> <script type='text/javascript' src='ieupdate.js'></script>";
        //string plyr = "<embed src='Players/flvplayer.swf' width='425' height='355' bgcolor='#FFFFFF' type='application/x-shockwave-flash' wmode='transparent' pluginspage='http://www.macromedia.com/go/getflashplayer' flashvars='file=" + vfname + "&autostart=true&frontcolor=0xCCCCCC&backcolor=0x000000&lightcolor=0x996600&showdownload=false&showeq=false&repeat=false&volume=100&useaudio=false&usecaptions=false&usefullscreen=true&usekeys=true'></embed>";
        plh.Controls.Add(new LiteralControl(plyr));
        if (!IsPostBack)
        {

            
            bool Ismobile = false;
            string[] mobiles =
            new[]
                {
                    "midp","android","j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                     "opwv", "chtml","320x480",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi", 
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                     "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };
            //Loop through each item in the list created above 
            //and check if the header contains that text
            foreach (string s in mobiles)
            {
                // if (Request.ServerVariables["HTTP_USER_AGENT"].
                if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                {
                    Ismobile = true;
                }
            }

            if (Ismobile.Equals(true))
            {
                Response.Redirect("http://fritziespetcarepros.com/mobileweb/Dog_and_Pet_SuperBowl.aspx".ToLower());
				HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location",Request.Url.ToString().Replace("http://fritziespetcarepros.com/", "http://fritziespetcarepros.com/Dog_and_Pet_SuperBowl.aspx"));
                
                int ServiceID = ServiceId;
                int PageID = pageid;
                BindData(ServiceID, PageID);
            }

            else
            {
                //HttpContext.Current.Response.Status = "301 Moved Permanently";
                //HttpContext.Current.Response.AddHeader("Location",
                //Request.Url.ToString().Replace(Request.Url.ToString(), ("http://fritziespetcarepros.com/Index.aspx").ToLower()));
                BindData(ServiceId, pageid);
            }


        }
    }

    public void BindData(int ServiceID, int PageID)
    {
        StoreFront ObjService = new StoreFront();
        DataSet ds = new DataSet();
        ds = ObjService.GetServiceDetailFront(ServiceID, PageID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (PageID == 1)
            {
                ImgService.ImageUrl = Session["HomePath"] + "StoreData/Images/" + ds.Tables[0].Rows[0]["Image"].ToString();
                lblServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/" + ds.Tables[0].Rows[0]["PageName"].ToString()));
            }
            if (PageID == 2)
            {
                ImgService.ImageUrl = Session["HomePath"] + "StoreData/HomeServices/" + ds.Tables[0].Rows[0]["Image"].ToString();
                lblServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                //litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/" + ds.Tables[0].Rows[0]["PageName"].ToString()));
            }
            if (PageID == 3)
            {
                ImgService.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["Image"].ToString();
                lblServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
                //litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/" + ds.Tables[0].Rows[0]["PageName"].ToString()));
            }
        }
        else
        {

        }

    }
}
