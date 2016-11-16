Feature: SampleTest
	In order to avoid silly mistakes
	As a automation QA
	I want to be able to open a browser session

@mytag
Scenario: Go to Google
	Given I go to "https://google.co.uk"
	Then the page should be successfully loaded
