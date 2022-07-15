Feature: PizzaPurchasing
	A simple website is for purchasing a pizza.

@PizzaPurchasing
Scenario: Select pizza and purchase it.
	Given launch joe's pizza website
	Then Click on Navbar Menu Link
	Then Menu page should be displayed 
	And select pizza
	And Click on Cart Icon
	Then Order Checkout page should be displayed 
	Then change the quantity in Checkout page
	And Click on Proceed button
	Then Payment section should be displayed
	Then fill the input fields
	And Click on Pay button
	Then Order Confirmation page should be displayed