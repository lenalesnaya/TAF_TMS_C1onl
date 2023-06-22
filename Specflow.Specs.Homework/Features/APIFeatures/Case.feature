Feature: Case

Check CRUD case operations

@API
@Case
Scenario: Add case
	When add case
	Then case is added

@API
@Case
Scenario: Get case
	Given add case
	When get case
	Then case received

@API
@Case
Scenario: Update case
	Given add case
	When update case
	Then case updated

@API
@Case
Scenario: Delete case
	Given add case
	When delete case
	Then case deleted
