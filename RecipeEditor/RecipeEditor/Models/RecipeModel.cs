using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RecipeEditor.Models
{
	public class RecipeModel
	{
		public class AuthorModel
		{
			public string Name { get; set; }
			public Uri Url { get; set; }
		}

		public class QuantityModel
		{
			public float Amount { get; set; }
			public string Unit { get; set; }
		}

		public class IngredientModel
		{
			public string Name { get; set; }
			public Uri Url { get; set; }
		}

		public class ComponentIngredientModel
		{
			public QuantityModel Quantity { get; set; }
			public IngredientModel Ingredient { get; set; }
			public bool IsOptional { get; set; }
		}

		public class ComponentModel
		{
			public string Title { get; set; }
			public string Preparation { get; set; }
			public List<ComponentIngredientModel> Ingredients { get; set; }
		}

		public class ImageModel
		{
			public string Author { get; set; }
			public Uri Url { get; set; }
			public Uri GalleryUrl { get; set; }
		}

		public string Title { get; set; }
		public List<string> Categories { get; set; }
		public int NumViews { get; set; }
		public int AverageRating { get; set; }
		public ImageModel Image { get; set; }
		public List<ComponentModel> Components { get; set; }
		
		public string Json { get
		{
			var stream = new MemoryStream();
			var ser = new DataContractJsonSerializer(GetType());
			ser.WriteObject(stream, this);
			return Encoding.UTF8.GetString(stream.ToArray());
		}}
	}
}