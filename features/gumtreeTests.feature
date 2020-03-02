Feature: gumtreeSearch
	check if the Gumtree homepage is loaded and count the results per page

@regression
Scenario: Count results per page
	Given I navigate to gumtree homepage
	And I search for 'toyota'
	And I count number of results match '30'
	Then I find the label that show number of results

@regression
Scenario: Count results per page
	Given I navigate to gumtree homepage
	And I search for 'toyota'
	And I count number of results match '30'
	Then I find the label that show number of results
