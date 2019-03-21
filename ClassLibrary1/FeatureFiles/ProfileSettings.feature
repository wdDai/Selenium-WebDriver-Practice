Feature: Profile settings
	In order to describe myself
	As an user
	I want to be able to update my basic settings

@profile_settings
Scenario: Profile update
	Given I have logged in
	And I am in basic setting page
	And I have entered new valid information
	When I press save button
	Then I should see the new information is saved

@profile_settings
Scenario: Profile update error massages
	Given I have logged in
	And I am in basic setting page
	And I have entered invalid information
	When I press save button
	Then I should see acording error massages
