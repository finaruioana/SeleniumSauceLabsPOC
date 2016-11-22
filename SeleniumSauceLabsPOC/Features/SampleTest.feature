Feature: SampleTest
	In order to avoid silly mistakes
	As a automation QA
	I want to be able to open a browser session

@mytag
Scenario: Can find search results
	Given I am on the google page
	When I search for "BrowserStack"
	Then I should see title "BrowserStack - Google Search"
