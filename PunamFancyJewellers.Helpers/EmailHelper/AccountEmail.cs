namespace PunamFancyJewellers.Helpers.EmailHelper
{
    public class AccountEmail : IAccountEmail
    {
        public async Task<bool> SendRegistrationEmailAsync(IEmailSender emailSender, string receipientEmail, string callbackUrl)
        {
            string _subject = "Registration";
            string _body = $"Please  <a href=\"{callbackUrl}\">click here</a> to confirm your registration";

            return await emailSender.SendEmailAsync(receipientEmail, _subject, _body, true);
        }
    }
}