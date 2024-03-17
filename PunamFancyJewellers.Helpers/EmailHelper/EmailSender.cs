using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using PunamFancyJewellers.Helpers.Extensions;
using PunamFancyJewellers.Helpers.Extensions.Conversion;

namespace PunamFancyJewellers.Helpers.EmailHelper
{
    public class EmailSender : IEmailSender
    {
        private readonly bool _enableSsl;
        private readonly MailAddress _fromAddress;
        private readonly string _host;
        private readonly string _password;
        private readonly int _port;
        private readonly string _userName;

        public EmailSender(IConfiguration configuration)
        {
            _enableSsl = configuration.GetConfigurationValue("emailConfigurations:resetpassword:enableSsl").ToBoolean();
            _fromAddress = new MailAddress(configuration.GetConfigurationValue("emailConfigurations:resetpassword:fromAddress"));
            _host = configuration.GetConfigurationValue("emailConfigurations:resetpassword:host");
            _password = configuration.GetConfigurationValue("emailConfigurations:resetpassword:password");
            _port = configuration.GetConfigurationValue("emailConfigurations:resetpassword:port").ToInt();
            _userName = configuration.GetConfigurationValue("emailConfigurations:resetpassword:userName");
        }

        public async Task<bool> SendEmailAsync(string email, string subject, string message, bool isHtml = false)
        {
            using (SmtpClient client = new SmtpClient(_host))
            {
                client.Port = _port;
                client.Credentials = new NetworkCredential(_userName, _password);
                client.EnableSsl = _enableSsl;
                MailMessage mailMessage = new MailMessage()
                {
                    From = _fromAddress,
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isHtml,
                };

                mailMessage.To.Add(email);

                try
                {
                    await client.SendMailAsync(mailMessage);
                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}