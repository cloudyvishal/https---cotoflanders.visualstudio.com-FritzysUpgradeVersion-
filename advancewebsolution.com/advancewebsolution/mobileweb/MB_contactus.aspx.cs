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
using System.Drawing;
using System.Net.Mail;
using System.Text;
using advancewebtosolution.BO;

public partial class MB_contactus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ClearFileds();
            }
            catch(Exception ex) { throw ex; }
        }
    }
    public void SuccessMessage(string Message)
    {
        try
        {
            divError.Visible = true;
            divError.Attributes.Add("Class", "successTable");
            lblError.Visible = true;
            lblError.Text = Message;
            lblError.ForeColor = Color.Green;
        }
        catch(Exception ex) { throw ex; }
    }
    private void ClearFileds()
    {
        try
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtContactEmail.Text = "";
            txtMobile.Text = "";
            txtMessage.Text = "";
        }
        catch (Exception ex) { throw ex; }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            StoreFront ObjStoreFront = new StoreFront();
            //Add to Database
            ObjStoreFront.AddContactus(txtFName.Text.Trim(),
                                        txtLName.Text.Trim(),
                                        txtContactEmail.Text.Trim(),
                                        txtMobile.Text.Trim(),
                                        txtMessage.Text.Trim()
                                        );


            string Mailbody = ContentManager.GetStaticeContentEmail("ContactUs.htm").Replace("~", "#");
            Mailbody = Mailbody.Replace("<!-- FirstName -->", txtFName.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- LastName -->", txtLName.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- Email -->", txtContactEmail.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- Phone -->", txtMobile.Text.Trim());
            Mailbody = Mailbody.Replace("<!-- Suggestion -->", txtMessage.Text.Trim());

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
            ClearFileds();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}
