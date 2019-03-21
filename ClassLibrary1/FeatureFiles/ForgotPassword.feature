Feature: ForgotPassword
	In order to login
	As an user
	I want to be able to reset my password

@ForgotPassword
Scenario: email not registered
	Given I'm in reset password page
	And I have entered an unregistered email address
	When I press reset password button
	Then I should see an unregistered email address message

@ForgotPassword
Scenario: email invalid
	Given I'm in reset password page
	And I have entered an invalid email address
	When I press reset password button
	Then I should see an invalid email address message
