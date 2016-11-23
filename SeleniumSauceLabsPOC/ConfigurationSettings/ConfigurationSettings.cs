using System;
using System.Collections.Specialized;
using System.Configuration;

namespace SeleniumSauceLabsPOC.ConfigurationSettings
{
    public class ConfigurationSettings:IConfigurationSettings
    {
        public ConfigurationSettings()
        {
          Capabilities = ConfigurationManager.GetSection("capabilities") as NameValueCollection;
            Username = Environment.GetEnvironmentVariable("SAUCE_USERNAME") ??
                          ConfigurationManager.AppSettings.Get("user");
            Key = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY") ??
                           ConfigurationManager.AppSettings.Get("key");
            Server = ConfigurationManager.AppSettings.Get("server");
        }
     
        public NameValueCollection Capabilities { get; }
        public string Username { get; }
        public string Key { get; }
        public string Server { get; }
    }
}