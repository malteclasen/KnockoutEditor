using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Collections.Generic;

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
			return FindDisplayedList(by).Single();
		}

		private IEnumerable<IWebElement> FindDisplayedList(By by)
		{
			return Web.FindElements(by).Where(e => e.Displayed);
		}

		private void EnsureIsInPreview()
		{
			var previewButton = Web.FindElement(By.XPath("//form[@id='RecipeEditor']//button[.='vorschau']"));
			if (previewButton.Displayed)
				previewButton.Click();
		}

		private void EnsureIsInEdit()
		{
			var editButton = Web.FindElement(By.XPath("//form[@id='RecipeEditor']//button[.='bearbeiten']"));
			if (editButton.Displayed)
				editButton.Click();
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

        [Then(@"the title should be ""(.*)""")]
        public void ThenTheTitleShouldBe(string text)
        {
			EnsureIsInPreview();
			FindDisplayed(By.XPath("//form[@id='RecipeEditor']//h1")).Text.Should().Be(text);
        }

		private void ThenTheTitleOfTheNthComponentShouldBe(int position, string text)
		{
			EnsureIsInPreview();
			FindDisplayed(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[{1}]", text, position+1)
				)).Text.Should().Be(text);
		}       

        [Then(@"the title of the first component should be ""(.*)""")]
        public void ThenTheTitleOfTheFirstComponentShouldBe(string text)
        {
			ThenTheTitleOfTheNthComponentShouldBe(0, text);
        }

		[Then(@"the title of the third component should be ""(.*)""")]
		public void ThenTheTitleOfTheThirdComponentShouldBe(string text)
		{
			ThenTheTitleOfTheNthComponentShouldBe(2, text);
		}

        
        [Then(@"the preparation of the first component should be ""(.*)""")]
        public void ThenThePreparationOfTheFirstComponentShouldBe(string text)
        {
			EnsureIsInPreview();
			FindDisplayed(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zubereitung']/following-sibling::h3[1]/following-sibling::div[@contenteditable][1]", text)
				)).Text.Should().Be(text);
		}

		[When(@"I click on the add component button")]
		public void WhenIClickOnTheAddComponentButton()
		{
			FindDisplayed(By.XPath(
				"//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::div/button[img[@alt='list-add']]"
				)).Click();
		}

		[Then(@"there should be (.*) components")]
		public void ThenThereShouldBeComponents(int num)
		{
			EnsureIsInPreview();
			FindDisplayedList(By.XPath("//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::h3")).Should().HaveCount(num);
		}

		[When(@"I click on the first remove component button")]
		public void WhenIClickOnTheFirstRemoveComponentButton()
		{
			FindDisplayedList(By.XPath(
				"//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::div/button[img[@alt='list-remove']]"
				)).First().Click();
		}

		[When(@"I click on the empty category field")]
		public void WhenIClickOnTheEmptyCategoryField()
		{
			CurrentElement = FindDisplayedList(By.XPath(
				"//form[@id='RecipeEditor']//h3[.='Kategorien']/following-sibling::ul/li/input"
				)).Single(e => string.IsNullOrEmpty(e.GetAttribute("value")));
			CurrentElement.Click();
		}

		[Then(@"there should be (.*) categories")]
		public void ThenThereShouldBeCategories(int num)
		{
			EnsureIsInPreview();
			FindDisplayedList(By.XPath(
				"//form[@id='RecipeEditor']//h3[.='Kategorien']/following-sibling::ul/li"
				)).Should().HaveCount(num);
		}

		[Then(@"the title of the third category should be ""(.*)""")]
		public void ThenTheTitleOfTheThirdCategoryShouldBe(string text)
		{
			EnsureIsInPreview();
			FindDisplayed(By.XPath(
				"//form[@id='RecipeEditor']//h3[.='Kategorien']/following-sibling::ul/li[3]"
				)).Text.Should().Be(text);
		}

		[When(@"I click somewhere else")]
		public void WhenIClickSomewhereElse()
		{
			Web.FindElement(By.TagName("header")).Click();
		}

		[Then(@"there should be (.*) category fields")]
		public void ThenThereShouldBeCategoryFields(int num)
		{
			EnsureIsInEdit();
			FindDisplayedList(By.XPath(
				"//form[@id='RecipeEditor']//h3[.='Kategorien']/following-sibling::ul/li/input"
				)).Should().HaveCount(num);
		}

		[Then(@"there should be an empty category field")]
		public void ThenThereShouldBeAnEmptyCategoryField()
		{
			EnsureIsInEdit();
			FindDisplayedList(By.XPath(
				"//form[@id='RecipeEditor']//h3[.='Kategorien']/following-sibling::ul/li/input"
				)).Where(e => string.IsNullOrEmpty(e.GetAttribute("value"))).Should().NotBeEmpty();
		}

		[When(@"I click on the first category field")]
		public void WhenIClickOnTheFirstCategoryField()
		{
			CurrentElement = FindDisplayedList(By.XPath(
				"//form[@id='RecipeEditor']//h3[.='Kategorien']/following-sibling::ul/li/input"
				)).First();
			CurrentElement.Click();
		}

		[Then(@"the title of the first category should be ""(.*)""")]
		public void ThenTheTitleOfTheFirstCategoryShouldBe(string text)
		{
			EnsureIsInPreview();
			FindDisplayedList(By.XPath("//form[@id='RecipeEditor']//h3[.='Kategorien']/following-sibling::ul/li")).First().Text.Should().Be(text);
		}

		[When(@"I set the empty ingredient field of the component ""(.*)"" to (.*) (.*) (.*)")]
		public void WhenISetTheEmptyIngredientFieldOfTheComponentTo(string componentName, string amount, string unit, string ingredientName)
		{
			var rows = FindDisplayedList(By.XPath(string.Format("//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::h3[.='{0}']/following-sibling::table[@class='edit']/tbody/tr", componentName)));
			foreach (var row in rows)
			{
				var amountField = row.FindElement(By.XPath("td[1]/input"));
				var unitField = row.FindElement(By.XPath("td[2]/input"));
				var ingredientField = row.FindElement(By.XPath("td[3]/input"));
				if (string.IsNullOrEmpty(amountField.GetAttribute("value")) && string.IsNullOrEmpty(unitField.GetAttribute("value")) && string.IsNullOrEmpty(ingredientField.GetAttribute("value")))
				{
					amountField.SendKeys(amount);
					unitField.SendKeys(unit);
					ingredientField.SendKeys(ingredientName);
					return;
				}
			}
		}

		[Then(@"there should be (.*) ingredient fields in the component ""(.*)""")]
		public void ThenThereShouldBeIngredientFieldsInTheComponent(int num, string componentName)
		{
			EnsureIsInEdit();
			FindDisplayedList(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::h3[.='{0}']/following-sibling::table[@class='edit']/tbody/tr", componentName)))
				.Should().HaveCount(num);
		}

		[Then(@"there should be an empty ingredient field in the component ""(.*)""")]
		public void ThenThereShouldBeAnEmptyIngredientFieldInTheComponent(string componentName)
		{
			EnsureIsInEdit();
			var rows = FindDisplayedList(By.XPath(string.Format("//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::h3[.='{0}']/following-sibling::table[@class='edit']/tbody/tr", componentName)));
			var found = false;
			foreach (var row in rows)
			{
				var amountField = row.FindElement(By.XPath(row + "/td[1]/input"));
				var unitField = row.FindElement(By.XPath(row + "/td[2]/input"));
				var ingredientField = row.FindElement(By.XPath(row + "/td[3]/input"));
				if (string.IsNullOrEmpty(amountField.GetAttribute("value")) && string.IsNullOrEmpty(unitField.GetAttribute("value")) && string.IsNullOrEmpty(ingredientField.GetAttribute("value")))
					found = true;
			}
			found.Should().BeTrue();
		}

		[When(@"I clear the second ingredient field of the component ""(.*)""")]
		public void WhenIClearTheSecondIngredientFieldOfTheComponent(string componentName)
		{
			var row = string.Format("//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::h3[.='{0}']/following-sibling::table[@class='edit']/tbody/tr[2]", componentName);
			var amountField = FindDisplayed(By.XPath(row + "/td[1]/input"));
			var unitField = FindDisplayed(By.XPath(row + "/td[2]/input"));
			var ingredientField = FindDisplayed(By.XPath(row + "/td[3]/input"));
			amountField.Clear();
			unitField.Clear();
			ingredientField.Clear();
		}

		[Then(@"the component ""(.*)"" should not contain (.*)")]
		public void ThenTheComponentShouldNotContainMargarine(string componentName, string ingredientName)
		{
			EnsureIsInPreview();
			FindDisplayedList(By.XPath(
				string.Format("//form[@id='RecipeEditor']//h2[.='Zutaten']/following-sibling::h3[.='{0}']/following-sibling::table[@class='preview']/tbody/tr/td[.='Margarine']", componentName)
				)).Should().BeEmpty();
		}

    }
}
