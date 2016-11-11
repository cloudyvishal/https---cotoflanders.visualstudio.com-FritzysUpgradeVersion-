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

public partial class MB_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["UserID"] = null;
            txtUserName.Focus();
        }
        catch(Exception ex) { throw ex; }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            StoreFront objStoreFront = new StoreFront();
            DataSet ds = new DataSet();
            ds = objStoreFront.GetLoginUser(txtUserName.Text.Trim(), txtpassword.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IsActive"].ToString().ToLower() == "false")
                {
                    Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                    Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                    Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                    Session["IsLogin"] = "1";
                    Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();

                    lblLoginerror.Visible = false;
                    Response.Redirect("~/mobileweb/MB_index.aspx");
                }
                else
                {
                    lblLoginerror.Visible = true;
                    lblLoginerror.Text = "Your Account Is Disabled By Administrator of This Site. Please Contact Administrator.";
                }
            }
            else
            {
                lblLoginerror.Visible = true;
            }
        }
        catch(Exception ex) { throw ex; }
    }
}
