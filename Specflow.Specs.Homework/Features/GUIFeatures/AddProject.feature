Feature: AddProject

Background: General user login
	Given general user login

@GUI
Scenario: Add a project
	Given open project adding page
	When add "<project name>" project
	Then the projects page is opened

Examples:
	| project name |
	| Good project |
	| Nice project |
	| Happy project |
	| Cool project |