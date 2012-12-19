using System;
using System.IO;
using System.Web;

namespace RecipeEditor.JsTests
{
	public class ScriptHandler : IHttpHandler
	{
		#region IHttpHandler Members

		public bool IsReusable
		{
			get { return true; }
		}

		private string FindFile(HttpRequest request)
		{
			var path = request.Path;
			var local = request.MapPath(path);
			if (File.Exists(local))
				return local;

			var linked = request.MapPath("~") + "../RecipeEditor/" + path;
			if(File.Exists(linked))
				return linked;

			return null;
		}

		public void ProcessRequest(HttpContext context)
		{
			var path = FindFile(context.Request);
			if (path != null)
			{
				context.Response.WriteFile(path);
				context.Response.ContentType = "text/javascript";
			}
			else
			{
				context.Response.StatusCode = 404;
			}			
		}

		#endregion
	}
}
