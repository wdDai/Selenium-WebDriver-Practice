Feature: Order Search
	In order to manage orders
	As an administrator
	I want to be able to search for orders

@Order_search
Scenario: Default search for course orders
	Given I am logged in as administrator
	And I am in admin page
	And I have clicked orders manage then course order manage 
	When I press search button
	Then I should see some results

@Order_search
Scenario: Default search for class orders
	Given I am logged in as administrator
	And I am in admin page
	And I have clicked orders manage then class order manage 
	When I press search button
	Then I should see some results

@Order_search
Scenario Outline: multiple searches for course orders with different filters
	Given I am logged in as administrator
	And I am in admin page
	And I have clicked orders manage then course order manage 
	And I have chosen start date "<start_date>"
	And I have chosen status "<status>"
	And I have chosen payment method "<payment_method>"
	And I have chosen keyword type "<keyword_type>"
	When I press search button
	Then I should see expected result according to "<start_date>", "<status>", "<payment_method>", "<keyword_type>"

Examples: 
| start_date       | status | payment_method | keyword_type |
| 2017-12-14 22:51 |        |                |              |
|                  |已付款|                |              |
|                  |        | 支付宝          |              |
|                  |        |                | 课程名称      |

@Order_search
Scenario Outline: multiple searches for class orders with different filters
	Given I am logged in as administrator
	And I am in admin page
	And I have clicked orders manage then class order manage 
	And I have chosen start date "<start_date>"
	And I have chosen status "<status>"
	And I have chosen payment method "<payment_method>"
	And I have chosen keyword type "<keyword_type>"
	When I press search button
	Then I should see expected result according to "<start_date>", "<status>", "<payment_method>", "<keyword_type>"

Examples: 
| start_date       | status | payment_method | keyword_type |
| 2017-12-14 22:51 |        |                |              |
|                  |  已付款 |                |              |
|                  |        | 支付宝          |              |
|                  |        |                | 班级编号     |

