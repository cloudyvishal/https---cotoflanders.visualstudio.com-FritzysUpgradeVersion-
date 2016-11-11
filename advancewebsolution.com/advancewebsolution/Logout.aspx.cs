using advancewebtosolution.BO.CaptchaClass;
using System;
using System.Web.Security;
using System.Web.UI;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("UserName");
        Session.Remove("MemberName");
        Session.Remove("UserID");
        Session["IsLogin"] = "0";
        Session["UserType"] = "4";

        string sb = "";
        sb += "<script language=javascript>\n";
        sb += "window.onload = window.history.forward(0);";
        sb += "\n</script>";

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "glScDes", "<script>" + sb.ToString() + "</script>", true);
        FormsAuthentication.SignOut();
        Response.Redirect("~/Index.aspx?" + EncryptQueryString(string.Format("msg ={0}", "SignOut")), false);
    }
    #region "Encryption"
    public string EncryptQueryString(string strQueryString)
    {
        EncryptDecryptQueryString objEDQueryString = new EncryptDecryptQueryString();
        return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
    }
    #endregion
}
