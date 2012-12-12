using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace RecipeEditor.Tests
{
    [Binding]
    public class RecipeEditorSteps
    {
		private static RemoteWebDriver Web
		{
			get { return WebUiContext.WebDriver; }
		}

		private IWebElement FindDisplayed(By by)
		{
			return Web.FindElements(by).Where(e => e.Displayed).Single();
		}
	
		private IWebElement CurrentElement { get; set; }

        [Given(@"I am in edit mode")]
        public void GivenIAmInEditMode()
        {
			FindDisplayed(By.XPath("//div[@id='Recipe']//button[.='bearbeiten']")).Click();
        }

        [When(@"I click on the ""(.*)"" button")]
        public void WhenIClickOnTheButton(string text)
        {
			FindDisplayed(By.XPath(string.Format("//button[.='{0}']", text))).Click();
        }
        
        [When(@"I click on the title")]
        public void WhenIClickOnTheTitle()
        {
			CurrentElement = FindDisplayed(By.XPath("//form[@id='RecipeEditor']//h1"));
			CurrentElement.Click();
        }
        
        [When(@"I clear the text")]
        public void WhenIClearTheText()
        {
			CurrentElement.Clear();
        }
        
        [When(@"I type ""(.*)""")]
        public void WhenIType(string text)
        {
			CurrentElement.SendKeys(text);
        }
        
        [When(@"I click on the preparation component title ""(.*)""")]
        public void WhenIClickOnThePreparationComponentTitle(string text)
        {
			CurrentElement = FindDisplayed(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[.='{0}']", text)
				));
			CurrentElement.Click();
		}

		[When(@"I click on the first preparation component title")]
		public void WhenIClickOnTheFirstPreparationComponentTitle()
		{
			CurrentElement = FindDisplayed(By.XPath("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[1]"));
			CurrentElement.Click();
		}

		[When(@"I click on the first preparation text")]
		public void WhenIClickOnTheFirstPreparationComponentText()
		{
			CurrentElement = FindDisplayed(By.XPath("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[1]/following-sibling::div[@contenteditable='true'][1]"));
			CurrentElement.Click();
		}

        [When(@"I click on the preparation text for ""(.*)""")]
        public void WhenIClickOnThePreparationComponentTextFor(string text)
        {
			CurrentElement = FindDisplayed(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[.='{0}']/following-sibling::div[@contenteditable='true'][1]", text)
				));
			CurrentElement.Click();
		}

		[Then(@"I should be in view mode")]
		public void ThenIShouldBeInViewMode()
		{
			Web.FindElement(By.Id("Recipe")).Displayed.Should().BeTrue();
			Web.FindElement(By.Id("RecipeEditor")).Displayed.Should().BeFalse();
		}        

        [Then(@"I should be in edit mode")]
        public void ThenIShouldBeInEditMode()
        {
			Web.FindElement(By.Id("Recipe")).Displayed.Should().BeFalse();
			Web.FindElement(By.Id("RecipeEditor")).Displayed.Should().BeTrue();
			Web.FindElement(By.XPath("//form[@id='RecipeEditor']//button[.='vorschau']")).Displayed.Should().BeTrue();
        }
        
        [Then(@"I should be in preview mode")]
        public void ThenIShouldBeInPreviewMode()
        {
			Web.FindElement(By.Id("Recipe")).Displayed.Should().BeFalse();
			Web.FindElement(By.Id("RecipeEditor")).Displayed.Should().BeTrue();
			Web.FindElement(By.XPath("//form[@id='RecipeEditor']//button[.='bearbeiten']")).Displayed.Should().BeTrue();
		}

		private void EnsureIsInPreview()
		{
			var previewButton = Web.FindElement(By.XPath("//form[@id='RecipeEditor']//button[.='vorschau']"));
			if (previewButton.Displayed)
				previewButton.Click();
		}

        [Then(@"the title should be ""(.*)""")]
        public void ThenTheTitleShouldBe(string text)
        {
			EnsureIsInPreview();
			FindDisplayed(By.XPath("//form[@id='RecipeEditor']//h1")).Text.Should().Be(text);
        }
        
        [Then(@"the title of the first component should be ""(.*)""")]
        public void ThenTheTitleOfTheFirstComponentShouldBe(string text)
        {
			EnsureIsInPreview();
			FindDisplayed(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[1]", text)
				)).Text.Should().Be(text);
        }
        
        [Then(@"the preparation of the first component should be ""(.*)""")]
        public void ThenThePreparationOfTheFirstComponentShouldBe(string text)
        {
			EnsureIsInPreview();
			FindDisplayed(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[1]/following-sibling::div[@contenteditable][1]", text)
				)).Text.Should().Be(text);
		}
    }
}
