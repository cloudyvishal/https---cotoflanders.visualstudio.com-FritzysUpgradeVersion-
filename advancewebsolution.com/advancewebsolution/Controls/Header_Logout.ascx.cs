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

public partial class Controls_Header_Logout : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lnkLogo.HRef = Session["HomePath"] + "index.aspx";
    }
    protected void btnSearchLogin_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Search.aspx?Key=" + txtSearchLogout.Text.Trim());
    }
}
