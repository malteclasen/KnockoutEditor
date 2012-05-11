using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RecipeEditor
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			var defaultBundle = new Bundle("~/Scripts/default", new JsMinify());
			defaultBundle.AddFile("~/Scripts/knockout-2.1.0.js");
			defaultBundle.AddFile("~/Scripts/knockout.mapping-latest.js");
			defaultBundle.AddFile("~/Scripts/jquery-1.7.2.min.js");
			//defaultBundle.AddFile("~/Scripts/jquery-ui-1.8.19.js");
			//defaultBundle.AddFile("~/Scripts/jquery.unobtrusive-ajax.min.js");
			//defaultBundle.AddFile("~/Scripts/jquery.validate.min.js");
			//defaultBundle.AddFile("~/Scripts/jquery.validate.unobtrusive.min.js");
			//defaultBundle.AddFile("~/Scripts/modernizr-2.5.3.js");
			defaultBundle.AddFile("~/Scripts/richtexteditor.js");			
			BundleTable.Bundles.Add(defaultBundle);

			var recipeBundle = new Bundle("~/Scripts/recipe", new JsMinify());
			recipeBundle.AddFile("~/Scripts/recipeeditor.js");
			BundleTable.Bundles.Add(recipeBundle);
			
			//BundleTable.Bundles.RegisterTemplateBundles();
		}
	}
}