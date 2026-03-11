Feature: [Selenium 4] ECommerce Playground Demo - 1

@searchItems-1
Scenario: Search for iPod Nano - 1
	Given I select the Software category
	When I search for iPod Nano
	Then I should get 4 results for iPod Nano

@searchItems-2
Scenario: Search for HTC Touch HD - 1
	Given I select the Tablets category
	When I search for HTC Touch HD
	Then I should get 8 results for HTC Touch HD