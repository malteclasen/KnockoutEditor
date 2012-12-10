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
        private static Server _server;
		private static WebDriver _webDriver;
		private IsolationMode _webDriverIsolation;
		private IsolationMode _serverIsolation;

		protected WebUiTestBase(IsolationMode webDriverIsolation = IsolationMode.Class, IsolationMode serverIsolation = IsolationMode.Global)
		{
			_webDriverIsolation = webDriverIsolation;
			_serverIsolation = serverIsolation;
		}

		protected RemoteWebDriver WebDriver
		{
			get { return _webDriver.Driver; }
		}

		[ClassInitialize]
		public void ClassInitialize()
		{ 
			if(_webDriverIsolation != IsolationMode.Global)
				StopDrivers();
			if (_serverIsolation != IsolationMode.Global)
				StopIIS();
		}
 
        [TestInitialize]
        public void TestInitialize() 
		{
			if (_server == null)
				_server = new Server();
			if (_webDriver == null)
				_webDriver = new WebDriver();
        }
 
        [TestCleanup]
        public void TestCleanup() 
		{
			if(_webDriverIsolation == IsolationMode.Method)
				StopDrivers();
			if (_serverIsolation == IsolationMode.Method)
				StopIIS();
        }

		[ClassCleanup]
		public void ClassCleanup()
		{
			if (_webDriverIsolation == IsolationMode.Class)
				StopDrivers();
			if (_serverIsolation == IsolationMode.Class)
				StopIIS();
		}

		private void StopDrivers()
		{
			if (_webDriver != null)
			{
				_webDriver.Dispose();
				_webDriver = null;
			}
		}

		private void StopIIS()
		{
			if (_server != null)
			{
				_server.Dispose();
				_server = null;
			}
		}

        public Uri GetAbsoluteUrl(string relativeUrl) {
            if (!relativeUrl.StartsWith("/")) {
                relativeUrl = "/" + relativeUrl;
            }
            return new Uri(_server.Root, relativeUrl);
        }		 
    }
}