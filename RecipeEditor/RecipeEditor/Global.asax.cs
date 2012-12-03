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

			RegisterBundles();
		}

		private static void RegisterBundles()
		{
			RegisterDefaultBundles();
			RegisterRecipeBundles();
			RegisterFileUploadBundles();
		}

		private static void RegisterRecipeBundles()
		{
			var scripts = new Bundle("~/Scripts/recipe", new JsMinify()).Include("~/Scripts/recipeeditor.js");
			BundleTable.Bundles.Add(scripts);

			var styles = new Bundle("~/Content/recipe").Include("~/Content/RecipeEditor.less");
			styles.Transforms.Add(new LessTransform());
			styles.Transforms.Add(new CssMinify());
			BundleTable.Bundles.Add(styles);
		}

		private static void RegisterFileUploadBundles()
		{
			var scripts = new Bundle("~/Scripts/fileuploader", new JsMinify()).Include("~/Scripts/fileuploader.js");
			BundleTable.Bundles.Add(scripts);

			var styles = new Bundle("~/Content/fileuploader", new CssMinify()).Include("~/Content/fileuploader.css");
			BundleTable.Bundles.Add(styles);
		}

		private static void RegisterDefaultBundles()
		{
			var scripts = new Bundle("~/Scripts/default", new JsMinify())
				.Include("~/Scripts/knockout-2.2.0.js")
				.Include("~/Scripts/knockout.mapping-latest.js")
				.Include("~/Scripts/jquery-1.8.3.js")
				//.Include("~/Scripts/jquery-ui-1.9.2.js")
				.Include("~/Scripts/jquery.unobtrusive-ajax.js")
				.Include("~/Scripts/jquery.validate.js")
				.Include("~/Scripts/jquery.validate.unobtrusive.js")
				.Include("~/Scripts/modernizr-2.6.2.js")
				.Include("~/Scripts/richtexteditor.js");
			BundleTable.Bundles.Add(scripts);

			var styles = new Bundle("~/Content/default", new CssMinify())
				.IncludeDirectory("~/Content/themes/base/minified", "*.css")
				.Include("~/Content/Site.css");
			BundleTable.Bundles.Add(styles);	
		}
	}
}