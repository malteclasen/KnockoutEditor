using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
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

		private string ProjectFolder
		{
			get
			{
				if (NCrunch.Framework.NCrunchEnvironment.NCrunchIsResident())
					return Path.GetDirectoryName(NCrunch.Framework.NCrunchEnvironment.GetOriginalProjectPath());
				return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory))) + "\\RecipeEditor.Tests";
			}
		}

		public WebDriver()
		{
#if CHROME
			_driver = new ChromeDriver(ProjectFolder);
#else
			_driver = new PhantomJSDriver(ProjectFolder);
#endif
		}

		public void CatchLog()
		{
			_driver.ExecuteScript(@"console.defaultLog=console.log; console.log=function(msg){console.defaultLog(msg); console.logFile+=msg+'\n';};");
		}

		public string Log
		{
			get { return (string)_driver.ExecuteScript(@"return console.logFile;"); }
		}

		public void ClearLog()
		{
			_driver.ExecuteScript(@"console.logFile='';");
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
