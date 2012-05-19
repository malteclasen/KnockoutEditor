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
			var scripts = new Bundle("~/Scripts/recipe", new JsMinify());
			scripts.AddFile("~/Scripts/recipeeditor.js");
			BundleTable.Bundles.Add(scripts);

			var styles = new Bundle("~/Content/recipe", new LessMinify());
			styles.AddFile("~/Content/RecipeEditor.less");
			BundleTable.Bundles.Add(styles);
		}

		private static void RegisterFileUploadBundles()
		{
			var scripts = new Bundle("~/Scripts/fileuploader", new JsMinify());
			scripts.AddFile("~/Scripts/fileuploader.js");
			BundleTable.Bundles.Add(scripts);

			var styles = new Bundle("~/Content/fileuploader", new CssMinify());
			styles.AddFile("~/Content/fileuploader.css");
			BundleTable.Bundles.Add(styles);
		}

		private static void RegisterDefaultBundles()
		{
			var scripts = new Bundle("~/Scripts/default", new JsMinify());
			scripts.AddFile("~/Scripts/knockout-2.1.0.js");
			scripts.AddFile("~/Scripts/knockout.mapping-latest.js");
			scripts.AddFile("~/Scripts/jquery-1.7.2.min.js");
			//defaultBundle.AddFile("~/Scripts/jquery-ui-1.8.19.min.js");
			scripts.AddFile("~/Scripts/jquery.unobtrusive-ajax.min.js");
			scripts.AddFile("~/Scripts/jquery.validate.min.js");
			scripts.AddFile("~/Scripts/jquery.validate.unobtrusive.min.js");
			scripts.AddFile("~/Scripts/modernizr-2.5.3.js");
			scripts.AddFile("~/Scripts/richtexteditor.js");
			BundleTable.Bundles.Add(scripts);

			var styles = new Bundle("~/Content/default", new CssMinify());
			styles.AddDirectory("~/Content/themes/base/minified", "*.css");
			styles.AddFile("~/Content/Site.css");
			BundleTable.Bundles.Add(styles);	
		}
	}
}