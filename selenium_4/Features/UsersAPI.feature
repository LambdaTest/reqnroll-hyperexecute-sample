Feature: DummyJSON Users API Integration

@api
Scenario: Verify user exists by last name
	Given I request the users list from the DummyJSON API
	When I parse the API response
	Then I should verify that a user with the last name "Johnson" exists