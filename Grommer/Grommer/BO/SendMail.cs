using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;

public class SendMail
{
    public SendMail()
    {
    }
    public void AppointmentMail(string ToMail, string subject, string MailBody)
    {
        MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ToMail);
        objMailMsg.BodyEncoding = Encoding.UTF8;
        objMailMsg.Subject = subject;
        objMailMsg.Body = MailBody;
        objMailMsg.Priority = MailPriority.High;
        objMailMsg.IsBodyHtml = true;
        SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
        objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
        objSMTPClient.EnableSsl = true;
        objSMTPClient.Send(objMailMsg);
    }
    public void PaymentMail(string p, string datenew, string Appoinment, string Appoinment_Date, string emailadd, string totalprice, string CC_Name, string mMessage, string Mailbody)
    {
        try
        {
            MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], emailadd);
            objMailMsg.BodyEncoding = Encoding.UTF8;
            objMailMsg.Subject = "Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";
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
            string error = ex.Message;
        }
    }
}
