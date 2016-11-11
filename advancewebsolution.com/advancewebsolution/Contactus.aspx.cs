using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using advancewebtosolution.BO;

public partial class Contactus : System.Web.UI.Page
{
    #region Head 
    public void SuccessMessage(string Message)
    {
        divError.Visible = true;
        divError.Attributes.Add("Class", "successTable");
        lblError.Visible = true;
        lblError.Text = Message;
        lblError.ForeColor = System.Drawing.Color.Green;
    }
    
    #endregion 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberName"] != null)
        {
            divUserName.Attributes.Add("style", "Display:block");
            lblWelcome.Text = "Welcome - " + Session["MemberName"].ToString();

            DataSet ds = new DataSet();
            if (!(null == Session["UserName"]))
            {
                //ds = objStoreFront.GetAppInfoforPayment(Session["UserName"].ToString());
                ctlZipcode.Visible = false;
                imgbtnMakePayment.Visible = true;
            }
            else
            {
                divUserName.Attributes.Add("style", "Display:none");
                ctlZipcode.Visible = true;
                imgbtnMakePayment.Visible = false;
            }
        }
        if (Session["MemberName"] != null)
        {
            ctlZipcode.Visible = false;
            imgbtnMakePayment.Visible = true;
        }
        else
        {
            ctlZipcode.Visible = true;
            imgbtnMakePayment.Visible = false;
        }
    }
    #region event
    /*
        1. Save the contact us information in database and mail to admin about contactus information 
     */
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        //Add to Database
        ObjStoreFront.AddContactus(txtFName.Text.Trim(),txtLName.Text.Trim(),txtContactEmail.Text.Trim(),txtMobile.Text.Trim(),txtMessage.Text.Trim());

      
        string Mailbody = ContentManager.GetStaticeContentEmail("ContactUs.htm").Replace("~", "#");
        Mailbody = Mailbody.Replace("<!-- FirstName -->", txtFName.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- LastName -->", txtLName.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- Email -->", txtContactEmail.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- Phone -->", txtMobile.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- Suggestion -->", txtMessage.Text.Trim());
        try
        {
            MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["ToEmail"]);
            objMailMsg.BodyEncoding = Encoding.UTF8;
            objMailMsg.Subject = "Contact us detail : " + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
            objMailMsg.Body = Mailbody;
            objMailMsg.Priority = MailPriority.High;
            objMailMsg.IsBodyHtml = true;
            SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
            objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
            objSMTPClient.EnableSsl = true;
            objSMTPClient.Send(objMailMsg);
            SuccessMessage("Message sent successfully");
            btnSave.Enabled = true;
        }
        catch 
        {
            lblError.Text = "Sorry Something Wrong Occured...Plz Try After some time";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
        txtFName.Text = "";
        txtLName.Text = "";
        txtContactEmail.Text = "";
        txtMobile.Text = "";
        txtMessage.Text = "";
    }
    #endregion 
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        StoreFront ObjStoreFront = new StoreFront();
        ObjStoreFront.AddContactus(txtFName.Text.Trim(),
                                    txtLName.Text.Trim(),
                                    txtContactEmail.Text.Trim(),
                                    txtMobile.Text.Trim(),
                                    txtMessage.Text.Trim()
                                    );

        SuccessMessage("Message sent successfully");
        string Mailbody = ContentManager.GetStaticeContentEmail("ContactUs.htm").Replace("~", "#");
        Mailbody = Mailbody.Replace("<!-- FirstName -->", txtFName.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- LastName -->", txtLName.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- Email -->", txtContactEmail.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- Phone -->", txtMobile.Text.Trim());
        Mailbody = Mailbody.Replace("<!-- Suggestion -->", txtMessage.Text.Trim());
        try
        {
            MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["ToEmail"]);
            objMailMsg.BodyEncoding = Encoding.UTF8;
            objMailMsg.Subject = "Contact us detail : " + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
            objMailMsg.Body = Mailbody;
            objMailMsg.Priority = MailPriority.High;
            objMailMsg.IsBodyHtml = true;
            SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
            objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
            objSMTPClient.EnableSsl = true;
            objSMTPClient.Send(objMailMsg);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        txtFName.Text = "";
        txtLName.Text = "";
        txtContactEmail.Text = "";
        txtMobile.Text = "";
        txtMessage.Text = "";
    }
    protected void imgbtnMakePayment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PaymentPrepaid.aspx");
    }
}
