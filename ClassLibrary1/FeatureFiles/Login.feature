Feature: login
	In order to use the website
	As an user
	I want to be able to login

@login
Scenario: login with valid user name and password, rememberme is not selected
	Given I'm in the homepage
	And I can select login
	When I enter user name and password without rememberme selected
	Then I should be able to login and see avatar

@login
Scenario: login with user name and password, rememberme is selected
	Given I'm in the homepage
	And I can select login
	When I enter user name and password with rememberme selected
	Then I should be able to login and see avatar

@login
Scenario: login with invalid user name and password
	Given I'm in the homepage
	And I can select login
	When I enter invalid user name and password
	Then I should not be able to login and see avatar
