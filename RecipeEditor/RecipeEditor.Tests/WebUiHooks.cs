using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RecipeEditor.Tests
{
	[Binding]
	public class WebUiHooks
	{
		[BeforeScenario]
		public void BeforeScenario()
		{
			WebUiContext.TestInitialize();
		}

		[AfterScenario]
		public void AfterScenario()
		{
			WebUiContext.TestCleanup();
		}
		
		[AfterTestRun]
		public static void AfterTestRun()
		{
			WebUiContext.RunCleanup();
		}

		[BeforeFeature]
		public static void BeforeFeature()
		{
			WebUiContext.ClassInitialize();
		}

		[AfterFeature]
		public static void AfterFeature()
		{
			WebUiContext.ClassCleanup();
		}
	}
}
