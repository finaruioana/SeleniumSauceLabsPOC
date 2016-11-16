using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumSauceLabsPOC.Browsers
{
    public static class CustomChromeDriver
    {
        public static DesiredCapabilities GetCaoa()
        {
            var capabilitiess = DesiredCapabilities.Chrome();
            capabilitiess.SetCapability("platform", "Windows XP");
            capabilitiess.SetCapability("version", "43.0");

          return new RemoteWebDriver(new URL(URL), caps);
        }
    }
}