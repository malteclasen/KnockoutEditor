﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeEditor.Models;

namespace RecipeEditor.Controllers
{
    public class RecipeController : Controller
    {
        //
        // GET: /Recipe/

        public ActionResult Index()
        {
        	var model = new RecipeModel
        		{
        			Title = "Streuselkuchen",
        			AverageRating = 3,
        			Categories = new List<string> {"Kuchen und Torten", "Kleingebäck"},
        			NumViews = 4428,
					Image = new RecipeModel.ImageModel { Author = "Malte", Url = new Uri("/Content/Images/streuselkuchen.jpg", UriKind.Relative), GalleryUrl = new Uri("/gallery/streuselkuchen", UriKind.Relative) },
        			Components = new List<RecipeModel.ComponentModel>
        				{
        					new RecipeModel.ComponentModel
        						{
        							Title = "Teig",
        							Preparation = MvcHtmlString.Create("Mehl in eine Schüssel geben und eine Kuhle hineindrücken. Zucker, Hefe und <emph>lauwarmen</emph> Soja-Reis-Drink hineingeben. Mit einem Küchentuch zudecken und 15 Minuten lang gehen lassen. Margarine zerlassen und ebenfalls in die Kuhle geben. Von innenheraus mit dem restlichen Mehl verkneten. Nochmals 15 Minuten lang zugedeckt gehen lassen. Auf einem mit Backpapier ausgelegten Blech ausrollen und wieder 15 Minuten lang gehen lassen."),
        							Ingredients = new List<RecipeModel.ComponentIngredientModel>
        								{
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 400, Unit = "g"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Mehl", Url = new Uri("/Mehl", UriKind.Relative)}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 75, Unit = "g"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Margarine", Url = new Uri("/Margarine", UriKind.Relative)}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 75, Unit = "g"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Zucker", Url = new Uri("/Zucker", UriKind.Relative)}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 150, Unit = "ml"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Soja-Reis-Drink"}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 1, Unit = "Pk"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Hefe, trocken", Url = new Uri("/Hefe", UriKind.Relative)}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 1, Unit = "Pk"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Vanillezucker"},
        											IsOptional = true
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Ingredient = new RecipeModel.IngredientModel() {Name = "Salz", Url = new Uri("/Salz", UriKind.Relative)}
        										}
        								}
        						},
        					new RecipeModel.ComponentModel
        						{
        							Title = "Streusel",
        							Preparation = MvcHtmlString.Create("Mehl, Zucker und Zimt vermischen, Margarine zerlassen und alles verkneten. Streusel auf dem ausgerollten, gegangenen Teig <strong>gleichmäßig</strong> verteilen und ca. 20 Minuten bei 180°C Umluft backen."),
        							Ingredients = new List<RecipeModel.ComponentIngredientModel>
        								{
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 300, Unit = "g"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Mehl", Url = new Uri("/Mehl", UriKind.Relative)}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 175, Unit = "g"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Margarine", Url = new Uri("/Margarine", UriKind.Relative)}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Quantity = new RecipeModel.QuantityModel {Amount = 300, Unit = "g"},
        											Ingredient = new RecipeModel.IngredientModel {Name = "Zucker", Url = new Uri("/Zucker", UriKind.Relative)}
        										},
        									new RecipeModel.ComponentIngredientModel
        										{
        											Ingredient = new RecipeModel.IngredientModel {Name = "Zimt", Url = new Uri("/Zimt", UriKind.Relative)}
        										}
        								}
        						}
        				}
        		};
		    return View(model);
        }
    }
}
