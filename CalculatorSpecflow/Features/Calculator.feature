@Calculator
Feature: Validate basic operations like add and substract two numbers

Calculator: Simple Tests for Windows Calculator

Scenario Outline: Add two numbers
	Given Calculator starts
	When User selects number <number1>
	And User press operator <operator1>
	And User selects number <number2>
	And User press operator <operator2>
	Then Result should be <result>
Examples:
	| number1 | operator1 | number2 | operator2 | result |
	| 2       | +         | 2       | =         | 4      |
	| 5       | +         | 5       | =         | 10     |
    | 10      | +         | 5       | =         | 15     |
	| 11      | +         | 51      | =         | 62     |