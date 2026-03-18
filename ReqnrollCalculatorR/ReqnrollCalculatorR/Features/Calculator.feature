Feature: Calculator

Simple calculator for adding two numbers

@calculator @addition
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

	Scenario: Subtract two numbers
	Given the first number is 200
	And the second number is 60
	When the two numbers are subtracted
	Then the result should be 140

	Scenario: Multiply two numbers
	Given the first number is 16
	And the second number is 5
	When the two numbers are multiplied
	Then the result should be 80

	Scenario: Divide two numbers
	Given the first number is 360
	And the second number is 6
	When the two numbers are divided
	Then the result should be 60
	
	Scenario: Check number is even or odd
	Given the number is 7
	When the number is checked for even or odd
	Then the result should be "odd"

	