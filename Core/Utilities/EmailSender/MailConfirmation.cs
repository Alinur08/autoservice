using Core1.Utilities.EmailSender;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace Core1.Validators
{
    public class MailConfirmation:IEmailVerification
    {
        
        public void SendCode(MailContext mailContext,string mail,string code)
        {
            using (MailMessage emailMessage = new MailMessage())
            {
                emailMessage.From = new MailAddress(mailContext.HostEmail,mailContext.DisplayName);
                emailMessage.To.Add(new MailAddress(mail));
                emailMessage.Subject = mailContext.Subject;
                emailMessage.Body =$"{mailContext.Body+code}";
                emailMessage.Priority = MailPriority.Normal;
                using (SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    MailClient.EnableSsl = true;
                    MailClient.Credentials = new System.Net.NetworkCredential(mailContext.HostEmail, mailContext.HostEmailPassword);
                    MailClient.Send(emailMessage);
                    MailClient.UseDefaultCredentials = true;
                }
            }
        }
        public bool Verify(char[] code, char[] checkCode)
        {
            for (var i=0;i<code.Length;i++)
            {
                if (code[i] != checkCode[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
