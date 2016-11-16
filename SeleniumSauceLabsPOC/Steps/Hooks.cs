using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumSauceLabsPOC.Steps
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _browser;

        public Hooks(IWebDriver browser)
        {
            _browser = browser;
        }

        [AfterScenario]
        public void TearDown()
        {
            _browser.Dispose();
        }

    }
}