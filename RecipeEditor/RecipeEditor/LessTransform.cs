using System;
using System.Web.Optimization;

namespace RecipeEditor
{
	public class LessTransform : IBundleTransform
	{
		public void Process(BundleContext context, BundleResponse response)
		{
			response.Content = dotless.Core.Less.Parse(response.Content);
			response.ContentType = "text/css";
		}
	}
}