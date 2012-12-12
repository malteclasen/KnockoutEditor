using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;

namespace RecipeEditor.Tests
{
	[Binding]
	public class RecipeViewerSteps
	{
		private static RemoteWebDriver Web
		{
			get { return WebUiContext.WebDriver; }
		}

		[Given(@"I am on the homepage")]
		public void GivenIAmOnTheHomepage()
		{
			Web.Navigate().GoToUrl(WebUiContext.RootUrl);
		}

		[Given(@"I am on the ""(.*)"" recipe page")]
		public void GivenIAmOnTheRecipePage(string p0)
		{
			Web.Navigate().GoToUrl(WebUiContext.RootUrl.Append("/Recipe"));
		}

		[When(@"I follow the ""(.*)"" link")]
		public void WhenIFollowTheLink(string linkText)
		{
			Web.FindElementByLinkText(linkText).Click();
		}

		[Then(@"the recipe for ""(.*)"" should be visible")]
		public void ThenTheRecipeForShouldBeVisible(string title)
		{
			Web.FindElement(By.TagName("h1")).Text.Should().Be(title);
		}

		[Then(@"there should be the component ""(.*)""")]
		public void ThenThereShouldBeTheComponent(string title)
		{
			Web.FindElements(By.TagName("h3")).Should().Contain(e => e.Text == title);
		}

		[Then(@"the component ""(.*)"" should contain (.*) (.*) (.*)")]
		public void ThenTheComponentShouldContain(string component, float amount, string unit, string ingredientName)
		{
			Web.FindElements(By.XPath(
				string.Format("//h2[.='Zutaten']/following-sibling::h3[.='{0}']/following-sibling::table[1]//tr[td[1][.='{1}'] and td[2][.='{2}'] and td[3][.='{3}']]", component, amount, unit, ingredientName)
				)).Should().NotBeEmpty();
		}

		[Then(@"the component ""(.*)"" should contain an unspecified amount of (.*)")]
		public void ThenTheComponentShouldAnUnspecifiedAmountOf(string component, string ingredientName)
		{
			Web.FindElements(By.XPath(
				string.Format("//h2[.='Zutaten']/following-sibling::h3[.='{0}']/following-sibling::table[1]//tr[td[1][.=''] and td[2][.=''] and td[3][.='{1}']]", component, ingredientName)
				)).Should().NotBeEmpty();
		}

		[Then(@"the preparation of ""(.*)"" should have a strong emphasis of ""(.*)""")]
		public void ThenThePreparationOfShouldHaveAStrongEmphasisOf(string component, string phrase)
		{
			Web.FindElements(By.XPath(
				 string.Format("//h2[.='Zubereitung']/following-sibling::h3[.='{0}']/following-sibling::div[1]//strong[.='{1}']", component, phrase)
				 )).Should().NotBeEmpty();
		}
	}
}
