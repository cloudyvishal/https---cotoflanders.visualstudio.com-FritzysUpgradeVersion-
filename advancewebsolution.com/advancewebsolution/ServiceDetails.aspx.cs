using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using advancewebtosolution.BO;

public partial class ServiceDetails : System.Web.UI.Page
{
    /*
        function Use to bind service data to datalist
     * as well as use to bind all pet releated data of releated service 
     * where html page cumes dynamic
     * 
     */
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
            }
            if (PageID == 3)
            {
                ImgService.ImageUrl = Session["HomePath"] + "StoreData/ServicePageServices/" + ds.Tables[0].Rows[0]["Image"].ToString();
                lblServiceTitle.Text = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                Page.Title = ds.Tables[0].Rows[0]["ServiceTitle"].ToString();
                lblServiceDesc.Text = ds.Tables[0].Rows[0]["ServiceDescription"].ToString();
            }
        }
        else
        {

        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
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
                if (Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                {
                    Ismobile = true;
                }
            }

            if (Ismobile.Equals(true))
            {
                string repData = Request.Url.ToString();
                string p = repData.Replace("/", "/mobileweb/").ToLower();

                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("Location",
                Request.Url.ToString().Replace(Request.Url.ToString(), p));
                int ServiceID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                int PageID = Convert.ToInt32(Request.QueryString["Page"].ToString());
                BindData(ServiceID, PageID);
            }

            else
            {
            }

           
        }
    }
}
		 