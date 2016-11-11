using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.UI;

namespace advancewebtosolution.BO
{
    public class SendMail
    {
        public SendMail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Appointment Mail Send

        public void AppointmentMail(string ToMail, string subject, string MailBody)
        {
            try
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
            catch { }
        }


        #endregion

        #region mobile Payment Successfull
        public void PrePaymentMail(string Mailbody)
        {
            try
            {
                MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["ToEmail"]);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = " Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";
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
        public void PrePaymentMail(string ToMember, string Mailbody)
        {
            try
            {
                MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ToMember);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = " Payment Details For Fritzys Pet Care Pros Mobile Grooming Services";
                objMailMsg.Body = Mailbody;
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
        }
        #endregion

        #region SendMailPrePaid
        public void SendMailPrePaid(string Mailbody)
        {
            try
            {
                MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["ToEmail"]);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = "Appointment Details For Fritzys Pet Care Pros Mobile Grooming Services";
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

        #endregion

        #region Payment Refund Request
        public void RefundRequest(string Mailbody, string To)
        {
            try
            {
                MailMessage objMailMsg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], To);
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = "Payment Refund Request";
                objMailMsg.Body = Mailbody;
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
        }
        #endregion
    }
}