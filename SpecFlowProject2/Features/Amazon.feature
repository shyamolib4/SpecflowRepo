Feature: Amazon Add To Cart

Scenario: Amazon Add to Cart
	Given We are on the Amazon website
	When We search for a Television and Add to Cart
	Then We verify the added item and logout