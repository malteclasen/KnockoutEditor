Feature: RecipeViewer
	In order to bake a cake
	As a layman
	I want to get to know what I need and how I do it

Scenario: Navigate to the recipe
	Given I am on the homepage
	When I follow the "Rezept" link
	Then the recipe for "Streuselkuchen" should be visible

Scenario: View the recipe
	Given I am on the "Streuselkuchen" recipe page
	Then there should be the component "Teig"
	And there should be the component "Streusel"
	And the component "Teig" should contain 400 g Mehl
	And the component "Streusel" should contain an unspecified amount of Zimt
	And the preparation of "Streusel" should have a strong emphasis of "gleichmäßig"
