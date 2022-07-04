#Feature: SpecFlowFeature1
#	Simple calculator for adding two numbers
#
#@mytag
#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120


Feature: Purchase Test
	Create an automated test that purchases an item from the AutomationPractice website.

@purchase
Scenario: Purchase an item
	Given a user is signed in to the AutomationPractice website with email "jane_smith222@gmail.com" and password "averysecurepassword?123"
	And the user is on the home page