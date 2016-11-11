using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using advancewebtosolution.BO;
using advancewebtosolution.Admin;
using System.Web.Security;
using System.Text;

public partial class Controls_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["remUsername"] != null && Request.Cookies["remPassword"] != null)
            {
                var bytesUserName = Convert.FromBase64String(Request.Cookies["remUsername"].Value);
                var outputUserName = MachineKey.Unprotect(bytesUserName, "myAdminKey");
                var bytesPassword = Convert.FromBase64String(Request.Cookies["remPassword"].Value);
                var outputPassword = MachineKey.Unprotect(bytesPassword, "myAdminKey");

                txtUsername.Text = Encoding.UTF8.GetString(outputUserName);
                txtPassword.Attributes.Add("value", Encoding.UTF8.GetString(outputPassword));
                chkRemember.Checked = true;

            }
            lblLoginerror.Visible = false;
        }
    }
    /*
    On clickin this button will check the user validation and Authenticatio of user then set UserType, cookie, 
    * On error it will show message 
    */
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        StoreFront objStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        ds = objStoreFront.GetLoginUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["IsActive"].ToString().ToLower() == "false")
            {
                Session["UserName"] = ds.Tables[0].Rows[0]["UserName"].ToString();
                Session["MemberName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                Session["IsLogin"] = "1";
                Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();

                if (chkRemember.Checked == true)
                {
                    Request.Cookies.Remove("remUsername");
                    Request.Cookies.Remove("remPassword");
                    HttpContext.Current.Request.Cookies.Clear();

                    var cookieTextUserName = Encoding.UTF8.GetBytes(txtUsername.Text);
                    var cookieTextUserPassword = Encoding.UTF8.GetBytes(txtPassword.Text);

                    var encryptedUserNameValue = Convert.ToBase64String(MachineKey.Protect(cookieTextUserName, "myAdminKey"));
                    var encryptedPasswordValue = Convert.ToBase64String(MachineKey.Protect(cookieTextUserPassword, "myAdminKey"));

                    HttpCookie c = new HttpCookie("remUsername", encryptedUserNameValue);
                    c.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                    Response.Cookies.Add(c);

                    HttpCookie c1 = new HttpCookie("remPassword", encryptedPasswordValue);
                    c1.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                    Response.Cookies.Add(c1);
                    if (Request.Cookies["IsLogin"] == null)
                    {
                        HttpCookie c2 = new HttpCookie("IsLogin", "1");
                        c2.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                        Response.Cookies.Add(c2);
                    }
                    Response.Redirect(string.Concat(Convert.ToString(Session["HomePath"]), "Appointmentnew.aspx"));

                }
                else
                {
                    Response.Cookies["remUsername"].Expires = DateTime.Now.AddYears(-30);
                    Response.Cookies["remPassword"].Expires = DateTime.Now.AddYears(-30);
                    HttpCookie c = new HttpCookie("IsLogin", "0");
                    c.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                    Response.Cookies.Add(c);
                    Response.Redirect(string.Concat(Convert.ToString(Session["HomePath"]), "Appointmentnew.aspx"));

                }
            }
          else 
            {
                lblLoginerror.Visible = true;
                lblLoginerror.Text = "Your account Has been disabled by administrator of this site ,please contact administrator";
                ModalLogin.Show();
            }
        }
        else
        {
            lblLoginerror.Visible = true;
            ModalLogin.Show();
        }
    }

    /*
     Forgot password click will validate user mailid from database and send mail to this mailid which include Username and password 
     * else show the message invalid user 
     
     
     */
    protected void ImgSubmitForgot_Click(object sender, ImageClickEventArgs e)
    {
        divForgot.Attributes.Add("Style", "display:none");
        DivlnkForgot.Attributes.Add("Style", "display:block");
        divlblForgotmessage.Attributes.Add("Style", "display:block");
        Global ObjPassword = new Global();
        DataSet ds = new DataSet();
        ds = ObjPassword.GetPasswordAdmin(txtforgotUsername.Text.Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblForgotmessage.Text = "<br> Please check your mail account <br> for username and password";

            string Message = ContentManager.GetStaticeContentEmail("ForgotPassword.htm").Replace("~", "#");
            Message = Message.Replace("<!-- Username -->", txtforgotUsername.Text.Trim());
            Message = Message.Replace("<!-- Password -->", ds.Tables[0].Rows[0]["Password"].ToString());

            //string Message = " <table cellpadding='5' cellspacing='0' width='70%' border='1' style='background:#F1EBE2;'>" +
            //"<tr><td colspan='2'><h1 style='font-size:20px; color:#503414;'>Forgot Password</h1></td>" +
            //"</tr><tr><td style='width:25%;'>Username :</td>" +
            //"<td> " + txtforgotUsername.Text.Trim() + "</td>" +
            //"</tr><tr><td>Password :</td>" +
            //"<td> " + ds.Tables[0].Rows[0]["Password"].ToString() + "</td></tr></table>";

            Global ObjSubjec = new Global();
            DataSet ds_Subject = ObjSubjec.GetEmailSubject("ForgotPassword.htm");

            SendMails ObjMai = new SendMails();
            ObjMai.SendEmails(ConfigurationManager.AppSettings["FromEmail"], txtforgotUsername.Text.Trim(), ds_Subject.Tables[0].Rows[0]["Subject"].ToString(), Message);
        }
        else
        {
            lblForgotmessage.Text = "<br> Please enter valid username.<br> ";
        }
        DivlnkForgot.Attributes.Add("Style", "display:none");
        ModalLogin.CancelControlID = "closeLoginWindow";
        ModalLogin.Show();
        txtforgotUsername.Text = "";
    }
}
