Feature: ProblemsSpecflowStudying

A short summary of the feature

@GUI
@POSITIVE
@SMOKE
Scenario: Using different defs classes
	Given new browser is opened
	* a login page is displayed
	* the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then settings page is opened

#
#@GUI
#@POSITIVE
#@SMOKE
#Scenario: Using different defs classes 2
#	Given new browser is opened
#	* a login page is displayed
#	* the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
#	Then settings page is opened