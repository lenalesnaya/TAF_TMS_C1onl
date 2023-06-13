Feature: BackgroundSpecflowStudying

A short summary of the feature

Background: Open login page
	Given browser is opened
	* login page is opened

Scenario: Positive test
	When user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then the title is "All Projects - TestRail"

Scenario: Negative test
	When user "atrostyanko@gmail.com" with password "Qwertyu_2" logged in
	Then the title is "Login - TestRail"