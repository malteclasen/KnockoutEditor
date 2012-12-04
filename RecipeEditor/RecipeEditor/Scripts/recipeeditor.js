function QuantityModel(data) {
    this.Amount = ko.observable(data.Amount);
    this.Unit = ko.observable(data.Unit);
}

function IngredientModel(data) {
    this.Name = ko.observable(data.Name);
    this.Url = ko.observable(data.Url);
}

function RecipeIngredientModel(data) {
    this.Quantity = ko.observable();
    if (data.Quantity)
        this.Quantity(new QuantityModel(data.Quantity));
    this.Ingredient = ko.observable();
    this.Ingredient(new IngredientModel(data.Ingredient));
}

function ComponentModel(data) {
    var self = this;
    this.Title = ko.observable(data.Title);
    this.Preparation = ko.observable(data.Preparation);
    this.Ingredients = ko.observableArray();
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

    this.onUndo = function(model, event) {
        contentEditor.undo();
    };

    this.onRedo = function(model, event) {
        contentEditor.redo();
    };
}

function RecipeViewModel(initialData) {
    var self = this;
    self.data = ko.observable();

    this.revert = function(onSuccess) {
        $.getJSON("/Recipe/Get", function(data) {
            self.data(ko.mapping.fromJS(data, mapping));
            if (onSuccess) onSuccess();
        })
            .error(function(e, jqxhr, settings, exception) { console.log(exception); });
    };

    this.onRevert = function () {
        if (confirm("sicher?")) self.revert();
    };

    this.onSave = function () {
        $.ajax("/Recipe/Edit", {
            data: ko.mapping.toJSON(self.data),
            type: "post",
            contentType: "application/json",
            dataType: "json",
            success: function (result) { alert(result); }
        })
            .error(function (e, jqxhr, settings, exception) { console.log(exception); });
    };

    this.onUpdateTitle = function (model, event) {
    	self.data().Title($(event.target).text());
    };

    //http://knockoutjs.com/documentation/plugins-mapping.html
    var mapping = {
        'Components': {
            create: function(options) {
                return new ComponentModel(options.data);
            }
            //,
            //key: function(data) {
            //	return ko.utils.unwrapObservable(data.id);
            //}
        }
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
