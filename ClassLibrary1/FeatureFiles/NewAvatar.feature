Feature: New avatar
	In order to identify myself
	As an user
	I want to upload a customized image as my avatar

@New_avatar
Scenario: upload avatar
	Given I am logged in
	And I chosed 个人设置
	And I pressed 头像设置
	When I upload a new avatar
	Then I should be able to save my new avatar.
