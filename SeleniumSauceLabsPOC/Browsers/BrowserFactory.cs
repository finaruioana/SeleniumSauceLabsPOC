using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SeleniumSauceLabsPOC.Browsers
{
    public class BrowserFactory
    {

        //SauceLabs
        public static IWebDriver Get(string browser, string browserVersion, string platform)
        {
            const string accessKey = "<key>";
            const string username = "<username>";
            const string url = "https://ondemand.saucelabs.com:443/wd/hub";
            var capabilities = new DesiredCapabilities();

            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Platform, platform);
            capabilities.SetCapability(CapabilityType.Version, browserVersion);
            capabilities.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);

            capabilities.SetCapability("username", username);
            capabilities.SetCapability("accessKey", accessKey);

            return new RemoteWebDriver(new Uri(url), capabilities);
        }
    }
}