namespace PunamFancyJewellers.Helpers.EmailHelper
{
    public interface IAccountEmail
    {
        public Task<bool> SendRegistrationEmailAsync(IEmailSender emailSender, string receipientEmail, string callbackUrl);
    }
}