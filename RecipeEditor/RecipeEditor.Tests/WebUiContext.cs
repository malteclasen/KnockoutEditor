using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Tests
{
	public static class WebUiContext
	{
		private static Server _server;
		private static WebDriver _webDriver;

		public static void ClassInitialize(IsolationMode webDriverIsolation = IsolationMode.Feature, IsolationMode serverIsolation = IsolationMode.Feature)
		{
			if (webDriverIsolation != IsolationMode.Global)
				StopWebDriver();
			if (serverIsolation != IsolationMode.Global)
				StopServer();
		}

		public static void ScenarioInitialize()
		{
			if (_server == null)
				_server = new Server();
			if (_webDriver == null)
				_webDriver = new WebDriver();
		}

		public static void ScenarioCleanup(IsolationMode webDriverIsolation = IsolationMode.Feature, IsolationMode serverIsolation = IsolationMode.Feature)
		{
			if (webDriverIsolation == IsolationMode.Scenario)
				StopWebDriver();
			if (serverIsolation == IsolationMode.Scenario)
				StopServer();
		}

		public static void FeatureCleanup(IsolationMode webDriverIsolation = IsolationMode.Feature, IsolationMode serverIsolation = IsolationMode.Feature)
		{
			if (webDriverIsolation == IsolationMode.Feature)
				StopWebDriver();
			if (serverIsolation == IsolationMode.Feature)
				StopServer();
		}

		public static void RunCleanup()
		{
			StopWebDriver();
			StopServer();
		}

		private static void StopWebDriver()
		{
			if (_webDriver != null)
			{
				_webDriver.Dispose();
				_webDriver = null;
			}
		}

		private static void StopServer()
		{
			if (_server != null)
			{
				_server.Dispose();
				_server = null;
			}
		}

		public static Uri RootUrl
		{
			get { return _server.Root; }
		}

		public static RemoteWebDriver WebDriver
		{
			get { return _webDriver.Driver; }
		}

		public static string Log
		{
			get { return _webDriver.Log; }
		}

		public static void CatchLog()
		{
			_webDriver.CatchLog();
		}
	}
}
