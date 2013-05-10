using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
 
namespace RecipeEditor.Tests {

    [TestClass]
	public abstract class WebUiTestBase
	{
		private IsolationMode _webDriverIsolation;
		private IsolationMode _serverIsolation;

		protected WebUiTestBase(IsolationMode webDriverIsolation = IsolationMode.Class, IsolationMode serverIsolation = IsolationMode.Global)
		{
			if (NCrunch.Framework.NCrunchEnvironment.NCrunchIsResident())
				throw new InvalidOperationException("ncrunch not supported, as it does not run ClassCleanup"); //todo: refactor tests to avoid clas cleanup
			_webDriverIsolation = webDriverIsolation;
			_serverIsolation = serverIsolation;
		}

		protected RemoteWebDriver Web
		{
			get { return WebUiContext.WebDriver; }
		}

		[ClassInitialize]
		public void ClassInitialize()
		{
			WebUiContext.ClassInitialize(_webDriverIsolation, _serverIsolation);
		}
 
        [TestInitialize]
        public void TestInitialize() 
		{
			WebUiContext.TestInitialize();
        }
 
        [TestCleanup]
        public void TestCleanup() 
		{
			WebUiContext.TestCleanup(_webDriverIsolation, _serverIsolation);
        }

		[ClassCleanup]
		public void ClassCleanup()
		{
			WebUiContext.ClassCleanup(_webDriverIsolation, _serverIsolation);
		} 
    }
}