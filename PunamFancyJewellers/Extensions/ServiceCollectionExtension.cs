using PunamFancyJewellers.Helpers.EmailHelper;

namespace PunamFancyJewellers.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IAccountEmail, AccountEmail>();
        }
    }
}