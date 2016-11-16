using Autofac;
using OpenQA.Selenium;
using SeleniumSauceLabsPOC.Browsers;
using SeleniumSauceLabsPOC.ConfigurationSettings;

namespace SeleniumSauceLabsPOC.Support
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            IConfigurationSettings configurationSettings = new ConfigurationSettings.ConfigurationSettings();
            builder.Register(c => configurationSettings).As<IConfigurationSettings>().SingleInstance();

            var browser = BrowserFactory.Get(configurationSettings.TargetBrowser,
                configurationSettings.TargetBrowserVersion, configurationSettings.TargetPlatform);
            builder.Register(c => browser).As<IWebDriver>().SingleInstance();
        }
    }
}