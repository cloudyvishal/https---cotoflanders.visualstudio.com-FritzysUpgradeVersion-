using System.Configuration;
using System.Net.Mail;
using System.Text;

namespace advancewebtosolution.Admin
{
    public class SendMails
    {
        public SendMails()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public void SendEmails(string FromEmailId, string ToEmailId, string Subject, string message)
        {
            try
            {
                MailMessage objMailMsg = new MailMessage(FromEmailId, ToEmailId);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = Subject;
                objMailMsg.Body = message;
                objMailMsg.Priority = MailPriority.High;
                objMailMsg.IsBodyHtml = true;
                SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
                objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
                objSMTPClient.EnableSsl = true;
                objSMTPClient.Send(objMailMsg);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool SendEmailsWithVal(string FromEmailId, string ToEmailId, string Subject, string message)
        {
            try
            {
                MailMessage objMailMsg = new MailMessage(FromEmailId, ToEmailId);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = Subject;
                objMailMsg.Body = message;
                objMailMsg.Priority = MailPriority.High;
                objMailMsg.IsBodyHtml = true;
                SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
                objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
                objSMTPClient.EnableSsl = true;
                objSMTPClient.Send(objMailMsg);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void SendRequestEmails(string FromEmailId, string ToEmailId, string Subject, string FName, string LName, string SenderName)
        {
            string message = "<div style='font-family: Arial; font-size: 12px;'>";
            message = message + "<p>Hi&nbsp;<b>" + FName + "&nbsp;" + LName + "</b> </p>";
            message = message + "<p>" + SenderName + "&nbsp;has requested to be your friend on Hicpics. </p>";
            message = message + "<p>To accept or reject this request, please visit www.hicpics.com  <br />  <p>";
            message = message + "Thanks,&nbsp;" + SenderName + "</p>";
            message = message + "</div>";
            try
            {
                MailMessage objMailMsg = new MailMessage(FromEmailId, ToEmailId);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = Subject;
                objMailMsg.Body = message;
                objMailMsg.Priority = MailPriority.High;
                objMailMsg.IsBodyHtml = true;
                SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
                objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
                objSMTPClient.EnableSsl = true;
                objSMTPClient.Send(objMailMsg);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void SendProviderRequestEmails(string FromEmailId, string ToEmailId, string Subject, string FName, string LName, string SenderName)
        {
            string message = "<div style='font-family: Arial; font-size: 12px;'>";
            message = message + "<p>Hi&nbsp;<b>" + FName + "&nbsp;" + LName + "</b> </p>";
            message = message + "<p>" + SenderName + "&nbsp;is now added to your subscriber list. </p>";
            message = message + "<p>For more information visit www.hicpics.com  <br />  <p>";
            message = message + "Thanks,&nbsp;" + SenderName + "</p>";
            message = message + "</div>";
            try
            {
                MailMessage objMailMsg = new MailMessage(FromEmailId, ToEmailId);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = Subject;
                objMailMsg.Body = message;
                objMailMsg.Priority = MailPriority.High;
                objMailMsg.IsBodyHtml = true;
                SmtpClient objSMTPClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"].ToString(), 587);
                objSMTPClient.Host = ConfigurationManager.AppSettings["SmtpServer"];
                objSMTPClient.EnableSsl = true;
                objSMTPClient.Send(objMailMsg);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}