using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using advancewebtosolution.BO;

public partial class X2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String Path = ContentManager.GetPhysicalPath(Session["HomePath"] + "StoreData/VisitVan");
        DirectoryInfo di = new DirectoryInfo(Path);
        FileInfo[] rgFiles = di.GetFiles();
        string str = string.Empty;
        for (int i = 0; i < rgFiles.Length; i++)
        {
            if (rgFiles[i].Extension == ".jpg")
            {
                if (str == "")
                    str = "StoreData/VisitVan/" + rgFiles[i];
                else
                    str = str + "#StoreData/VisitVan/" + rgFiles[i];
            }
        }
        Response.Write(str);
    }
}
