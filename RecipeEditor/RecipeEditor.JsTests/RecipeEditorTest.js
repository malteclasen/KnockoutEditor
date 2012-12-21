/// <reference path="../RecipeEditor/Scripts/jquery-1.8.3.js" />
/// <reference path="Scripts/jasmine-jquery-1.3.1.js" />

/// <reference path="../RecipeEditor/Scripts/knockout-2.2.0.debug.js" />
/// <reference path="../RecipeEditor/Scripts/knockout.mapping-latest.debug.js" />

/// <reference path="../RecipeEditor/Scripts/recipeeditor.js" />
/// <reference path="../RecipeEditor/Scripts/richtexteditor.js" />

describe("Recipe Editor", function () {

	describe("Ingredient Model", function () {

		it("should indicate that it is empty when neither name nor url is supplied", function () {
			var ingredient = new IngredientModel({});

			expect(ingredient.IsEmpty()).toBe(true);
		});

		it("should indicate that it is not empty when a name is supplied", function () {
			var ingredient = new IngredientModel({Name:"MyName" });

			expect(ingredient.IsEmpty()).toBe(false);
		});

	});

	it("should", function () {
		expect(true).toBe(true);
	});
});
