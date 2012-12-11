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

		public static void ClassInitialize(IsolationMode webDriverIsolation = IsolationMode.Class, IsolationMode serverIsolation = IsolationMode.Global)
		{
			if (webDriverIsolation != IsolationMode.Global)
				StopDrivers();
			if (serverIsolation != IsolationMode.Global)
				StopIIS();
		}

		public static void TestInitialize()
		{
			if (_server == null)
				_server = new Server();
			if (_webDriver == null)
				_webDriver = new WebDriver();
		}

		public static void TestCleanup(IsolationMode webDriverIsolation = IsolationMode.Class, IsolationMode serverIsolation = IsolationMode.Global)
		{
			if (webDriverIsolation == IsolationMode.Method)
				StopDrivers();
			if (serverIsolation == IsolationMode.Method)
				StopIIS();
		}

		public static void ClassCleanup(IsolationMode webDriverIsolation = IsolationMode.Class, IsolationMode serverIsolation = IsolationMode.Global)
		{
			if (webDriverIsolation == IsolationMode.Class)
				StopDrivers();
			if (serverIsolation == IsolationMode.Class)
				StopIIS();
		}

		public static void RunCleanup()
		{
			StopDrivers();
			StopIIS();
		}

		private static void StopDrivers()
		{
			if (_webDriver != null)
			{
				_webDriver.Dispose();
				_webDriver = null;
			}
		}

		private static void StopIIS()
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
	}
}
