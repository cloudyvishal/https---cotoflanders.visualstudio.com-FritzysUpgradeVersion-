using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using advancewebtosolution.BO;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["remUsername"] != null)
            {
                txtUsername.Text = Request.Cookies["remUsername"].Value.ToString();
                chkRemember.Checked = true;
            }
            if (Request.Cookies["remPassword"] != null)
            {
                txtPassword.Attributes.Add("value", Request.Cookies["remPassword"].Value.ToString());
                chkRemember.Checked = true;

            }
        }
    }
    #region Login
    protected void btnLogin_Click1(object sender, ImageClickEventArgs e)
    {
        StoreFront objStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        ds = objStoreFront.GetLoginUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
            Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
            Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
            Session["IsLogin"] = "1";
            Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();

            lblLoginerror.Visible = false;
            
            if (chkRemember.Checked == true)
            {
                HttpContext.Current.Request.Cookies.Clear();
                if (Request.Cookies["remUsername"] == null)
                {
                    HttpCookie c = new HttpCookie("remUsername", txtUsername.Text);
                    c.Expires =  DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                    Response.Cookies.Add(c);
                }
                if (Request.Cookies["remPassword"] == null)
                {
                    HttpCookie c = new HttpCookie("remPassword", txtPassword.Text);
                    c.Expires =  DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                    Response.Cookies.Add(c);
                }
            }
            else
            {
                Response.Cookies["remUsername"].Expires = DateTime.Now.AddYears(-30);
                Response.Cookies["remPassword"].Expires = DateTime.Now.AddYears(-30);
            }
            Response.Redirect("index.aspx");
        }
        else
        {
            lblLoginerror.Visible = true;
        }
        


    }
    #endregion
}
