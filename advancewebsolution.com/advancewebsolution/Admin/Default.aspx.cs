using System;
using System.Data;
using System.Web;
using advancewebtosolution.BO;
using System.Configuration;
using System.Text;
using System.Web.Security;

public partial class Admin_Default : System.Web.UI.Page
{
    /* Error message and success messages are use to display messages to user*/
    public void ErrMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "errorTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    public void SuccesfullMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
    }
    /* Page load event check that remember me on this pc if it is yes then set the textbox and keep remember me on this pc feature on */
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies["RemeberMe"] != null && Request.Cookies["RemeberMePassword"] != null)
                {
                    var bytesUserName = Convert.FromBase64String(Request.Cookies["RemeberMe"].Value);
                    var outputUserName = MachineKey.Unprotect(bytesUserName, "myAdminKey");
                    var bytesPassword = Convert.FromBase64String(Request.Cookies["RemeberMePassword"].Value);
                    var outputPassword = MachineKey.Unprotect(bytesPassword, "myAdminKey");

                    txtUserId.Text = Encoding.UTF8.GetString(outputUserName);
                    chkRemember.Checked = true;

                    txtPass.Attributes.Add("value", Encoding.UTF8.GetString(outputPassword));
                    chkRemember.Checked = true;
                }
            }
            catch 
            {
                Response.Cookies["RemeberMe"].Expires = DateTime.Now.AddYears(-30);
                Response.Cookies["RemeberMePassword"].Expires = DateTime.Now.AddYears(-30);
            }
        }
    }
    /* This region check user validation with GetUser() frunction */
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserId.Text == "" || txtPass.Text == "") ErrMessage("Please Enter UserName/Password.");
        else GetUser();
    }
    /* function ius use to check user authentication as well set session AdminUserName , UserID, AdminUserType  as well check remember me on this pc */
    public void GetUser()
    {
        try
        {
            User ObjUser = new User();
            DataSet DT = ObjUser.GetUser(txtUserId.Text, txtPass.Text);
            if (DT.Tables[0].Rows.Count > 0)
            {
                Session["AdminUserName"] = DT.Tables[0].Rows[0]["Firstname"].ToString() + " " + DT.Tables[0].Rows[0]["Lastname"].ToString();
                Session["AdminID"] = DT.Tables[0].Rows[0]["UserID"].ToString();
                Session["AdminUserType"] = DT.Tables[0].Rows[0]["UserType"].ToString();

                if (chkRemember.Checked)
                {
                    Request.Cookies.Remove("RemeberMe");
                    Request.Cookies.Remove("RemeberMePassword");
                    HttpContext.Current.Request.Cookies.Clear();
                    var cookieTextUserName = Encoding.UTF8.GetBytes(txtUserId.Text);
                    var cookieTextUserPassword = Encoding.UTF8.GetBytes(txtPass.Text);

                    var encryptedUserNameValue = Convert.ToBase64String(MachineKey.Protect(cookieTextUserName, "myAdminKey"));
                    var encryptedPasswordValue = Convert.ToBase64String(MachineKey.Protect(cookieTextUserPassword, "myAdminKey"));

                    HttpCookie c = new HttpCookie("RemeberMe", encryptedUserNameValue);
                    c.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                    Response.Cookies.Add(c);
                    HttpCookie c1 = new HttpCookie("RemeberMePassword", encryptedPasswordValue);
                    c1.Expires = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings["addCookieForDay"]));
                    Response.Cookies.Add(c1);
                }
                else
                {
                    Response.Cookies["RemeberMe"].Expires = DateTime.Now.AddYears(-30);
                    Response.Cookies["RemeberMePassword"].Expires = DateTime.Now.AddYears(-30);
                }
                Response.Redirect("~/Admin/AdminHome.aspx", false);
            }
            else
            {
                ErrMessage("Please verify your username and password");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
        }
    }

}
