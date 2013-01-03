using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Tests
{
	class FindByXPath
	{
		private static string GetHtml()
		{
			return (string)Web.ExecuteScript("return document.documentElement.outerHTML;");
		}

		private static string SolutionFolder
		{
			get { return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))); }
		}

		private static string ToXhtml(string html)
		{
			using (var tidy = new System.Diagnostics.Process())
			{
				tidy.StartInfo.FileName = SolutionFolder + "/tidy.exe";
				tidy.StartInfo.Arguments = "--doctype html5 --output-xml yes --char-encoding utf8 --newline lf --clean yes --indent auto --tidy-mark no --wrap 0";
				tidy.StartInfo.UseShellExecute = false;
				tidy.StartInfo.RedirectStandardInput = true;
				tidy.StartInfo.RedirectStandardOutput = true;

				tidy.Start();
				tidy.StandardInput.Write(html);
				tidy.StandardInput.Close();
				var xhtml = tidy.StandardOutput.ReadToEnd();

				tidy.WaitForExit();

				return xhtml;
			}
		}

		private static RemoteWebDriver Web
		{
			get { return WebUiContext.WebDriver; }
		}

		public static void ShouldBe(string xpath, string expected)
		{
			ShouldBe(by => Web.FindElement(by), xpath, expected);
		}

		public static void ShouldBe(Func<By, IWebElement> finder, string xpath, string expected)
		{
			string exceptionMessage = null;
			string found = null;
			try
			{
				found = finder(By.XPath(xpath)).Text;
			}
			catch (Exception e)
			{
				exceptionMessage = string.Format(", but threw \"{0}\" at \"{1}\"", e.Message, e.StackTrace);
			}
			finally
			{
				if (found != expected || exceptionMessage != null)
				{
					var html = GetHtml();
					var xhtml = ToXhtml(html);

					var reader = new StringReader(xhtml);
					var xdoc = new System.Xml.XPath.XPathDocument(reader);
					var nav = xdoc.CreateNavigator();
					var node = nav.SelectSingleNode(xpath);
					var value = (node != null ? node.TypedValue.ToString() : null);

					Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, value,
						string.Format("xpath expression \"{0}\" applied to\n\n{1}\n\nshould yield \"{2}\"{3}", xpath, xhtml, expected, exceptionMessage));
				}
			}
		}
	}
}
