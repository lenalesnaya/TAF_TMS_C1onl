Feature: Parametrized Specflow studying

A short summary of the feature

#@tag1
Scenario: Steps parameterization
	Given browser is opened
	* login page is opened
	When user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then the title is "All Projects - TestRail"
	* project Id is 123