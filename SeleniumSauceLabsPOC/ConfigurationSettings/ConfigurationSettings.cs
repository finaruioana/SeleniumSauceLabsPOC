using System.Configuration;

namespace SeleniumSauceLabsPOC.ConfigurationSettings
{
    public class ConfigurationSettings:IConfigurationSettings
    {
        public ConfigurationSettings()
        {
            TargetBrowser = ConfigurationManager.AppSettings["TargetBrowser"];
            TargetBrowserVersion = ConfigurationManager.AppSettings["TargetBrowserVersion"];
            TargetPlatform = ConfigurationManager.AppSettings["TargetPlatform"];

        }
        public string TargetBrowser { get; }
        public string TargetBrowserVersion { get; }
        public string TargetPlatform { get; }
    }
}