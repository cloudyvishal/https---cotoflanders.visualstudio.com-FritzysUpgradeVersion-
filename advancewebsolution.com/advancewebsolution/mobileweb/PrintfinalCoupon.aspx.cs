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

public partial class Mobile_PrintfinalCoupon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ImgName = "";
        string ImagePath;
        try
        {
            ImgName = Request.QueryString["CouponID"].ToString();

            Banner newObj = new Banner();
            DataSet ds = newObj.GetBannerImageNameandpath(Convert.ToInt32(Request.QueryString["CouponID"].ToString()));
            ImagePath = Session["HomePath"] + "StoreData/BannerNew/" + ds.Tables[0].Rows[0]["BannerName"].ToString();

            string imagepath = ImagePath;
            string fulpath = ContentManager.GetPhysicalPath(imagepath);
            if (System.IO.File.Exists(fulpath))
            {
                ImgGift.ImageUrl = imagepath;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
