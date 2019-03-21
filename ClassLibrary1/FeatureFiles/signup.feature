Feature: signup
	In order to get an account
	As an user
	I want to be able to signup

@signup
Scenario: signup information validation
	Given I am in signup page
	Given I have entered the following data as my emailaddress, username, password, captha code:
	| data                           | 
	| aaa@.com                       |
	| 111111111111111111111111111111 | 
	| 1234                           |
	| 0                              |
	When I click register
	Then I should see alerts for the above entering
