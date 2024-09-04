using Microsoft.Extensions.Options;
using Store.Application.Contracts.Infrastructure;
using Store.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSetting emailSetting;

        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            this.emailSetting = emailSetting.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = emailSetting.Host,
                    Port = emailSetting.Port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailSetting.FromAddress, emailSetting.FromPassword)
                };
                using (var message = new MailMessage(emailSetting.FromAddress, email.To)
                {
                    Subject = email.Subject,
                    Body = email.Body
                })
                {
                    await smtp.SendMailAsync(message);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
