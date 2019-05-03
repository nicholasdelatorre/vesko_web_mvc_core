using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VeskoWeb.Domain.Models;
using VeskoWeb.Domain.Services;

namespace VeskoWeb.Services
{
    public class AuthMessageSender : IEmailSender
    {
        public AuthMessageSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message, string name)
        {
            try
            {
                Execute(email, subject, message, name).Wait();
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Execute(string email, string subject, string message, string name)
        {
            try
            {
                string toEmail = "nicholas.delatorre@gmail.com";
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.AppendLine($"<h1>{subject}</h1>");
                sbMessage.AppendLine($"<h4>Cliente: {name}</h4>");
                sbMessage.AppendLine($"<p><b>E-mail de contato: {email}</b></p>");
                sbMessage.AppendLine($"<p>{message}</p>");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Nicholas Dela Torre")
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                mail.Subject = "API_Envio_Email - " + subject;
                mail.Body = sbMessage.ToString();
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //outras opções
                //mail.Attachments.Add(new Attachment(arquivo));
                //

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
