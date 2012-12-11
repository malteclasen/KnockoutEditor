using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Tests
{
	static class UriExtension
	{
		public static Uri Append(this Uri @base, string relative)
		{
			return new Uri(@base, relative);
		}
	}
}
