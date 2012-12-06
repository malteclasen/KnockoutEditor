function QuantityModel(data) {
    this.Amount = ko.observable(data.Amount);
    this.Unit = ko.observable(data.Unit);
}

function IngredientModel(data) {
	var self = this;
    this.Name = ko.observable(data.Name);
    this.Url = ko.observable(data.Url);

    this.IsEmpty = ko.computed(function () {
    	return (!self.Name()) && (!self.Url());
    }, this);
}

function RecipeIngredientModel(data) {
	var self = this;
	this.Quantity = ko.observable();
    this.Quantity(new QuantityModel(data.Quantity));
    this.Ingredient = ko.observable();
    this.Ingredient(new IngredientModel(data.Ingredient));

    this.HasQuantity = ko.computed(function () {
    	return self.Quantity().Amount() || self.Quantity().Unit();
    }, this);
    this.IsEmpty = ko.computed(function () {
    	return (!self.HasQuantity()) && (self.Ingredient().IsEmpty());
    }, this);
}

function ComponentModel(data) {
    var self = this;
    this.Title = ko.observable(data.Title);
    this.Preparation = ko.observable(data.Preparation);

    this.AddEmptyIngredient = function () {
    	var emptyIngredient = new RecipeIngredientModel({ Quantity: { Amount: null, Unit: null }, Ingredient: { Name: null, Url: null } });
    	self.Ingredients.push(emptyIngredient);
    	return emptyIngredient;
    };

    this.Ingredients = ko.observableArray();

    this.LastIngredient = ko.computed(function () {
    	if (self.Ingredients().length === 0)
    		return null;
    	return self.Ingredients()[self.Ingredients().length-1];
    }, this);

    this.LastIngredientSubscription = null;

    this.LastIngredient.subscribe(function (newValue) {
    	if (self.LastIngredientSubscription !== null) {
    		self.LastIngredientSubscription.dispose();
    	}

    	var currentLastIngredient = newValue;
    	if (currentLastIngredient === null)
    		currentLastIngredient = self.AddEmptyIngredient();
    	if (!currentLastIngredient.IsEmpty())
			currentLastIngredient = self.AddEmptyIngredient();

    	self.LastIngredientSubscription = currentLastIngredient.IsEmpty.subscribe(function (newValue) {
    		if (!newValue) {
				self.AddEmptyIngredient();
			}
		}, this);
    }, this);

    this.Ingredients($.map(data.Ingredients, function (item) { return new RecipeIngredientModel(item); }));

    this.onUpdatePreparation = function(model, event) {
        contentEditor.cleanUp(event.target);
        self.Preparation($(event.target).html());
    };

    this.onUpdateTitle = function (model, event) {
    	self.Title($(event.target).text());
    };

    this.onFormatBold = function(model, event) {
        contentEditor.formatBold();
    };

    this.onFormatItalic = function(model, event) {
        contentEditor.formatItalic();
    };
}

function CategoryModel(data) {
	var self = this;
	this.Name = ko.observable(data.Name);
	this.Url = ko.observable(data.Url);

	this.IsEmpty = ko.computed(function () {
		return (!self.Name()) && (!self.Url());
	}, this);
}

function RecipeViewModel(initialData) {
    var self = this;
    self.data = ko.observable();

    this.revert = function(onSuccess) {
        $.getJSON("/Recipe/Get", function(data) {
            self.data(ko.mapping.fromJS(data, mapping));
            if (onSuccess) {
            	onSuccess();
            }
            RefreshRecipeEditorDisplay();
        })
            .error(function(e, jqxhr, settings, exception) { console.log(exception); });
    };

    this.onRevert = function () {
    	if (confirm("Soll wirklich neu geladen werden? Alle ungespeicherten Änderungen gehen verloren.")) {
    		self.revert();
    	}
    };

    this.onSave = function () {
        $.ajax("/Recipe/Edit", {
            data: ko.mapping.toJSON(self.data),
            type: "post",
            contentType: "application/json",
            dataType: "json",
            success: function (result) { ShowLogMessage(result); }
        })
            .error(function (e, jqxhr, settings, exception) { console.log(exception); });
    };

    this.onUpdateTitle = function (model, event) {
    	self.data().Title($(event.target).text());
    };

    this.onAddComponent = function (model, event) {
    	self.data().Components.push(new ComponentModel({ Title: "neu", Preparation: "", Ingredients: [] }));
    	RefreshRecipeEditorDisplay();
    }

    this.onRemoveComponent = function (model, event) {
    	self.data().Components.remove(model);
    }

    this.AddEmptyCategory = function () {
    	var emptyCategory = new CategoryModel({ Name: null, Url: null });
    	self.data().Categories.push(emptyCategory);
    	return emptyCategory;
    };

    this.LastCategory = ko.computed(function () {
    	if (!self.data() || self.data().Categories().length === 0)
    		return null;
    	return self.data().Categories()[self.data().Categories().length - 1];
    }, this);

    this.LastCategorySubscription = null;

    this.LastCategory.subscribe(function (newValue) {
    	if (self.LastCategorySubscription !== null) {
    		self.LastCategorySubscription.dispose();
    	}

    	var currentLastCategory = newValue;
    	if (currentLastCategory === null)
    		currentLastCategory = self.AddEmptyCategory();
    	if (!currentLastCategory.IsEmpty())
    		currentLastCategory = self.AddEmptyCategory();

    	self.LastCategorySubscription = currentLastCategory.IsEmpty.subscribe(function (newValue) {
    		if (!newValue) {
    			self.AddEmptyCategory();
    		}
    	}, this);
    }, this);

     //http://knockoutjs.com/documentation/plugins-mapping.html
    var mapping = {
    	'Components': {
    		create: function (options) {
    			return new ComponentModel(options.data);
    		}
    	},
    	'Categories': {
    		create: function (options) {
    			return new CategoryModel(options.data);
    		}
    	}
    	//,
    	//key: function(data) {
    	//	return ko.utils.unwrapObservable(data.id);
    	//}
    };

    //self.revert(onLoaded);
    self.data(ko.mapping.fromJS(initialData, mapping));
	//var unmapped = ko.mapping.toJS(viewModel);

    self.json = ko.computed(function () {
        return ko.mapping.toJSON(self.data);
    }, this);
}

function ShowRecipeEditor() {    
	$("#RecipeEditor").removeClass("preview").addClass("editor");
	$(".contenteditable").attr("contenteditable", "true");
}

function RefreshRecipeEditorDisplay() {
	$(".contenteditable").attr("contenteditable", "true");
}

function HideRecipeEditor() {
	$("#RecipeEditor").removeClass("editor").addClass("preview");
	$(".contenteditable").attr("contenteditable", "false");
}

var recipeViewModel;

function InitRecipeViewModel(initialData) {
    recipeViewModel = new RecipeViewModel(initialData);
}

function InitRecipeEditor() {
    ko.applyBindings(recipeViewModel);
    $("#RecipeEditor").show();
    ShowRecipeEditor();    
    $("#Recipe").hide();
}

function ShowLogMessage(message) {
	$(".messageLog").text(message).show().delay(10000).fadeOut(2000);
}