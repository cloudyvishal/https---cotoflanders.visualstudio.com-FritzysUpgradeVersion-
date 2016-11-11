using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using AjaxControlToolkit;
using advancewebtosolution.BO;

/*
    This page will show a slide show for which images will controled by the admin 
 * admin have a facility to upload the inamges 
 * for slide show we are using ajax toolkit control
 */
public partial class Visitourvan : System.Web.UI.Page
{
//[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Assert, Unrestricted = true)]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(null == Session["UserName"]))
        {
            ctlZipcode.Visible = false;
            imgbtnMakePayment.Visible = true;
        }
        else
        {
            ctlZipcode.Visible = true;
            imgbtnMakePayment.Visible = false;
        }
        litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/VisitOurVan.htm"));
         
    }
    protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PaymentPrepaid.aspx");
    }
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod]
    //public static Slide[] GetSlides()
    //{
    //    AjaxControlToolkit.Slide[] slides = null;
    //    //String Path = ContentManager.GetPhysicalPath("http://fritziespetcarepros.com/Fritzy/" + "StoreData/VisitVan/");
    //    String Path = ContentManager.GetPhysicalPath("http://fritziespetcarepros.com/Fritzy/" + "StoreData/VisitVan/");
    //    DirectoryInfo directory = new DirectoryInfo(Path);
    //    if (directory.Exists)
    //    {
    //        FileInfo[] images = directory.GetFiles();
    //        slides = new AjaxControlToolkit.Slide[images.Length];
    //        int i = 0;
    //        foreach (FileInfo image in images)
    //        {
    //            string title = image.Name;
    //            slides[i] = new AjaxControlToolkit.Slide("StoreData/VisitVan/" + title, "title", "title");
    //            i++;
    //        }
    //    }
    //    return slides;
    //}
    //protected void SlideShowExtender1_ResolveControlID(object sender, ResolveControlEventArgs e)
    //{

    //}
}
