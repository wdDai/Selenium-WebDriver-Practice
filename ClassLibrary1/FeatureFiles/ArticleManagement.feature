
Feature: Article Management
	In order manage the articles
	As an administrator
	I want to be able to operate the articles

@Article_search_filters
Scenario Outline: Doing info search on Info Management Page with multiple filter
	Given I have logged in as an administrator
	And I have navigated to article management page
	And I have set the filters as "<category>", "<keywords>", "<property>", "<status>"
	When I press search
	Then Search result should match the expected result for "<category>", "<keywords>", "<property>", "<status>"

Examples: 
| category | keywords | property | status |
| EduSoho  | MOOC     |          |        |
|          | 教育     | 推荐      | 未发布 |
| 行业资讯  |          |          |        |
|          |          | 推荐     | 已发布  |
|          |          |          | 回收站  |

@Article_editing
Scenario: Changing the status of an article
	Given I have logged in as an administrator
	And I have navigated to article management page
	When I change the status of an article
	Then The status of the article should change accordingly

@Article_editing
Scenario: Adding a category on Info Management Page
	Given I have logged in as an administrator
	And I have navigated to category management page
	And I have clicked add category button
	And I have entered the following data as title, code, parent, SEO title, SEO keywords, SEO describtion, publish
	| data           |
	| added category |
	| abcd           |
	| EduSoho        |
	| 111            |
	| 222            |
	| 333            |
	| yes            |
	When I click save button
	Then The added category should show in the category list


@Article_editing
Scenario: Adding a new Category and Edit the category, change the Category name
	Given I have logged in as an administrator
	And I have navigated to category management page
	And I have added a new category
	When I change the name of the new category
	Then I shoude see the name changed accordingly 