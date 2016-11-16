using System.Configuration;

namespace SeleniumSauceLabsPOC.ConfigurationSettings
{
    public class ConfigurationSettings:IConfigurationSettings
    {
        public ConfigurationSettings()
        {
            TargetBrowser = ConfigurationManager.AppSettings["TargetBrowser"];
            TargetOs = ConfigurationManager.AppSettings["TargetOS"];
            TargetDevice = ConfigurationManager.AppSettings["TargetDevice"];

        }
        public string TargetBrowser { get; }
        public string TargetOs { get; }
        public string TargetDevice { get; }
    }
}