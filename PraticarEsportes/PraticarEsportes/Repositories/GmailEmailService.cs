using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PraticarEsportes.Repositories
{
    
    public interface IEmailService
    {
        bool SendEmailService(EmailMessage message);
    }

    

    public class SmtpConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }

    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool isHtml { get; set; }
    }

    public class GmailEmailService : IEmailService
    {
        private readonly SmtpConfiguration _config;

        public GmailEmailService()
        {
            _config = new SmtpConfiguration();
            var gmailUserName = "praticaresportes.com@gmail.com";
            var gmailPassword = "pi4semestre";
            var gmailHost = "smtp.gmail.com";
            var gmailPort = 587;
            var gmailSsl = true;
            _config.Username = gmailUserName;
            _config.Password = gmailPassword;
            _config.Host = gmailHost;
            _config.Port = gmailPort;
            _config.Ssl = gmailSsl;
        }

        public bool SendEmailService(EmailMessage message)
        {
            var success = false;
            try
            {
                var smtp = new SmtpClient
                {
                    Host            = _config.Host,
                    Port            = _config.Port,
                    EnableSsl       = _config.Ssl,
                    DeliveryMethod  = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.Username, _config.Password)
                };
                using (var smtpMessage = new MailMessage(_config.Username, message.ToEmail))
                {
                    smtpMessage.Subject = message.Subject;
                    smtpMessage.Body = message.Body;
                    smtpMessage.IsBodyHtml = message.isHtml;
                    smtp.Send(smtpMessage);
                }
                success = true;
            }
            catch (Exception ex)
            {

            }
            return success;
        }
    }
}