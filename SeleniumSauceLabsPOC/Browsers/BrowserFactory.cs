using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
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
            if (!capabilities.HasCapability("platformName"))
                return new RemoteWebDriver(new Uri(settings.Server), capabilities);
            if( capabilities.GetCapability("platformName").Equals("Android"))
                return new AndroidDriver<IWebElement>(new Uri(settings.Server), capabilities,new TimeSpan(0, 2, 0));
                return new IOSDriver<IWebElement>(new Uri(settings.Server), capabilities, new TimeSpan(0, 2, 0));
        }
    }
}