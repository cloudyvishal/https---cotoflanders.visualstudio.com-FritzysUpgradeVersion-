using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using advancewebtosolution.BO;

public partial class PrintCoupon : System.Web.UI.Page
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

        if (ImgName == "No")
        {
            Banner newObj = new Banner();
            DataSet ds = newObj.GetDefaultCouponName();
            ImagePath = Session["HomePath"] + "StoreData/Coupon/" + ds.Tables[0].Rows[0]["DefaultCouponName"].ToString();
        }
        else if (ImgName == "")
        {
            Banner newObj = new Banner();
            DataSet ds = newObj.GetDefaultCouponName();
            ImagePath = Session["HomePath"] + "StoreData/Coupon/" + ds.Tables[0].Rows[0]["DefaultCouponName"].ToString();
        }
        else
        {
            ImagePath  = Session["HomePath"] + "StoreData/Coupon/" + Request.QueryString["PageName"] + "/" + ImgName;
        }
        string imagepath = ImagePath;
        string fulpath = ContentManager.GetPhysicalPath(imagepath);
        if (System.IO.File.Exists(fulpath))
        {
             ImgGift.ImageUrl =    imagepath;
        }
        else
        {
             ImgGift.ImageUrl = Session["HomePath"] + "StoreData/Coupon/" + "CommonCoupon.jpg";
        }
    }
}
