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

public partial class Controls_Footer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsLogin"].ToString() == "1")
        {
        }
        else
        {
        }
        litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/FooterContent.htm"));
    }
}
