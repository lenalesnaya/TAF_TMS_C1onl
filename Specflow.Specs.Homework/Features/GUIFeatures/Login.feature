Feature: Login

@GUI
Scenario: Positive login
	When general user login
	Then the dashboard page is opened

@GUI
Scenario: Negative login
	When user "atrostyanko@gmail.com" with password "Qwertyu_2" log in
	Then the login page is opened
