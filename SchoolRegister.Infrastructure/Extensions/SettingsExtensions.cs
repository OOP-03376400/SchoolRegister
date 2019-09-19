using Microsoft.Extensions.Configuration;

namespace SchoolRegister.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T: new()
        {
            var section = typeof(T).Name.Replace("settings",string.Empty);
            var configurationValue = new T();
            configuration.GetSection(section).Bind(configurationValue);
            return configurationValue;
        }
    }
}