using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SeleniumSauceLabsPOC.Browsers
{
    public class BrowserFactory
    {
        private const string AccessKey = "cb525b27-a0ec-47c9-b3c6";
        private const string Username = "ioanafinaru";
        private const string Url = "https://ondemand.saucelabs.com:443/wd/hub";


        public static IWebDriver Get(string browser, string browserVersion, string platform)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
           
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Platform, platform);
            capabilities.SetCapability(CapabilityType.Version, browserVersion);
            capabilities.SetCapability("username", Username);
            capabilities.SetCapability("accessKey", AccessKey);
            capabilities.SetCapability("name",ScenarioContext.Current.ScenarioInfo.Title);

            return new RemoteWebDriver(new Uri(Url), capabilities);
        }
    }
}