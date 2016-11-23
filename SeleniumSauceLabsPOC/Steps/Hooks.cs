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
            var passed = ScenarioContext.Current.TestError == null;
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)_browser).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                _browser.Quit();
                _browser.Dispose();
            }
     
        }

    }
}