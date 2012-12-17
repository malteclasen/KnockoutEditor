Feature: RecipeEditor
	In order to edit a recipe
	As a registered user
	I want to be able to modify all properties of a recipe

Scenario: Show View
	Given I am on the "Streuselkuchen" recipe page
	Then I should be in view mode

Scenario: Show Editor
	Given I am on the "Streuselkuchen" recipe page
	When I click on the "bearbeiten" button
	Then I should be in edit mode

Scenario: Show Preview
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the "vorschau" button
	Then I should be in preview mode

Scenario: Edit Title
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the title
	And I clear the text
	And I type "Kirschstreusel"
	Then the title should be "Kirschstreusel"

Scenario: Edit Component Title
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the first preparation component title
	And I clear the text
	And I type "Kuchenteig"
	Then the title of the first component should be "Kuchenteig"

Scenario: Edit Component Preparation
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the first preparation text
	And I clear the text
	And I type "Alles verrühren"
	Then the preparation of the first component should be "Alles verrühren"

Scenario: Add Component
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the add component button
	Then there should be 3 components
	And the title of the third component should be "neu"

Scenario: Remove Component
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the first remove component button
	Then there should be 1 components
	And the title of the first component should be "Streusel"

Scenario: Add Category
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the empty category field
	And I type "Blechkuchen"
	Then there should be 3 categories
	And the title of the third category should be "Blechkuchen"

Scenario: Dynamically Add Category Fields
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the empty category field
	And I type "Blechkuchen"
	Then there should be 4 category fields 
	And there should be an empty category field

Scenario: Remove Category
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the first category field
	And I clear the text
	Then there should be 1 categories
	And the title of the first category should be "Kleingebäck"

Scenario: Add Ingredient to new Component
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I click on the add component button
	And I set the empty ingredient field of the component "neu" to 30 ml Wasser
	Then the component "neu" should contain 30 ml Wasser

Scenario: Add Ingredient to existing Component
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I set the empty ingredient field of the component "Teig" to 30 ml Wasser
	Then the component "Teig" should contain 30 ml Wasser

Scenario: Dynamically Add Ingredient Fields
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I set the empty ingredient field of the component "Teig" to 30 ml Wasser
	Then there should be 9 ingredient fields in the component "Teig"
	Then there should be an empty ingredient field in the component "Teig"

Scenario: Remove Ingredient from Component
	Given I am on the "Streuselkuchen" recipe page
	And I am in edit mode
	When I clear the second ingredient field of the component "Teig"
	Then the component "Teig" should not contain Margarine
