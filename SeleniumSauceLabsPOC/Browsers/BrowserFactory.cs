using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumSauceLabsPOC.ConfigurationSettings;
using TechTalk.SpecFlow;

namespace SeleniumSauceLabsPOC.Browsers
{
    public class BrowserFactory
    {
        public static IWebDriver Get(IConfigurationSettings settings)
        {
           var capabilities = new DesiredCapabilities();
            if (settings.Capabilities != null)
                foreach (var key in settings.Capabilities.AllKeys)
                {
                    capabilities.SetCapability(key, settings.Capabilities[key]);
                }
            capabilities.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);
            capabilities.SetCapability("username", settings.Username);
            capabilities.SetCapability("accessKey", settings.Key);

            return new RemoteWebDriver(new Uri(settings.Server), capabilities);
        }
    }
}