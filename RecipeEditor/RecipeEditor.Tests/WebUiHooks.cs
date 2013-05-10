using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace RecipeEditor.Tests
{
	[Binding]
	public class WebUiHooks
	{
#if !CHROME
		[Before("NoPhantomJs")]
		public static void SkipPhantomJs()
		{
			true.Should().BeFalse("This test is known to fail when run in PhantomJs");
		}
#endif

		[BeforeScenario]
		public void BeforeScenario()
		{
			WebUiContext.ScenarioInitialize();
		}

		[AfterScenario]
		public void AfterScenario()
		{
			WebUiContext.ScenarioCleanup();
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
			WebUiContext.FeatureCleanup();
		}
	}
}
