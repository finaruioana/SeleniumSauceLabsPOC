using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumSauceLabsPOC.Browsers
{
    public class BrowserFactory
    {

        private static string _accessKey = "cb525b27-a0ec-47c9-b3c6-47a4ceb37ca5";
        private static string _username = "ioanafinaru";
        private static string _url= "http://" + _username + ":" + _accessKey + "@ondemand.saucelabs.com:80/wd/hub";


        public static IWebDriver Get(string browser, string browserVersion, string platform)
        {
            DesiredCapabilities capabilities;
            switch (browser)
            {
                case "Chrome":
                    capabilities = DesiredCapabilities.Chrome();
                    break;
                case "Firefox":
                    capabilities = DesiredCapabilities.Firefox();
                    break;
                default: throw new Exception("RegisterBrowser - Browser not available");
            }
            capabilities.SetCapability("platform", platform);
            capabilities.SetCapability("version", browserVersion);

            return new RemoteWebDriver(new Uri(_url), capabilities);
        }
    }
}