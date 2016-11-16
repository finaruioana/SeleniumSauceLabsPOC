using System;
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
        [Given(@"I go to ""(.*)""")]
        public void GivenIGoTo(string p0)
        {
            _browser.Navigate().GoToUrl(p0);
            IWebElement query = _browser.FindElement(By.Name("q"));
            query.SendKeys("Browserstack");
            query.Submit();
        }
        [Then(@"the page should be successfully loaded")]
        public void ThenThePageShouldBeSuccessfullyLoaded()
        {
           Assert.That(_browser.Title, Is.EqualTo("Google"));
        }

    }
}
