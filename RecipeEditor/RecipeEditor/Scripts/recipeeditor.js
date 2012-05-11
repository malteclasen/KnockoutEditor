var serverData = {
    title: "Streuselkuchen",
    categories: ["Kuchen und Torten", "Kleingebäck"],
    author: { name: "Malte", url: "/user/malte" },
    views: 4428,
    rating: 3,
    image: { author: "Malte", src: "/Content/images/streuselkuchen.jpg", galleryUrl: "/gallery" },
    components: [
			{
			    title: "Teig",
			    preparation: "Mehl in eine Schüssel geben und eine Kuhle hineindrücken. Zucker, Hefe und lauwarmen Soja-Reis-Drink hineingeben. Mit einem Küchentuch zudecken und 15 Minuten lang gehen lassen. Margarine zerlassen und ebenfalls in die Kuhle geben. Von innenheraus mit dem restlichen Mehl verkneten. Nochmals 15 Minuten lang zugedeckt gehen lassen. Auf einem mit Backpapier ausgelegten Blech ausrollen und wieder 15 Minuten lang gehen lassen.",
			    ingredients: [
					{
					    quantity: { amount: 400, unit: "g" },
					    ingredient: { name: "Mehl", url: "/Mehl" }
					},
					{
					    quantity: { amount: 75, unit: "g" },
					    ingredient: { name: "Margarine", url: "/Margarine" }
					},
					{
					    quantity: { amount: 75, unit: "g" },
					    ingredient: { name: "Zucker", url: "/Zucker" }
					},
					{
					    quantity: { amount: 150, unit: "ml" },
					    ingredient: { name: "Soja-Reis-Drink" }
					},
					{
					    quantity: { amount: 1, unit: "Pk" },
					    ingredient: { name: "Hefe, trocken", url: "/Hefe" }
					},
					{
					    quantity: { amount: 1, unit: "Pk" },
					    ingredient: { name: "Vanillezucker" },
					    optional: true
					},
					{
					    ingredient: { name: "Salz", url: "/Salz" }
					}
				]
			},
			{
			    title: "Streusel",
			    preparation: "Mehl, Zucker und Zimt vermischen, Margarine zerlassen und alles verkneten. Streusel auf dem ausgerollten, gegangenen Teig gleichmäßig verteilen und ca. 20 Minuten bei 180°C Umluft backen.",
			    ingredients: [
					{
					    quantity: { amount: 300, unit: "g" },
					    ingredient: { name: "Mehl", url: "/Mehl" }
					},
					{
					    quantity: { amount: 175, unit: "g" },
					    ingredient: { name: "Margarine", url: "/Margarine" }
					},
					{
					    quantity: { amount: 300, unit: "g" },
					    ingredient: { name: "Zucker", url: "/Zucker" }
					},
					{
					    ingredient: { name: "Zimt", url: "/Zimt" }
					}
				]
			}
		]
};

function QuantityModel(data) {
    this.amount = ko.observable(data.amount);
    this.unit = ko.observable(data.unit);
}

function IngredientModel(data) {
    this.name = ko.observable(data.name);
    this.url = ko.observable(data.url);
}

function RecipeIngredientModel(data) {
    this.quantity = ko.observable();
    if (data.quantity)
        this.quantity(new QuantityModel(data.quantity));
    this.ingredient = ko.observable();
    this.ingredient(new IngredientModel(data.ingredient));
}

function ComponentModel(data) {
    var self = this;
    this.title = ko.observable(data.title);
    this.preparation = ko.observable(data.preparation);
    this.ingredients = ko.observableArray();
    this.ingredients($.map(data.ingredients, function (item) { return new RecipeIngredientModel(item) }));

    this.onUpdatePreparation = function (model, event) {
        console.log('update ' + $(event.target).html());
        contentEditor.cleanUp(event.target);
        self.preparation($(event.target).html());
    }

    this.onFormatBold = function (model, event) {
        contentEditor.formatBold();
    }

    this.onFormatItalic = function (model, event) {
        contentEditor.formatItalic();
    }

    this.onUndo = function (model, event) {
        contentEditor.undo();
    }

    this.onRedo = function (model, event) {
        contentEditor.redo();
    }
}

function RecipeViewModel() {
    var self = this;
    self.data = ko.observable();

    //http://knockoutjs.com/documentation/plugins-mapping.html
    var mapping = {
        'components': {
            create: function (options) {
                return new ComponentModel(options.data);
            }
            //,
            //key: function(data) {
            //	return ko.utils.unwrapObservable(data.id);
            //}
        }
    }

    self.data(ko.mapping.fromJS(serverData, mapping))
    //var unmapped = ko.mapping.toJS(viewModel);

    self.json = ko.computed(function () {
        return ko.mapping.toJSON(self.data);
    }, this);
}

var viewModel = new RecipeViewModel();
ko.applyBindings(viewModel);
