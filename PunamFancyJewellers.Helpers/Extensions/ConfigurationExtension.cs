using Microsoft.Extensions.Configuration;

namespace PunamFancyJewellers.Helpers.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetConfigurationValue(this IConfiguration configuration, string key, string defaultValue = "")
        {
            string? value = configuration[key];
            if (value is null)
            {
                //TODO: Write logging
                Console.WriteLine($"Configuration key : {key} is not found");
                return defaultValue;
            }
            return value;
        }
    }
}