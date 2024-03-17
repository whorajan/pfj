namespace PunamFancyJewellers.Helpers.EmailHelper
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message, bool isHtml = false);
    }
}