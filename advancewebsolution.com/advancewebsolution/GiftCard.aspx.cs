using advancewebtosolution.BO;
using System;

public partial class GiftCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        litContent.Text = ContentManager.GetFileContentView(ContentManager.GetPhysicalPath(Session["HomePath"].ToString() + "StoreData/StaticeContent/GiftCard.htm"));
    }
}
