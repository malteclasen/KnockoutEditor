using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeEditor.Tests
{
	class WebDriver : IDisposable
	{
		private static RemoteWebDriver _driver;
		public RemoteWebDriver Driver { get { return _driver; } }

		private string SolutionFolder
		{
			get { return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))); }
		}

		public WebDriver()
		{
			_driver = new ChromeDriver(SolutionFolder);
		}

		public void Dispose()
		{
			_driver.Quit();
			_driver.Dispose();
			GC.SuppressFinalize(this);
		}

		~WebDriver()
		{
			Dispose();
		}
	}


}
