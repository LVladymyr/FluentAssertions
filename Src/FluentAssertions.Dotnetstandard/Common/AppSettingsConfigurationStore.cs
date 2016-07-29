using Microsoft.Extensions.Configuration;

namespace FluentAssertions.Common
{
    internal class AppSettingsConfigurationStore : IConfigurationStore
    {
        private IConfigurationRoot config;
        public AppSettingsConfigurationStore(IConfigurationRoot config)
        {
            this.config = config;
        }

        public string GetSetting(string name)
        {
            string value = this.config[name];
            return !string.IsNullOrEmpty(value) ? value : null;
        }
    }
}