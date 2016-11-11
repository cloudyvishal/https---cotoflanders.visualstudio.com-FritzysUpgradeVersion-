using System;
using System.Configuration;
using System.Data;
using System.Net.Mail;
public partial class forgotpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        stylesheet.Href = Convert.ToString(Session["Style"]);
        if (!IsPostBack)
        {

        }
    }
    private int GId
    {
        get
        {
            if (Session["GId"] != null)
            {
                return int.Parse(Session["GId"].ToString());
            }
            else
                return 0;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text != "")
        {
            Groomer ObjGroomer = new Groomer();
            DataSet ds = new DataSet();
            ds = ObjGroomer.GrmmoerGetPassword(txtEmail.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Sendmail(ds.Tables[0].Rows[0]["Name"].ToString(), ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["UserName"].ToString(), ds.Tables[0].Rows[0]["Password"].ToString());
                SuccesfullMessage("Please check your mail account for username and password");
                txtEmail.Text = "";
            }
            else
            {
                ErrMessage("Please enter correct email id."); ;
                txtEmail.Text = "";
            }
        }
    }

    /* Send mail function for  forgotpassword is below */
    public void Sendmail(string FullName, string Email, string Username, string Password)
    {
        string Message = " <table cellpadding='5' cellspacing='0' width='50%' border='1' style='background:#F1EBE2;'>" +
          "<tr><td colspan='2'> Hello " + FullName.ToString() + ",<br> Your login details are as follows:.</td>" +
          "</tr><tr><td style='width:20%;'>Username :</td>" +
          "<td> " + Username + "</td>" +
          "</tr><tr><td>Password :</td>" +
          "<td> " + Password + "</td></tr>" +
          "<tr></tr></table>";

        MailMessage msg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], Email);
        msg.Subject = "Fritzys Groomer-Forgot Password Recovery";
        msg.Body = Message;
        msg.Priority = MailPriority.High;
        msg.IsBodyHtml = true;
        msg.Priority = MailPriority.Normal;

        SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
        objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
        objSMTPClient.EnableSsl = true;
        objSMTPClient.Send(msg);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }


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

}
