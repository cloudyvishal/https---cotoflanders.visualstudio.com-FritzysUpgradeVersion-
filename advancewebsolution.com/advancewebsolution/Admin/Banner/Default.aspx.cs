using System;

namespace advancewebtosolution
{
    public partial class Admin_Baner_Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageBaner.aspx");
        }
    }
}
