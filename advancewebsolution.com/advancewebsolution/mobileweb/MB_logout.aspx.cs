using System;
using System.Configuration;
using System.Web;
using System.Web.UI;

public partial class mobileweb_MB_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");

            Session.Remove("UserName");
            Session.Remove("MemberName");
            Session.Remove("UserID");

            Session["IsLogin"] = "0";
            Session["UserType"] = "4";

            string sb = "";
            sb += "<script language=javascript>\n";
            sb += "window.onload = window.history.forward(0);";
            sb += "\n</script>";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "glScMob1", "<script>" + sb.ToString() + "</script>", true);
            Response.Redirect(Session["MobilePath"] + "MB_login.aspx");
        }
        catch(Exception ex)
        { throw ex; }
    }
}
