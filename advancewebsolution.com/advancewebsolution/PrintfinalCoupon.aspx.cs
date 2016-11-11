using System;
using System.Data;
using advancewebtosolution.BO;

public partial class PrintfinalCoupon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ImgName = "";
        string ImagePath;
        try
        {
            ImgName = Request.QueryString["CouponID"].ToString();
        }
        catch
        {
        }
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
}

