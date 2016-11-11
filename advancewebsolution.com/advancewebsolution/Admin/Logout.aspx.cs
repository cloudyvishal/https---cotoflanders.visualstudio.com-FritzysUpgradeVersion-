using System;
using System.Web.UI;

public partial class Admin_Logout : System.Web.UI.Page
{
    /* On logout set all session to null and redirect to home page */
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("AdminUserName");
        Session.Remove("AdminID");
        Session.Remove("AdminUserType");

        string sb="";
        sb += "<script language=javascript>\n";
        sb += " function preventBack(){window.history.forward();}";
        sb += " setTimeout(";
        sb += "   preventBack()";
        sb += ", 0);    window.onunload = function(){ null};alert(''); ";
     
        sb += "\n</script>";

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "glSc", "<script>"+sb.ToString()+"</script>", true);
        Response.Redirect("~/Admin/default.aspx");
    }
}
