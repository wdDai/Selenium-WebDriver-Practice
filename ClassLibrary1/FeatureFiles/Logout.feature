Feature: Logout
	In order to protect my account
	As an user
	I want to be able to logout

@Logout
Scenario: Logout
	Given I'm in homepage and logged in
	When I choose logout
	Then I should be logged out
