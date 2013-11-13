using System.Configuration;
using System.Linq;
using Photography.Core.Contracts.Service;

namespace Photography.Service.Bolts
{
    internal class ServiceConfiguration : IConfiguration
    {
        private const string EmailDirectoryConfigKey = "emailDirectory";
        private const string DefaultEmailDirectory = "\\emails";

        private const string PasswordResetRequestTimeoutInMinutesConfigKey = "passwordResetRequestTimeoutInMinutes";
        private const int DefaultPasswordResetRequestTimeoutInMinutes = 20;

        public ServiceConfiguration()
        {
            EmailDirectory = GetStringValue(EmailDirectoryConfigKey, DefaultEmailDirectory);

            PasswordResetRequestTimeoutInMinutes = GetIntValue(PasswordResetRequestTimeoutInMinutesConfigKey, DefaultPasswordResetRequestTimeoutInMinutes);
        }

        public string EmailDirectory { get; private set; }

        public int PasswordResetRequestTimeoutInMinutes { get; private set; }

        private static string GetStringValue(string configurationKey, string defaultValue)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Any(key => key == configurationKey))
            {
                return ConfigurationManager.AppSettings[configurationKey];
            }
            
            return defaultValue;
        }

        private static int GetIntValue(string configurationKey, int defaultValue)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Any(key => key == configurationKey))
            {
                int value;
                if (int.TryParse(ConfigurationManager.AppSettings[configurationKey], out value))
                {
                    return value;
                }
            }
               
            return defaultValue;
        }
    }
}
