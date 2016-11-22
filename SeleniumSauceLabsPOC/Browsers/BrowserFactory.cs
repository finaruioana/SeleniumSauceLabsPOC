using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SeleniumSauceLabsPOC.Browsers
{
    public class BrowserFactory
    {

        public static IWebDriver Get(string browser, string browserVersion, string platform)
        {
            var accessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
            var  username = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            const string url = "https://ondemand.saucelabs.com:443/wd/hub";
            var capabilities = new DesiredCapabilities();

            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Platform, platform);
            capabilities.SetCapability(CapabilityType.Version, browserVersion);

            capabilities.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);
            capabilities.SetCapability("build","1.0.0");
            
            capabilities.SetCapability("username", username);
            capabilities.SetCapability("accessKey", accessKey);

            return new RemoteWebDriver(new Uri(url), capabilities);
        }
    }
}