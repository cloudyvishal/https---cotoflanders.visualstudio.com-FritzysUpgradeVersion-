using System;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using advancewebtosolution.BO;
using System.Text;
/* Page for forgot password to send mail to user in responce .*/

public partial class Admin_ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /* On Submit we will check for valid user frmo database and  give appropriate message */
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtUserId.Text != "")
        {
            Global ObjForGot = new Global();
            DataSet ds = new DataSet();
            ds = ObjForGot.GetPassword(txtUserId.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Sendmail(ds.Tables[0].Rows[0]["FullName"].ToString(), ds.Tables[0].Rows[0]["Email"].ToString(), ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["Password"].ToString());
                lblError.Text = "Please check your mail account for username and password";
            }
            else
            {
                lblError.Text = "Please enter correct Username";
            }
        }
    }
    /* Send mail function for  forgotpassword is below */
    public void Sendmail(string FullName, string Email, string Username,  string Password )
    {
        string Message = " <table cellpadding='5' cellspacing='0' width='50%' border='1' style='background:#F1EBE2;'>" +
          "<tr><td colspan='2'> Hello " + FullName.ToString() + ",<br> Your login details are as follows:.</td>" +
          "</tr><tr><td style='width:20%;'>Username :</td>" +
          "<td> " + Username + "</td>" +
          "</tr><tr><td>Password :</td>" +
          "<td> " + Password + "</td></tr>"+
          "<tr><td colspan='2'>Have a great time on Fritzy's, <br>The Fritzy's Team. <br> <a href='http://fritziespetcarepros.com/Fritzy/Admin'> http://fritziespetcarepros.com/Fritzy/Admin </a></td></tr></table>";

        MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], Email.ToString());
        objMailMsg.BodyEncoding = Encoding.UTF8;
        objMailMsg.Subject = "Forgot Password";
        objMailMsg.Body = Message;
        objMailMsg.Priority = MailPriority.High;
        objMailMsg.IsBodyHtml = true;
        SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
        objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
        objSMTPClient.EnableSsl = true;
        objSMTPClient.Send(objMailMsg);
    }
}
