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

Scenario: Remove Component

Scenario: Add Category

Scenario: Remove Category

Scenario: Add Ingredient to new Category

Scenario: Add Ingredient to existing Category

Scenario: Remove Ingredient from Category
