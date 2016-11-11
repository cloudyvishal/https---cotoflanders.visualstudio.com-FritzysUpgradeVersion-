using System;
using System.Configuration;
using advancewebtosolution.BO;
using System.Text;
using System.Net.Mail;

/*

 Suggestion control is use on Index page and on clickin will open a popup 
 will countain field for suggestion, after fill all field it will send mail and alse add entery in database 

  */
public partial class Controls_Suggestion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSuggestion.ImageUrl = Session["HomePath"] + "Images/btn_suggestion_box_bg.jpg";
    }

    /*
     OnSubmit after validation it will add data in database and also send a mail to admin  
     */
    protected void btnSumbmit_Click(object sender, EventArgs e)
    {
        Global Obj_Suggest = new Global();
        Obj_Suggest.AddSuggestion(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtComment.Text.Trim());

        string Message = ContentManager.GetStaticeContentEmail("Suggestion.htm").Replace("~", "#");
        Message = Message.Replace("<!-- Name -->", txtName.Text.Trim());
        Message = Message.Replace("<!-- Email -->", txtEmail.Text.Trim());
        Message = Message.Replace("<!-- Phone -->", txtPhone.Text.Trim());
        Message = Message.Replace("<!-- Suggestion -->", txtComment.Text.Trim());
        
        try
        {

            MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["ToEmail"]);
            objMailMsg.BodyEncoding = Encoding.UTF8;
            objMailMsg.Subject = "Suggestion from : " + txtName.Text.Trim(); ;
            objMailMsg.Body = Message;
            objMailMsg.Priority = MailPriority.High;
            objMailMsg.IsBodyHtml = true;
            SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
            objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
            objSMTPClient.EnableSsl = true;
            objSMTPClient.Send(objMailMsg);
        }
        catch
        {
        }
        txtName.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtComment.Text = "";
    }
     
}
