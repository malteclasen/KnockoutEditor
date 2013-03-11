using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using OpenQA.Selenium;
using FluentAssertions;

namespace RecipeEditor.Tests
{
	[TestClass]
	public class RecipeEditorTest : WebUiTestBase
	{
		[TestMethod]
		public void ShowsLinkToRecipeOnHomepage()
		{
			Web.Navigate().GoToUrl(WebUiContext.RootUrl);
			var a = Web.FindElement(By.TagName("a"));

			a.Text.Should().Be("Rezept");
		}
	}
}
