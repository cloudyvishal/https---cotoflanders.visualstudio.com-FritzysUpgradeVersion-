using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using advancewebtosolution.BO;
using advancewebtosolution.Admin;

public partial class Controls_Header_Login : System.Web.UI.UserControl
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
            lblLoginerror.Visible = false;
        }

    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        StoreFront objStoreFront = new StoreFront();
        DataSet ds = new DataSet();
        ds = objStoreFront.GetLoginUser(txtUsername.Text.Trim(), txtPassword.Text.Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["IsActive"].ToString().ToLower() == "false")
            {
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
                lblLoginerror.Text = "Your Account Is Disabled By Administrator of This Site/n Please Contact Administrator.";
            }
        }

        else
        {
            lblLoginerror.Visible = true;
            ModalLogin.Show();
        }
    }
   
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

           string Message = " <table cellpadding='5' cellspacing='0' width='50%' border='1' style='background:#F1EBE2;'>" +
           "<tr><td colspan='2'><h1 style='font-size:20px; color:#503414;'>Forgot Password</h1></td>" +
           "</tr><tr><td style='width:20%;'>Username :</td>" +
           "<td> " + txtforgotUsername.Text.Trim() + "</td>" +
           "</tr><tr><td>Password :</td>" +
           "<td> " + ds.Tables[0].Rows[0]["Password"].ToString() +"</td></tr></table>";

            SendMails ObjMai = new SendMails();
            ObjMai.SendEmails(ConfigurationManager.AppSettings["FromEmail"], txtforgotUsername.Text.Trim(), "Fritzy's : Password detail", Message);
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
