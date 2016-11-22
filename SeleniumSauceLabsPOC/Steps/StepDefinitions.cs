using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumSauceLabsPOC.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private readonly IWebDriver _browser;

        public StepDefinitions(IWebDriver browser)
        {
            _browser = browser;
        }
        [Given(@"I am on the google page")]
        public void GivenIAmOnTheGooglePage()
        {
            _browser.Navigate().GoToUrl("https://www.google.com/");
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string keyword)
        {
            var q = _browser.FindElement(By.Name("q"));
            q.SendKeys(keyword);
            q.Submit();
        }

        [Then(@"I should see title ""(.*)""")]
        public void ThenIShouldSeeTitle(string title)
        {
            Thread.Sleep(5000);
            Assert.That(_browser.Title, Is.EqualTo(title));
        }
    }
}
