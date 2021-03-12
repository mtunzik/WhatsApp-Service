using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ThanosApp
{
    public class Common
    {
        /// <summary>
        /// Creates mail object and sends
        /// </summary>
        /// <param name="mailTo">To address of Mail</param>
        /// <param name="mailSubject">Subject of Mail</param>
        /// <param name="mailBody">Body of Mail</param>
        /// <param name="mailFrom">From address of Mail</param>
        /// <param name="mailCC">CC address of Mail, multiple addresses are seperated by a comma</param>
        /// <param name="mailBCC">BCC address of Mail, multiple addresses are seperated by a comma</param>
        /// <returns></returns>
        public static bool SendMail(string mailTo, string mailSubject, string mailBody, string mailFrom, string mailCC, string mailBCC)
        {
            bool mailSend = true;
            string mailError = string.Empty;
            try
            {
                // mailBody = mailBody.Replace("<%LiveSiteHeader%>", ConfigurationManager.AppSettings["LiveSiteHeader"].ToString());
                MailMessage mail = new MailMessage(mailFrom, mailTo, mailSubject, mailBody);

                mail.IsBodyHtml = true;
                if (!string.IsNullOrEmpty(mailCC))
                {
                    mail.CC.Add(mailCC);
                }
                if (!string.IsNullOrEmpty(mailBCC))
                {
                    mail.Bcc.Add(mailBCC);
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Send(mail);
                return mailSend;
            }
            catch (Exception err)
            {
                mailError = "Failed : " + mailTo + " -> " + err.Message + "<br>";
                mailSend = false;
                //Log Error message

                return mailSend;
            }
        }

        public async Task SendMail(Email email)
        {
            string mailError = string.Empty;
            try
            {
                MailMessage mail = new MailMessage(email.mailFrom, email.To, email.Subject, email.Body);

                mail.IsBodyHtml = email.IsBodyHtml;
                if (!string.IsNullOrEmpty(email.CC))
                {
                    mail.CC.Add(email.CC);
                }
                if (!string.IsNullOrEmpty(email.BCC))
                {
                    mail.Bcc.Add(email.BCC);
                }
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception err)
            {
                mailError = "Failed : " + email.To + " -> " + err.Message + "<br>";
            }
        }

    }
}