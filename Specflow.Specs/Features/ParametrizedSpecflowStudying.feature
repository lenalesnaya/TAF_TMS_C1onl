Feature: Parametrized Specflow studying

A short summary of the feature

Scenario: Steps parameterization
	Given browser is opened
	* login page is opened
	When user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then the title is "All Projects - TestRail"
	* project Id is 123

Scenario Outline: Parameterization with table of values (outline)
	Given browser is opened
	* login page is opened
	When user "<username>" with password "<password>" logged in
	Then the title is "All Projects - TestRail"
	* project Id is <Id>

	Examples:
	| username              | password  | Id  |
	| atrostyanko@gmail.com | Qwertyu_1 | 123 |
	| atrostyanko@gmail.com | Qwertyu_1 | 456 |

#Scenario Template: Parameterization with table of values (template)
#	Given browser is opened
#	* login page is opened
#	When user "<username>" with password "<password>" logged in
#	Then the title is "All Projects - TestRail"
#	* project Id is <Id>
#
#	Examples:
#	| username              | password  | Id  |
#	| atrostyanko@gmail.com | Qwertyu_1 | 123 |
#	| atrostyanko@gmail.com | Qwertyu_1 | 456 |