Feature: Specflow studying

A short summary of the feature

#@tag1
Scenario: Simple test
	Given Browser is opened :P
	When Login page is opened ;P
	Then Username fieled is displayed

Scenario: Simple test witn And
	Given Browser is opened :P
	And Login page is opened ;P
	Then Username fieled is displayed
	* Password fieled is displayed

Scenario: Simple test with But
	Given Browser is opened :P
	* Login page is opened ;P
	Then Username fieled is displayed
	But Error isn`t displayed
